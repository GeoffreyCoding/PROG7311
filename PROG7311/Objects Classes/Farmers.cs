using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Objects_Classes
{
    public class Farmers
    {
        /// <summary>
        /// saves farmer instance to implement singleton class
        /// </summary>
        private static Farmers instance;
        /// <summary>
        /// Stores entity object for employee
        /// </summary>
        public Farmers FarmersEntity;
        /// <summary>
        /// Ensures only 1 instance is being used
        /// </summary>
        public static Farmers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Farmers();
                }
                return instance;
            }
        }

        public int FarmerId { get => farmerId; set => farmerId = value; }

        private int farmerId;
        
    }
}