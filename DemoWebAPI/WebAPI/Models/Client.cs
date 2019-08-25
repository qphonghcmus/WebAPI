using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Enum = WebAPI.Helper.Enum;

namespace WebAPI.Models
{
    public class Client
    {
        [Key]
        public virtual string Id { get; set; }
        [Required]
        public virtual string Secret { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string Name { get; set; }
        public virtual Enum.ApplicationTypes ApplicationType { get; set; }
        public virtual bool Active { get; set; }
        public virtual int RefreshTokenLifeTime { get; set; }
        [MaxLength(100)]
        public virtual string AllowedOrigin { get; set; }
    }

    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Table("Clients");
            Id(x => x.Id);
            Map(x => x.Secret);
            Map(x => x.Name);
            Map(x => x.ApplicationType).CustomType<Enum.ApplicationTypes>();
            Map(x => x.Active);
            Map(x => x.RefreshTokenLifeTime);
            Map(x => x.AllowedOrigin);
        }
    }
}