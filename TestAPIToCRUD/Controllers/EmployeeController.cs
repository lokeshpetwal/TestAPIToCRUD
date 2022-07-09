using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestAPIToCRUD.DB;
using TestAPIToCRUD.Models;

namespace TestAPIToCRUD.Controllers
{  [ApiController]
   [Route("Api/Controller")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {

            _db = db;
        }
        [HttpGet]
        [Route("Show/Employee")]
        public List<EmployeeModel> ShowEmployee()
        {

            var res = _db.Employee.ToList();
            return res ;
        }
        
        [HttpPost]
        [Route("Post/Employee")]
        public HttpResponseMessage AddEmployee(EmployeeModel emp)
        {

            if (emp.Id == 0)
            {
                _db.Employee.Add(emp);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(emp).State = EntityState.Modified;
                _db.SaveChanges();
            }
            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);
            return hrm;

        }
        [HttpDelete]
        [Route("del/Employee")]
        public HttpResponseMessage Delete(int id)
        {
            var delres = _db.Employee.Where(m => m.Id == id).First();

            _db.Employee.Remove(delres);
            _db.SaveChanges();
            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);
            return hrm;

        }
        [HttpGet]
        [Route("Edit/Employee")]
        public EmployeeModel EditProduct(int id)
        {
            var resEdit = _db.Employee.Where(m => m.Id == id).First();

            EmployeeModel employee = new EmployeeModel();

            employee.Id = resEdit.Id;
            employee.Name = resEdit.Name;
            employee.Salary = resEdit.Salary;
            employee.Email = resEdit.Email;
            employee.Dept = resEdit.Dept;
            employee.Mobile = resEdit.Mobile;
            employee.Company = resEdit.Company;



            return employee;


        }

        [HttpPost]
        [Route("user/login")]
        public LogInModel LogIn(LogInModel log)
        {
            LogInModel obj = new LogInModel();
            var res = _db.LogIn.Where(m => m.Email == log.Email).FirstOrDefault();
            if (res == null)
            {
                obj.Email ="email is not found";
                
                
            }
            else
            {
                if (res.Email == log.Email && res.Password == log.Password)
                {
                    obj.Email = res.Email;
                    obj.Password = res.Password;
                }
                else
                {
                    obj.Password = "invalid password";
                }
                
            }
            return obj;
        }
    }
}
 