"# itikaf-tracker" 

### SOLUTION PROJECT
dotnet new sln -n ItikafTracker

### DOMAIN
dotnet new classlib -n ItikafTracker.Domain --framework net8.0

### APPLICATION
dotnet new classlib -n ItikafTracker.Application --framework net8.0


### INSFRASTRUCTURE
dotnet new classlib -n ItikafTracker.Infrastructure --framework net8.0
 
### PRESENTATION LAYERS
dotnet new webapi -n ItikafTracker.API --framework net8.0 --use-controllers

### ADD KE SOLUTION
dotnet sln add ItikafTracker.Domain
dotnet sln add ItikafTracker.Application
dotnet sln add ItikafTracker.Infrastructure
dotnet sln add ItikafTracker.API


### REFERENCE FILE
dotnet add ItikafTracker.Application reference ItikafTracker.Domain`
dotnet add ItikafTracker.Infrastructure reference ItikafTracker.Application`
dotnet add ItikafTracker.API reference ItikafTracker.Application
dotnet add ItikafTracker.API reference ItikafTracker.Infrastructure

### AUTH
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore

### CREATE CONTROLLER
dotnet new apicontroller -n AuthController -o Controllers


### AUTH JWT
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.5

### RUNNING PROJECT
dotnet new controller -n AuthController -api


### BUILD
dotnet build