using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Wpf.Toolkit;

namespace PROG7311
{
    public partial class About : Page
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Add Farmer button
        /// </summary>
        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            //holds farmer first name
            string fName = txtFirstName.Text;
            string userSurname = txtSurname.Text;
            string userEmail = txtEmail.Text;
            string userLocation = txtLocation.Text;
            string userPhoneNumber = txtPhoneNumber.Text;
            string userPassword = txtPassword.Text;
            bool isValid = false;
            //validate userEmail
            invalidEmail.Visible = false;
            isValid = _toolBox._AddFarmer.addNewFarmer(fName, userSurname, userEmail, userLocation, userPhoneNumber, userPassword, lblInvalidEmail);
            if (isValid == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModalScript", "$('#errorModal').modal('show');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "successModalScript", "$('#successModal').modal('show');", true);
            }
        }
    }
}