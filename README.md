# Factory Organization for Dr. Sillystringz's Factory

## A C# MVC web application made for the factory of Dr. Sillystringz. This web application can manage a database of the factory's engineers and the machines they are licensed to repair.

### By Simi Oyin

## Technologies Used

- C#
- HTML
- CSS
- Bootstrap
- .NET 6
- ASP.NET Core MVC
- Razor View Engine
- MySQL Workbench
- MySQL Community Server
- Entity Framework Core

## Description

Upon landing at the home page, the user is presented with lists of both existing engineers and machines in the database. If either of the lists are empty, placeholder text will be there instead. Here, the user can choose to populate either list -- engineer or machine. Clicking the engineers or machines listed allows the user to see their/its details. From here, the user may choose to edit details or delete the entry.

The user can link objects from one class to another. For instance:

- For a specified engineer, a specified machine can be added to their list, noting that the engineer is able to repair said machine.
- The relationship is mirrored in that an engineer is able to be added to a machine's list.
- The above mentioned join relationship can be removed from either perspective -- engineer or machine -- and it will be reflected upon viewing details from the other's direction.

### Additional Details:

- This web application was written using C#, run using .NET framework, its ability to run in a browser enabled using the ASP.NET Core MVC framework, and database query and relationships handled using Entity Framework Core.
- Utilizes a many-to-many relationship between the two classes -- engineer and machine.
- Data annotations and conditionals are in place to validate user input.
- Full CRUD functionality works for both classes.
- Styling uses CSS and Bootstrap.
- Data storage is managed using MySQL. Entity Framework Core .NET Command-line Tools (or dotnet ef) is used for database version control -- migrations are created to tell MySQL how the database is structured and updated as needed.

### Key objectives for this project include:

- using Entity Framework Core for database communication,
- practicing database naming conventions,
- implementing a many-to-many database relationship,
- being able to view both sides of the many-to-many relationship,
- CRUD functionality (create, read, update, and delete) for at least one of the classes,
- and setting up the project as well as providing instruction to any users so that build files and sensitive information are not tracked by Git (i.e. .gitignore, appsettings.json, bin, obj).

## Setup/Installation Requirements

### Required Technology

- Verify that you have the required technology installed for MySQL (https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/) and MySQL Workbench (https://dev.mysql.com/doc/workbench/en/).
- Also check that Entity Framework Core's dotnet-ef tool is installed on your system so that it can perform database migrations and updates. Run the following command in your terminal:
  `$ dotnet tool install --global dotnet-ef --version 6.0.0`

### Setting Up the Project

1. Open your terminal (e.g., Terminal or GitBash).
2. Navigate to where you want to place the cloned directory.
3. Clone the repository from the GitHub link by entering in this command:
   `$ git clone https://github.com/simioyin222/FactoryOrganization`
4. Navigate to the project's production directory Factory, and create a new file called appsettings.json.
5. Within appsettings.json, add the following code, replacing the `uid`, and `pwd` values with your username and password for MySQL. Under `database`, add any name that you deem fit -- although "Factory" is suggested for organization sake and clarity of purpose.
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
     }
   }
6. In the terminal, while in the project's production directory Factory, run the following command. It will utilize the repository's migrations to create and update the database. You may opt to verify that the database has been created successfully in MySQL Workbench.
$ dotnet ef database update.


#### Running the Project

-In the command line, while in the project's production directory Factory, run this command to compile and execute the web application. A new browser window should open, allowing you to interact with it.
$ dotnet run
-Alternatively, using the command dotnet run will execute the application. Manually open a browser window and navigate to the application url (ex: https://localhost:7026 or http://localhost:5088)
$ dotnet run
-Optionally, to compile this web app without running it, enter:
$ dotnet build

### Known Bugs
Please report any bugs to simi.oyinkolade@gmail.com.

## Contributing
Contributions to improve the application are welcome. Fork the repository, make your changes, and submit a pull request.
- Please let me know if you know how to change the color or make text bold for the machine and engineer text result/inputs 
- Please let me know if you know how to live change engineers and machines being added to card "To Do"  then once relationship made or add one to the other 
it should update to the "In Progress" card then once deleted in the the "Done" card.

### License

MIT License

Copyright (c) 2023 Simi Oyin

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: