using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using Models.Model;
using StudentBL;

namespace StudentWebApiOuth2.Controllers
{

    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {

        string _connection = ConfigurationManager.ConnectionStrings["StudentskaSluzba_Database"].ConnectionString;

        //}

        [HttpGet]
        [Authorize]
        [Route("GetAllStudents")]
        public async Task<IHttpActionResult> GetAllStudentsAsync()
        {
            try
            {
                List<Student> list = new List<Student>();
                using (StudentBusiness studentBusiness = new StudentBusiness(_connection))
                {
                    list = await studentBusiness.GetAllStudents();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("ReadStudentProcedure")]
        public async Task<IHttpActionResult> ReadStudentProcedure()
        {
            try
            {
                List<Student> list = new List<Student>();
                using (StudentBusiness studentBusiness = new StudentBusiness(_connection))
                {
                    list = await studentBusiness.ReadStudentProcedure();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Authorize]
        [Route("InsertStudent")]
        public async Task<IHttpActionResult> InsertStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int list=0;
                using (StudentBusiness studentBusiness = new StudentBusiness(_connection))
                {
                    list = await studentBusiness.InsertStudent(student);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Authorize]
        [Route("UpdateStudent")]
        public async Task<IHttpActionResult> UpdateStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (StudentBusiness studentBusiness = new StudentBusiness(_connection))
                {
                    await studentBusiness.UpdateStudent(student);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteStudent/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (StudentBusiness studentBusiness = new StudentBusiness(_connection))
                {
                    await studentBusiness.DeleteStudent(id);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
