using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROG7311.Objects_Classes
{
    public class Passwords
    {
        /// <summary>
        /// implementing singleton design pattern
        /// </summary>
        private static Passwords instance;
        /// <summary>
        /// instantiating connection string from web.config
        /// </summary>
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        /// <summary>
        /// Stores entity object for employee
        /// </summary>
        public Passwords PasswordEntity;
        /// <summary>
        /// Stores entity objects
        /// </summary>
        private Database1Entities1 Entity;
        /// <summary>
        /// Constructor which ensures only 1 instance of password is instantiated
        /// </summary>
        public static Passwords Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Passwords();
                }
                return instance;
            }
        }
        
    }
}