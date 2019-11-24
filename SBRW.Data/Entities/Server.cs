// This file is part of SBRW.Data by heyitsleo.
// 
// Created: 11/23/2019 @ 10:07 AM.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBRW.Data.Entities
{
    [Table("servers")]
    public class Server
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(32)]
        public string ServerKey { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(8)]
        public string CountryCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        [Url]
        public string GameEndpoint { get; set; }

        public ICollection<ServerStats> Stats { get; set; }
    }
}