using Models.Model;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL
{
    public class KursBusiness:IDisposable
    {
        IDbConnection _connection = null;
        string connectionString = ConfigurationManager.ConnectionStrings["StudentskaSluzba_Database"].ConnectionString;
        public KursBusiness()
        {
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            catch(Exception ex)
            {
                string mess = ex.ToString();
            }
        }
        public void Dispose()
        {

        }
        public async Task<List<Kurs>> GetAllCourses()
        {
           
            try
            {
                using (KursRepository kursRepostory = new KursRepository(_connection))
                {
                    return await kursRepostory.GetAllCourses();
                }
            }
            catch(Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }

        public async Task<int> InsertKurs(Kurs kurs)
        {

            try
            {
                using (KursRepository kursRepository = new KursRepository(_connection))
                {
                    return await kursRepository.InsertCourse(kurs);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return 0;
            }
        }
    }
}
