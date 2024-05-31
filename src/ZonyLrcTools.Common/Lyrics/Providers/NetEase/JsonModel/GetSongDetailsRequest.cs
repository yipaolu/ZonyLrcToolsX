using Newtonsoft.Json;

namespace ZonyLrcTools.Common.Lyrics.Providers.NetEase.JsonModel
{
    public class GetSongDetailsRequest
    {
        public GetSongDetailsRequest(long songId)
        {
            SongId = songId;
            SongIds = $"%5B{songId}%5D";
        }

        [JsonProperty("id")] public long SongId { get; }

        [JsonProperty("ids")] public string SongIds { get; }
    }
}