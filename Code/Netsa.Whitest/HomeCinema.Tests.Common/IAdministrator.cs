using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeCinema.Tests.Common.Models;

namespace HomeCinema.Tests.Common
{
    public interface IAdministrator
    {
        void Register(RegistrationModel model);
        void Login(string modelEmail, string modelPassword);
        bool IsLoggedIn();
    }
}
