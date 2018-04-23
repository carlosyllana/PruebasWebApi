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
    public class UserAsyncController : ApiController
    {
        private readonly IUserBlAsync _userBlAsync;

        public UserAsyncController(IUserBlAsync userBlAsync) 
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
