using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Settings;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}