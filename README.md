Geoffrey Huth ST10081932 PROG7311 POE Task 2
Visual Studio 2022
C# 4.7.8 .Net Framework
Web Application 

GitHulink :
https://github.com/GeoffreyCoding/PROG7311.git 

Stock Management App.
These pre-created accounts can be used to access the application

Employee Account Email and Passwords:
Johnathan123! John@WebDev.co.za
Kyle123! Kyle@WebDev.co.za
Matt123! MLub@WebDev.co.za
Ethan123! EHaas@WebDev.co.za

Farmer Account Email and Passwords:
gggggggggg GSimon@Gmail.com
LLLLLLLLLL GShaep@Gmail.com
HHHHHHHHHH HFarmer@vcconnect.edu.za
UUUUUUUUUU K.Farmer_2@mweb.co.za
IIIIIIIIII K.Farmer_2@Stasy.edu.za
______________________________________________________________________________________________________
How to Use:
If Your an Employee:
1) log in using your employee email and password then use the navigation menu above to access all features
If your a farmer: 
1) An employee must first create your account and then you can log in using your assigned email and password

Employee Features: 

Once logged in you can click on the navigation menu to access all features or press signout to log into another account

In Add Farmer you must type in all user details then click the button bellow. The program will guide you on what information to include.
The Farmers email cannot already exist in the database

In ViewFarmerProducts you can enter a product type,name and choose a date range. You can then click apply filter and it will display the 
relevant data.
You can also click clear filter to display the defafult data with no filter.

Farmer Features:

Once logged in you can once again use the navigation menu to access all features or press signout to log into another account

In Add product you must type in all product details then click the button bellow. The program will once again guide you on what information to input. Please remember than one farmer account cannot have multiple matching productTypes.
______________________________________________________________________________________________________
Technical Information

The application uses interface for each layout and the DBHandler. The DBHandler and all object classes use instances to implement the
singleton class. This is all controlled inside of the relevant classes and the toolbox which controls all instance handling.
Entity framework has been added as a feature and is used to temporarily store all data in the database.
The basic class structure includes a class for each page layout alongside object classes for specific tables in the database and to store the users login information. Their is also a DBHandler class which handles all LinQ and sql queries. The toolbox class handles all instances as stated previously.
______________________________________________________________________________________________________
References

ChatGpt was used to assist in making the HTML pages and the SQL queries for ViewFarmerProduct.
Stack overflow was used for backend optimization and fixing bugs.
Bootswap was used for the errormessage popups.
ChatGpt was used to display the modal



