How to use the application:

Step A:

1) Create your own local SQL database to be used for running this application. 

2) Open the "BirthClinicPlanningDB" project, and open the "Context.cs" file. 

3) Replace the connection string with you own connection string in the "OnConfiguring()" method, and save. 

4) Set the "BirthClinicPlanningDB" project as your startup project. 

4) In the package manager console, type: "update-database", to apply the included migration fil to the database. 


======================================   Now you are ready to run the application  =========================================


Step B:

1) Set the "BirthClinicGUI" as you startup project. 

2) Run the application by pushing the "F5" button. The WPF application will now start. 

3) 