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
    public class StudentRepository:IDisposable
    {
        private IDbConnection _connection;
        public StudentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Student>> ReadStudentProcedure()
        {
            try
            {
                var result = await _connection.QueryAsync<Student>("[ReadStudent]", commandType: CommandType.StoredProcedure);

                return result.ToList();

            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                var q0 = @"select * from Student";

                var list = await _connection.QueryAsync<Student>(q0);


                
                foreach(Student s in list)
                {
                    var q2 = new
                    {
                        Id = s.Student_ID
                    };
                    var q1 = @"select c.* from (select * from [Kurs Student] where Student_ID=@Id) b join Kurs c on b.Kurs_ID = c.Kurs_ID";
                    var list1 = await _connection.QueryAsync<Kurs>(q1,q2);
                    s.Kursevi = list1.ToList();
                }
                return list.ToList();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
        public async Task<int> InsertStudent(Student student)
        {
            try
            {
                var q = @"INSERT INTO Student(Broj_Indeksa, Ime, Prezime,Godina, Status_Studenta)          
            VALUES (@Broj_Indeksa, @Ime, @Prezime,@Godina, @Status_Studenta);SELECT CAST(SCOPE_IDENTITY() as int)";

                var result = await _connection.QueryAsync<int>(q, student);

                return result.Single();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return 0;
            }
        }
        public async Task UpdateStudent(Student student)
        {
            try
            {
                var q = @"update Student 
            set Broj_Indeksa=@Broj_Indeksa, ime = @Ime, Prezime=@Prezime, Status_Studenta = @Status_Studenta, Godina=@Godina
            Where Student_ID = @Student_ID";

                await _connection.QueryAsync(q, student);
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }

        }
        public async Task DeleteStudent(int id)
        {
            try
            {
                var p = new
                {
                    ID = id
                };
                var q1 = @"Delete from [Kurs Student] where Student_ID = @ID";

                await _connection.QueryAsync(q1, p);
                var q2 = @"Delete from Student where Student_ID = @ID";

                await _connection.QueryAsync(q2, p);
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
