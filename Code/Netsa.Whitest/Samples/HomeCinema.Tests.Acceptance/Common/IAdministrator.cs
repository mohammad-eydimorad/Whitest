using HomeCinema.Tests.Acceptance.Common.Models;

namespace HomeCinema.Tests.Acceptance.Common
{
    public interface IAdministrator
    {
        void Register(RegistrationModel model);
        void Login(string email, string password);
        bool IsLoggedIn();
    }
}
