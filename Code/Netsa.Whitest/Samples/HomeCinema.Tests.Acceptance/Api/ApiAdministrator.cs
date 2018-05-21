using System;
using HomeCinema.Tests.Acceptance.Common;
using HomeCinema.Tests.Acceptance.Common.Models;
using HomeCinema.Tests.Acceptance.Web.Login;
using ISC.Whitest.Web.UI.PageObjectModel;

namespace HomeCinema.Tests.Acceptance.Api
{
    public class ApiAdministrator : IAdministrator
    {
        public void Register(RegistrationModel model)
        {
            //Send HTTP POST to register
        }
        public void Login(string email, string password)
        {
        }
        public bool IsLoggedIn()
        {
            return true;
        }
    }
}