using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ProductManagement.Entity;
using ProductManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly string _connectionString;
        public UserRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public User GetUserByUserName(string username, string password)
        {
            var user = new User();
            var procName = "spCheckUser";
            var param = new DynamicParameters();
            param.Add("@username", username);
            param.Add("@password", password);
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (var result = SqlMapper.QueryMultiple(connection,
                procName, param, commandType: CommandType.StoredProcedure))
                    {
                        user = result.ReadFirstOrDefault<User>();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;

        }
    }
}
