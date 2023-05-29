using PROG7311.Interfaces;
using PROG7311.Objects_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
/*Geoffrey Huth ST10081932 PROG7311 POE Task 2*/
namespace PROG7311.Classes
{
    public class AddProduct: IAddProductInterface
    {
        /// <summary>
        /// Creates the toolbox instance
        /// </summary>
        private static Type toolBox = typeof(toolBox);
        private static object[] parameters = new object[] { };
        private static object obj = Activator.CreateInstance(toolBox, parameters);
        private toolBox _toolBox = obj as toolBox;
        public bool saveProductData()
        {
            try
            {
                bool isValid = false;
                //creating product type object
                ProductType productType = new ProductType();
                productType.pType = _toolBox._Product.ProductType;
                productType.pName = _toolBox._Product.ProductName;
                productType.pDateAdded = _toolBox._Product.ProductDateAdded;
                //creating productdatastore object
                int typeId = _toolBox._DBHandler.addProductTypeToDB1Entity(productType);
                if (typeId == -1)
                {
                    //displays a modal style dialogue box that the user will see notifying them that there was a problem when addinding
                    //the object to the database. QUESTION: What information is relevant to the user vs a developer in terms of crashes?
                    return true;
                }
                _toolBox._Product.ProductTypeId = typeId;
                //saving data to product object
                ProductStore productStore = new ProductStore();
                productStore.prodQty = Convert.ToInt32(_toolBox._Product.ProductQty);
                productStore.ProdTypeId = _toolBox._Product.ProductTypeId;
                productStore.ProdDateAdded = _toolBox._Product.ProductDateAdded;
                productStore.prodRemaining = productStore.prodQty;
                //adding product to entity
                isValid = _toolBox._DBHandler.addProductDataToDB1Entity(productStore);
                if (isValid == false)
                {
                    //displays a modal style dialogue box that the user will see notifying them that there was a problem when addinding
                    //the object to the database. QUESTION: What information is relevant to the user vs a developer in terms of crashes?
                    return true;
                }
                //creating productList Object
                ProductList productList = new ProductList();
                productList.farmerId = _toolBox._DBHandler.getFarmerId(_toolBox._userDataStore.UserEmail);
                productList.prodTypeId = _toolBox._Product.ProductTypeId;
                //adding link to product list
                isValid = _toolBox._DBHandler.addProductAndFarmerLinkToProductList(productList);
                if (isValid == false)
                {
                    //displays a modal style dialogue box that the user will see notifying them that there was a problem when addinding
                    //the object to the database. QUESTION: What information is relevant to the user vs a developer in terms of crashes?
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------