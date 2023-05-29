using PROG7311.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROG7311.Objects_Classes
{
    
    public class userDataStore
    {
        private string userRole;
        private string userEmail;
        private string userSalt;
        private string userPassword;
        private int passwordID;
        private static userDataStore instance;
        public string UserRole { get => userRole; set => userRole = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserSalt { get => userSalt; set => userSalt = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public int PasswordID { get => passwordID; set => passwordID = value; }

        public static userDataStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new userDataStore();
                }
                return instance;
            }
        }

          }
}