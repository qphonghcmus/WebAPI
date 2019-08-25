using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class User
    {
        public virtual long Id { get; protected set; }
        public virtual string UserName { get; set; }
        public virtual string PassWord { get; set; }
        public virtual string Roles { get; set; }
    }

    public class UseMap : ClassMap<User>
    {
        public UseMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.UserName);
            Map(x => x.PassWord);
            Map(x => x.Roles);
        }
    }
}