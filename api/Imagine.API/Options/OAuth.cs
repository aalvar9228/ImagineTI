namespace Imagine.API.Options
{
    public class OAuth
    {
        public const string Section = nameof(OAuth);

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
