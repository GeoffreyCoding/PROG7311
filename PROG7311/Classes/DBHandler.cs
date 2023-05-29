using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using PROG7311.Interfaces;
using PROG7311.Objects_Classes;
using System.Globalization;
using System.Data;
using System.Diagnostics;
//Geoffrey Huth ST10081932 POE TASK 2
namespace PROG7311.Classes
{
    /// <summary>
    /// DB Hander class. All interactions with the database entity using entity framework or directly with the database1 DB using sql
    /// is handled in this class
    /// </summary>
    public class DBHandler : IDBInterface
    {
        /// <summary>
        /// creating instance for toolbox
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        //CONNECTION STRING
        private string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        //SQL COMMAND STORE
        private SqlCommand _sqlCommand;
        //SQL CONNECTION STORE
        private SqlConnection _connection;
        //DATABASE ENTITY OBJECT
        private Database1Entities1 Entity;
        //creating database connection
        public void connectDB()
        {
            this._connection = new SqlConnection(ConnString);
            this._sqlCommand = new SqlCommand
            {
                Connection = this._connection,
                CommandType = CommandType.Text
            };
        }
        //checking if an email is in the database
        public bool isEmployee(string userEmail)
        {
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    //getting the first record or returning null of the matching record
                    var isFound = this.Entity.Employees.FirstOrDefault(p => p.empEmail == userEmail);
                    if (isFound != null)
                    {
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
        //checking wether an email is in the farmer table
        public bool isFarmer(string userEmail)
        {
            try
            {
                using (this.Entity = new Database1Entities1())
                {

                    //getting the first record or returning null of the matching record
                    var isFound = this.Entity.Farmers.FirstOrDefault(p => p.fEmail == userEmail);
                    if (isFound != null)
                    {
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
        /// Checking if the product type already exists
        /// </summary>
        public bool isProductType(string productType,string userEmail)
        {
            this.connectDB();
            bool isFound = false;

            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = this._connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT P.pType FROM ProductType P,Farmer F,ProductList PL " +
                                  "WHERE (PL.farmerId = F.FarmerId) AND (PL.prodTypeId = P.pTypeId) " +
                                  "AND (P.pType LIKE '%" + productType + "%') " +
                                  "AND (F.fEmail LIKE '%" + userEmail + "%') "
                };

                using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    var dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        return true; // Result found
                    }
                    else
                    {
                        return false; // No result found
                    }
                }


                return false;
            }
            catch (Exception ex)
            {
                // Handle the exception
                return false;
            }
        }
        /// <summary>
        /// adding the farmers password to the database and then returning the new passwords, passwordId
        /// </summary>
        public int saveFarmerPassword(Password password)
        {
            try
            {
                int newEntryPasswordID = -1;
                using (var context = new Database1Entities1())
                {
                    context.Passwords.Add(password);
                    context.SaveChanges();
                    newEntryPasswordID = context.Passwords.FirstOrDefault(p => p.HashedPassword == password.HashedPassword).PasswordID;
                }
                return newEntryPasswordID;
            }
            catch (Exception ex) { return -1; }

        }
        /// <summary>
        /// Adding farmer object to the database entity
        /// </summary>
        public bool addFarmerToDB1Entity(Farmer farmer)
        {
            try
            {
                using (var context = new Database1Entities1())
                {
                    //adding object
                    context.Farmers.Add(farmer);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// adding the product type object to the database entity and returning the new records primary key (pTypeId).
        /// </summary>
        public int addProductTypeToDB1Entity(ProductType productType)
        {
            try
            {
                int newTypeId = -1;
                using (var context = new Database1Entities1())
                {
                    context.ProductTypes.Add(productType);
                    context.SaveChanges();
                    //LinQ
                    newTypeId = context.ProductTypes.FirstOrDefault(p => p.pType == productType.pType).pTypeId;
                    return newTypeId;
                }
            }
            catch (Exception ex)
            { return -1; }
        }

        public bool addProductAndFarmerLinkToProductList(ProductList productList)
        {
            try
            {
                using (var context = new Database1Entities1())
                {
                    context.ProductLists.Add(productList);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            { return false; }
        }
        public bool addProductDataToDB1Entity(ProductStore productStore)
        {
            try
            {
                using (var context = new Database1Entities1())
                {
                    //LinQ
                    context.ProductStores.Add(productStore);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            { return false; }
        }

        /// <summary>
        /// gets the salt key of the user by using their password ID
        /// </summary>
        public string getSaltKeyByEmail(string userEmail)
        {
            try
            {
                string userSaltKey = "";
                using (this.Entity = new Database1Entities1())
                {
                    userSaltKey = this.Entity.Passwords.FirstOrDefault(p => p.Email == userEmail)?.Salt;
                    return userSaltKey;
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
        /// <summary>
        /// using the hashed password it looks for a matching hashed password in the database
        /// </summary>
        public bool searchForMatchingPassword(string hashedPassword)
        {
            try
            {

                using (this.Entity = new Database1Entities1())
                {
                    var foundHashedPassword = this.Entity.Passwords.SingleOrDefault(p => p.HashedPassword == hashedPassword);
                    if (foundHashedPassword != null)
                    {
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
        /// getting all the product and the respective farmer data without any of the filter options. Only used when page loads
        /// </summary>
        /// <returns></returns>
        public DataTable getProductDataTable()
        {
            this.connectDB();
            DataTable productDataTable = new DataTable();

            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = this._connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT  Farmer.fName + ',' + Farmer.sName AS Fullname,ProductType.pType,ProductType.pDateAdded,Farmer.fLocation,Farmer.fEmail,Farmer.fPhoneNumber " +
                                  "From ProductType,ProductList,Farmer " +
                                  "where Farmer.FarmerId = ProductList.farmerId " +
                                  "AND ProductList.prodTypeId = ProductType.pTypeId"
                };

                using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlDataAdapter.Fill(productDataTable);
                }

                return productDataTable;
            }
            catch (Exception ex)
            {
                // Handle the exception
                return productDataTable;
            }
        }
        /// <summary>
        /// Getting the farmers ID by using their name in a LinQ 
        /// </summary>
        public int getFarmerIdByName(string userFirstName)
        {
            int userId = -1;
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    userId = this.Entity.Farmers.FirstOrDefault(p => p.fName == userFirstName).FarmerId;
                    if (userId != null)
                    {
                        return userId;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            { return -1; }
        }
        public int getFarmerId(string userEmail)
        {
            int userId = -1;
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    userId = this.Entity.Farmers.FirstOrDefault(p => p.fEmail == userEmail).FarmerId;
                    if (userId != null)
                    {
                        return userId;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            { return -1; }

        }
        public int getTypeId(string productType)
        {
            int typeId = -1;
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    typeId = this.Entity.ProductTypes.FirstOrDefault(p => p.pType == productType).pTypeId;
                    if (typeId != null)
                    {
                        return typeId;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            { return -1; }
        }

        public DataTable filterProductData(string sqlCmd)
        {
            this.connectDB();
            DataTable FilteredProductDataTable = new DataTable();
            try
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = this._connection,
                    CommandType = CommandType.Text,
                    CommandText = sqlCmd
                };

                using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlDataAdapter.Fill(FilteredProductDataTable);
                }

                return FilteredProductDataTable;
            }
            catch (Exception ex)
            {
                return FilteredProductDataTable;
            }
        }
        public int getFarmerIdViaEmail(string userEmail)
        {
            int farmerId = -1;
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    farmerId = this.Entity.Farmers.FirstOrDefault(p => p.fEmail == userEmail).FarmerId;
                    if (farmerId != null)
                    {
                        return farmerId;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            { return -1; }

        }

    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------