﻿using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace kursach_diplom_api
{
    public class AuthOptions
    {
        
            public const string ISSUER = "MyAuthServer";
            public const string AUDIENCE = "MyAuthClient";
            const string KEY = "mysupersecret_secretkey!123";
            public const int LIFETIME = 60;
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
    }
}