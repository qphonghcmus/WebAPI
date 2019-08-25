using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IAuthRepository : IDisposable
    {
        Client FindClient(string clientId);
        User FindUser(string username, string password);
        bool AddRefreshToken(RefreshToken token);
        bool RemoveRefreshToken(RefreshToken token);
        bool RemoveRefreshToken(string tokenId);
        RefreshToken FindRefreshToken(string refreshTokenId);
        IList<RefreshToken> GetAllRefreshTokens();
    }
}
