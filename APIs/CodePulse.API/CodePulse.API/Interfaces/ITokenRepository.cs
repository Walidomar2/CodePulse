using Microsoft.AspNetCore.Identity;

namespace CodePulse.API.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
