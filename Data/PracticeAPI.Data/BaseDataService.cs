using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PracticeAPI.Data
{
    public abstract class BaseDataService
    {
        private readonly string _connStr;
        public BaseDataService(string connStr)
        {
            _connStr = connStr;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }
    }
}
