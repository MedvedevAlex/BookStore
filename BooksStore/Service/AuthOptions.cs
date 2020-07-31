using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Serivce
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthBookStoreApi"; // издатель токена
        public const string AUDIENCE = "AuthBookStoreClient"; // потребитель токена
        const string KEY = "b1ef8d0761fca2f7b090bf5645500b7d6e2d388f870044cf4fc63cd14020f2df";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey() 
            => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
