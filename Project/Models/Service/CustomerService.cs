using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models.Service
{
    public class CustomerService
    {
        public List<SelectListItem> GetCustomer()
        {
            DbService dbservice = new DbService();
            String connStr = dbservice.GetConnStr();
            SqlConnection conn = new SqlConnection(connStr);
            String sql = @"select CustomerID,CompanyName from sales.Customers order by CustomerID ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dataTable = ds.Tables[0];

            List<SelectListItem> customername = new List<SelectListItem>();

            foreach (DataRow row in dataTable.Rows)
            {
                customername.Add(new SelectListItem
                {
                    Value = row["CustomerID"].ToString(),
                    Text = row["CompanyName"].ToString()
                });
            }
            return customername;
        }
    }
}