<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/ragnar.svg" alt="Ragnar TTRPG" width="100" height="100" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/heatpeakstudio.svg" alt="HeatPeak Studio" width="100" height="100" />
</div>

# Ragnar TTRPG Platform - Legacy Implementation (hp-main)

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)
[![Node.js](https://img.shields.io/badge/Node.js-20.x-green.svg)](https://nodejs.org/)
[![React](https://img.shields.io/badge/React-18.x-blue.svg)](https://reactjs.org/)
[![MongoDB](https://img.shields.io/badge/MongoDB-6.x-green.svg)](https://www.mongodb.com/)
[![Express](https://img.shields.io/badge/Express-4.x-black.svg)](https://expressjs.com/)

## Table of Contents

- [Overview](#overview)
  - [Legacy Architecture Context](#legacy-architecture-context)
- [Live Demo](#live-demo)
- [Technology Stack](#technology-stack)
  - [Backend (Node.js/Express)](#backend-nodejsexpress)
  - [Frontend (React)](#frontend-react)
  - [Database Design](#database-design)
- [Project Structure](#project-structure)
- [Core Features](#core-features)
  - [Character Management System](#character-management-system)
  - [AI-Generated Reference Image System](#ai-generated-reference-images-system)
  - [Legacy Authentication](#legacy-authentication)
  - [API Architecture](#api-architecture)
- [Development Setup](#development-setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Architecture Evolution](#architecture-evolution)
  - [From Legacy to Modern](#from-legacy-to-modern)
- [License](#license)
- [Related Repositories](#related-repositories)

## Overview

This repository represents the **legacy implementation** of the Ragnar TTRPG Platform, originally conceived as an innovative digital solution to revolutionize tabletop role-playing game experiences. The project was designed to create hybrid tools that would enhance both online and in-person gaming sessions, offering a superior alternative to existing market solutions through modern technology integration.

**Project Context**: This legacy implementation by **HeatPeak Studio** represents the foundational phase of what was intended to be a commercial TTRPG platform. After extensive development and multiple technical iterations, the ambitious scope of creating a complete market-ready solution proved challenging given available time and financial resources. The project has since been preserved and documented to showcase the technical evolution and development expertise achieved during its active development phase.

### Legacy Architecture Context

The `hp-main` branch demonstrates a traditional **MERN stack** approach (MongoDB, Express.js, React, Node.js) with document-based data modeling, representing the initial phase of the platform's development when it focused on core TTRPG functionality without cloud integration.

## Live Demo

**[Try the Live Demo](https://ragnar-legacy.onrender.com/rpg/)**

This legacy implementation features a **fully functional live demo** showcasing the complete TTRPG platform capabilities. While other branches in this repository represent various technological transitions and may have incomplete frontend implementations, this legacy version provides a comprehensive demonstration of some of the core platform and game world building's ideas.

> **Note**: The demo runs on a free hosting tier, so initial loading may take 30-60 seconds as the server spins up from sleep mode.

## Technology Stack

### Backend (Node.js/Express)

- **Runtime**: Node.js 20.x with ES6+ features
- **Framework**: Express.js 4.x with middleware architecture
- **Database**: MongoDB 6.x with Mongoose ODM
- **Security**: Helmet.js for security headers, CORS configuration
- **HTTP Client**: Native fetch API and Axios for external requests

### Frontend (React)

- **Framework**: React 18.x with functional components and hooks
- **Routing**: React Router DOM v6 for client-side navigation
- **Styling**: Tailwind CSS with Material Tailwind components and Headless UI
- **Build Tool**: Vite for fast development and optimized builds
- **HTTP Client**: Axios for API communication
- **TypeScript**: Basic TypeScript configuration for type checking

### Database Design

- **Type**: Document-based (MongoDB)
- **Schema**: Mongoose models with embedded documents
- **Characters**: Flexible document structure with nested abilities
- **Classes/Races**: JSON-based configurations with dynamic properties

## Project Structure

```text
project-root/
├── backend/                    # Node.js/Express API server
│   ├── app.js                 # Main Express application with security and CORS
│   ├── apiRouter.js           # Central API routing hub
│   ├── routes/
│   │   └── rpg.js            # RPG game mechanics routes
│   ├── controllers/
│   │   └── rpg.js            # RPG game mechanics controller
│   ├── models/
│   │   ├── characters.js      # MongoDB character schema with Mongoose
│   │   ├── races.js          # Race definitions and racial traits
│   │   ├── states.js         # Game states and conditions
│   │   ├── classes.js        # Character classes and progression
│   │   ├── items.js          # Items and equipment
│   │   ├── spells.js         # Spells and magical abilities
│   │   └── abilities.js      # Abilities and skills
│   ├── static/
│   │   └── rpg/
│   │       └── references/   # AI-generated reference images
│   │           ├── characters_*/  # Character reference images
│   │           ├── races_*/      # Race illustration images  
│   │           └── states_*/     # Game state visual icons
│   ├── package.json          # Backend dependencies and scripts
│   └── package-lock.json     # Backend dependency lock file
├── frontend/                  # React client application
│   ├── src/
│   │   ├── App.jsx           # Main application component with routing
│   │   ├── index.jsx         # React entry point and root render
│   │   ├── Main.jsx          # Landing page (construction notice)
│   │   ├── NotFoundPage.jsx  # 404 error page component
│   │   └── routes/
│   │       ├── Rpg.jsx       # RPG navigation hub with dynamic loading
│   │       └── rpg/          # RPG feature components
│   │           ├── Sheets.jsx    # Character sheet viewer and management
│   │           ├── Classes.jsx   # Character classes and abilities
│   │           ├── Showcase.jsx  # Races and states display component
│   │           ├── Private.jsx   # Authentication and registration
│   │           └── functions.js  # Utility functions for RPG mechanics
│   ├── public/
│   │   ├── construction-under-kipp.gif  # Construction page asset
│   │   ├── logo.png          # Application logo
│   │   └── logo.svg          # Application logo (SVG)
│   ├── package.json          # Frontend dependencies and scripts
│   ├── package-lock.json     # Frontend dependency lock file
│   ├── vite.config.js        # Vite build configuration
│   ├── vite.config.js.timestamp-*  # Vite config timestamps
│   ├── tailwind.config.js    # TailwindCSS configuration
│   ├── postcss.config.js     # PostCSS configuration
│   ├── tsconfig.json         # TypeScript configuration
│   ├── index.css             # Global CSS styles
│   └── index.html            # Main HTML template
├── .github/
│   └── workflows/
│       └── main.yml          # GitHub Actions CI/CD pipeline
├── .gitignore                # Git ignore patterns
├── package.json              # Root package.json for workspace
├── package-lock.json         # npm lock file for consistent installs
├── LICENSE.md                # Creative Commons license
└── README.md                 # This documentation
```

## Core Features

### Character Management System

- **Character Sheets**: Dynamic character sheet display with MongoDB document flexibility
- **Character Classes**: Class-based progression system with abilities and bonuses
- **Character Races**: Racial traits and bonuses affecting character capabilities
- **Game States**: Status effects and conditions management

### AI-Generated Reference Images System

The platform features an innovative **AI-generated imagery system** that provides visual references for characters, races, and game states:

#### Image Organization

- **Storage**: Images stored in `backend/static/rpg/references/` directory
- **Naming Convention**: `{type}_{mongoObjectId}_{imageIndex}.{extension}`
  - `characters_64ff1e2eb54467e9c99031ba_0.png` - Character reference image
  - `races_6509e0cfa44ab0dcb1afb524_0.png` - Race reference image  
  - `states_650af11799d5f2f359e65c95_0.jpg` - Game state visual reference

#### Database Integration

Each MongoDB document includes a `references` field:

```javascript
references: {
  type: [String],        // Array of image filenames
  default: []           // Empty array if no images
}
```

#### API Access

Images are served through a dedicated endpoint:

```javascript
GET /api/rpg/references/:imgName
// Serves images from backend/static/rpg/references/ directory
```

#### Visual Content Categories

- **Character References**: AI-generated portraits and character visualizations
- **Race Illustrations**: Visual representations of different fantasy races
- **State Icons**: Status effect and condition imagery for game mechanics

This system allows the platform to provide rich visual context for TTRPG elements without requiring manual artwork creation, leveraging AI to generate consistent and thematic imagery.

### Legacy Authentication

- Simple session-based authentication (pre-Azure AD B2C)
- Basic user registration and login functionality
- Character ownership and access control

### API Architecture

- **RESTful Design**: Standard HTTP methods with JSON responses
- **Route Organization**: Centralized routing through `apiRouter.js` with modular route files
- **Controller Pattern**: Business logic separated in `controllers/` directory
- **Error Handling**: Basic try-catch patterns with console logging
- **CORS Configuration**: Configured for HeatPeak Studio domain (legacy)

## Development Setup

### Prerequisites

- Node.js 20.x or higher
- MongoDB 6.x (local or cloud instance)
- npm or yarn package manager

### Installation

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd <project-directory>
   git checkout hp-main
   ```

2. **Backend Setup**

   ```bash
   cd backend
   npm install
   npm start
   ```

3. **Frontend Setup**

   ```bash
   cd frontend
   npm install
   npm run dev
   ```

4. **Database Setup**

   ```bash
   # Ensure MongoDB is running locally or configure connection string
   # Import sample data if needed
   mongoimport --db ragnar --collection characters --file database/sample_data.json
   ```

5. **AI Reference Images**

   The system includes pre-generated AI reference images in `backend/static/rpg/references/`. These images are automatically served through the Express static middleware and linked to MongoDB documents via the `references` field array.

## Architecture Evolution

### From Legacy to Modern

This legacy implementation served as the foundation for the modern platform, demonstrating the evolution from:

**Legacy (hp-main)**:

- MongoDB document storage
- Express.js middleware architecture  
- React with component-level state
- Basic authentication
- Monolithic deployment

**Modern (jh-main)**:

- PostgreSQL with Entity Framework
- .NET Core Web API architecture
- Angular with NgRx state management
- Azure AD B2C authentication
- Microservices with Azure deployment

## License

This project is licensed under the [Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License](https://creativecommons.org/licenses/by-nc-nd/4.0/).

### Commercial Use

For commercial licensing inquiries, please contact the development team.

## Related Repositories

- **hp-jh-transition**: Spring Boot/Angular transition implementation
- **jh-main**: Modern Angular/.NET Core implementation
- **jh-devops**: DevOps infrastructure and CI/CD pipelines  
- **jh-cloud**: Cloud services and infrastructure as code
- **main**: Unified repository with historical context

---

*This legacy implementation represents the foundational work that evolved into the modern Ragnar TTRPG Platform. While maintained for reference, active development continues in the jh-main branch with modern cloud-native architecture.*
