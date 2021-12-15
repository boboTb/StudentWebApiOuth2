using System;
using System.Collections.Generic;
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
using Microsoft.Owin.Host.SystemWeb;
using System.Configuration;

namespace StudentWebApiOuth2.Controllers
{

    [RoutePrefix("api/KursStudent")]
    public class KursStudentController : ApiController
    {
        string _connection = ConfigurationManager.ConnectionStrings["StudentskaSluzba_Database"].ConnectionString;

        [HttpGet]
        [Authorize]
        [Route("GetAllCoursesByStudent")]
        public async Task<IHttpActionResult> GetAllCoursesByStudent(int id)
        {
            try
            {
                List<Kurs_Student> list = new List<Kurs_Student>();
                using (KursStudentBusiness kursStudentBusiness = new KursStudentBusiness(_connection))
                {
                    list = await kursStudentBusiness.GetAllCoursesByStudent(id);
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
        [Route("GetAllStudentByCourse")]
        public async Task<IHttpActionResult> GetAllStudentByCourse(int id)
        {
            try
            {
                List<Kurs_Student> list = new List<Kurs_Student>();
                using (KursStudentBusiness kursStudentBusiness = new KursStudentBusiness(_connection))
                {
                    list = await kursStudentBusiness.GetAllStudentByCourse(id);
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
        [Route("InsertCourseStudent")]
        public async Task<IHttpActionResult> InsertCourseStudent(Kurs_Student kurs_Student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (KursStudentBusiness kursStudentBusiness = new KursStudentBusiness(_connection))
                {
                    await kursStudentBusiness.InsertCourseStudent(kurs_Student);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteCourseStudent")]
        public async Task<IHttpActionResult> DeleteCourseStudent(Kurs_Student kurs_Student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (KursStudentBusiness kursStudentBusiness = new KursStudentBusiness(_connection))
                {
                    await kursStudentBusiness.DeleteCourseStudent(kurs_Student);
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
