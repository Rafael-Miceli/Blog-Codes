using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebAppSpotifyConsumer.Controllers
{
    public class Playlists
    {
        [JsonProperty("items")]
        public List<Playlist> Items { get; set; }
    }

    public class Playlist
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("owner")]
        public PublicProfile Owner { get; set; }
    }

    public class PublicProfile
    {
        [JsonProperty("id")]
        public String Id { get; set; }
    }
}