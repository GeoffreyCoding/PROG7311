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
            DataTable filteredDataTable = new DataTable();
            try
            {
                string sqlCmd = "";
                string farmerName = _toolBox.viewProductFiltercs.FarmerName;
                string farmerType = _toolBox.viewProductFiltercs.FilterProductType;
                string startDate = _toolBox.viewProductFiltercs.StartDate;
                string endDate = _toolBox.viewProductFiltercs.EndDate;
                bool filterName = _toolBox.viewProductFiltercs.EnableName;
                bool filterType = _toolBox.viewProductFiltercs.EnableType;
                bool filterStartDate = _toolBox.viewProductFiltercs.EnableStartDate;
                bool filterEndDate = _toolBox.viewProductFiltercs.EnableEndDate;
                //checking if all options were selected
                sqlCmd = sqlSelector(farmerType,farmerName,startDate,endDate,filterType,filterName,filterStartDate,filterEndDate);
                filteredDataTable = _toolBox._DBHandler.filterProductData(sqlCmd);
                return filteredDataTable;
            }
            catch(Exception ex)
            {
                return filteredDataTable;
            }
            
        }

        public string sqlSelector(string filterType,string filterFarmerName, string filterStartDate, string filterEndDate,bool typeFilter,bool nameFilter,bool startFilter,bool endFilter)
        {
            string sqlCmd = "SELECT P.pType,P.pDateAdded,F.fName + ',' + F.sName As \"Fullname\",F.fLocation,F.fEmail,F.fPhoneNumber " +
                            "FROM Farmer F,ProductType P,ProductList PL " +
                            "WHERE (PL.farmerId = F.FarmerId) AND (PL.prodTypeId = P.pTypeId) ";
            if (nameFilter)
            {
                sqlCmd = sqlCmd + " AND (F.fName LIKE '%" + filterFarmerName + "%' OR F.sName LIKE '%" + filterFarmerName + "%')";
            }
            if (typeFilter)
            {
                sqlCmd = sqlCmd + " AND (P.pType LIKE '%" + filterType + "%')";
            }
            if (startFilter  && endFilter)
            {
                sqlCmd = sqlCmd + " AND P.pDateAdded >= '" + filterStartDate + "' AND P.pDateAdded <= '" + filterEndDate + "'";
            }
            return sqlCmd;

        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------