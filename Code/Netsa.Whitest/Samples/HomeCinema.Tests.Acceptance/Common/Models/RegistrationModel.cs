using ISC.Whitest.Web.Core.ValueTransformation;

namespace HomeCinema.Tests.Acceptance.Common.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long Code { get; set; }
    }

    //Just for test
    public class RegistrationTestModel : RegistrationModel
    {
        [TransformValue(FieldType.Email)]
        public new string Email { get; set; }

        [TransformValue(FieldType.Number)]
        public new long Code { get; set; }

    }
}
