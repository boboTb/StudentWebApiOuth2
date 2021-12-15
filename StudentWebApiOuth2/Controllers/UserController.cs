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
using System.Web.Http.Cors;
using Microsoft.Extensions.Configuration;
using Models.Model;
using StudentBL;

namespace StudentWebApiOuth2.Controllers
{

    [RoutePrefix("api/Token")]
    public class UserController : ApiController
    {

        string _connection = ConfigurationManager.ConnectionStrings["StudentskaSluzba_Database"].ConnectionString;

        [HttpGet]
        [Route("Token")]
        public async Task<IHttpActionResult> GetUser()
        {
            try
            {
                List<Kurs> list = new List<Kurs>();
                using (KursBusiness kursBusiness = new KursBusiness())
                {
                    list = await kursBusiness.GetAllCourses();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
