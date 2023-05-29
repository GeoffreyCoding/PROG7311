using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PROG7311.Interfaces
{
    internal interface AddFarmerInterface
    {
        bool addNewFarmer(string fName, string userSurname, string userEmail, string userLocation, string userPhoneNumber,string password,Label lblInvalidEmail);
        bool createPasswordObject();
    }
}
