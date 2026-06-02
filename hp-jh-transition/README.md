<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/ragnar.svg" alt="Ragnar TTRPG" width="80" height="80" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/heatpeakstudio.svg" alt="HeatPeak Studio" width="80" height="80" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/jugglehive.svg" alt="Juggle Hive" width="80" height="80" />
</div>

# Ragnar TTRPG Platform — Technology Transition Phase

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)
[![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.2.2-brightgreen.svg)](https://spring.io/projects/spring-boot)
[![Angular](https://img.shields.io/badge/Angular-17.1-red.svg)](https://angular.io/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue.svg)](https://www.postgresql.org/)

## Overview

The intermediate implementation of the Ragnar TTRPG Platform, documenting the migration from MERN stack to enterprise technologies. This branch captures the transition from **HeatPeak Studio** to **Juggle Hive**, exploring Spring Boot and Angular as a stepping stone toward the modern .NET Core architecture.

### Technology Stack Progression

| Phase | Frontend | Backend | Database |
|-------|----------|---------|----------|
| Legacy (hp-main) | React 18 + Vite | Node.js + Express | MongoDB |
| **Transition (this)** | **Angular 17 + CLI** | **Spring Boot 3.2 + Maven** | **PostgreSQL + JPA** |
| Modern (jh-main) | Angular 18 + NgRx | .NET Core + EF | PostgreSQL + Azure |

## Architecture

| Component | Technology |
|-----------|-----------|
| Backend | Spring Boot 3.2.2 (Java 17) |
| Frontend | Angular 17.1 + TypeScript |
| Database | PostgreSQL 16 + JPA/Hibernate |
| Build | Maven (backend), Angular CLI (frontend) |
| Styling | TailwindCSS |
| State | @ngrx/store |

Key migration patterns:

- **Database**: MongoDB documents → PostgreSQL relational schema with JPA
- **Type Safety**: JavaScript → TypeScript → (eventually C#)
- **Architecture**: Monolithic → Modular with Spring Boot auto-configuration

## Project Structure

```text
├── backend/
│   ├── src/main/java/com/heatpeakstudio/backend/
│   │   ├── BackendApplication.java   # Spring Boot main class
│   │   └── WebRoutingConfig.java     # SPA routing configuration
│   ├── pom.xml                       # Maven dependencies
│   └── Dockerfile
├── frontend/
│   ├── src/app/
│   │   ├── login/                    # Login component
│   │   ├── main/                     # Main component
│   │   ├── navbar/                   # Navigation component
│   │   └── pages/ttrpg/             # TTRPG components
│   ├── angular.json
│   └── package.json
├── development/
│   ├── Start_Backend.bat             # Windows backend startup
│   └── Start_Frontend.bat            # Windows frontend startup
├── design/
│   ├── ui-mockup-legacy.svg          # Legacy UI prototypes (Alessia Grassi, Figma)
│   └── character-page-mockup.svg     # Character page mockup (Alessia Grassi, Figma)
├── .github/workflows/main.yml
├── LICENSE.md
└── README.md
```

## Getting Started

### Prerequisites

- Java 17+, Maven 3.6+
- Node.js 18+, Angular CLI 17+
- PostgreSQL 16+

### Installation

```bash
git checkout hp-jh-transition

# Backend
cd backend && mvn clean install && java -jar target/backend.jar

# Frontend (separate terminal)
cd frontend && npm install && ng serve

# Database
psql -c "CREATE DATABASE ragnar_ttrpg;"
```

Windows users can use `development/Start_Backend.bat` and `development/Start_Frontend.bat`.

## License

[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/) — For commercial inquiries, contact the development team.

---

<sub>Part of the **[Ragnar TTRPG Platform](../README.md)** monorepo — see the root README for the full evolution across all phases.</sub>
