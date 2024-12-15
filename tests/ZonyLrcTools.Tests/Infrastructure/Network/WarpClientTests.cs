using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shouldly;
using Xunit;
using ZonyLrcTools.Common.Configuration;
using ZonyLrcTools.Common.Infrastructure.Network;
using ZonyLrcTools.Common.Updater;

namespace ZonyLrcTools.Tests.Infrastructure.Network
{
    public class WarpClientTests : TestBase
    {
        [Fact]
        public async Task PostAsync_Test()
        {
            var client = ServiceProvider.GetRequiredService<IWarpHttpClient>();

            var response = await client.PostAsync(@"https://www.baidu.com");
            response.ShouldNotBeNull();
            response.ShouldContain("百度");
        }

        [Fact]
        public async Task GetAsync_Test()
        {
            var client = ServiceProvider.GetRequiredService<IWarpHttpClient>();

            var response = await client.GetAsync(DefaultUpdater.UpdateUrl);
            response.ShouldNotBeNull();
            response.ShouldContain("NewVersion");
        }

        [Fact]
        public async Task GetAsyncWithProxy_Test()
        {
            var option = ServiceProvider.GetRequiredService<IOptions<GlobalOptions>>();
            option.Value.NetworkOptions.Ip = "127.0.0.1";
            option.Value.NetworkOptions.Port = 4780;

            var client = ServiceProvider.GetRequiredService<IWarpHttpClient>();

            var response = await client.GetAsync(DefaultUpdater.UpdateUrl);

            response.ShouldNotBeNull();
            response.ShouldContain("NewVersion");
        }
    }
}