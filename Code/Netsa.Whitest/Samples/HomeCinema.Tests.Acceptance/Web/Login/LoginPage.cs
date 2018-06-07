using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.UI.PageObjectModel;

namespace HomeCinema.Tests.Acceptance.Web.Login
{
    public class LoginPage : BasePage<LoginPage>
    {
        protected override string RelativeUrl => "#/login";
        public LoginPage(){}

        public LoginPage DoLogin(string username, string password)
        {
            return this;
        }
    }
}
