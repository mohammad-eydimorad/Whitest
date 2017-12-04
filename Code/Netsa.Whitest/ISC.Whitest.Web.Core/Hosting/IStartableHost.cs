using System;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.Hosting
{
    public interface IStartableHost : IHost, IDisposable
    {
        Task Start();
        Task Stop();
    }
}