using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class RefreshToken
    {
        [Key]
        public virtual string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Subject { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string ClientId { get; set; }
        public virtual DateTime IssuedUtc { get; set; }
        public virtual DateTime ExpiresUtc { get; set; }
        [Required]
        public virtual string ProtectedTicket { get; set; }
    }

    public class RefreshTokenMap : ClassMap<RefreshToken>
    {
        public RefreshTokenMap()
        {
            Table("RefreshTokens");
            Id(x => x.Id);
            Map(x => x.Subject);
            Map(x => x.ClientId);
            Map(x => x.IssuedUtc);
            Map(x => x.ExpiresUtc);
            Map(x => x.ProtectedTicket);
        }
    }
}