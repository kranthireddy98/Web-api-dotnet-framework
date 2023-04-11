using EntityFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApi2.Controllers
{
    public class EmployeeeeController : ApiController
    {
        
        public HttpResponseMessage Post([FromBody] Dictionary<string, string> data)
        {
            // Process the data here
            EmployeeDBEntities context = new EmployeeDBEntities();
            var gender = data["Geder"];
            var result1 = context.Employees.Where(e => e.Gender.ToLower() == gender.ToLower()).ToList();
            var result = new Dictionary<string, object>
        {
            { "Message", "Data received successfully!" },
            { "Data", data }
        };
            return Request.CreateResponse(HttpStatusCode.OK, result1);
        }
    }
}
