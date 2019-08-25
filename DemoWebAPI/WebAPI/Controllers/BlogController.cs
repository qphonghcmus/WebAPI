using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Routing;
using WebAPI.Auth;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // URI: api/Blog/
    [RoutePrefix("api/Blog")]
    public class BlogController : ApiController
    {
        // GET: api/Blog
        /// <summary>
        /// Get all blogs
        /// </summary>
        /// <returns></returns>
        //[BasicAuthentication]
        //[Authorize]
        [CustomAuthorize]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            using (var repository = FluentNHibernateHelper.GetRepository())
            {
                var blogs = repository.GetAll<Blog>();
                return Ok(blogs);
            }
        }

        // GET: api/Blog/5
        /// <summary>
        /// Get blog by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:long:min(1)}")]
        [CustomAuthorize]
        public IHttpActionResult GetById(long id)
        {
            using (var repository = FluentNHibernateHelper.GetRepository())
            {
                Blog blog = repository.Get<Blog>(id);
                return Ok(blog);
            }
        }

        // POST: api/Blog
        [Route("")]
        //[CustomAuthorize]
        public void Post([FromBody]Blog value)
        {
        }

        // PUT: api/Blog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Blog/5
        public void Delete(int id)
        {
        }
    }
}
