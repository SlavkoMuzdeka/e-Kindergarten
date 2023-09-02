# e-Kindergarten

## Project Overview

The "e-Kindergarten" project is a desktop application developed in C# using Windows Forms for managing kindergarten institutions. This application streamlines various aspects of kindergarten management, including personnel records, child data, group allocation, daily activities, and financial transactions. It utilizes a MySQL database for secure data storage and retrieval, providing a user-friendly interface for kindergarten administrators.

## Getting Started

Follow these steps to set up and run the e-Kindergarten application on your local machine:

1. Prerequisites:

- **Visual Studio:** Install Visual Studio on your machine. You can download it from the official Visual Studio [website](https://visualstudio.microsoft.com/).

2. Clone the Repository

```bash
    git clone https://github.com/YourUsername/YourRepository.git
```

3. Open the Project in Visual Studio:

- Launch Visual Studio.
- Click on "File" > "Open" > "Project/Solution" and select the cloned repository.

4. Set Up the MySQL Database:

Execute the provided SQL scripts (script.sql and data.sql from database folder) to create the required database schema and tables.

```bash
    mysql -u <username> -p <database_name> < schema.sql
    mysql -u <username> -p <database_name> < data.sql
```

Replace <username> with your MySQL username and <database_name> with the name of your database.

5. Configure Database Connection:

- In the project source code, locate the database configuration file.
- Provide the necessary database credentials to connect to your MySQL database.

6. Run the Application

## Key Features

- Database Integration: The application should utilize a database management system (DBMS) of your choice. The database connection details, including the connection string, must be read from an application configuration file. The database should consist of 7-15 tables (or equivalent if a non-relational database is used).

- User Accounts: The application should support different types of user accounts, including at least two types such as administrators and clerks. User authentication and role-based access control should be implemented.

- Internationalization: Internationalization should be supported with at least two languages, including English and one of the official languages of your country. This internationalization should be at the form level, and data-level internationalization is optional.

- User Preferences: Implement user settings, allowing users to choose from several (at least three) different themes/styles, each with different color schemes, fonts, and more. The system should remember the user's preference and apply it upon login.
