using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Interfaces
{
    public interface IDBInterface
    {
        void connectDB();
        bool isEmployee(string userEmail);
        bool isFarmer(string userEmail);
        int saveFarmerPassword(Password password);
        bool addFarmerToDB1Entity(Farmer farmer);
        string getSaltKeyByEmail(string userEmail);
        bool searchForMatchingPassword(string hashedPassword);
        bool addProductAndFarmerLinkToProductList(ProductList productList);
        DataTable getProductDataTable();
        int getFarmerIdByName(string userFirstName);
        int getFarmerId(string userEmail);
        int getTypeId(string productType);
        DataTable filterProductData(string sqlCmd);
        bool isProductType(string productType, string userEmail);
    }
}
