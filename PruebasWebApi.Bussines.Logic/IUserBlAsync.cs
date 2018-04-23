using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasWebApi.Bussines.Logic
{
    public interface IUserBlAsync
    {
        Task<User> SetUserAsync(User user, string key);
        Task<User> GetUserAsync(string key);
    }
}
