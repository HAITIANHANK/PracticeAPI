using PracticeAPI.Data.Entities;
using PracticeAPI.Data.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Data.Repos.Impl
{
    /// <inheritdoc cref="IUserRepo" />
    public class UserRepo : BaseRepo, IUserRepo
    {
        public UserRepo(BaseDataService dataSvc) : base(dataSvc)
        {
        }

        protected override string TableName => "Users";

        /// <inheritdoc />
        public async Task SaveName(UserEntity user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = $"@{nameof(user.FirstName)}",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = user.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = $"@{nameof(user.LastName)}",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = user.LastName
                },
                new SqlParameter()
                {
                    ParameterName = $"@{nameof(user.FullName)}",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = user.FullName
                }
            };
            await base.Create(StoredProcedures.InsertUser, parameters.ToArray());
        }

        private struct StoredProcedures
        {
            public const string InsertUser = "dbo_usp_INSERT_Users";
        }
    }
}
