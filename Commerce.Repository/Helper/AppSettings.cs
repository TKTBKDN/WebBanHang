namespace Commerce.Repository.Helper
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string RefreshSecret { get; set; }
        public string HashTextKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
