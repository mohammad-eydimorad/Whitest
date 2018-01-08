using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.Hooks
{
    public interface IWebConfiguratonHook
    {
        void Start();
        void Stop();
    }
}
