using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7311.Interfaces
{
    public interface DBInterface
    {
        void connectDB();
        bool isEmployee(string userEmail);
        bool isFarmer(string userEmail);
        int saveFarmerPassword(Password password);
        bool addFarmerToDB1Entity(Farmer farmer);
        string getSaltKeyByEmail(string userEmail);
        bool searchForMatchingPassword(string hashedPassword);
        bool addProductAndFarmerLinkToProductList(ProductList productList);
        bool isProductType(string productType);
    }
}
