using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Mvc;
using EntityFrame;
namespace WebApi2.Controllers
{
    public class EmployeesController : ApiController
    {
        public HttpResponseMessage Get(string gender = "All")
        {
            EmployeeDBEntities context = new EmployeeDBEntities();
            switch (gender.ToLower())
            {
                case "all":
                    var result = context.Employees;
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                case "male":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        context.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                case "female":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        context.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        "value for gender must be All, Male or Female." + gender + "is Invalid");


            }

           
        }

        public HttpResponseMessage Get(int id)
        {
            EmployeeDBEntities context = new EmployeeDBEntities();

            var entity = context.Employees.FirstOrDefault(e => e.ID == id);

            if(entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Employee with id = " + id.ToString() + " Not Found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
        }

        //public HttpResponseMessage Post([FromBody] Employee employee) {

        //    try {
        //        using (var context = new EmployeeDBEntities())
        //        {
        //            context.Employees.Add(employee);
        //            context.SaveChanges();

        //            var message = Request.CreateResponse(HttpStatusCode.Created, employee);
        //            message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex){
        //      return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);


        //    }

        //} 

        public HttpResponseMessage Post([FromBody] Dictionary<string, string> data)
        {
            try
            {  // Process the data here
                EmployeeDBEntities context = new EmployeeDBEntities();
                var result1 = context.Employees;
                return Request.CreateResponse(HttpStatusCode.OK, result1);
                //return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            using(EmployeeDBEntities context = new EmployeeDBEntities())
            {
                try
                {
                    var entity = context.Employees.FirstOrDefault(
                        e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id + " Not Found");
                    }
                    else
                    {
                        context.Employees.Remove(entity);
                        context.SaveChanges();
                        return  Request.CreateResponse(HttpStatusCode.OK);

                    }
                    
                }
                catch(Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

         public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {

            using (EmployeeDBEntities context = new EmployeeDBEntities())
            {
                var entity = context.Employees.FirstOrDefault(e =>
                e.ID == id);
                try
                {
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee With id =" + id + " not found");
                    }else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;
                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, employee);
                    }
                }
                catch(Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }
        public HttpResponseMessage Put([FromUri] string name, [FromBody] Employee employee)
        {

            using (EmployeeDBEntities context = new EmployeeDBEntities())
            {
                var entity = context.Employees.FirstOrDefault(e =>
                e.LastName == name);
                try
                {
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee With id =" + name + " not found");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;
                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, employee);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


    }
}
