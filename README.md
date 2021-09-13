# RestWebApiInMemoryEFCore
An API developed in AspNetCore using integration tests and in-memory database.

## Dependencies
DotNet Core 3.1

## Installing
1. Clone the repo:
   ```sh
   git clone https://github.com/richardblynd/RestWebApiInMemoryEFCore.git
   ```
2. Run project, access folder `WebApi`   and execute:
   ```sh
   dotnet run
   ```
3. The server will start at https://localhost:5001/

## Testing

You can list all data performing a get request in this endpoint https://localhost:5001/movies

For run integration tests run following command in folder `Test`:
   ```sh
   dotnet test
   ```

## Configure your own data
When the application starts up, the data is loaded via a CSV file. You can set the path of the CSV file in the `appsettings.json` file in the `WebApi` folder. After changing the file, it is necessary to restart the application.
For integration tests, check the `integrationsettings.json` configuration file in the `WebApi` folder.

## Golden Raspberry Award
The theme of this application is based on the Golden Raspberry Award. You can get the producer with the longest interval between two consecutive awards, and the one with the fastest two awards via the endpoint https://localhost:5001/awards/min_max_award_interval