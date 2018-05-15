using HomeCinema.Tests.Acceptance.Common;
using HomeCinema.Tests.Acceptance.Common.Models;
using HomeCinema.Tests.Acceptance.Web.Login;
using ISC.Whitest.Web.UI.PageObjectModel;

namespace HomeCinema.Tests.Acceptance.Web
{
    public class WebAdministrator : IAdministrator
    {
        private readonly Pager _pager;
        public WebAdministrator(Pager pager)
        {
            _pager = pager;
        }
        public void Register(RegistrationModel model)
        {
            
        }

        public void Login(string email, string password)
        {
            _pager.Page<LoginPage>()
                .Open()
                .DoLogin(email, password);
        }

        public bool IsLoggedIn()
        {
            return true;
        }
    }
}
