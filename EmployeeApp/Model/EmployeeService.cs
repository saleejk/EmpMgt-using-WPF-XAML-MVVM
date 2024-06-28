using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace EmployeeApp.Model
{
    public class EmployeeService
    {
        public string connectionString = "data source=DESKTOP-4HK2TSI;database=employeeDB;integrated security=SSPI;TrustServerCertificate=True";

        public EmployeeService()
        {      
        }
        public List<Employee> GetAll()
        {
            try
            {
                List<Employee> employeesList = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select * from employee", connection);
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = Convert.ToInt32(sdr["id"]);
                        emp.Name = sdr["name"].ToString();
                        emp.Title = sdr["title"].ToString();
                        emp.Department = sdr["department"].ToString();
                        employeesList.Add(emp);
                    }
                    return employeesList;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }  
        }
        public bool AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into employee(name,title,department)values(@name,@title,@department)", connection);
                command.Parameters.AddWithValue("name", employee.Name);
                command.Parameters.AddWithValue("title", employee.Title);
                command.Parameters.AddWithValue("department", employee.Department);
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update employee set name=@name,title=@title,department=@department where id=@id",connection);
                command.Parameters.AddWithValue("name", employee.Name);
                command.Parameters.AddWithValue("title", employee.Title);
                command.Parameters.AddWithValue("department", employee.Department);
                command.Parameters.AddWithValue("id", employee.Id);
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from employee where id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
                return true;    
        }
    }
}
