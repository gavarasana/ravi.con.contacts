# ravi.con.contacts
Test to see how SQL commands are issued when using AddRange

## EF Migrations
To create schema in your local database server.
1) Update appsettings.json with the right databasa connection string.
2) Run "dotnet ef migrations add initial_create"
3) Run "dotnet ef database update"

## To test the operations
1) Open SQL server profiler. Create new trace and connect to the SQL server database.
2) Run the application and check the profiler
