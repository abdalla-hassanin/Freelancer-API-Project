﻿using System.Text.Json.Serialization;

namespace FreelancerApiProject.Service.DTO
{
    public class AuthModel
    {
        public int Id { get; set; }         // represent client / freelancer id based on his role
        public string Message { get; set; }

        public bool IsAuthenticated { get; set; }  // false by default

        public string Username { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresOn { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }



    }
}