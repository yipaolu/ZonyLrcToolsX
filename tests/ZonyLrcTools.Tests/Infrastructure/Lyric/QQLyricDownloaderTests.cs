using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;
using ZonyLrcTools.Cli.Infrastructure.Lyric;

namespace ZonyLrcTools.Tests.Infrastructure.Lyric
{
    public class QQLyricDownloaderTests : TestBase
    {
        private readonly ILyricDownloader _lyricDownloader;

        public QQLyricDownloaderTests()
        {
            _lyricDownloader = GetService<IEnumerable<ILyricDownloader>>()
                .FirstOrDefault(t => t.DownloaderName == InternalLyricDownloaderNames.QQ);
        }

        [Fact]
        public async Task DownloadAsync_Test()
        {
            var lyric = await _lyricDownloader.DownloadAsync("东风破", "周杰伦");
            lyric.ShouldNotBeNull();
            lyric.IsPruneMusic.ShouldBe(false);
        }
        
        // About the new feature mentioned in issue #87.
        // Github Issue: https://github.com/real-zony/ZonyLrcToolsX/issues/87
        [Fact]
        public async Task DownloadAsync_Issue85_Test()
        {
            var lyric = await _lyricDownloader.DownloadAsync("Looking at Me", "Sabrina Carpenter");

            lyric.ShouldNotBeNull();
            lyric.IsPruneMusic.ShouldBeFalse();
            lyric.ToString().ShouldContain("你好像快要不能呼吸");
        }
    }
}