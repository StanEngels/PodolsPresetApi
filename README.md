# PodolsPresetApi
Online ampification software.

## Changing environment variables 
Use the [LaunchSettings.json example](https://github.com/StanEngels/PodolsPresetApi/blob/main/Example%20files/launchSettings.example.json) and change the "change me" values to your values.\

`"DATABASE_CONNECTION_STRING": "Your database connection string"`\
`"INCOMING_CORS_URL": "http://Your_react_app:3000"`\
`"KEYCLOAK_AUTHORITY_URL": "http://Your_keycloak_url/auth/realms/your_realm/"`\
`"KEYCLOAK_AUDIENCE": "Your_audience" (This is normally your client in keycloak)`

## After changing the environment variables

Make sure the file path becomes "PresetApi/Properties/launchSettings.json" when you finished adding your values.

## Run the SLN file or use the "dotnet run" command
This should run the application and make api calls available from localhost.
