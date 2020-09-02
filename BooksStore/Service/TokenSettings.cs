namespace ViewModel.Models
{
    public class TokenSettings
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Получать токена
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Ключ шифрования токена
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Время жизни токена
        /// </summary>
        public int LifeTime { get; set; }
    }
}
