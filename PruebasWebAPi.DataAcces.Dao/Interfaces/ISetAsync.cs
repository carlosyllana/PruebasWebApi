using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasWebAPi.DataAcces.Dao
{
    public interface ISetAsync<T> where T: GenericObject
    {
        Task<T> SetAsync(T entity, string key);
    }
}
