﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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

        protected virtual async Task Create(string sproc, List<SqlParameter> sprocParams)
        {
            using SqlConnection conn = _dataSvc.GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sproc;
            cmd.Parameters.AddRange(sprocParams.ToArray());
            await cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();
        }

        protected virtual async Task<DataTable> Get(string sproc, List<SqlParameter> sprocParams)
        {
            using SqlConnection conn = _dataSvc.GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sproc;
            cmd.Parameters.AddRange(sprocParams.ToArray());
            using SqlDataReader queryResults = await cmd.ExecuteReaderAsync();
            DataTable resultTable = new DataTable();
            resultTable.Load(queryResults);
            await conn.CloseAsync();
            return resultTable;
        }

        protected virtual async Task<DataTable> Update(string sproc, List<SqlParameter> sprocParams)
        {
            using SqlConnection conn = _dataSvc.GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sproc;
            cmd.Parameters.AddRange(sprocParams.ToArray());
            using SqlDataReader queryResults = await cmd.ExecuteReaderAsync();
            DataTable resultTable = new DataTable();
            resultTable.Load(queryResults);
            await conn.CloseAsync();
            return resultTable;
        }
    }
}
