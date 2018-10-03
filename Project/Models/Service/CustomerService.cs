using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models.Service
{
    public class CustomerService
    {
        public List<SelectListItem> GetCustomer()
        {
            List<SelectListItem> customername = new List<SelectListItem>();
            customername.Add(new SelectListItem{
                Value = "1",
                Text = "Kobe"
            });
            customername.Add(new SelectListItem
            {
                Value = "2",
                Text = "James"
            });
            return customername;
        }
    }
}