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
        public List<Index> GetOrders(Index arg)
        {
            
            DbService dbservice = new DbService();
            String connStr = dbservice.GetConnStr();                
            SqlConnection conn = new SqlConnection(connStr);
            String sql = @"Select a.OrderID,b.CompanyName,a.OrderDate,a.ShippedDate from Sales.Orders a join Sales.Customers b on a.CustomerID = b.CustomerID Where ";
            if (arg.OrderID.HasValue)
            {
                sql += "OrderID = @OrderID";
            }
            else
            {
                sql += "OrderID like @OrderID";
            }
            if (!String.IsNullOrEmpty(arg.CompanyName))
            {
                sql += " and CompanyName = @CompanyName";
            }
            if (arg.EmployeeID.HasValue)
            {
                sql += " and EmployeeID = @EmployeeID";
            }
            if (arg.ShipperID.HasValue)
            {
                sql += " and ShipperID = @ShipperID";
            }
            if (arg.OrderDate.HasValue)
            {
                sql += " and OrderDate = @OrderDate";
            }
            if (arg.ShippedDate.HasValue)
            {
                sql += " and ShippedDate = @ShippedDate";
            }

            SqlCommand command = new SqlCommand(sql, conn);

            if (arg.OrderID.HasValue)
            {
                command.Parameters.Add(new SqlParameter("@OrderID", arg.OrderID));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@OrderID","%"));
            }
            if (!String.IsNullOrEmpty(arg.CompanyName))
            {
                command.Parameters.Add(new SqlParameter("@CompanyName", arg.CompanyName));
            }
            if (arg.EmployeeID.HasValue)
            {
                command.Parameters.Add(new SqlParameter("@EmployeeID", arg.EmployeeID));
            }
            if (arg.ShipperID.HasValue)
            {
                command.Parameters.Add(new SqlParameter("@ShipperID", arg.ShipperID));
            }
            if (arg.OrderDate.HasValue)
            {
                command.Parameters.Add(new SqlParameter("@OrderDate", arg.OrderDate));
            }
            if (arg.ShippedDate.HasValue)
            {
                command.Parameters.Add(new SqlParameter("@ShippedDate", arg.ShippedDate));
            }       

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
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

        public String InserOrder(Orders orders)
        {
            var mess = "";
            DbService dbservice = new DbService();
            String connStr = dbservice.GetConnStr();
            SqlConnection conn = new SqlConnection(connStr);
            String sql = @"Insert into [Sales].[Orders]
                          ([CustomerID]
                          ,[EmployeeID]
                          ,[OrderDate]
                          ,[RequiredDate]
                          ,[ShippedDate]
                          ,[ShipperID]
                          ,[Freight]
                          ,[ShipName]
                          ,[ShipAddress]
                          ,[ShipCity]
                          ,[ShipRegion]
                          ,[ShipPostalCode]
                          ,[ShipCountry])
                          VALUES
                          (@CustomerID
                          ,@EmployeeID
                          ,@OrderDate
                          ,@RequiredDate
                          ,@ShippedDate
                          ,@ShipperID
                          ,@Freight
                          ,@ShipName
                          ,@ShipAddress
                          ,@ShipCity
                          ,@ShipRegion
                          ,@ShipPostalCode
                          ,@ShipCountry)";         //新增訂單

            SqlCommand command = new SqlCommand(sql,conn);
            command.Parameters.Add(new SqlParameter("@CustomerID", orders.CustomerID));
            command.Parameters.Add(new SqlParameter("@EmployeeID", orders.EmployeeID));
            command.Parameters.Add(new SqlParameter("@OrderDate", orders.OrderDate));
            command.Parameters.Add(new SqlParameter("@RequiredDate", orders.RequiredDate));
            command.Parameters.Add(new SqlParameter("@ShippedDate", orders.ShippedDate));
            command.Parameters.Add(new SqlParameter("@ShipperID", orders.ShipperID));
            command.Parameters.Add(new SqlParameter("@Freight", orders.Freight));
            command.Parameters.Add(new SqlParameter("@ShipName", orders.ShipName));
            command.Parameters.Add(new SqlParameter("@ShipAddress", orders.ShipAddress));
            command.Parameters.Add(new SqlParameter("@ShipCity", orders.ShipCity));
            command.Parameters.Add(new SqlParameter("@ShipRegion", orders.ShipRegion));
            command.Parameters.Add(new SqlParameter("@ShipPostalCode", orders.ShipPostalCode));
            command.Parameters.Add(new SqlParameter("@ShipCountry", orders.ShipCountry));
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                mess = "新增成功";
            }
            catch(Exception)
            {
                transaction.Rollback();
                mess = "新增失敗";
                throw;                
            }
            finally
            {
                conn.Close();
            }

            //int neworderid = Convert.ToInt32(command.ExecuteScalar());
            return mess;

        }
    }
}