using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROG7311.Objects_Classes
{
    public class Employees
    {
        private static Employees instance;
        
        public static Employees Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Employees();
                }
                return instance;
            }
        }
        
    }
}