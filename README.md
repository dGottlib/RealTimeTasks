
     REAL TIME TASKS

     By Devorah Gottlieb

     Real Time Tasks is a React application that enables multiple users to add and complete tasks

     TECHNOLOGIES USED:
     SignalR
     Entity Framework
     React


     DESCRIPTION:         
     This application has the standard login/signup and the home page is only be accessible 
     to logged in users.

     On the home page, there is a table with all the current outstanding (incomplete) tasks.

     If a given task has not been started by anyone yet, there is be a button next to the task       
     that says "I'm doing this one". When clicked, the button changes to "I'm done",
     however, only for that logged in user.
 
     All other users should see a disabled button that says "{name of user} is doing this".

     When the user that chose a task clicks on the "I'm done" button,
     that task disappears from the table, for all users.


     SETUP / INSTALLATION:

     1. Modify the connection string in appsettings.json to reflect your database environment

     2. run the following commands
          dotnet ef migrations add initial
          dotnet ef database update