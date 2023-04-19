namespace BLL.Models
{
    public class JwtModel
    {
        public int ExpirationTime { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
