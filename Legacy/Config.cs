using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Legacy
{
    public static class Config
    {
        public static string ConnectionString {
            get
            {
                return ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
        }
    }
}