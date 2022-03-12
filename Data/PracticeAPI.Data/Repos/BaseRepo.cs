using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Data.Repos
{
    public abstract class BaseRepo
    {
        private readonly BaseDataService _dataSvc;
        public BaseRepo(BaseDataService dataSvc)
        {
            _dataSvc = dataSvc;
        }
        protected abstract string TableName { get; }

        protected virtual async Task Create(string sproc, SqlParameter[] sprocParams)
        {
            using SqlConnection conn = _dataSvc.GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sproc;
            cmd.Parameters.AddRange(sprocParams);
            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();
        }
    }
}
