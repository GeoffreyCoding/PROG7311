using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Xceed.Wpf.Toolkit;
/*Geoffrey Huth ST10081932 PROG7311 POE TASK 2*/
namespace PROG7311
{
    /// <summary>
    /// Add Farmer Page, the user will input the details. The details will be validated and then if correct then objects will be created
    /// the objects will be used to insert new entries into their respective tables
    /// </summary>
    public partial class About : Page
    {
        /// <summary>
        /// creating toolbox instance
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        //loades the page...
        protected void Page_Load(object sender, EventArgs e)
        {
            if(_toolBox._userDataStore.UserRole != "Employee")
            {
                Response.Redirect("Login.aspx");
            }
        }
        /// <summary>
        /// Add Farmer button which initiates the add farmer feature
        /// </summary>
        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            //holds farmer first name
            string userFirstName = txtFirstName.Text;
            string userSurname = txtSurname.Text;
            string userEmail = txtEmail.Text;
            string userLocation = txtLocation.Text;
            string userPhoneNumber = txtPhoneNumber.Text;
            string userPassword = txtPassword.Text;
            bool isValid = false;
            //sending data to addnew farmer method in the Add farmer class
            isValid = _toolBox._AddFarmer.addNewFarmer(userFirstName, userSurname, userEmail, userLocation, userPhoneNumber, userPassword);
            if (isValid == true)
            {
                //farmer added successfully
                ScriptManager.RegisterStartupScript(this, this.GetType(), "successModalScript", "$('#successModal').modal('show');", true);
            }
            else
            {
                //failed to add farmer
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModalScript", "$('#errorModal').modal('show');", true);
            }
        }
    }
}