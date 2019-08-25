using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class Method
    {

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Action { get; set; }
        public virtual int Params { get; set; }
    }
    public class MethodMap : ClassMap<Method>
    {
        public MethodMap()
        {
            Table("Methods");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Action);
            Map(x => x.Params);
        }
    }
}