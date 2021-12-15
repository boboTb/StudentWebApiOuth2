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
    public class UserBusiness : IDisposable
    {
        IDbConnection _connection = null;
        public UserBusiness(string connectionString)
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
        public async Task<User> GetUser(string username,string pass)
        {
           
            try
            {
                using (UserRepository userRepository = new UserRepository(_connection))
                {
                    return await userRepository.GetUser(username,pass);
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
