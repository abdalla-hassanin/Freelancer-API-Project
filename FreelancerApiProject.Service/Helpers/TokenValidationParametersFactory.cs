using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FreelancerApiProject.Service.Helpers;

public static class TokenValidationParametersFactory
{
    public static TokenValidationParameters Create(string issuer, string audience, string secretKey)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // No clock skew
        };
    }
}