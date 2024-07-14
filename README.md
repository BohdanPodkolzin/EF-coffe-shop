# EntityFrameworkCoffeeShop

## Overview

EntityFrameworkCoffeeShop is a learning project designed to demonstrate various functionalities of Entity Framework Core in a C# application. This project includes implementations of CRUD operations, one-to-many and many-to-many relationships, and logging.

## Getting Started

To run this application, follow the steps below:

### Prerequisites

Make sure you have the following installed on your machine:
- .NET SDK
- Visual Studio or Visual Studio Code

### Launching the Application

1. **Set Working Directory:**
   - In `Properties/launchSettingsTemplate.json`, update the `workingDirectory` property to the full folder path where your `.sln` file is located.

   ```json
   {
       "profiles": {
           "EntityFrameworkCoffeeShop": {
               "commandName": "Project",
               "workingDirectory": "full-folder-path-where-sln-is-located"
             }
         }
     }

2. **Rename launch settings file:**
   - Rename `launchSettingsTemplate.json` to `launchSettings.json`.

3. **Launch the Application:**
   - Open the project in your preferred IDE.
   - Run the application.

## Features

Within Entity Framework, this project implements:
- CRUD operations
- One-to-many relationships
- Many-to-many relationships
- Logging Factory

## Dependencies

- Entity Framework Core
- Entity Framework Core SQLite
- Entity Framework Core Tools
- Microsoft Extensions Logging Console
- Spectre.Console

## License

[License Information Here](https://github.com/BohdanPodkolzin/EF-coffee-shop/blob/main/LICENSE)
