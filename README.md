Manual

1. Firstly Install the ASP .Net Core Web API (https://github.com/AlgooRhythm/SimpleCRUD) application

2. Then setup the database connection in file ~\appsettings.json, as per your database connection.

3. Then updated the API URL of this application, at the folder ~\Services\GlobalSettings\GlobalSettingsService.cs (eg: https://localhost:7186/)
as per in the ASP .Net Core Web API application (https://github.com/AlgooRhythm/SimpleCRUD) URL during run that application.

4. Make sure the API URL, the port number is correct.

5. Run this C# Blazor UI, and try performing data Create, Edit, View and Delete. It will sync the data in the setup database.
