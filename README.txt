How to use the application:

Step A:

1) Choose a random connection string from your SQL server.

2) Open the "BirthClinicPlanningDB" project, and open the "Context.cs" file. 

3) Replace the connection string with you own connection string in the "OnConfiguring()" method, AND edit the "Catalog" assignment to a name of your choice. 
   Press save. 

4) Set the "BirthClinicPlanningDB" project as your startup project. 

5) Go to your "Package Manager Console" and set "Package source" to "All", AND "Default Project" as "BirthClinicPlanningDB".

6) In the package manager console, type: "update-database", to apply the included migration files to the database. (The DB will be created on its own with seeded data) 

7) Ensure that the tables has been created in your local database. 


======================================   Now you are ready to run the application  =========================================


Step B:

1) Set the "BirthClinicGUI" as you startup project. 

2) Run the application by pushing the "F5" button. The WPF application will now start. 


====================================== Use cases to try ======================================

Step C:

UC1 - Add an appointment)

1. Press the "Add Appointment"-button. 

2. Put in room number.

3. Choose what room you want for the appointment - if you choose the maternityroom you will be asked to fill in info for the baby.

4. Change the timeframe or keep the one suggested

5. Add one or more of the many clinicians.

6. Put in the CPR-number - this must be a real cpr number - the application uses the "check11" to validate cpr numbers

7. Add the nam of the mom.

8. If you want, you can add the dad aswell - his CPR must be a real one also.

9. Press "Ok" and the appointment added. 


UC2 - See room status)

1. Press the "See room status"-button

2. Choose any room and double-click

3. If there the room is currently occupied, the info will show.


UC3 - Delete appointment)

1. On the mainwindow - choose an appointment and click on it

2. Press the "delete appointment"-button

3. the appointment is now deleted


UC4 - Explore)

1. After UC1 you can see the appointment you added - You can see all appointments on the mainwindow

2. Try to double-click one. 

3. Here you see all the info on the appointment. 



======================================   Clean up  =========================================


Step D:

1) Right click at the database at your local sql server, and delete the database. 

Now you are ready to start over from step A. 