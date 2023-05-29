using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROG7311.Objects_Classes
{
    public class viewProductFiltercs
    {
        private static viewProductFiltercs instance;

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
        public int FarmerId { get => farmerId; set => farmerId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        private string filterProductType;
        private int farmerId;
        private DateTime startDate;
        private DateTime endDate;
    }
}