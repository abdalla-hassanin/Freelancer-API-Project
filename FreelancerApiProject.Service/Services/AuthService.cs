using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.DTO;
using FreelancerApiProject.Service.Helpers;
using FreelancerApiProject.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace FreelancerApiProject.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IFreelancerService _freelancerService;
        private readonly IClientService _clientService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService
        (UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork,
            SignInManager<ApplicationUser> signInManager,
            IFreelancerService freelancerService,
            IClientService clientService,
            IEmailService emailService,
            IConfiguration configuration,
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _freelancerService = freelancerService;
            _clientService = clientService;
            _emailService = emailService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            var existingUserByEmail = await _userManager.FindByEmailAsync(model.Email);
            if (existingUserByEmail != null)
                return new AuthModel { Message = "Email is already registered!" };

            var existingUserByUsername = await _userManager.FindByNameAsync(model.Username);
            if (existingUserByUsername != null)
                return new AuthModel { Message = "Username is already registered!" };

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            try
            {
                // Associate user with either Freelancer or Client role
                if (model.Role == (int)UserRole.Freelancer)
                {
                    var freelancer = new Freelancer { Name = model.Username };
                    await _freelancerService.CreateAsync(freelancer);
                    user.FreelancerId = freelancer.Id;
                }
                else if (model.Role == (int)UserRole.Client)
                {
                    var client = new Client { Name = model.Username };
                    await _clientService.CreateAsync(client);
                    user.ClientId = client.Id;
                }


                // Create User with roles
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return new AuthModel { Message = string.Join(", ", result.Errors.Select(e => e.Description)) };

                var role = model.Role == (int)UserRole.Freelancer ? "Freelancer" : "Client";
                await _userManager.AddToRoleAsync(user, role);

                // Generate email confirmation token
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = GenerateEmailConfirmationLink(user.Id, token);


                // Send email confirmation
                await _emailService.SendAsync(new EmailModel
                {
                    To = user.Email,
                    Subject = "Email Confirmation",
                    Body = $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>."
                });

                // Generate JWT token and refresh token
                var jwtToken = GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken(jwtToken);

                // Save refresh token
                user.RefreshTokens = new List<RefreshToken> { refreshToken };
                await _userManager.UpdateAsync(user);

                // Prepare AuthModel response
                var roles = await _userManager.GetRolesAsync(user);


                return new AuthModel
                {
                    Id = user.FreelancerId ?? user.ClientId ?? 0,
                    Email = user.Email,
                    IsAuthenticated = true,
                    Username = user.UserName,
                    Roles = roles.ToList(),
                    Token = jwtToken,
                    ExpiresOn = DateTime.UtcNow.AddMinutes(60), // Token expiration time
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.ExpiresOn,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering a new user.");
                return new AuthModel { Message = "An error occurred during registration. Please try again later." };
            }
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.UserName!),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName!),
                user.FreelancerId != null
                    ? new Claim(ClaimTypes.Role, "Freelancer")
                    : new Claim(ClaimTypes.Role, "Client")
            };


            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Token validity period
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string jwtToken)
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                JwtToken = jwtToken, // Store the generated JWT token
                ExpiresOn = DateTime.UtcNow.AddDays(7), // Refresh token validity period
                CreatedOn = DateTime.UtcNow
            };
        }

        private string GenerateEmailConfirmationLink(string userId, string token)
        {
            var baseUrl = _configuration["AppUrl"];
            var encodedToken = Uri.EscapeDataString(token); // Encode the token
            return $"{baseUrl}/api/auth/confirm-email?userId={userId}&token={encodedToken}";
        }

        public async Task<AuthModel> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new AuthModel { Message = "Invalid user ID." };

            var decodedToken = Uri.UnescapeDataString(token); // Properly decode the token
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (!result.Succeeded)
                return new AuthModel { Message = "Email confirmation failed." };

            return new AuthModel { IsAuthenticated = true, Message = "Email confirmed successfully." };
        }

        public async Task<AuthModel> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return new AuthModel { Message = "Invalid username or password." };

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            var isSignedInSuccess = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!isPasswordValid && !isSignedInSuccess.Succeeded)
                return new AuthModel { Message = "Invalid username or password." };

            if (!await _userManager.IsEmailConfirmedAsync(user))
                return new AuthModel { Message = "Email not confirmed." };

            // // Check if the user is already logged in
            var activeRefreshToken = user.RefreshTokens?.FirstOrDefault(rt => rt.ExpiresOn > DateTime.UtcNow);
            if (activeRefreshToken != null)
            {
                return new AuthModel { Message = "User is already logged in.", Token = activeRefreshToken.JwtToken };
            }

            // Generate JWT token and refresh token
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(jwtToken);

            // Save refresh token
            user.RefreshTokens!.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            // Get user roles
            var roles = await _userManager.GetRolesAsync(user);

            return new AuthModel
            {
                Id = user.FreelancerId ?? user.ClientId ?? 0,
                Email = user.Email!,
                IsAuthenticated = true,
                Username = user.UserName!,
                Roles = roles.ToList(),
                Token = jwtToken,
                ExpiresOn = DateTime.UtcNow.AddMinutes(60), // Token expiration time
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn,
            };
        }

        public async Task<AuthModel> LogoutAsync()
        {
            var usernameClaim = _signInManager.Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
            {
                _logger.LogWarning("Logout attempt failed: No user to log out.");
                return new AuthModel { Message = "No user is currently logged in." };
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return new AuthModel { Message = "User not found." };

            // Invalidate the user's refresh tokens
            if (!user.RefreshTokens!.Any())
            {
                return new AuthModel { Message = "User is not logged in." };
            }

            user.RefreshTokens!.Clear();
            await _userManager.UpdateAsync(user);

            // Sign out the user
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User {Username} logged out successfully.", username);
            return new AuthModel { Message = "Logout successful." };
        }
        public async Task<AuthModel> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("Forgot Password: User with email {Email} not found.", email);
                return new AuthModel { Message = "Email not registered." };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = GeneratePasswordResetLink(user.Id, token);

            await _emailService.SendAsync(new EmailModel
            {
                To = user.Email!,
                Subject = "Password Reset",
                Body = $"Please reset your password by clicking <a href='{resetLink}'>here</a>."
            });

            _logger.LogInformation("Password reset link sent to {Email}.", email);
            return new AuthModel { Message = "Password reset link has been sent to your email." };
        }

        public async Task<AuthModel> ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                _logger.LogWarning("Reset Password: User with ID {UserId} not found.", model.UserId);
                return new AuthModel { Message = "Invalid user ID." };
            }

            var decodedToken = Uri.UnescapeDataString(model.Token);
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Password reset failed for user ID {UserId}: {Errors}", model.UserId,
                    string.Join(", ", result.Errors.Select(e => e.Description)));
                return new AuthModel { Message = "Password reset failed." };
            }

            _logger.LogInformation("Password reset successfully for user ID {UserId}.", model.UserId);
            return new AuthModel { Message = "Password has been reset successfully." };
        }

        public async Task<AuthModel> ChangePasswordAsync(ChangePasswordModel model)
        {
            // Get the current user from the authentication context
            var userId = _userManager.GetUserId(_signInManager.Context.User);

            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("Change Password: No user is currently authenticated.");
                return new AuthModel { Message = "No user is currently authenticated." };
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Change Password: User with ID {UserId} not found.", userId);
                return new AuthModel { Message = "Invalid user ID." };
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Password change failed for user ID {UserId}: {Errors}", userId,
                    string.Join(", ", result.Errors.Select(e => e.Description)));
                return new AuthModel { Message = "Password change failed." };
            }

            _logger.LogInformation("Password changed successfully for user ID {UserId}.", userId);
            return new AuthModel { Message = "Password has been changed successfully." };
        }

        private string GeneratePasswordResetLink(string userId, string token)
        {
            var baseUrl = _configuration["AppUrl"];
            var encodedToken = Uri.EscapeDataString(token);
            return $"{baseUrl}/api/auth/reset-password?userId={userId}&token={encodedToken}";
        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            // Find the user that has the specific refresh token
            var user = await _userManager.Users
                .Include(u => u.RefreshTokens) // Include the RefreshTokens collection
                .SingleOrDefaultAsync(u => u.RefreshTokens!.Any(rt => rt.Token == token));

            if (user == null)
                return new AuthModel { Message = "Invalid token." };

            // Find the specific refresh token
            var refreshToken = user.RefreshTokens!.SingleOrDefault(rt => rt.Token == token);

            // Check if the token is valid and active
            if (refreshToken == null || !refreshToken.IsActive)
                return new AuthModel { Message = "Invalid or expired refresh token." };

            // Generate a new JWT token
            var jwtToken = GenerateJwtToken(user);

            // Update the refresh token with a new JWT token and expiration date
            refreshToken.JwtToken = jwtToken;
            refreshToken.ExpiresOn = DateTime.UtcNow.AddDays(7); // Extend expiration

            await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            return new AuthModel
            {
                Id = user.FreelancerId ?? user.ClientId ?? 0,
                Email = user.Email!,
                IsAuthenticated = true,
                Username = user.UserName!,
                Roles = roles.ToList(),
                Token = jwtToken,
                ExpiresOn = DateTime.UtcNow.AddMinutes(60), // Token expiration time
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn,
            };
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            // Find the user that has the specific refresh token
            var user = await _userManager.Users
                .Include(u => u.RefreshTokens)
                .SingleOrDefaultAsync(u => u.RefreshTokens!.Any(rt => rt.Token == token));

            if (user == null) return false;

            // Find the specific refresh token
            var refreshToken = user.RefreshTokens!.SingleOrDefault(rt => rt.Token == token);

            if (refreshToken == null || !refreshToken.IsActive) return false;

            // Revoke the token
            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        public async Task<AuthModel> ResendEmailConfirmationAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user ==null || user.EmailConfirmed)
                return new AuthModel { Message = "Invalid email or email already confirmed." };

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = GenerateEmailConfirmationLink(user.Id, token);

            await _emailService.SendAsync(new EmailModel
            {
                To = user.Email!,
                Subject = "Email Confirmation",
                Body = $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>."
            });

            return new AuthModel { Message = "Email confirmation link has been resent." };
        }
        
        public async Task<bool> CheckTokenValidityAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token cannot be null or empty.", nameof(token));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = TokenValidationParametersFactory.Create(
                _configuration["Jwt:Issuer"]!,
                _configuration["Jwt:Audience"]!,
                _configuration["Jwt:Key"]!
            );

            try
            {
                // Validate the token
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return validatedToken != null;
            }
            catch (SecurityTokenException)
            {
                // Token is invalid
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                throw new InvalidOperationException("An error occurred while validating the token.", ex);
            }
        }
    }
}