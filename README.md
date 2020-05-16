# Customer.ProfileManagement
ASP.NET Web API and Razor Application for Managing Customer Profile
Customer Profile Management
The Application is used for managing customer profile. Where user can store Email, First Name, Last Name, Date of Birth and Mobile Number(optional).
Technology Stack
	Microsoft .NET Core Web API (Back End)
	Microsoft ASP.NET Razor (Front End)
	Temp Store DB MDF file
	Use in Memory File for Test
	NUnit Test Cases

Project Architecture
1)	Customer.Profile.API
This project is exposing API for Add, Edit, Delete, Get Customer Profile.
	Controllers- API Controller
	Mapper – Automapper to Map Viewmodel to model and vice versa
	Validation – Custom Validation Attribute for Date of Birth so that person should be over 18 in order to save in customer profile.

2)	Customer.Profile.Store
This Project contain DB MDF file and Service implementation to connect to Database and do the record management in Database.
	DB – Contain mdf file
	Model – Entity Model to be mapped with Database table
	Services – Implementation of Insert, Update delete record in Database using Entity Framework.
	The interface here is exposed to be used as service in different module (example API) to do the record management implementation.

3)	Customer.Profile.Web
This is Web application build in ASP.NET Core uses Razor for building UI which is presented to user for Customer Profile Management
	Common- AppSetting Class, which map configuration from appsetting.json to this. Here the API base Url is mapped which is being called by the web to do Customer Profile record management.
	Models - Contain ViewModel
	Services – Client Interface is use to do API call implementation Get/Put/POST/Delete. Repository is actually calling this client service and implementing the operation to manage customer profile implementation.
	Validation – Custom DataAnotation validation for Date of Birth not be less then 18years.
	Views – Contain cshtml file UI
	AddCustomerProfileRegistration – Registering AppSetting class to map configuration from appsetting.json .
	CustomerProfileController – Controller class for ASP.NET MVC UI backend implementation.
4)	NUniteTestProject1
Contain test cases for Web API exposed for customer profile management. It used in memory database.

Scopes
There are few of the cases for future scope I would like to implement in this application.
1)	Authentication in Web API
2)	Logging and Proper Exception handling Web Project

Application Configuration
1)	The location for database mdf file should be configured in Customer.profile.API Project -> appsettings.json file property -> ConnectionString
Or
As mention in current file the setting is C:\DB the mdf file can be copied here.
2)	The Web API end point need to be configured in Customer.Profile.Web -> appsettiings.json file property -> CustomerProfileApiUrl



