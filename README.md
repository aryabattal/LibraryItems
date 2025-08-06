# ManageLibraryItemsAndEmployees

This project is a .NET 6 web application for managing library items and employees. It includes features for admin management, library item CRUD operations, user authentication, and search functionality.

## Project Structure

- `Program.cs` / `Startup.cs`: Application entry point and configuration.
- `Controllers/`: Main controllers for handling requests (AdminLogin, Home, LibraryItems, SearchResult).
- `Data/`: Database context, entities, and migrations.
- `Areas/`: Contains feature areas like Admin and API (v1, v2), Identity management.
- `Extensions/`: Utility extension methods.
- `LibraryItems/`: (Folder for library item-related logic/models.)
- `Models/`: View models and error models.
- `Views/`: Razor views for UI (AdminLogin, Home, SearchResult, Shared, Error).
- `wwwroot/`: Static files (CSS, JS, libraries, favicon).
- `Properties/`: Launch and service configuration files.
- `appsettings.json` / `appsettings.Development.json`: Application configuration.
- `ManageLibraryItemsAndEmployees.csproj`: Project file.
- `ManageLibraryItemsAndEmployees.sln`: Solution file.

## Getting Started

1. **Restore dependencies:**
   ```pwsh
   dotnet restore
   ```
2. **Build the project:**
   ```pwsh
   dotnet build
   ```
3. **Run the application:**
   ```pwsh
   dotnet run
   ```

## Database

- Database migrations are located in `Data/Migrations/`.
- SQL scripts for initial data are in `Data/sql-data-libraryitems-employees.sql`.

## Features

- Admin area for managing employees and library items
- API endpoints (v1, v2)
- Identity and authentication
- Search functionality

## Contributing

Feel free to fork and submit pull requests.
