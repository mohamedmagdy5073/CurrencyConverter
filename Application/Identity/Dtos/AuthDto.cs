namespace Application.Identity.Dtos
{
    public class AuthDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
