using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC01.Tests.Acceptance.Models
{
    public static class RegisterErrors
    {
        public const string ShortPasswordError = @"must be at least (\d?) characters";
        public const string PasswordConfirmationDoNotMatch = @" password and confirmation password do not match";
        public const string ShouldAtLastOneDigit = @"must have at least one digit";
    }
}
