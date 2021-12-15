using Models.Model;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL
{
    public class KursStudentBusiness:IDisposable
    {
        IDbConnection _connection = null;
        public KursStudentBusiness(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }
        public void Dispose()
        {

        }
        public async Task<List<Kurs_Student>> GetAllCoursesByStudent(int id)
        {
           
            try
            {
                using (KursStudentRepository kursStudentRepository = new KursStudentRepository(_connection))
                {
                    return await kursStudentRepository.GetAllCoursesByStudent(id);
                }
            }
            catch(Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
        public async Task<List<Kurs_Student>> GetAllStudentByCourse(int id)
        {

            try
            {
                using (KursStudentRepository kursStudentRepository = new KursStudentRepository(_connection))
                {
                    return await kursStudentRepository.GetAllStudentByCourse(id);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
        public async Task InsertCourseStudent(Kurs_Student kurs_Student)
        {

            try
            {
                using (KursStudentRepository kursStudentRepository = new KursStudentRepository(_connection))
                {
                    await kursStudentRepository.InsertCourseStudent(kurs_Student);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
              
            }
        }

        public async Task DeleteCourseStudent(Kurs_Student kurs_Student)
        {

            try
            {
                using (KursStudentRepository kursStudentRepository = new KursStudentRepository(_connection))
                {
                    await kursStudentRepository.DeleteCourseStudent(kurs_Student);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
        }
    }
}
