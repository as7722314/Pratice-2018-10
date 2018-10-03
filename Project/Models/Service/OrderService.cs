using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.Models.Service
{
    public class OrderService
    {
        /*
        private string GetConnStr()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Dbconnect"].ConnectionString;
        }
        */
        public List<Index> GetOrders()
        {
            
            DbService dbservice = new DbService();
            String connStr = dbservice.GetConnStr();                
            SqlConnection conn = new SqlConnection(connStr);
            String sql = @"Select a.OrderID,b.CompanyName,a.OrderDate,a.ShippedDate from Sales.Orders a join Sales.Customers b on a.CustomerID = b.CustomerID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dataTable = ds.Tables[0];
            List<Index> data = new List<Index>();
            
            foreach(DataRow i in dataTable.Rows)
            {
                data.Add(new Index()
                {
                    OrderID = Convert.ToInt32(i["OrderID"]),
                    CompanyName = Convert.ToString(i["CompanyName"]),
                    OrderDate = Convert.ToDateTime(i["OrderDate"]),                    
                    ShippedDate = (!String.IsNullOrWhiteSpace(i["ShippedDate"].ToString())) ? new DateTime?(Convert.ToDateTime(i["ShippedDate"])) : null
                });
            }
            
            return data;
        }
    }
}