using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Auth;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {
        private readonly AuthRepository _repo = null;

        public RefreshTokensController()
        {
            _repo = new AuthRepository();
        }

        // GET: api/RefreshTokens
        [Authorize]
        [Route]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RefreshTokens/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RefreshTokens
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RefreshTokens/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RefreshTokens/5
        [AllowAnonymous]
        [Route]
        public IHttpActionResult Delete(string tokenId)
        {

            var result = _repo.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");
        }
    }
}
