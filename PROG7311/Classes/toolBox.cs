using PROG7311.Layouts;
using PROG7311.Objects_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Geoffrey Huth ST10081932 PROG7311 POE TASK 2
namespace PROG7311.Classes
{
    /// <summary>
    /// The toolbox controls all the instances of the application.
    /// </summary>
    public class toolBox
    {
        //Login
        public Login _Login = new Login();
        //DBHandler
        public DBHandler _DBHandler = new DBHandler();
        //pwdHashing
        public pwdHashing _pwdHashing = new pwdHashing();
        //AddFarmer
        public AddFarmer _AddFarmer = new AddFarmer();
        //ViewFarmer
        public ViewFarmerProducts _ViewFarmer = new ViewFarmerProducts();
        //AddProduct
        public AddProduct _AddProduct = new AddProduct();
        //viewFarmerProduct
        public viewFarmerProduct _viewFarmerProduct = new viewFarmerProduct();
        //userDataStore
        public userDataStore _userDataStore = userDataStore.Instance;
        //Farmer Object Class
        public Farmers _Farmers = Farmers.Instance;
        //Product Object Class;
        public Product _Product = Product.Instance;
        //View product filter object class
        public viewProductFiltercs viewProductFiltercs = viewProductFiltercs.Instance;
    }
}
//------------------------------------------------------------End-Of-File--------------------------------------------------