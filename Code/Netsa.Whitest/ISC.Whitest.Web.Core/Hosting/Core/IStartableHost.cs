using System;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.Hosting.Core
{
    public interface IStartableHost : IHost, IDisposable
    {
        Task Start();
        Task Stop();
    }
}