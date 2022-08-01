# Employee_MVC_App

This application uses the mvc architecture of .net core along with entity framework, it also uses sql server as the database and jquery libraries(datatables and sweetalert2).

The core purpose of this application is to create employees with different roles so it is mostly crud operations with user permissions.

**Architecture**

This application uses the unit of work design pattern along with dependency injection in mvc controllers. The Unit of Work pattern is used to group one or more operations (usually database CRUD operations) into a single transaction or “unit of work” so that all operations either pass or fail as one unit.

**Run Migrations**

To run migrations and update db you should run the following commands from nugget package manager console in visual studio

1. Add-Migrations "some text"
2.  Update-Database
