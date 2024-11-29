using System.IO;
using Shouldly;
using Xunit;
using ZonyLrcTools.Common;

namespace ZonyLrcTools.Tests;

public class MusicInfoTests
{
    [Fact]
    public void InvalidFilePathTest()
    {
        var tempFilePath = Path.GetTempFileName();
        var errorFilePath = $"{tempFilePath}" + "?:";
        
        var musicInfo = new MusicInfo(errorFilePath, "你好", "Zony");
        musicInfo.FilePath.ShouldBe(tempFilePath);
    }
}