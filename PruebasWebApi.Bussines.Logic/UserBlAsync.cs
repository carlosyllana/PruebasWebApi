using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using PruebasWebAPi.DataAcces.Dao;

namespace PruebasWebApi.Bussines.Logic
{
    public class UserBlAsync : IUserBlAsync
    {


        private readonly IDaoAsync<User> _iDao = null;

        //Preparamos la inyección de dependencias.
        public UserBlAsync(IDaoAsync<User> idao)
        {
            this._iDao = idao;
        }

        public Task<User> GetUserAsync(string key)
        {
            return this._iDao.GetAsync(key);
        }

        public Task<User> SetUserAsync(User user, string key)
        {
            return this._iDao.SetAsync(user, key);
        }
    }
}
