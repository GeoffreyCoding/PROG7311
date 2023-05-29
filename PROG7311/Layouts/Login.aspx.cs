using PROG7311.Classes;
using PROG7311.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
    public partial class _Default : Page
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox,parameters);
        private toolBox _toolBox = obj as toolBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["status"] == "signout")
            {
                _toolBox._userDataStore.UserRole = "";
                _toolBox._Farmers.FarmerId = -1; ;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmail.Text;
            //The users inputted plain text password
            string userPassword = txtPassword.Text;
            //storing data into userDataStore for later use in Login.cs class
            _toolBox._userDataStore.UserEmail = userEmail;
            _toolBox._userDataStore.UserPassword = userPassword;
            _toolBox._Login.logInUser(lblInvalidEmail,lblInvalidPassword);
            if(_toolBox._userDataStore.UserPassword != "" && _toolBox._userDataStore.UserPassword != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
            
    }        
}