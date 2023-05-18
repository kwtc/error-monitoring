# [WIP] Error monitoring

A web API for collecting app errors (Bugsnag lite). 

The API will support registering and retrieving app error reports as well as setting up webhooks to facilitate report notification to other apps. 

The purpose of the API is not to be used as a log but rather just a notification system so some sort of report cleanup functionality will also be added at some point.

Dotnet client implementation [Kwtc.ErrorMonitoring.Client](https://github.com/kwtc/error-monitoring-client-dotnet)

## WORK IN PROGRESS!
- [X] API key authorization (simple)
- [X] Receive and persist reports
- [X] API versioning
- [ ] Support webhooks
- [ ] Report cleanup system

## Implementation details
This section will contain info related the implementation and configuration of the API.

### Persistence
A docker compose file is provided that spins up a MySQL 8 environment, creates a database with a root user and password and executes an sql initialization file which is also provided, that creates tables matching the domain models.

Simply install Docker and run the following terminal command in the /database folder:

```
docker compose up
```

A MySQL connection factory is registered by default and requires a connection string to be defined in appsettings.

```c#
var connection = new MySqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
```

See example in `appsettings.Development.json` it is configured to work with the development database defined in the docker configuration.

### API versioning
Although not super important for the project API versioning is supported using [Microsoft.AspNetCore.Mvc.Versioning](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning/) and [Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer). The `ApiControllerBase` class defines a base route with versioning which applies the version from the required `[ApiVersion]` class attribute. This does however pose the limitation that derived controllers can't define a route prefix on a class level, because it would override the versioning.

Swagger documentation of versions is automatically generated.