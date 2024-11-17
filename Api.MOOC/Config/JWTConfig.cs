namespace Api.MOOC.Config
{
    public class JWTConfig
    {
        public string SecrectKey { get; set; }
        public string Issuer { get; set; } 
        public string Audience { get; set; }
        public int ExpireSeconds { get; set; }
    }
}
