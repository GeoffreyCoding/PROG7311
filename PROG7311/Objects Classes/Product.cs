using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Objects_Classes
{
    public class Product
    {
        /// <summary>
        /// saves farmer instance to implement singleton class
        /// </summary>
        private static Product instance;
        /// <summary>
        /// Stores entity object for employee
        /// </summary>
        public Product FarmersEntity;
        /// <summary>
        /// Constructor
        /// </summary>
        public static Product Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Product();
                }
                return instance;
            }
        }

        private string productName;
        private string productType;
        private int productQty;
        private DateTime productDateAdded;
        private int productTypeId;
        private int productId;

        public string ProductName { get => productName; set => productName = value; }
        public string ProductType { get => productType; set => productType = value; }
        public int ProductQty { get => productQty; set => productQty = value; }
        public DateTime ProductDateAdded { get => productDateAdded; set => productDateAdded = value; }
        public int ProductTypeId { get => productTypeId; set => productTypeId = value; }
        public int ProductId { get => productId; set => productId = value; }

    }
}