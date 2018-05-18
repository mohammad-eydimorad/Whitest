using ISC.Whitest.Web.Core.ValueTransformation;

namespace HomeCinema.Tests.Acceptance.Common.Models
{
    public class RegistrationModel
    {
        [TransformValue("RegisterationEmail", FieldType.Email)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
