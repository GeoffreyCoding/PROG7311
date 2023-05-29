using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311.Layouts
{
    public partial class ViewFarmerProducts : System.Web.UI.Page
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate Farmers DDL
            List<string> farmerNames = _toolBox._DBHandler.getFarmerNames();
            farmerNames.Insert(0, "All"); // Add "All" at the beginning of the list
            ddlFarmers.Items.Clear(); // Clear existing items if needed
            foreach (string farmerName in farmerNames)
            {
                ddlFarmers.Items.Add(new ListItem(farmerName));
            }
            // Populate Type DDL
            List<string> farmerTypes = _toolBox._DBHandler.getProductType();
            farmerTypes.Insert(0, "All"); // Add "All" at the beginning of the list
            ddlProductType.Items.Clear(); // Clear existing items if needed
            foreach (string farmerType in farmerTypes)
            {
                ddlProductType.Items.Add(new ListItem(farmerType));
            }
            //populate table with all data with current Farmer
            DataTable allFarmersDataTable = _toolBox._DBHandler.getProductDataTable();
            gvProducts.DataSource = allFarmersDataTable;
            gvProducts.DataBind();

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            _toolBox.viewProductFiltercs.FarmerId = ddlFarmers.SelectedIndex;
            _toolBox.viewProductFiltercs.FilterProductType = ddlProductType.SelectedIndex.ToString();
            _toolBox.viewProductFiltercs.StartDate = Convert.ToDateTime(txtStartDate.Text);
            _toolBox.viewProductFiltercs.EndDate = Convert.ToDateTime(txtEndDate.Text);
            DataTable filteredProductsDataTable = _toolBox._viewFarmerProduct.filterProductTypes();
            if(filteredProductsDataTable.Rows.Count <= 0 || filteredProductsDataTable == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModalScript", "$('#errorModal').modal('show');", true);
            }
            else
            {
                gvProducts.DataSource = filteredProductsDataTable;
                gvProducts.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "successModalScript", "$('#successModal').modal('show');", true);
            }

        }
    }
}