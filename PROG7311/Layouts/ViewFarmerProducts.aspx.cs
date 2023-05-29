using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Geoffrey Huth ST10081932 PROG7311 POE TASK 2
namespace PROG7311.Layouts
{
    /// <summary>
    /// View farmer products page
    /// </summary>
    public partial class ViewFarmerProducts : System.Web.UI.Page
    {
        /// <summary>
        /// creating toolbox instance
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        /// <summary>
        /// loading the page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //checking if the user is logged in
            if (_toolBox._userDataStore.UserRole != "Employee")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //if the user is logged in then it will load the table
                putDataInGridView();

            }
        }
        /// <summary>
        /// Filters all the data
        /// </summary>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //checking if the farmer textbox is empty or not
            _toolBox.viewProductFiltercs.EnableName = string.IsNullOrWhiteSpace(txtFarmers.Text) ? false : true;
            //assigning the value of the farmer name to the farmername object attribute
            _toolBox.viewProductFiltercs.FarmerName = txtFarmers.Text;
            //checking if the product type textbox is empty or not
            _toolBox.viewProductFiltercs.EnableType = string.IsNullOrWhiteSpace(txtProductType.Text) ? false : true;
            _toolBox.viewProductFiltercs.FilterProductType = txtProductType.Text;

            DateTime startDate;
            //formatting the date into an SQL friendly format... yyyy/MM/dd... So that it matches the database
            if (DateTime.TryParse(txtStartDate.Text,out startDate))
            {
                _toolBox.viewProductFiltercs.StartDate = startDate.ToString("yyyy/MM/dd");
                _toolBox.viewProductFiltercs.EnableStartDate = true;
            }
            else
            {
                _toolBox.viewProductFiltercs.EnableStartDate = false;
            }

            DateTime endDate;
            //formatting the date so that it matches the db
            if (DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                _toolBox.viewProductFiltercs.EndDate = endDate.ToString("yyyy/MM/dd");
                _toolBox.viewProductFiltercs.EnableEndDate = true;
            }
            else
            {
                _toolBox.viewProductFiltercs.EnableEndDate = false;
            }
            //filtering the product types and getting all the data into a data table
            DataTable filteredProductsDataTable = _toolBox._viewFarmerProduct.filterProductTypes();
            if(filteredProductsDataTable == null)
            {
                //not found
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModalScript", "$('#errorModal').modal('show');", true);
            }
            else
            {
                //found
                gvProducts.DataSource = filteredProductsDataTable;
                gvProducts.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "successModalScript", "$('#successModal').modal('show');", true);
            }
        }
        /// <summary>
        /// putting the data in the grid view
        /// </summary>
        protected void putDataInGridView()
        {

            // Populate table with all data for the current Farmer
            DataTable allFarmersDataTable = _toolBox._DBHandler.getProductDataTable();
            gvProducts.DataSource = allFarmersDataTable;
            gvProducts.DataBind();
        }
        /// <summary>
        /// default search with no filters
        /// </summary>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            putDataInGridView();
        }
    }
}
//-----------------------------------------------------------------END-OF-FILE----------------------------------------------------