using PracticeAPI.Data.Entities;
using PracticeAPI.Data.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

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
            await base.Create(StoredProcedures.InsertUser, parameters);
        }

        /// <inheritdoc />
        public async Task<UserEntity> GetUser(int userID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = $"@{nameof(UserEntity.UserID)}",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = userID
                }
            };
            
            DataTable queryData =
                await base.Get(StoredProcedures.GetUser, parameters);

            List<UserEntity> userEntities = new List<UserEntity>();

            if (queryData.Rows.Count == 0)
                return null;

            foreach (DataRow row in queryData.Rows)
            {
                UserEntity entity = new UserEntity()
                {
                    UserID = row.Field<int>(nameof(UserEntity.UserID)),
                    FirstName = row.Field<string>(nameof(UserEntity.FirstName)),
                    LastName = row.Field<string>(nameof(UserEntity.LastName)),
                    FullName = row.Field<string>(nameof(UserEntity.FullName))
                };
                userEntities.Add(entity);
            }

            return userEntities.SingleOrDefault();
        }

        private struct StoredProcedures
        {
            public const string InsertUser = "dbo_usp_INSERT_Users";
            public const string GetUser = "dbo_usp_SELECT_Users";
        }
    }
}
