using ClassLibrary1;
using PruebasWebApi.Bussines.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebasWebApi.Business.Facade.Controllers
{
    public class UserAsyncController : ApiController
    {
        private readonly IUserBlAsync _usuarioBlAsync;

        public UserAsyncController(IUserBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }


        /// <summary>
        /// Gets a student by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IHttpActionResult> GetAsync(string key)
        {
            //Thread.Sleep(10000);
            return Ok(await this._usuarioBlAsync.GetUserAsync(key));
        }


        /// <summary>
        /// Add a student into redis by appseting key
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IHttpActionResult> AddAsync(User entity)
        {
            // Thread.Sleep(10000);
            string key = ConfigurationTools.GetRedisKey();
            return Ok(await this._usuarioBlAsync.SetUserAsync(entity, key));
        }
    }
}
