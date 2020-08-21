﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Service
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthBookStoreApi"; // издатель токена
        public const string AUDIENCE = "AuthBookStoreClient"; // потребитель токена
        const string KEY = "b1ef8d0761fca2f7b090bf5645500b7d6e2d388f870044cf4fc63cd14020f2df";   // ключ для шифрации
        public const int LIFETIME = 60; // время жизни токена - 60 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey() 
            => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
