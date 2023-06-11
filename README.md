# Test project for Modsen Internship

API uses JWT authentication. To run API use following commands:

 + `dotnet build`
 + ```bash 
    dotnet user-jwts create --role "admin"
    dotnet user-jwts create --role "user"
    ```
 + `dotnet run`