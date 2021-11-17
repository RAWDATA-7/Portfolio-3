using DataServiceLib.Domain;

namespace DataServiceLib
{
    public interface IAuthService
    {
        string CreateToken(User user);
    }
}
