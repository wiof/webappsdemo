using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CibDemo.Controllers
{
    public class HealthController : ApiController
    {
        private static bool Healthy { get; set; } = true; 

        // GET: api/Health
        public Object Get()
        {
            if (Healthy == false)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return new { healthy = Healthy };
        }


        // POST: api/Health
        public Object Post([FromBody]string value)
        {
            Healthy = Convert.ToBoolean(value);
            return new { healthy = Healthy };
        }

    }
}
