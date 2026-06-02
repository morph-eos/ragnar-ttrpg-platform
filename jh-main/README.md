<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/ragnar.svg" alt="Ragnar TTRPG" width="100" height="100" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/jugglehive.svg" alt="Juggle Hive" width="100" height="100" />
</div>

# Ragnar TTRPG Platform — Main Application

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)
[![Angular](https://img.shields.io/badge/Angular-18-red.svg)](https://angular.io/)
[![.NET Core](https://img.shields.io/badge/.NET%20Core-8-purple.svg)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue.svg)](https://www.postgresql.org/)

## Overview

The most advanced implementation of the Ragnar TTRPG Platform, developed by the complete **Juggle Hive** team. This branch represents the culmination of the platform's technical evolution, featuring a modern .NET 8 API, an Angular SPA, a PostgreSQL database, and Azure File Storage for asset hosting.

## Architecture

| Component | Technology |
|-----------|-----------|
| API Server | .NET Core 8 + Entity Framework Core |
| Frontend | Angular 18 + TypeScript + TailwindCSS |
| Database | PostgreSQL (Npgsql provider) |
| Cloud / Storage | Azure File Storage (asset hosting via SAS) |
| CI/CD | GitHub Actions → GHCR image, deploy dispatched to an Azure VM (see `jh-devops`) |
| Container | Docker (multi-stage build, 5 stages) |

Key capabilities:

- Complete TTRPG game mechanics (characters, skills, items, classes, regions)
- Azure File Storage integration with SAS-based asset access (`AzureFileService`)
- RESTful API with 23 controllers, 22 models, 22 service interfaces

> No end-user authentication is implemented in this codebase; the `User`
> entity and controller exist, but login/identity was not built.

## Project Structure

```text
├── JuggleHiveWebapp.Server/
│   ├── Controllers/              # API controllers (23 files)
│   ├── Models/                   # Entity models + DB context (22 files)
│   ├── Services/
│   │   ├── Interfaces/           # Service contracts (22 files)
│   │   └── [implementations]     # Business logic (22 files)
│   ├── Program.cs                # Application startup
│   └── appsettings.json
├── jugglehivewebapp.client/
│   ├── src/app/
│   │   ├── components/           # UI component library
│   │   ├── services/             # Angular services
│   │   └── directives/           # Custom directives
│   ├── angular.json
│   └── package.json
├── database/
│   ├── ttrpg_postgres.sql        # Schema definition
│   └── sample_data.sql           # Test data
├── design/
│   ├── jugglehive-ui-design.svg  # UI mockups (Alessia Grassi, Figma)
│   └── ragnar-ui-design.svg      # Platform design concepts (Alessia Grassi, Figma)
├── JuggleHiveWebapp.sln
├── Dockerfile
├── LICENSE.md
└── README.md
```

## Getting Started

### Prerequisites

- .NET 8 SDK
- Node.js 18+
- PostgreSQL 14+

### Installation

```bash
git checkout jh-main

# Database
createdb ragnar_ttrpg
psql -d ragnar_ttrpg -f database/ttrpg_postgres.sql
psql -d ragnar_ttrpg -f database/sample_data.sql  # optional

# Backend
cd JuggleHiveWebapp.Server && dotnet restore && dotnet run

# Frontend (separate terminal)
cd jugglehivewebapp.client && npm install && npm start
```

Access at `https://localhost:4200` (frontend) and `https://localhost:7154` (API).

### Docker

```bash
docker build -t ragnar-ttrpg-platform .
docker run -p 80:8080 ragnar-ttrpg-platform
```

## Development Team

- **Davide Gritta** ([GitHub](https://github.com/GrittaGit)) — Backend Developer, Database Designer
- **Gianluca Rossetti** ([GitHub](https://github.com/Ross9519)) — Full-Stack Developer
- **Stefano Sciacovelli** ([GitHub](https://github.com/morph-eos)) — DevOps, Automation
- **Alessia Grassi** ([LinkTree](https://linktr.ee/alessiagrassi)) — UI/UX Designer (Figma)
- **Paolo Nicola Leovino** ([LinkedIn](https://www.linkedin.com/in/paolonicolaleovino/)) — Game Designer

## License

[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/) — For commercial inquiries, contact the development team.

---

<sub>Part of the **[Ragnar TTRPG Platform](../README.md)** monorepo — see the root README for the full evolution across all phases.</sub>
