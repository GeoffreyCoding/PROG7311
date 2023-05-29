using PROG7311.Classes;
using PROG7311.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311
{
    /// <summary>
    /// This page is the login page which gets the users inputs email and password, it then validates it and looks
    /// for matches in the database
    /// </summary>
    public partial class _Default : Page
    {
        protected HtmlGenericControl invalidCredentialsDiv;
        /// <summary>
        /// create the instance of the toolbox
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox,parameters);
        private toolBox _toolBox = obj as toolBox;
        /// <summary>
        /// loads all the GUI of the application
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["status"] == "signout")
            {
                _toolBox._userDataStore.UserRole = "";
                _toolBox._Farmers.FarmerId = -1; ;
            }
        }
        /// <summary>
        /// btnLogin onclick event
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //stores user email
            string userEmail = txtEmail.Text;
            //The users inputted plain text password
            string userPassword = txtPassword.Text;
            bool validLogin = false;
            //storing data into userDataStore for later use in Login.cs class
            _toolBox._userDataStore.UserEmail = userEmail;
            _toolBox._userDataStore.UserPassword = userPassword;
            validLogin = _toolBox._Login.logInUser();
            //redirects users to the home page once all credentials are validated
            if (validLogin)
            {
                invalidCredentialsDiv = (HtmlGenericControl)FindControl("invalidCredentials");
                invalidCredentials.Style["display"] = "none"; // Hide the element if the login is valid
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                invalidCredentialsDiv = (HtmlGenericControl)FindControl("invalidCredentials");
                invalidCredentials.Style["display"] = "block"; // Show the element if the login is invalid
            }
        }
            
    }        
}
//--------------------------------------------------------------END-OF-FILE---------------------------------------------------