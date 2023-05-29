using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311.Layouts
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            //validate type here
            isValid = _toolBox._DBHandler.isProductType(txtProductType.Text);
            if(isValid == false)
            {
                validEmail.Visible = false;
                _toolBox._Product.ProductName = txtProductName.Text;
                _toolBox._Product.ProductType = txtProductType.Text;
                _toolBox._Product.ProductQty = Convert.ToInt32(txtProductQty.Text);
                _toolBox._Product.ProductDateAdded = System.DateTime.Now;
                isValid = _toolBox._AddProduct.saveProductData();
                if(isValid == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModalScript", "$('#errorModal').modal('show');", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "successModalScript", "$('#successModal').modal('show');", true);
            }
            validEmail.Visible = true;
        }
    }
}