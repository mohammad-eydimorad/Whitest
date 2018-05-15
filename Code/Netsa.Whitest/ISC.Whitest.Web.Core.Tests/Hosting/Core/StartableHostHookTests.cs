using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Hosting.Core;
using NSubstitute;
using Xunit;

namespace ISC.Whitest.Web.Core.Tests.Hosting.Core
{
    public class StartableHostHookTests
    {
        [Fact]
        public void Start_should_call_Start_on_host()
        {
            //Arrange
            var host = Substitute.For<IStartableHost>();
            var sut = new StartableHostHook(host);

            //Act
            sut.Start();

            //Assert
            host.Received(1).Start();
        }


        [Fact]
        public void Stop_should_call_Stop_on_host()
        {
            //Arrange
            var host = Substitute.For<IStartableHost>();
            var sut = new StartableHostHook(host);

            //Act
            sut.Stop();

            //Assert
            host.Received(1).Stop();
        }

    }
}
