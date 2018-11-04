using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example47App.Controllers
{
    public class ValuesController : ApiController
    {
        private List<string> values = new List<string>() { "value1",  "value2" };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (id > values.Count()) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            return values[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            values.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            if (id > values.Count() || string.IsNullOrEmpty(value)) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            values[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (id > values.Count()) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            values.RemoveAt(id);
        }
    }
}
