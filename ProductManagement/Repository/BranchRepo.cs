using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class BranchRepo: IBranchRepo
    {
        private readonly string _connectionString;
        string Message = "";
        public BranchRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Branch GeBranch(int BranchId)
        {
            var Branch = new Branch();
            var procName = "sp_getBranchById";
            var param = new DynamicParameters();
            param.Add("@BranchId", BranchId);

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (var multiResult = SqlMapper.QueryMultiple(connection,
                procName, param, commandType: CommandType.StoredProcedure))
                    {
                        Branch = multiResult.ReadFirstOrDefault<Branch>();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Branch;
        }
        public IEnumerable<Branch> GetBranches()
        {
            List<Branch> branches = new List<Branch>();
            try
            {

                var procName = "SP_GetBranches";
                //var param = new DynamicParameters();
                //param.Add("@CategoryId", null);
                //param.Add("@CategoryName", null);
                //param.Add("@CategoryDesc", null);
               // param.Add("@CategoryStatus", null);
               // param.Add("@TranUser", null);
                //param.Add("@Operation", 2);
                //param.Add("@Message", "", null, ParameterDirection.Output);
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        branches = SqlMapper.Query<Branch>(connection, procName,  commandType: CommandType.StoredProcedure).ToList();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return branches;
        }

        [HttpPost]
        public string SaveBranch(Branch branch)
        {
            string procName = "sp_UpdateBranch";
            var param = new DynamicParameters();
            string msg = "Data Saved SucessFully";
            param.Add("@BranchId", branch.BranchId, DbType.Int32, ParameterDirection.Input);
            param.Add("@BranchName", branch.BranchName);
            param.Add("@BranchDesc", branch.BranchDesc);
            param.Add("@BranchStatus", branch.BranchStatus);

            param.Add("@Message","",null,ParameterDirection.Output);


            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlMapper.Execute(connection,
                procName, param, commandType: CommandType.StoredProcedure);
                    Message = param.Get<string>("@Message");

                  }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Message;
        }
    
        [HttpPost]
        public string AddBranch(Branch branch)
        {
            string procName = "sp_InsertBranch";
            var param = new DynamicParameters();
            param.Add("@BranchName", branch.BranchName);
            param.Add("@BranchDesc", branch.BranchDesc);
            param.Add("@BranchStatus", branch.BranchStatus);
            param.Add("@Message", "", null, ParameterDirection.Output);


            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlMapper.Execute(connection,
                procName, param, commandType: CommandType.StoredProcedure);
                    Message = param.Get<string>("@Message");


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Message;
        }

        public string DeleteBranch(int BranchId)
        {
            
            var procName = "[sp_DeleteBranch]";
            var param = new DynamicParameters();
            param.Add("@BranchId", BranchId);
            param.Add("@Message", "", null, ParameterDirection.Output);

           
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlMapper.Execute(connection,
                procName, param, commandType: CommandType.StoredProcedure);

                    Message = param.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Message;

        }




    }
}
