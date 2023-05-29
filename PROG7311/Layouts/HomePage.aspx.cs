using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311
{
    /// <summary>
    /// Homepage
    /// </summary>
    public partial class HomePage : Page
    {
        /// <summary>
        /// creates instance of toolbox
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks that the user has already signed in
            if (_toolBox._userDataStore.UserRole == null || _toolBox._userDataStore.UserRole == "")
            {
                //redirecting user if they have not signed in yet
                Response.Redirect("Login.aspx");
            }
        }

        protected void BtnBackToLogin_Click(object sender, EventArgs e)
        {
            // Redirect to the login page or perform any desired action
            Response.Redirect("Login.aspx");
        }

    }
}