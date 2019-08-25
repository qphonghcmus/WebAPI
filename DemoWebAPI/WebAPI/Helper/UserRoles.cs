using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Mod = "Mod";
        public const string User = "User";

        public static Dictionary<UserMethodSub, bool> user_method_dict;
    }
}