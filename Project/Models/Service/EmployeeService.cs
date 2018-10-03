using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models.Service
{
    public class EmployeeService
    {
        public List<SelectListItem> GetName()
        {            
            //List<SelectListItem> employeesname = new List<SelectListItem>();

            DbService dbservice = new DbService();
            String connStr = dbservice.GetConnStr();            
            SqlConnection conn = new SqlConnection(connStr);
            String sql = @"Select EmployeeID,LastName+FirstName Name from HR.Employees";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dataTable = ds.Tables[0];

            List<SelectListItem> employeesname = new List<SelectListItem>();

            foreach(DataRow row in dataTable.Rows)
            {
                employeesname.Add(new SelectListItem
                {
                    Value = row["EmployeeID"].ToString(),
                    Text = row["Name"].ToString()
                });
            }            
            

            return employeesname;
        }


    }
}