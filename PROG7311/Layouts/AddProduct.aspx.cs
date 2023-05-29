using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Layouts
{
    /// <summary>
    /// Add product page which allows a logged in farmer to add a product to his profile
    /// </summary>
    public partial class AddProduct : System.Web.UI.Page
    {
        /// <summary>
        /// creating toolbox instance
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        //loads pages
        protected void Page_Load(object sender, EventArgs e)
        {
            //checking if the user has logged in
            if (_toolBox._userDataStore.UserRole != "Farmer")
            {
                //redirecting user
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            string userEmail = _toolBox._userDataStore.UserEmail;
            //looking for a matching type string to ensure uniqueness of type
            isValid = _toolBox._DBHandler.isProductType(txtProductType.Text,userEmail);
            if(isValid == false)
            {
                //assigning variables to Product Object 
                _toolBox._Product.ProductName = txtProductName.Text;
                _toolBox._Product.ProductType = txtProductType.Text;
                _toolBox._Product.ProductQty = Convert.ToInt32(txtProductQty.Text);
                _toolBox._Product.ProductDateAdded = System.DateTime.Now;
                isValid = _toolBox._AddProduct.saveProductData();
                if(isValid == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideModalScript", "$('#errorModal').modal('hide');", true);
                    //success
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "successModalScript", "$('#successModal').modal('show');", true);
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "hideModalScript2", "$('serrorModal').modal('hide');", true);
            //failed
            ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModalScript", "$('#errorModal').modal('show');", true);
        }
    }
}