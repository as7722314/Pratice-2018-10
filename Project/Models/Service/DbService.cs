﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.Service
{
    public class DbService
    {
        public string GetConnStr()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Dbconnect"].ConnectionString;
        }
    }
}