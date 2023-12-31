# ASP.NET / PostgreSQL / Svelte Web app

The foundation for a fullstack web app using [ASP.NET / C#](https://dotnet.microsoft.com/en-us/apps/aspnet), [Postgres](https://www.postgresql.org/), and [SvelteKit](https://kit.svelte.dev/).

## Overview

This is an MVC application which means that the frontend sends requests to the backend and the response is displayed in a UI to the user.
The example provided is in the form of a simple todo list app.

### Frontend

The frontend uses SvelteKit as well as other NPM packages using [Yarn](https://yarnpkg.com/).
- [TypeScript](https://www.typescriptlang.org/)
- [Vite](https://vitejs.dev/)
- [Tailwind CSS](https://tailwindcss.com/)
- [DaisyUI](https://daisyui.com/)
- [Axios](https://axios-http.com/)
- [ESLint](https://eslint.org/)
- [Prettier](https://prettier.io/)

### Backend

The backend uses ASP.NET through C# with Postgres for its database through [Npgsql](https://www.npgsql.org/).
This project is configured for [Omnisharp](https://www.omnisharp.net/), but your LSP or IDE shouldn't matter much.

### Recommended tools

- [VS Code](https://code.visualstudio.com/)
- [Docker Desktop](https://docs.docker.com/desktop/)
- [Beekeeper Studio](https://www.beekeeperstudio.io/) for viewing the database
- [Postman](https://www.postman.com/) for testing the API if necessary

#### Recommended VS Code extensions

All of these extensions can be easily installed when you open this repo in VS Code.
- [Svelte for VS Code](https://marketplace.visualstudio.com/items?itemName=svelte.svelte-vscode)
- [TypeScript Next](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-next)
- [Tailwind CSS IntelliSense](https://marketplace.visualstudio.com/items?itemName=bradlc.vscode-tailwindcss)
- [ESLint](https://marketplace.visualstudio.com/items?itemName=dbaeumer.vscode-eslint)
- [Prettier](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)
- [Todo Tree](https://marketplace.visualstudio.com/items?itemName=Gruntfuggly.todo-tree)
- [Git History](https://marketplace.visualstudio.com/items?itemName=donjayamanne.githistory)
- [Git Graph](https://marketplace.visualstudio.com/items?itemName=mhutchie.git-graph)

## Building

1. Install [NodeJS](https://nodejs.org/en), [Yarn](https://yarnpkg.com/getting-started/install), [.NET 7.0](https://dotnet.microsoft.com/en-us/download), and [Docker Desktop](https://docs.docker.com/desktop/) if you haven't already.
2. Clone this repo. Usually with `git clone https://github.com/njs-templates/aspnet-postgres-svelte.git`.
3. Delete the `.git/` folder from the project root. Alternatively, you can use [degit](https://github.com/Rich-Harris/degit) to do this for you.
4. Open the root of this directory and run the following to download npm packages.

```bash
cd frontend
yarn
```

5. Create a `.env` file at the root of the project and fill out the values with your preferences. You can just copy the `.env.example` to make sure it works, ***but the username and password should be changed in a production environment***.

6. While still in the root, run `docker-compose up -d` to create and run the Postgres database in the background. You can run `docker-compose down` to stop it.

7. While still in the root, run the following to install nuget packages. The aspnet-codegenerator is optional but recommended.

```bash
cd backend
dotnet restore
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet ef database update
dotnet run
```

8. Open localhost:[port] to make sure that the backend is working. Dotnet should tell you what port the app is running on if you're unsure.
9. Back in the root directory, run the following to start Vite and make sure that the frontend is working.

```bash
cd frontend
yarn dev
```

If you can see both pages and you can add, delete, and edit the todo items, you should be good to go.
