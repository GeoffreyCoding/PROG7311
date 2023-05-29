using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PROG7311.Classes
{
    public class viewFarmerProduct
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        /// <summary>
        /// uses the filter data in the viewProductFilter object and then searches the database for 
        /// </summary>
        /// <returns></returns>
        public DataTable filterProductTypes()
        {
            int checkFarmerId = _toolBox.viewProductFiltercs.FarmerId;
            string checkFarmerType = _toolBox.viewProductFiltercs.FilterProductType;
            DateTime startDate = _toolBox.viewProductFiltercs.StartDate;
            DateTime endDate = _toolBox.viewProductFiltercs.EndDate;
            DataTable filteredDataTable = new DataTable();
            if (checkFarmerId == 0 && checkFarmerType == "All")
            {
                filteredDataTable = _toolBox._DBHandler.filterProductData(1,checkFarmerType,checkFarmerId.ToString(),startDate,endDate);
            }
            else if(checkFarmerId == 0)
            {
                filteredDataTable = _toolBox._DBHandler.filterProductData(2, checkFarmerType, checkFarmerId.ToString(), startDate, endDate);
            }else if(checkFarmerType == "All")
            {
                filteredDataTable = _toolBox._DBHandler.filterProductData(3, checkFarmerType, checkFarmerId.ToString(), startDate, endDate);
            }
            else
            {
                filteredDataTable = _toolBox._DBHandler.filterProductData(4,checkFarmerType,checkFarmerId.ToString(),startDate,endDate);
            }

            return filteredDataTable;
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------