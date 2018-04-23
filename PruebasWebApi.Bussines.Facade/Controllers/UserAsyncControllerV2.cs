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

namespace PruebasWebApi.Bussines.Facade.Controllers
{
    //Creamos un UserAsynControllerV2 para probar el control de versiones de la api.
    //https://www.c-sharpcorner.com/UploadFile/97fc7a/demystify-web-api-versioning/
    public class UserAsyncControllerV2 : ApiController
    {
        private readonly IUserBlAsync _userBlAsync;

        public UserAsyncControllerV2(IUserBlAsync userBlAsync) 
        {
            _userBlAsync = userBlAsync;
        }

        public async  Task<User> GetUserAsync(string key)
        {
            Thread.Sleep(1000);
            return await this._userBlAsync.GetUserAsync(key);
        }

        public async Task<User> SetUserAsync(User user, string key)
        {
            return await this._userBlAsync.SetUserAsync(user,key);
        }
    }
}
