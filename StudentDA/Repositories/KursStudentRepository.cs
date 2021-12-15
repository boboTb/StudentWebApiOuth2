using Dapper;

using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class KursStudentRepository:IDisposable
    {
        private IDbConnection _connection;
        public KursStudentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Kurs_Student>> GetAllStudentByCourse(int id)
        {
            try
            {
                var p = new
                {
                    Id = id
                };
                var q = @"select * from Kurs Student where Kurs_ID = @Id";

                var list = await _connection.QueryAsync<Kurs_Student>(q, p);

                return list.ToList();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
        public async Task<List<Kurs_Student>> GetAllCoursesByStudent(int id)
        {
            try
            {
                var p = new
                {
                    Id = id
                };
                var q = @"select * from Kurs Student where Student_ID = @Id";

                var list = await _connection.QueryAsync<Kurs_Student>(q,p);

                return list.ToList();
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
                var q = @"INSERT INTO [Kurs Student](Kurs_ID,Student_ID)          
                VALUES (@Kurs_ID,@Student_ID)";

                var result = await _connection.QueryAsync(q, kurs_Student);

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
                var q = @"Delete from [Kurs Student] where Student_ID = @Student_ID and Kurs_ID = @Kurs_ID";

                await _connection.QueryAsync(q, kurs_Student);
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
        }

        public async Task ReplaceCourses(List<Kurs> list, int StudentID)
        {
            try
            {
                var p = new
                {
                    ID = StudentID
                };
                var q = @"Delete from [Kurs Student] where Student_ID = @ID";
                await _connection.QueryAsync(q, p);
                foreach (Kurs k in list)
                {
                    Kurs_Student ks = new Kurs_Student();
                    ks.Kurs_ID = k.Kurs_ID;
                    ks.Student_ID = StudentID;
                    await InsertCourseStudent(ks);
                }
                
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
        }
        public void Dispose()
        {

        }
    }
}
