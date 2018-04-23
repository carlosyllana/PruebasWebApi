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
    public class UserAsyncV2Controller : ApiController
    {
        private readonly IUserBlAsync _usuarioBlAsync;

        public UserAsyncV2Controller(IUserBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }



        [HttpGet()]
        public async Task<IHttpActionResult> GetAsync(string key)
        {
            //Thread.Sleep(10000);
            return Ok(await this._usuarioBlAsync.GetUserAsync(key));
        }


        //Mi post viene aquí, y le paso un usuario y la clave con la que se guarda. Al usuario le paso un Id, nombre y apellido SI? (escribe ok) 
        [HttpPost()]
        public async Task<IHttpActionResult> AddAsync(User entity)
        {
            // Thread.Sleep(10000);ç
            string key = ConfigurationTools.GetRedisKey();
            return Ok(await this._usuarioBlAsync.SetUserAsync(entity, key));
        }
    }
}
