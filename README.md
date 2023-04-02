# C# Web API with CRUD operations and MySQL database

This is a C# Web API that provides CRUD (Create, Read, Update, Delete) operations for a MySQL database. It can be run using Docker.

## Prerequisites

To run this application, you will need the following:

- .NET 6 Core
- Docker

## How to run

1. Clone this repository to your local machine:

```
git clone https://github.com/JorgeDorio/MoviesApi.git
```


2. Navigate to the project directory:


```
cd MoviesApi
```


3. Start the MySQL database in Docker:

```shell
docker run --name mysql-db -p 3306:3306 -e MYSQL_ROOT_PASSWORD=password -d mysql
```


Note: Replace "password" with your desired password for the MySQL root user.


4. Edit the `appsettings.json` file to match your database connection settings:

```json
{
  "ConnectionStrings": {
   "MovieConnection": "server=localhost;database=movie;user=root;password=password"
  }
}
```

5. Build and run the application using .NET CLI:

```shell
dotnet build
dotnet run
```

## Endpoints
You can see all endpoints in the docs:

- GET /swagger - see the docs


That's it! You should now have a working C# Web API with CRUD operations and a MySQL database running in Docker.


