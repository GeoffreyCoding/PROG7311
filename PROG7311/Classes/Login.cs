using Microsoft.Ajax.Utilities;
using PROG7311.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Classes
{
    /// <summary>
    /// Login Class which controls the backend of the login layout
    /// </summary>
    public class Login:LoginInterface
    {
        /// <summary>
        /// creates instance for toolbox
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        /// <summary>
        /// hashes the users plaintext password and then looks for a matching password in the database
        /// </summary>
        public bool logInUser()
        {
            string userEmail = _toolBox._userDataStore.UserEmail;
            string userPassword = _toolBox._userDataStore.UserPassword;
            //variable holding the hashed version of the entered password
            string hashedInput = "";
            bool validPwd = false;
            //searching for the salt key of the corresponding user 
            string salt = _toolBox._DBHandler.getSaltKeyByEmail(userEmail);
            if(salt != "error" && salt != null)
            {
                bool isValid = false;
                //generating the hashed password based off of the above salt key and the entered password
                hashedInput = _toolBox._pwdHashing.pwdHashWithSalt(salt, userPassword);
                _toolBox._userDataStore.UserPassword = hashedInput;
                //looking for a matching password credential
                validPwd = _toolBox._DBHandler.searchForMatchingPassword(hashedInput);
                if(validPwd != true)
                {
                    return false;
                }
                //validate userEmail
                isValid = _toolBox._DBHandler.isEmployee(userEmail);
                //setting the users role
                if(isValid == true)
                {
                    _toolBox._userDataStore.UserRole = "Employee";
                }
                else
                {
                    _toolBox._userDataStore.UserRole = "Farmer";
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------