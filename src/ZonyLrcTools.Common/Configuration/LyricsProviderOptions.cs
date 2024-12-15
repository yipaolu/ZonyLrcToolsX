﻿namespace ZonyLrcTools.Common.Configuration
{
    public class LyricsProviderOptions
    {
        /// <summary>
        /// 歌词下载器的唯一标识。
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 歌词下载时的优先级，当值为 -1 时是禁用。
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 搜索深度，值越大搜索结果越多，但搜索时间越长。
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 歌词下载器的扩展属性。
        /// </summary>
        public Dictionary<string, string>? Additional { get; set; }
    }
}