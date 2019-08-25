using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class Blog
    {
        public virtual long Id { get; protected set; }
        public virtual string Category { get; set; }
        public virtual string Image { get; set; }
        public virtual long Views { get; set; }
        public virtual DateTime Date_Publish { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Content { get; set; }
        public virtual long Author { get; set; }
        public virtual string Title { get; set; }
        public virtual bool IsActive { get; set; }
    }

    public class BlogMap : ClassMap<Blog>
    {
        public BlogMap()
        {
            Table("Blogs");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Category);
            Map(x => x.Image);
            Map(x => x.Views);
            Map(x => x.Date_Publish);
            Map(x => x.Summary);
            Map(x => x.Content);
            Map(x => x.Author);
            Map(x => x.Title);
            Map(x => x.IsActive);
        }
    }
}