using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
//Geoffrey Huth ST10081932 PROG7311 POE TASK 2
namespace PROG7311.Classes
{
    public class pwdHashing
    {
        /// <summary>
        /// generates a hashed password based off of the users input.The salt used was taken from the database
        /// </summary>
       public string pwdHashWithSalt(string salt,string userUnhashedPwd)
        {
            string hashedPwd = "";
            //converting salt
            byte[] convertedSalt = Convert.FromBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            hashedPwd = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userUnhashedPwd,
                salt: convertedSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPwd;
        }
        /// <summary>
        /// Creating a new salt key and hashed password for Add Farmer 
        /// </summary>
        public string[] pwdHashingWithoutSalt(string userPassword)
        {
            //creating new salt
            byte[] salt = new byte[128 / 8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(salt);
            }
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

           string[] pwdAndSaltKey = {hashed,Convert.ToBase64String(salt)};

            return pwdAndSaltKey;
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------