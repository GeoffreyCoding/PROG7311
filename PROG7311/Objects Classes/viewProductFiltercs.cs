using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Objects_Classes
{
    /// <summary>
    /// object to store the filters of the viewFarmerProduct page
    /// </summary>
    public class viewProductFiltercs
    {
        //stores the instance of the object
        private static viewProductFiltercs instance;
        //ensures that only 1 instance is being used
        public static viewProductFiltercs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new viewProductFiltercs();
                }
                return instance;
            }
        }

        public string FilterProductType { get => filterProductType; set => filterProductType = value; }
        public string FarmerName { get => farmerName; set => farmerName = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public bool EnableStartDate { get => enableStartDate; set => enableStartDate = value; }
        public bool EnableEndDate { get => enableEndDate; set => enableEndDate = value; }
        public bool EnableType { get => enableType; set => enableType = value; }
        public bool EnableName { get => enableName; set => enableName = value; }

        private string filterProductType;
        private string farmerName;
        private string startDate;
        private string endDate;
        private bool enableStartDate;
        private bool enableEndDate;
        private bool enableType;
        private bool enableName;
    }
}