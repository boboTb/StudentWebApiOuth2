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
    public class KursRepository:IDisposable
    {
        private IDbConnection _connection;
        public KursRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Kurs>> GetAllCourses()
        {
            try
            {
                var q = @"select * from Kurs";

                var list = await _connection.QueryAsync<Kurs>(q);

                return list.ToList();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }

        public async Task<int> InsertCourse(Kurs kurs)
        {
            try
            {
                var q = @"INSERT INTO Kurs(Naziv_Kursa)          
            VALUES (@Naziv_Kursa);SELECT CAST(SCOPE_IDENTITY() as int)";

                var result = await _connection.QueryAsync<int>(q, kurs);

                return result.Single();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return 0;
            }
        }
        public void Dispose()
        {

        }
    }
}
