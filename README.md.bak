# ControlWeight
Description: This application helps monitor body changes. In the main menu, the user can navigate to the 'about' section for a brief description of the application or go to their measurements. There, the user can add a new measurement, which includes: date, weight, hip circumference, waist circumference, thigh circumference, chest circumference, and arm circumference. The 'date' field automatically fills in with the current date, but the user can select a different date (if, for example they forgot to make an entry the previous day). There is one circumstance - the user cannot choose a date that is already recorded in the measurement history. Measurement history - the user also has access to their measurement history, which is stored in the database. Each measurement can be deleted or edited by the user (except for the 'date' field). The application is very clear and intuitive to use.

How to start: 
1.Backend:
    1.1 Create mssql database (If you use Visual Studio: Open ControlWebAPI, go to Tools -> NuGet Package Manager -> Package Maanger Console, send 'create-database' command)
    1.2. Execute migrations. Migrations files are available in ControlWeightAPI/ControlWeightAPI/Migrations (if you use Visual Studio, send 'update-database' command in Tools -> NuGet Package Manager -> Package Maanger Console. If you don't use Visual studio, open console, go to project directory, send 'dotnet ef database update' command. If you don't have EF Core CLI tool, first you have to install them: 'dotnet tool install --global dotnet-ef' command)
    1.3. Check settings: 
        - port settings in Properties directory-> launchSettings.json.
        - connectionString settings in Entities -> ControlWeightDBContext.cs
        - port in options.AddPolicy() in Program.cs (4200 port is default port used by Angular project)
    1.4. Run ControlWeightAPI

2.Frontend:
    2.1 Check settings:
        - port settings in .vscode/launch.json (4200 port is default port used by Angular project)
        - port settings in src/app/measures-and-history/service.ts
        - port settings in src/app/measures-and-history/measures-and-history/measures-and-history.component.ts (APIUrl variable)
        - port settings in src/proxy.conf.json
    2.2 Check if you have insstalled Angular. Run project ControlWeightUI (if you use 'Node.js command prompt', send 'ng serve --o' command. This command use default 4200 port.)

