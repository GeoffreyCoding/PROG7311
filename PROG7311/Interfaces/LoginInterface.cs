using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PROG7311.Interfaces
{
    internal interface LoginInterface
    {
        void logInUser(Label lblInvalidEmail, Label lblInvalidPassword);
    }
}
