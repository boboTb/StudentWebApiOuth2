
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Repositories
{

    public sealed class DalSession : IDisposable
    {
        public DalSession(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _id = Guid.NewGuid();
        }

        IDbConnection _connection = null;
        Guid _id = Guid.Empty;
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
