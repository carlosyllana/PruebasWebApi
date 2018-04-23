using ClassLibrary1;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasWebAPi.DataAcces.Dao
{
    public class RedisDao<T> : IDaoAsync<T> where T : GenericObject
    {

        private readonly IDatabase _redis;


        public RedisDao()
        {
            _redis = RedisConfig.RedisCache;
        }

        public async Task<T> SetAsync(T entity, string key)
        {
            await _redis.StringSetAsync(key, JsonConvert.SerializeObject(entity));
            return await GetAsync(key);
        }

        public async Task<T> GetAsync(string key)
        {
            return JsonConvert.DeserializeObject<T>(await this._redis.StringGetAsync(key));
        }

    }
}
