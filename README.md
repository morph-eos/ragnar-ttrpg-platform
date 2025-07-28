<div align="center">
  <table>
    <tr>
      <td align="center">
        <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/ragnar.svg" alt="Ragnar TTRPG" width="80" height="80" />
        <br><sub>The Platform</sub>
      </td>
      <td align="center">
        <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/heatpeakstudio.svg" alt="HeatPeak Studio" width="80" height="80" />
        <br><sub>From</sub>
      </td>
      <td align="center">
        <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/jugglehive.svg" alt="Juggle Hive" width="80" height="80" />
        <br><sub>To</sub>
      </td>
    </tr>
  </table>
</div>

# Ragnar TTRPG Platform - Technology Transition Phase (hp-jh-transition)

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)
[![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.2.2-brightgreen.svg)](https://spring.io/projects/spring-boot)
[![Angular](https://img.shields.io/badge/Angular-17.1-red.svg)](https://angular.io/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue.svg)](https://www.postgresql.org/)
[![Java](https://img.shields.io/badge/Java-17-orange.svg)](https://openjdk.org/)

## Table of Contents

- [Overview](#overview)
  - [Transition Context](#transition-context)
- [Architectural Evolution Journey](#architectural-evolution-journey)
  - [Technology Stack Progression](#technology-stack-progression)
  - [Migration Drivers](#migration-drivers)
- [Technology Stack](#technology-stack)
  - [Backend (Spring Boot 3.2.2)](#backend-spring-boot-322)
  - [Frontend (Angular 17.1)](#frontend-angular-171)
- [Project Structure](#project-structure)
- [Core Features](#core-features)
- [Development Setup](#development-setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Migration Lessons Learned](#migration-lessons-learned)
- [Team and Evolution](#team-and-evolution)
- [License](#license)
- [Related Repositories](#related-repositories)

## Overview

This repository represents the **technology transition phase** of the Ragnar TTRPG Platform, documenting the experimental architectural evolution during the active development of what was originally envisioned as a revolutionary digital TTRPG solution. This branch captures the intermediate stage where **HeatPeak Studio** explored enterprise technologies like Spring Boot and Angular, seeking to address the scalability and enterprise-readiness challenges identified in the initial MERN stack implementation.

**Development Context**: This transition phase represents the technical exploration period when the original commercial platform vision was being refined and upgraded. The experimentation with Java/Spring Boot and Angular was part of the effort to create a more robust, enterprise-grade solution that could better serve the intended market of digital-enhanced tabletop gaming. While this direction showed promise, the project's scope and resource requirements eventually led to the decision to preserve the work as a comprehensive technical portfolio rather than pursue full commercial completion.

### Transition Context

The `hp-jh-transition` branch demonstrates the strategic technology migration from document-based to relational architecture, serving as a crucial stepping stone in the platform's evolution toward enterprise-grade cloud-native implementation.

## Architectural Evolution Journey

### Technology Stack Progression

| Phase | Frontend | Backend | Database | Authentication |
|-------|----------|---------|----------|----------------|
| **Legacy (hp-main)** | React 18 + Vite | Node.js + Express | MongoDB + Mongoose | Session-based |
| **Transition (hp-jh-transition)** | Angular 17 + CLI | Spring Boot 3.2 + Maven | PostgreSQL + JPA | Spring Security |
| **Modern (jh-main)** | Angular 18 + NgRx | .NET Core + EF | PostgreSQL + Azure | Azure AD B2C |

### Migration Drivers

1. **Type Safety**: JavaScript → TypeScript → C# progression
2. **Data Modeling**: Document-based → Relational design patterns
3. **Enterprise Integration**: Simple auth → Spring Security → Azure AD
4. **Scalability**: Monolithic → Modular → Microservices architecture
5. **Cloud Readiness**: Local deployment → Container-ready → Azure-native

## Technology Stack

### Backend (Spring Boot 3.2.2)

- **Framework**: Spring Boot with auto-configuration and embedded Tomcat
- **Language**: Java 17 with modern language features
- **Database**: PostgreSQL 16 with JPA/Hibernate ORM
- **Build Tool**: Maven for dependency management and packaging
- **Architecture**: RESTful API with Spring MVC pattern

### Frontend (Angular 17.1)

- **Framework**: Angular with TypeScript for type safety
- **State Management**: @ngrx/store for reactive state management
- **Build Tool**: Angular CLI with Webpack bundling
- **Styling**: TailwindCSS for utility-first styling
- **HTTP Client**: Angular HttpClient with RxJS observables

### Database Evolution

- **From MongoDB**: Document-based flexible schema
- **To PostgreSQL**: Relational data modeling with constraints
- **ORM Transition**: Mongoose ODM → JPA/Hibernate
- **Query Language**: MongoDB queries → SQL with JPQL

## Project Structure

```text
hp-jh-transition/
├── backend/                    # Spring Boot application
│   ├── src/main/java/
│   │   └── com/heatpeakstudio/backend/
│   │       ├── BackendApplication.java     # Main Spring Boot application class
│   │       └── WebRoutingConfig.java       # SPA routing configuration
│   ├── src/main/resources/
│   │   └── application.properties          # Spring Boot configuration
│   ├── .mvn/                              # Maven wrapper directory
│   │   └── wrapper/
│   │       ├── maven-wrapper.jar          # Maven wrapper JAR
│   │       └── maven-wrapper.properties   # Maven wrapper configuration
│   ├── mvnw                               # Maven wrapper script (Unix)
│   ├── mvnw.cmd                           # Maven wrapper script (Windows)
│   ├── pom.xml                            # Maven dependencies and build configuration
│   ├── Dockerfile                         # Container configuration for deployment
│   ├── .gitignore                         # Backend Git ignore patterns
│   └── target/                            # Maven build output directory
├── frontend/                   # Angular application
│   ├── src/
│   │   ├── app/
│   │   │   ├── app.component.ts           # Root Angular component
│   │   │   ├── app.component.html         # Root component template
│   │   │   ├── app.component.css          # Root component styles
│   │   │   ├── app.component.spec.ts      # Root component tests
│   │   │   ├── app.module.ts              # Main application module
│   │   │   ├── app-routing.module.ts      # Angular routing configuration
│   │   │   ├── login/                     # Login component
│   │   │   │   ├── login.component.ts
│   │   │   │   ├── login.component.html
│   │   │   │   └── login.component.css
│   │   │   ├── main/                      # Main component
│   │   │   │   ├── main.component.ts
│   │   │   │   ├── main.component.html
│   │   │   │   └── main.component.css
│   │   │   ├── navbar/                    # Navigation component
│   │   │   │   ├── navbar.component.ts
│   │   │   │   ├── navbar.component.html
│   │   │   │   └── navbar.component.css
│   │   │   └── pages/                     # Feature pages
│   │   │       └── ttrpg/                 # TTRPG specific components
│   │   │           ├── ttrpg.component.ts
│   │   │           ├── ttrpg.component.html
│   │   │           └── ttrpg.component.css
│   │   ├── assets/                        # Static assets directory
│   │   │   ├── .gitkeep                   # Git placeholder for empty directory
│   │   │   ├── construction-under-kipp.gif # Construction placeholder image
│   │   │   ├── login.png                  # Login page image
│   │   │   ├── logo.png                   # Application logo
│   │   │   ├── logo.svg                   # Vector logo
│   │   │   └── logoborded.png             # Bordered logo variant
│   │   ├── index.html                     # Application shell
│   │   ├── main.ts                        # Angular bootstrap entry point
│   │   └── styles.css                     # Global application styles
│   ├── angular.json                       # Angular CLI configuration
│   ├── package.json                       # npm dependencies and scripts
│   ├── package-lock.json                  # npm dependency lock file
│   ├── tsconfig.json                      # TypeScript configuration
│   ├── tsconfig.app.json                  # TypeScript app-specific configuration
│   ├── tsconfig.spec.json                 # TypeScript testing configuration
│   ├── tailwind.config.js                 # TailwindCSS configuration
│   ├── .editorconfig                      # Editor configuration
│   ├── .gitignore                         # Frontend Git ignore patterns
│   └── README.md                          # Frontend-specific documentation
├── development/                # Development utilities and scripts
│   ├── Start_Backend.bat                  # Windows backend startup script
│   └── Start_Frontend.bat                 # Windows frontend startup script
├── .github/                               # GitHub Actions and workflows
│   └── workflows/
│       └── main.yml                       # CI/CD workflow configuration
├── design/                               # UI/UX Design Assets
│   ├── ui-mockup-legacy.svg               # Legacy UI design prototypes
│   └── character-page-mockup.svg          # Character page UI mockup
├── .gitignore                             # Git ignore patterns
├── LICENSE.md                             # Creative Commons license
└── README.md                              # This documentation
```

## Design Assets

### UI/UX Design Documentation

The `design/` directory contains the original UI design prototypes and mockups created during the transition phase. **All designs were created by Alessia Grassi using Figma** and exported as SVG assets for development reference:

- **ui-mockup-legacy.svg**: Legacy interface design prototypes showcasing the original vision for the Spring Boot + Angular implementation. These designs capture the intermediate UI concepts explored during the technology transition period, representing the bridge between the legacy MERN implementation and the modern enterprise architecture.

- **character-page-mockup.svg**: Comprehensive mockup of the character page interface, including character sheet layouts, attribute displays, and interactive elements designed for the TTRPG gaming experience. These designs integrate **Paolo Nicola Leovino's game mechanics** to ensure optimal user interaction patterns.

**Design Evolution Context**: These design artifacts document the UI/UX exploration during the platform's architectural transition, demonstrating the iterative design process that informed the eventual modern implementation in the `jh-main` branch.

## Core Features

### Transition Architecture

- **SPA Integration**: Spring Boot serves Angular static files with proper routing
- **API Design**: RESTful endpoints with JSON request/response patterns
- **Error Handling**: Centralized error pages with Angular fallback routing
- **Development Workflow**: Separate development servers with proxy configuration

### Spring Boot Benefits

- **Auto-Configuration**: Minimal configuration required for common scenarios
- **Dependency Injection**: Enterprise-grade IoC container
- **Data Access**: Spring Data JPA for repository pattern implementation
- **Security**: Built-in security features ready for enterprise integration
- **Testing**: Comprehensive testing framework with mock support

### Angular Advantages

- **Type Safety**: Full TypeScript integration with compile-time error checking
- **Component Architecture**: Reusable components with dependency injection
- **Reactive Programming**: RxJS observables for asynchronous data handling
- **CLI Tools**: Powerful development tools for scaffolding and building
- **Enterprise Ready**: Built-in features for large-scale application development

## Development Setup

### Prerequisites

- Java 17+ (OpenJDK recommended)
- Node.js 18+ with npm
- PostgreSQL 16+
- Maven 3.6+
- Angular CLI 17+

### Installation

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd transition-repo
   git checkout hp-jh-transition
   ```

2. **Backend Setup**

   ```bash
   cd backend
   mvn clean install
   java -jar target/backend.jar
   ```

3. **Frontend Setup**

   ```bash
   cd frontend
   npm install
   ng serve
   ```

4. **Database Setup**

   ```sql
   -- Create PostgreSQL database
   CREATE DATABASE ragnar_ttrpg;
   -- Configure connection in application.properties
   ```

### Quick Start (Windows)

Use the provided batch scripts for rapid development:

```batch
# Start backend (from development directory)
Start_Backend.bat

# Start frontend (from development directory)  
Start_Frontend.bat
```

## Migration Lessons Learned

### Architectural Decisions

1. **Database Migration Strategy**
   - Document → Relational mapping challenges
   - Data type conversion and normalization
   - Performance implications of JOIN operations vs embedded documents

2. **Frontend Framework Transition**
   - Component lifecycle management differences
   - State management evolution (useState → @ngrx/store)
   - Routing and navigation pattern changes

3. **Backend Technology Shift**
   - Express middleware → Spring Boot auto-configuration
   - JavaScript flexibility → Java type safety
   - npm ecosystem → Maven central repository

### Challenges Encountered

- **Learning Curve**: Team adaptation to Java and Angular ecosystems
- **Tooling Setup**: IDE configuration and build process optimization
- **Integration Complexity**: Frontend-backend communication patterns
- **Performance Tuning**: JVM optimization vs Node.js event loop

### Success Factors

- **Incremental Migration**: Gradual transition reducing risk
- **Documentation**: Comprehensive knowledge transfer
- **Team Training**: Skill development in new technologies
- **Prototype Validation**: Proof of concept before full migration

## Team and Evolution

### HeatPeak Studio Transition Phase

**Development Team:**
- **Stefano Sciacovelli**: [GitHub Profile](https://github.com/M04ph3u2) - Lead developer and architecture

**Design & Game Development Support:**

- **Alessia Grassi**: [LinkTree Page](https://linktr.ee/alessiagrassi) - UI/UX design concepts and mockups created in Figma
- **Paolo Nicola Leovino**: [LinkedIn Profile](https://www.linkedin.com/in/paolonicolaleovino/) - Game mechanics design and user interaction patterns

**Phase Details:**

- **Period**: Technology evaluation and migration experimentation
- **Focus**: Enterprise architecture preparation and technology stack evaluation
- **Learning**: Java/Spring Boot and Angular ecosystem mastery
- **Goal**: Foundation for potential team collaboration in modern implementation

### Path to JuggleHive Team Implementation

This transition phase provided crucial insights that influenced the final collaborative architecture in `jh-main`:

- **Technology Evaluation**: Assessment of Java/Spring vs .NET Core approaches
- **Cloud-Native Design**: Understanding of enterprise deployment patterns
- **Security Architecture**: Preparation for Azure AD B2C integration
- **Scalability Patterns**: Microservices architecture foundation
- **Development Practices**: DevOps and CI/CD pipeline preparation

**Team Collaboration**: While this transition branch was developed primarily by **Stefano Sciacovelli** ([GitHub Profile](https://github.com/M04ph3u2)), the insights gained directly contributed to the later collaborative effort in `jh-main` involving the complete team: Davide Gritta (Backend/Database), Gianluca Rossetti (Full-Stack Development), Alessia Grassi (UI/UX Design), and Paolo Nicola Leovino (Game Design).

## License

This project is licensed under the [Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License](https://creativecommons.org/licenses/by-nc-nd/4.0/).

### Commercial Use

For commercial licensing inquiries, please contact the development team.

## Related Repositories

- **hp-main**: Legacy MERN stack implementation
- **jh-main**: Modern Angular/.NET Core implementation
- **jh-devops**: DevOps infrastructure and CI/CD pipelines
- **jh-cloud**: Cloud services and infrastructure as code
- **main**: Unified repository with historical context

---

*This transition phase represents the technological bridge between legacy and modern implementations, demonstrating the evolution of the Ragnar TTRPG Platform toward enterprise-grade architecture.*
