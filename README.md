# [WIP] Error monitoring

## WORK IN PROGRESS!

A web api for collecting app errors (Bugsnag lite). 

The api will support registering and retrieving app error reports as well as setting up webhooks to facilitate report notification to other apps. 

The purpose of the api is not to be used as a log but rather just a notification system so some sort of report cleanup functionality will also be added at some point.

## Implementation details
This section will contain info related the implementation and configuration of the api.

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