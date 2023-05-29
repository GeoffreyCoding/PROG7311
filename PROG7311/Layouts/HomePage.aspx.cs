using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
    public partial class HomePage : Page
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnBackToLogin_Click(object sender, EventArgs e)
        {
            // Redirect to the login page or perform any desired action
            Response.Redirect("Login.aspx");
        }

    }
}