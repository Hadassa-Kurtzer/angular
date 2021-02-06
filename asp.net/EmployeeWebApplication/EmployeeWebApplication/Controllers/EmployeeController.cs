using EmployeeWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;



namespace EmployeeWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        [System.Web.Http.RoutePrefix("Api/Employee")]
        public class EmployeeAPIController : ApiController
        {
            employeeEntities objEntity = new employeeEntities();

            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("AllEmployeeDetails")]
            public IQueryable<EmployeeDetails> GetEmaployee()
            {
                try
                {
                    return objEntity.EmployeeDetails;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("GetEmployeeDetailsById/{employeeId}")]
            public IHttpActionResult GetEmaployeeById(string employeeId)
            {
                EmployeeDetails objEmp = new EmployeeDetails();
                int ID = Convert.ToInt32(employeeId);
                try
                {
                    objEmp = objEntity.EmployeeDetails.Find(ID);
                    if (objEmp == null)
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                return Ok(objEmp);
            }

            [System.Web.Http.HttpPost]
            [System.Web.Http.Route("InsertEmployeeDetails")]
            public IHttpActionResult PostEmaployee(EmployeeDetails data)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    objEntity.EmployeeDetails.Add(data);
                    objEntity.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

                return Ok(data);
            }

            [System.Web.Http.HttpPut]
            [System.Web.Http.Route("UpdateEmployeeDetails")]
            public IHttpActionResult PutEmaployeeMaster(EmployeeDetails employee)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    EmployeeDetails objEmp = new EmployeeDetails();
                    objEmp = objEntity.EmployeeDetails.Find(employee.EmpId);
                    if (objEmp != null)
                    {
                        objEmp.EmpName = employee.EmpName;
                        objEmp.Address = employee.Address;
                        objEmp.EmailId = employee.EmailId;
                        objEmp.DateOfBirth = employee.DateOfBirth;
                        objEmp.Gender = employee.Gender;
                        objEmp.PinCode = employee.PinCode;

                    }
                    int i = this.objEntity.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(employee);
            }
            [System.Web.Http.HttpDelete]
            [System.Web.Http.Route("DeleteEmployeeDetails")]
            public IHttpActionResult DeleteEmaployeeDelete(int id)
            {
                //int empId = Convert.ToInt32(id);  
                EmployeeDetails emaployee = objEntity.EmployeeDetails.Find(id);
                if (emaployee == null)
                {
                    return NotFound();
                }

                objEntity.EmployeeDetails.Remove(emaployee);
                objEntity.SaveChanges();

                return Ok(emaployee);
            }
        }
    }
}