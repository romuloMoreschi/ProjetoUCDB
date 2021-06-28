# ProjetoUCDB

This project was using code first, migrations are already generated in the infrastructure layer.

## Development server

Run `update-database` in infrastructure after set your database in context, that will generate database.
Them set your database in appsettings.json in the api layer.

!Important - The web project based in angular 12.0 https://github.com/romuloMoreschi/ProjetoUCDB.Web is searching for api on localhost:5000
