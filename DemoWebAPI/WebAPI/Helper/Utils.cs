using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WebAPI.Helper;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Auth
{
    public class Utils
    {
        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
        public static bool Login(string username, string password)
        {
            using (var repository = FluentNHibernateHelper.GetRepository())
            {
                var user = repository.Where<User>(u =>
                    u.UserName == username && u.PassWord == password);
                return user.Count != 0;
            }

        }

        public static User GetUserDetail(string username, string password)
        {

            using (IRepository repository = FluentNHibernateHelper.GetRepository())
            {
                return repository.Where<User>(user =>
                    user.UserName == username && user.PassWord == password).FirstOrDefault();
            }

        }

    }
}