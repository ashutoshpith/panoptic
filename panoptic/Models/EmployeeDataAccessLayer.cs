using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace panoptic.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Data Source=ASHUTOSH;Integrated Security=True";
        //to view all employees
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.City = rdr["City"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();

            }
            return lstemployee;

        }

        //to add new record
        public void AddEmplyee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }




        //to update the record

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@City", employee.City);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
