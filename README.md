# PodolsPresetApi
Online ampification software.

## Before you start create a MariaDB Database

This can be done through various methods but here is a [simple docker](https://hub.docker.com/_/mariadb) version.
Follow the instructions and make a database with user and grant the user permissions to your created database.

## Changing environment variables 
Use the [LaunchSettings.json example](https://github.com/StanEngels/PodolsPresetApi/blob/main/Example%20files/launchSettings.example.json) and change the "change me" values to your values.\

`"DATABASE_CONNECTION_STRING": "Your database connection string"`\
`"INCOMING_CORS_URL": "http://Your_react_app:3000"`\
`"KEYCLOAK_AUTHORITY_URL": "http://Your_keycloak_url/auth/realms/your_realm/"`\
`"KEYCLOAK_AUDIENCE": "Your_audience" (This is normally your client in keycloak)`

## After changing the environment variables

Make sure the file path becomes "PresetApi/Properties/launchSettings.json" when you finished adding your values.

## Run creating the database on your MariaDB server

Run: `dotnet ef database update` 
To create your database.

If you get an error message saying the "ef" command doesn't exist use:

`dotnet tool install --global dotnet-ef`
And run the command again

## Run the SLN file or use the "dotnet run" command
This should run the application and make api calls available from localhost.

## After this make sure you installed your frontend and start both apps
If you haven't yet installed the front-end app there is a readme [over here](https://github.com/StanEngels/PodolsReactApp/blob/master/README.md).
