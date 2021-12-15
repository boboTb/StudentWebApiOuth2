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

    [RoutePrefix("api/Kurs")]
    public class KursController : ApiController
    {


        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IHttpActionResult> GetAllCourses()
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

        [HttpPost]
        [Route("InsertKurs")]
        public async Task<IHttpActionResult> InsertKurs(Kurs kurs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int list=0;
                using (KursBusiness kursBusiness = new KursBusiness())
                {
                    list = await kursBusiness.InsertKurs(kurs);
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
