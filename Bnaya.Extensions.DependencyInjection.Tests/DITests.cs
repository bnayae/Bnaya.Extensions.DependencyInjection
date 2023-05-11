using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bnaya.Extensions.DependencyInjection.Tests
{
    public class DITests
    {
        #region Keyed_Test

        [Fact]
        public void Keyed_Test()
        {
            Logic? logic = GetLogic();
            var f = logic?.GetInfo("F");
            Assert.Equal("I'm Foo", f);
            var b = logic?.GetInfo("B");
            Assert.Equal("I'm Bar", b);
        }

        #endregion // Keyed_Test

        #region TryGet_Keyed_Test

        [Fact]
        public void TryGet_Keyed_Test()
        {
            Logic? logic = GetLogic();
            var f = logic?.TryGetInfo("F");
            Assert.Equal("I'm Foo", f);
            var b = logic?.TryGetInfo("B");
            Assert.Equal("I'm Bar", b);
            var z = logic?.TryGetInfo("Z");
            Assert.Null(z);
        }

        #endregion // TryGet_Keyed_Test

        #region Keyed_Mssing_Test

        [Fact]
        public void Keyed_Mssing_Test()
        {
            Logic? logic = GetLogic();

            Assert.Throws<InvalidOperationException>(() => logic?.GetInfo("Z"));
        }

        #endregion // Keyed_Mssing_Test

        #region GetLogic

        private static Logic? GetLogic()
        {
            IHost host = Host.CreateDefaultBuilder()
                 .ConfigureServices(services =>
                 {
                     services.AddKeyedSingleton<IInfo, Foo>("F");
                     services.AddKeyedSingleton<IInfo, Bar>("B");
                     services.AddScoped<Logic>();
                 })
                 .Build();

            //await host.RunAsync();
            var logic = host.Services.GetService<Logic>();
            return logic;
        }

        #endregion // GetLogic
    }
}