# ASP.NET / PostgresQL / Svelte Web app

The

## Building

1. Install [NodeJS](https://nodejs.org/en), [Yarn](https://yarnpkg.com/getting-started/install), [.NET 7.0](https://dotnet.microsoft.com/en-us/download), and [Docker Desktop](https://docs.docker.com/desktop/) if you haven't already.
2. Clone this repo. Usually with `git clone https://github.com/njs-templates/aspnet-postgres-svelte.git`.
3. Delete the `.git/` folder from the project root. Alternatively, you can use [degit](https://github.com/Rich-Harris/degit) to do this for you.
4. Open the root of this directory and run the following to download npm packages.

```bash
cd frontend
yarn
```

5. Create a `.env` file at the root of the project and fill out the values with your preferences. You can just copy the `.env.example` to make sure it works, but the username and password should be changed in a production environment.

6. Run `docker-compose up -d` to create and run the Postgres database in the background. You can run `docker-compose down` to stop it.

7. While still in the root, run the following to install nuget packages. The aspnet-codegenerator is optional but recommended.

```bash
cd backend
dotnet restore
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet ef database update
dotnet run
```

8. Open localhost:[port]/swagger to make sure that the backend is working.
9. Back in the root directory, run the following to start vite and make sure that the frontend is working.

```bash
cd frontend
yarn dev
```

If you can see both pages and you can add, delete, and edit the todo items, you should be good to go.
