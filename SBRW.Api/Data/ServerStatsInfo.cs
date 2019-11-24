// This file is part of WebServices by heyitsleo.
// 
// Created: 11/23/2019 @ 2:30 PM.

using System;
using System.Linq.Expressions;
using SBRW.Data.Entities;

namespace SBRW.Api.Data
{
    public class ServerStatsInfo
    {
        public ServerStatus Status { get; set; }
        public int Online { get; set; }
        public int Registered { get; set; }

        public static Expression<Func<ServerStats, ServerStatsInfo>> Projection
        {
            get
            {
                return s => new ServerStatsInfo
                {
                    Online = s.PlayersOnline,
                    Registered = s.PlayersRegistered,
                    Status = s.Status
                };
            }
        }
    }
}