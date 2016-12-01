using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; 
using System.Configuration; 
using System.Data.SqlClient;

namespace EmployeeDirectory
{
    public class EmployeeDirectory
    {
            public string name { get; set; } 
	        public string lname { get; set; } 
	        public string fname { get; set; } 
	        public Guid guid { get; set; } 
	        public string address { get; set; } 
	        public string interests { get; set; } 
	        public string age { get; set; } 
	        public string picture { get; set; }

        public List<EmployeeDirectory> GetEmployeesView(string lastname)
	        { 
	            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mwd"].ConnectionString); 
	            SqlCommand cmd = new SqlCommand("spEmployeeDirectoryViewDetail", conn); 
	            cmd.CommandType = CommandType.StoredProcedure; 
                SqlParameter parameterLName = new SqlParameter("@LName", SqlDbType.VarChar, 50); 
	            parameterLName.Value = lastname; 
	            cmd.Parameters.Add(parameterLName); 
	            List<EmployeeDirectory> employees = new List<EmployeeDirectory>(); 
	            try 
	            { 
	                conn.Open(); 
	                SqlDataReader rdr = cmd.ExecuteReader(); 
	                while (rdr.Read()) 
	                { 
	                    EmployeeDirectory ed = new EmployeeDirectory(); 
	                    ed.name = rdr["Name"].ToString(); 
	                    ed.guid = new Guid(rdr["Guid"].ToString()); 
	                    employees.Add(ed); 
	                } 
	            } 
	            catch (Exception ex) 
	            { 
	                throw new Exception(ex.ToString()); 
	            } 
	            finally 
                { 
	                cmd.Dispose(); 
	                conn.Close(); 
	            } 
	            return employees;             
	             
	        }

        public void GetEmployeesViewGuid(Guid guid)
	        { 
	            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mwd"].ConnectionString); 
	            SqlCommand cmd = new SqlCommand("spEmployeeDirectoryViewGuid", conn); 
	            cmd.CommandType = CommandType.StoredProcedure; 
	            SqlParameter parameterGuid = new SqlParameter("@Guid", SqlDbType.UniqueIdentifier, 37); 
	            parameterGuid.Value = guid; 
	            cmd.Parameters.Add(parameterGuid); 
	            try 
	            { 
	                conn.Open(); 
	                SqlDataReader rdr = cmd.ExecuteReader(); 
	                if(rdr.Read()) 
	                { 
	                    lname = rdr["LName"].ToString(); 
	                    fname = rdr["FName"].ToString(); 
	                    address = rdr["Address"].ToString(); 
	                    age = rdr["Age"].ToString(); 
	                    interests = rdr["Interests"].ToString(); 
	                    picture = rdr["Picture"].ToString(); 
	                } 
	            } 
	            catch (Exception ex) 
	            { 
	                throw new Exception(ex.ToString()); 
	            } 
	            finally 
	            { 
	                cmd.Dispose();
         	        conn.Close(); 
	            } 
	        } 
    }
}