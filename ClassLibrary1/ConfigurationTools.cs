using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ConfigurationTools
    {
        public ConfigurationTools()
        {
        }

        public static string GetRedisEndPoint()
        {

            return ConfigurationManager.AppSettings["RedisConnString"];
        }

        public static string GetRedisKey()
        {

            return ConfigurationManager.AppSettings["RedisKey"];
        }
    }
}
