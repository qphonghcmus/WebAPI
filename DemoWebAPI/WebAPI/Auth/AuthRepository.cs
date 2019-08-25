using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Helper;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Auth
{
    /// <summary>
    /// Repository dùng để xác thực
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        #region properties

        private readonly IRepository repo;

        #endregion

        #region Private methods

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthRepository()
        {
            repo = FluentNHibernateHelper.GetRepository();
        }

        #endregion

        #region Implemented methods

        
        public Client FindClient(string clientId)
        {
            return repo.Get<Client>(clientId);
        }

        public User FindUser(string username, string password)
        {
            User user = null;
            Task task = new Task(() =>
            {
                user = repo.Where<User>(u => u.UserName == username && u.PassWord == password).FirstOrDefault();
            });
            task.Start();
            task.Wait(500);
            return user;
        }

        public bool AddRefreshToken(RefreshToken token)
        {

            try
            {
                var existingToken = repo.Where<RefreshToken>(r=>r.Subject == token.Subject && r.ClientId == token.ClientId).FirstOrDefault();
                if (existingToken != null)
                {
                    var result = RemoveRefreshToken(existingToken);
                }
                repo.Insert<RefreshToken>(token);
                repo.Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool RemoveRefreshToken(RefreshToken token)
        {
            try
            {
                repo.Delete<RefreshToken>(token);
                repo.Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoveRefreshToken(string tokenId)
        {
            try
            {
                var refreshToken = repo.Where<RefreshToken>(r => r.Id == tokenId).FirstOrDefault();
                if (refreshToken != null)
                {
                    repo.Delete<RefreshToken>(r=>r.Id == tokenId);
                    repo.Commit();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public RefreshToken FindRefreshToken(string refreshTokenId)
        {
            return repo.Where<RefreshToken>(r => r.Id == refreshTokenId).FirstOrDefault();
        }

        public IList<RefreshToken> GetAllRefreshTokens()
        {
            return repo.GetAll<RefreshToken>();
        }

        public void Dispose()
        {
            repo.Dispose();
        }
        #endregion
    }
}