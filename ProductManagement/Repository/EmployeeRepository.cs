using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        private readonly string _connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
       
        public EmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee() {Id=1, Name="Ram", Department="HR", Email="ram@gmail.com"},
                new Employee() {Id=2, Name="Shyam", Department="Marketing", Email="shyam@gmail.com"},
                new Employee() {Id=3, Name="Hari", Department="Finance", Email="hari@gmail.com"},
                new Employee() {Id=4, Name="Krishna", Department="IT", Email="krishna@gmail.com"},
            };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> listEmployee = new List<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "Select * From Employees"; SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        
                        while (dataReader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = Convert.ToInt32(dataReader["Id"]);
                            employee.Name = Convert.ToString(dataReader["Name"]);
                            employee.Email = Convert.ToString(dataReader["Email"]);

                            employee.Department = Convert.ToString(dataReader["Department"]);


                            listEmployee.Add(employee);
                        }
                    }


                    connection.Close();


                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEmployee;
        }        

        

        public Employee GetEmployee(int empId)
        {
            var Employee = new Employee();
            var procName = "spGetEmployee";
            var param = new DynamicParameters();
            param.Add("@Id", empId);

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (var multiResult = SqlMapper.QueryMultiple(connection,
                procName, param, commandType: CommandType.StoredProcedure))
                    {
                        Employee = multiResult.ReadFirstOrDefault<Employee>();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Employee;
        }

        public int DeleteEmployee(int empId)
        {
            int RowsCount=0;
            
            var procName = "spDeleteEmployee";
            var param = new DynamicParameters();
            param.Add("@Id", empId);
            param.Add("@RowsCount", 0, null, ParameterDirection.Output);            

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlMapper.Execute(connection,
                procName, param, commandType: CommandType.StoredProcedure);

                   RowsCount = param.Get<int>("@RowsCount");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RowsCount;
           
        }

        public int SaveEmployee(Employee employee)
        {
            string procName = "spSaveEmployee";
            var param = new DynamicParameters();
            int Id = 0;

            param.Add("@Id", employee.Id, DbType.Int32, ParameterDirection.InputOutput);
            param.Add("@Name", employee.Name);
            param.Add("@Email", employee.Email);
            param.Add("@Department", employee.Department);
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlMapper.Execute(connection,
                procName, param, commandType: CommandType.StoredProcedure);

                    Id = param.Get<int>("@Id");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        
    }
}
