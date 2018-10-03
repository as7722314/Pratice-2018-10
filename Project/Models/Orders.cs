using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Orders
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [DisplayName("訂單編號")]
        public int OrderID { get; set; }
        /// <summary>
        /// 顧客名稱
        /// </summary>
        [DisplayName("顧客名稱")]
        public int CustomerID { get; set; }
        /// <summary>
        /// 負責員工
        /// </summary>
        [DisplayName("負責員工")]
        public int EmployeeID { get; set; }
        /// <summary>
        /// 訂單日期
        /// </summary>
        [DisplayName("訂單日期")]
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 需要日期
        /// </summary>
        [DisplayName("需要日期")]
        public DateTime RequiredDate { get; set; }
        /// <summary>
        /// 出貨日期
        /// </summary>
        [DisplayName("出貨日期")]
        public DateTime ShippedDate { get; set; }
        /// <summary>
        /// 出貨公司
        /// </summary>
        [DisplayName("出貨公司")]
        public int ShipperID { get; set; }
        /// <summary>
        /// 運費
        /// </summary>
        [DisplayName("運費")]
        public Decimal Freight { get; set; }
        /// <summary>
        /// 出貨地址
        /// </summary>
        [DisplayName("出貨地址")]
        public String ShipAddress { get; set; }
        /// <summary>
        /// 出貨地區
        /// </summary>
        [DisplayName("出貨地區")]
        public String ShipCity { get; set; }
        /// <summary>
        /// 出貨國家
        /// </summary>
        [DisplayName("出貨國家")]
        public String ShipRegion { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        [DisplayName("郵遞區號")]
        public String ShipPostalCode { get; set; }
        /// <summary>
        /// 出貨城市
        /// </summary>
        [DisplayName("出貨城市")]
        public String ShipCountry { get; set; }

        
    }
}