using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models.Service
{
    public class ShipperService
    {
        public List<SelectListItem> GetShipper()
        {
            DbService dbservice = new DbService();
            String connStr = dbservice.GetConnStr();
            SqlConnection conn = new SqlConnection(connStr);
            String sql = @"Select * from Sales.Shippers";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dataTable = ds.Tables[0];

            List<SelectListItem> shippersname = new List<SelectListItem>();

            foreach (DataRow row in dataTable.Rows)
            {
                shippersname.Add(new SelectListItem
                {
                    Value = row["ShipperID"].ToString(),
                    Text = row["CompanyName"].ToString()
                });
            }

            return shippersname;
        }
    }
}