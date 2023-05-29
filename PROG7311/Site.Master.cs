using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG7311
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// sends the user back to the login.aspx layout. Alongside this a status is sent packaged with the redirect 
        /// the status will tell login that the user is signing out so all object data should be wiped.
        /// </summary>
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            // Perform any necessary sign-out logic
            // Redirect the user back to the login page with a value
            Response.Redirect("Login.aspx?status=signout");
        }
    }
}