namespace AsadaLisboaBackend.Utils.OptionsPattern
{
    public class JwtOptions
    {
        public string KEY { get; set; } = string.Empty;
        public string ISSUER { get; set; } = string.Empty;
        public string AUDIENCE { get; set; } = string.Empty;
        public int EXPIRATION_MINUTES { get; set; } = 0;
    }
}
