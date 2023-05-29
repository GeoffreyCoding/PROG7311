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

namespace PROG7311.Classes
{
    public  class DBHandler : DBInterface
    {
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;

        private string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private SqlCommand _sqlCommand;
        private SqlConnection _connection;
        private Database1Entities1 Entity;
        public void connectDB()
        {
            this._connection = new SqlConnection(ConnString);
            this._sqlCommand = new SqlCommand
            {
                Connection = this._connection,
                CommandType = CommandType.Text
            };
        }

        public bool isEmployee(string userEmail)
        {
            try
            {
                using (this.Entity = new Database1Entities1())
                {
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

        public bool isFarmer(string userEmail)
        {
            try
            {
                using (this.Entity = new Database1Entities1())
                {
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

        public bool isProductType(string productType)
        {
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    var isFound = this.Entity.ProductTypes.FirstOrDefault(p => p.pType == productType);
                    if (isFound != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
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
        public bool addFarmerToDB1Entity(Farmer farmer)
        {
            try
            {
                using (var context = new Database1Entities1())
                {
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
        public int addProductTypeToDB1Entity(ProductType productType)
        {
            try
            {
                int newTypeId = -1;
                using (var context = new Database1Entities1())
                {
                    context.ProductTypes.Add(productType);
                    context.SaveChanges();
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

        public List<string> getFarmerNames()
        {
            try
            {
                List<string> farmerNameList;
                using (this.Entity = new Database1Entities1())
                {
                   farmerNameList = this.Entity.Farmers.Select(p => p.fName).ToList();
                    return farmerNameList;
                }
            }
            catch (Exception ex)
            {
                List<string> farmerNameList = null;
                return farmerNameList;
            }
        }

        public List<string> getProductType()
        {
            try
            {
                List<string> productTypeList;
                using (this.Entity = new Database1Entities1())
                {
                    productTypeList = this.Entity.ProductTypes.Select(p => p.pType).ToList();
                    return productTypeList;
                }
            }
            catch (Exception ex)
            {
                List<string> productTypeList = null;
                return productTypeList;
            }
        }

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
                    CommandText = "SELECT  Farmer.fName + ',' + Farmer.sName AS fFullname,ProductType.pType,ProductType.pDateAdded " +
                                  "From ProductType,ProductList,Farmer "+
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

        public int getFarmerId(string userEmail)
        {
            int userId = -1;
            try
            {
                using (this.Entity = new Database1Entities1())
                {
                    userId = this.Entity.Farmers.FirstOrDefault(p => p.fEmail == userEmail).FarmerId;
                    if(userId != null)
                    {
                        return userId;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            { return -1; }

        }

        public DataTable filterProductData( int sqlType,string filterTypeId,string filterFarmerId,DateTime filterStartDate,DateTime filterEndDate)
            {
            string sqlCmd = "";

            this.connectDB();
            DataTable FilteredProductDataTable = new DataTable();
            try 
            {
                switch (sqlType)
                {
                    case 1:
                        sqlCmd = "Select ProductType.pType,ProductType.pName,ProductType.pDateAdded " +
                                 "from ProductType,Farmer,ProductList " +
                                 "Where Farmer.FarmerId = ProductList.farmerId AND ProductList.prodTypeId = ProductType.pTypeId " +
                                 "AND ProductType.pDateAdded > "+ filterStartDate.Date.ToString() +" AND " +
                                 "ProductType.pDateAdded < " + filterEndDate.Date.ToString();
                        break;
                    case 2:
                        sqlCmd = "Select ProductType.pType,ProductType.pName,ProductType.pDateAdded " +
                                 "from ProductType,Farmer,ProductList " +
                                 "Where ProductList.farmerId = " + filterFarmerId + " AND ProductList.prodTypeId = ProductType.pTypeId " +
                                 "AND ProductType.pDateAdded > " + filterStartDate.Date.ToString() + " AND " +
                                 "ProductType.pDateAdded < " + filterEndDate.Date.ToString(); ;
                        break;
                    case 3:
                        sqlCmd = "Select ProductType.pType,ProductType.pName,ProductType.pDateAdded " +
                                 "from ProductType,Farmer,ProductList " +
                                 "Where Farmer.farmerId = ProductList.FarmerId AND ProductList.prodTypeId = " + filterTypeId + " " +
                                 "AND ProductType.pDateAdded > " + filterStartDate.Date.ToString() + " AND " +
                                 "ProductType.pDateAdded < " + filterEndDate.Date.ToString(); ;
                        break;
                    case 4:
                        sqlCmd = "Select ProductType.pType,ProductType.pName,ProductType.pDateAdded " +
                                 "from ProductType,Farmer,ProductList " +
                                 "Where ProductList.farmerId = "+ filterFarmerId+" AND ProductList.prodTypeId = "+filterTypeId + " " +
                                 "AND ProductType.pDateAdded > " + filterStartDate.Date.ToString() + " AND " +
                                 "ProductType.pDateAdded < " + filterEndDate.Date.ToString(); ; ;
                        break;
                }
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
            }catch(Exception ex)
            {
                return FilteredProductDataTable; 
            }
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------