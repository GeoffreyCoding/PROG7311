using Microsoft.Ajax.Utilities;
using PROG7311.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PROG7311.Classes
{
    public class Login:LoginInterface
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        /// <summary>
        /// hashes the users plaintext password and then looks for a matching password in the database
        /// </summary>
        public void logInUser(Label lblInvalidEmail,Label lblInvalidPassword)
        {
            string userEmail = _toolBox._userDataStore.UserEmail;
            string userPassword = _toolBox._userDataStore.UserPassword;
            //variable holding the hashed version of the entered password
            string hashedInput = "";
            bool validPwd = false;
            //searching for the salt key of the corresponding user 
            string salt = _toolBox._DBHandler.getSaltKeyByEmail(userEmail);
            if(salt != "error")
            {
                bool isValid = false;
                //generating the hashed password based off of the above salt key and the entered password
                hashedInput = _toolBox._pwdHashing.pwdHashWithSalt(salt, userPassword);
                _toolBox._userDataStore.UserPassword = hashedInput;
                //looking for a matching password credential
                validPwd = _toolBox._DBHandler.searchForMatchingPassword(hashedInput);
                //validate userEmail
                isValid = _toolBox._DBHandler.isFarmer(userEmail);
                if(isValid == true)
                {
                    _toolBox._userDataStore.UserRole = "Employee";
                }
                else
                {
                    _toolBox._userDataStore.UserRole = "Farmer";
                }
            }
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------