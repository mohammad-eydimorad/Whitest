using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeCinema.Tests.Common;
using HomeCinema.Tests.Common.Models;

namespace HomeCinema.Tests.Api
{
    public class ApiUser : IAdministrator
    {
        public void Register(RegistrationModel model)
        {
            
        }

        public void Login(string modelEmail, string modelPassword)
        {
            
        }

        public bool IsLoggedIn()
        {
            return false;
        }
    }
}
