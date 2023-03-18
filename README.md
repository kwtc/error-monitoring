# Error monitoring
A web api for collecting app errors (BugSnag lite). 

The api will support registering and retrieving app errors as well as setting up webhooks to facilitate error notification to other apps. 

The purpose of the api is not to be used as a log but rather just a notification system so some sort of error cleanup functionality will also be added at some point.

## Implementation details
This section will contain info related the implementation and configuration of the api.

### Persistence
A MySQL connection factory is registered by default and requires a connection string to be defined in appsettings.

```c#
var connection = new MySqlConnection(this.configuration.GetConnectionString("ConnectionString"));
```