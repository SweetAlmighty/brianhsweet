# brianhsweet

[![Website](https://img.shields.io/website?url=https%3A%2F%2Fbrianhsweet.com&label=website)](https://brianhsweet.com)
[![Client](https://github.com/SweetAlmighty/brianhsweet/actions/workflows/Client.yml/badge.svg)](https://github.com/SweetAlmighty/brianhsweet/actions/workflows/Client.yml)
[![Server](https://github.com/SweetAlmighty/brianhsweet/actions/workflows/Server.yml/badge.svg)](https://github.com/SweetAlmighty/brianhsweet/actions/workflows/Server.yml)
[![Last commit](https://img.shields.io/github/last-commit/SweetAlmighty/brianhsweet)](https://github.com/SweetAlmighty/brianhsweet/commits/main)
[![Dependabot](https://img.shields.io/badge/dependabot-enabled-025e8c?logo=dependabot)](.github/dependabot.yml)

![.NET](https://img.shields.io/badge/.NET-10-512bd4?logo=dotnet)
![React](https://img.shields.io/badge/React-19-61dafb?logo=react&logoColor=black)
![TypeScript](https://img.shields.io/badge/TypeScript-6-3178c6?logo=typescript&logoColor=white)
![Vite](https://img.shields.io/badge/Vite-8-646cff?logo=vite&logoColor=white)

Codebase for my personal website: a React single-page app backed by a small ASP.NET Core API that serves data from Azure Blob Storage.

## Project Structure

### Client

Built with React 19, TypeScript, Vite, and [Ant Design](https://ant.design). Deployed to Azure Static Web Apps.

### Server

An ASP.NET Core Web API, which stream files from Azure Blob Storage. Deployed to Azure App Service.

## Getting Started

### Prerequisites

- Node.js (LTS)
- .NET SDK 10 (see [global.json](global.json))

### Client

```sh
cd Client
npm ci
npm run dev
```

### Server


```sh
dotnet run --project Server
```

## CI/CD

GitHub Actions run on pushes and pull requests to `main`, scoped by path:

- **Client** (`Client.yml`): lint, format check, then build and deploy to Azure Static Web Apps. Pull requests get preview environments.
- **Server** (`Server.yml`): build, `dotnet format --verify-no-changes`, publish, then deploy to Azure on push.
