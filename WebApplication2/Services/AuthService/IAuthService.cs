﻿using WebApplication2.Models;

namespace WebApplication2.Services.AuthService
{
    public interface IAuthService
    {
        public string HashPassword(string password);
        public void SetUserPasswordHash(UserModel user, string password);
        public Task<UserModel> RegisterUser(UserModel newUser);
        public TokenModel GenerateJwtToken(string username);
        public bool VerifyPassword(UserModel user, string password);
    }
}
