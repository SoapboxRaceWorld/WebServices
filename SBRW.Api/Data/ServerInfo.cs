// This file is part of WebServices by heyitsleo.
// 
// Created: 11/23/2019 @ 1:18 PM.

using System;
using System.Linq;
using System.Linq.Expressions;
using SBRW.Data.Entities;

namespace SBRW.Api.Data
{
    /// <summary>
    /// Value-object that wraps properties of <see cref="Server" />
    /// </summary>
    public class ServerInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string GameEndpoint { get; set; }
        public string CountryCode { get; set; }
        public string Key { get; set; }
        public ServerStatsInfo Stats { get; set; }

        public static Expression<Func<Server, ServerInfo>> Projection
        {
            get
            {
                return x => new ServerInfo
                {
                    ID = x.ID,
                    Name = x.Name,
                    Category = x.Category,
                    CountryCode = x.CountryCode,
                    GameEndpoint = x.GameEndpoint,
                    Key = x.ServerKey,
                    Stats = x.Stats.OrderByDescending(s => s.TrackedAt)
                        .AsQueryable()
                        .Select(ServerStatsInfo.Projection)
                        .First()
                };
            }
        }
    }
}