// Backend.API/Contracts/Auth/GoogleLoginRequest.cs
namespace Backend.API.Contracts.Auth
{
    public class GoogleLoginRequest
    {
        public string IdToken { get; set; } = string.Empty; // dari frontend Google
    }
}
