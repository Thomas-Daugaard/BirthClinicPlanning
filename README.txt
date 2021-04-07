How to use the application:

Step A:

1) Choose a random connection string from your SQL server.

2) Open the "BirthClinicPlanningDB" project, and open the "Context.cs" file. 

3) Replace the connection string with you own connection string in the "OnConfiguring()" method, AND correct the "Catalog" assignment to a name of your choice. 
   Press save. 

4) Set the "BirthClinicPlanningDB" project as your startup project. 

5) Right click at the "BirthClinicGUI" project and choose "Unload project".

6) In the package manager console, type: "update-database", to apply the included migration file to the database. (The DB will be created on its own) 

7) Ensure that the tables has been created in your local database. 

8) Right click at the unloaded "BirthClinicGUI" Project, and choose "Reload project with dependencies".


======================================   Now you are ready to run the application  =========================================


Step B:

1) Set the "BirthClinicGUI" as you startup project. 

2) Run the application by pushing the "F5" button. The WPF application will now start. 

3) 