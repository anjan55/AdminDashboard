using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ProductManagement.Entity;
using ProductManagement.Helpers;
using ProductManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly string _connectionString;
        private readonly AppSettings _appSettings;
        private IConfiguration _config;
        public UserRepo(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _appSettings = appSettings.Value;
            _config = configuration;
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

                // return null if user not found
                    }
                }

                if (user == null)
                    return null;
                var userRole = GetRoleById(user.RoleId);
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _config["Jwt:Issuer"],
                    Audience = _config["Jwt:Issuer"],
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.FirstName.ToString()),
                    new Claim(ClaimTypes.Role,"Admin")
                    }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                user.Password = null;
                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetRoleById(int roleId)
        {
            string sqlText = "SELECT * FROM TBLUSERROLE WHERE ROLEID=@ROLEID";
            string roleName = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var result = connection.QueryFirstOrDefault(sqlText, new { @ROLEID = roleId });
                    roleName = result.RoleName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roleName;
        }
    }
}
