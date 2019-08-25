using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class UserMethod
    {
        public virtual long Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual long Method { get; set; }
        //public virtual string Action { get; set; }
    }

    public class UserMethodMap : ClassMap<UserMethod>
    {
        public UserMethodMap()
        {
            Table("UserMethods");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.UserName);
            Map(x => x.Method);
            //Map(x => x.Action);
        }
    }

    public class UserMethodSub
    {
        public string UserName { get; set; }
        public long Method { get; set; }

        public UserMethodSub(UserMethod u)
        {
            UserName = u.UserName;
            Method = u.Method;
        }

        public UserMethodSub(string username,long method)
        {
            UserName = username;
            Method = method;
        }
    }

    public class UserMethodEqualityComparer : IEqualityComparer<UserMethodSub>
    {
        public bool Equals(UserMethodSub x, UserMethodSub y)
        {
            if (x.UserName.ToLower() == y.UserName.ToLower() && x.Method == y.Method)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(UserMethodSub obj)
        {
            return obj.UserName.GetHashCode() ^ obj.Method.GetHashCode();
        }
    }
}