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
    public class UserRepository : IDisposable
    {
        private IDbConnection _connection;
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> GetUser(string username,string pass)
        {
            try
            {
                var p = new
                {
                    UserName = username,
                    Password = pass
                };
                var q = @"select * from AppUser where UserName = @UserName and Password = @Password";

                var user = await _connection.QueryAsync<User>(q,p);

                return user.FirstOrDefault();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }


        public void Dispose()
        {

        }
    }
}
