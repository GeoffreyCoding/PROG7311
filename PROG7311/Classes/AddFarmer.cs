using Microsoft.Ajax.Utilities;
using PROG7311.Interfaces;
using PROG7311.Objects_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.WebControls;

namespace PROG7311.Classes
{
    public class AddFarmer:AddFarmerInterface
    {
        /// <summary>
        /// Creates instance for toolbox 
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        /// <summary>
        /// assigns all the data to the Farmer object and then loads the addNew Farmer method
        /// </summary>
        public bool addNewFarmer(string fName,string userSurname,string userEmail,string userLocation,string userPhoneNumber ,string password)
        {
            try 
            {
                bool isValid = false;
                //validate userEmail to ensure it is unique
                isValid = _toolBox._DBHandler.isFarmer(userEmail);
                if (isValid == true)
                {
                    //sets email error popup to visible
                    return false;
                }
                else
                {
                    //sets email error popup to invisible
                    //hash password and returning hasehd password and the salt key
                    string[] hashingResults = _toolBox._pwdHashing.pwdHashingWithoutSalt(password);
                    _toolBox._userDataStore.UserPassword = hashingResults[0];
                    _toolBox._userDataStore.UserSalt = hashingResults[1];
                    _toolBox._userDataStore.UserEmail = userEmail;
                    //creating password object
                    isValid = createPasswordObject();
                    //saving data to Farmer object
                    Farmer farmer = new Farmer();
                    farmer.fName = fName;
                    farmer.sName = userSurname;
                    farmer.fEmail = userEmail;
                    farmer.fLocation = userLocation;
                    farmer.fPhoneNumber = userPhoneNumber;
                    farmer.fPasswordId = _toolBox._userDataStore.PasswordID;
                    //save new password , password id to user datastore
                    isValid = _toolBox._DBHandler.addFarmerToDB1Entity(farmer);
                    //creating productlist entity
                    if (isValid != false)
                    {
                        //displays a modal style dialogue box that the user will see notifying them that there was a problem when addinding
                        //the object to the database. QUESTION: What information is relevant to the user vs a developer in terms of crashes?
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        /// <summary>
        /// creates the object for password
        /// </summary>
        public bool createPasswordObject()
        {
            int passwordId = -1;
            //Creating password object
            Password password = new Password();
            password.HashedPassword = _toolBox._userDataStore.UserPassword;
            password.Salt = _toolBox._userDataStore.UserSalt;   
            password.Email = _toolBox._userDataStore.UserEmail;
            //saving user password credentials to password entity
            passwordId = _toolBox._DBHandler.saveFarmerPassword(password);
            _toolBox._userDataStore.PasswordID = passwordId;
            if(passwordId == -1)
            {
                return false;
            }
            return true;
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------