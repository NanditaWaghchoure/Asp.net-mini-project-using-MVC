using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        





        //string connectionString = "Put Your Connection string here";

        //To View all employees details    
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


                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.City = rdr["City"].ToString();
                    if (!(rdr["DateOfBirth"]is DBNull)) {
                        employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    }

                    //employee.ID = Convert.ToInt32(rdr["EmployeeID"]);  
                    //employee.Name = rdr["Name"].ToString();
       // employee.Gender = rdr["Gender"].ToString();
        //employee.Department = rdr["Department"].ToString();
       // employee.City = rdr["City"].ToString();

        lstemployee.Add(employee);  
                }
    con.Close();  
            }  
            return lstemployee;  
        }




        //To Add employees details
        public void AddEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);


                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Edit the Employee details
        public void SaveEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);



                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);


                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            

        }
        }


        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value =id;
                cmd.Parameters.Add(paramId);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}