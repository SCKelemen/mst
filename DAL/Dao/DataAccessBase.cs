using System;
using System.Data;

namespace DAL.Dao {
    public class DataAccessBase : IDisposable 
    {
        private readonly object _connection;

        protected DataAccessBase(string connectionString) 
        {
            _connection = connectionString;
        }
    }
}