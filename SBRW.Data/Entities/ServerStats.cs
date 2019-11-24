// This file is part of SBRW.Data by heyitsleo.
// 
// Created: 11/23/2019 @ 1:05 PM.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBRW.Data.Entities
{
    [Table("server_stats")]
    public class ServerStats
    {
        [Key]
        public int ID { get; set; }

        public Server Server { get; set; }
        public ServerStatus Status { get; set; }
        public DateTime TrackedAt { get; set; }
        public int PlayersOnline { get; set; }
        public int PlayersRegistered { get; set; }
    }
}