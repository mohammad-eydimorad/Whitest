using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.ValueTransformation;

namespace SampleMVC01.Tests.Acceptance.Models
{
    public class RegisterModel
    {
        [TransformValue("RegisterEmail",FieldType.Email)]
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
