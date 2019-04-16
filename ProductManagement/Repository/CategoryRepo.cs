using Dapper;
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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly string _connectionString;
        string Message = "";
        public CategoryRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public string DeleteCategory(int CategoryId)
        {
            
            var procName = "spDeleteCategory";
            var param = new DynamicParameters();
            param.Add("@CategoryId", CategoryId);
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

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                
                    var procName = "spGetCategories";
                    var param = new DynamicParameters();
                    
                try
                    {
                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                         categories = SqlMapper.Query<Category>( connection, procName, param, commandType: CommandType.StoredProcedure).ToList();
                         
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
            return categories;
        }

        public Category GetCategory(int CategoryId)
        {
            var Category = new Category();
            var procName = "spGetCategory";
            var param = new DynamicParameters();
            param.Add("@CategoryId", CategoryId);

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (var multiResult = SqlMapper.QueryMultiple(connection,
                procName, param, commandType: CommandType.StoredProcedure))
                    {
                        Category = multiResult.ReadFirstOrDefault<Category>();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Category;
        }

        public string UpdateCategory(Category category)
        {
            string procName = "spSaveCategory";
            var param = new DynamicParameters();            

            param.Add("@CategoryId", category.CategoryId);
            param.Add("@CategoryName", category.CategoryName);
            param.Add("@CategoryDesc", category.CategoryDesc);
            param.Add("@CategoryStatus", category.CategoryStatus);
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

        public string CreateCategory(Category category)
        {
            string procName = "spCreateCategory";
            var param = new DynamicParameters();

            param.Add("@CategoryId", category.CategoryId);
            param.Add("@CategoryName", category.CategoryName);
            param.Add("@CategoryDesc", category.CategoryDesc);
            param.Add("@CategoryStatus", category.CategoryStatus);
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

        public IEnumerable<CategoryOption>  GetCategoryOptions(int CategoryId)
        {
            
            List<CategoryOption> categoryOptions = new List<CategoryOption>();
            var procName = "spGetCategoryOption";
            var param = new DynamicParameters();
            param.Add("@CategoryId", CategoryId);

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    
                      categoryOptions = SqlMapper.Query<CategoryOption>(connection, procName, param, commandType: CommandType.StoredProcedure).ToList();

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return categoryOptions;
        }
    }
}
