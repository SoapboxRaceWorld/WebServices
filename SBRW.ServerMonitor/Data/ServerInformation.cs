// This file is part of SBRW.Api.ServerMonitor by heyitsleo.
// 
// Created: 11/23/2019 @ 5:04 PM.

using Newtonsoft.Json;

namespace SBRW.ServerMonitor.Data
{
    [JsonObject]
    public class ServerInformation
    {
        [JsonProperty("onlineNumber")]
        public int NumOnline { get; set; }

        [JsonProperty("numberOfRegistered")]
        public int NumRegistered { get; set; }
    }
}