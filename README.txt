How to use the application:

Step A:

1) Choose a random connection string from your SQL server.

2) Open the "BirthClinicPlanningDB" project, and open the "Context.cs" file. 

3) Replace the connection string with you own connection string in the "OnConfiguring()" method, AND edit the "Catalog" assignment to a name of your choice. 
   Press save. 

4) Set the "BirthClinicPlanningDB" project as your startup project. 

5) Go to your "Package Manager Console" and set "Package source" to "All", AND "Default Project" as "BirthClinicPlanningDB".

6) In the package manager console, type: "update-database", to apply the included migration files to the database. (The DB will be created on its own) 

7) Ensure that the tables has been created in your local database. 


======================================   Now you are ready to run the application  =========================================


Step B:

1) Set the "BirthClinicGUI" as you startup project. 

2) Run the application by pushing the "F5" button. The WPF application will now start. 

3) 