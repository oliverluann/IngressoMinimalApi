using MinimalApiCatalogo.Models;

namespace MinimalApiCatalogo.Services
{
    public interface ItokenService
    {
        string GetToken(string key, string issuer, string audience, UserModel user);
    }
}
