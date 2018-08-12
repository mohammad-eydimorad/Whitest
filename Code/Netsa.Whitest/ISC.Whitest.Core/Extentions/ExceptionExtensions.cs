using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.Extentions
{
    public static class ExceptionExtensions
    {
        public static string ExtractFullMessage(this Exception exception)
        {
            var messageBuilder = new StringBuilder();
            var targetException = exception;

            while (targetException != null)
            {
                messageBuilder.AppendLine(targetException.Message);
                targetException = targetException.InnerException;
            }
            return messageBuilder.ToString();
        }
    }
}
