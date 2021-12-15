using Microsoft.AspNetCore.Http;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Services
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //public static T GetObjectFromJson<T>(this ISession session, string key)
        //{
        //    var value = session.GetString(key);
        //    return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        //}
        public static Admin GetObjectFromJson(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(Admin) : JsonConvert.DeserializeObject<Admin>(value);
            //return value == null ? default(Admin) : JsonConvert.DeserializeObject<Admin>(value);
        }
    }
}
