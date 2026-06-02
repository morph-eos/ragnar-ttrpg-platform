<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/ragnar.svg" alt="Ragnar TTRPG" width="100" height="100" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/heatpeakstudio.svg" alt="HeatPeak Studio" width="100" height="100" />
</div>

# Ragnar TTRPG Platform — Legacy Implementation

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)
[![Node.js](https://img.shields.io/badge/Node.js-20.x-green.svg)](https://nodejs.org/)
[![React](https://img.shields.io/badge/React-18.x-blue.svg)](https://reactjs.org/)
[![MongoDB](https://img.shields.io/badge/MongoDB-6.x-green.svg)](https://www.mongodb.com/)

## Overview

The original MERN stack implementation of the Ragnar TTRPG Platform, developed by **HeatPeak Studio**. This is the foundational phase of the platform, featuring document-based data modeling, AI-generated reference images, and a browser-based character/rules showcase.

**[Live Demo](https://ragnar-legacy.onrender.com/rpg/)** — Initial loading may take 30-60 seconds (free hosting tier).

> **Repository note — what you're looking at.** This directory surfaces the
> **original MERN prototype** that HeatPeak Studio built first. The `hp-main`
> branch's own commit history *also* contains the studio's later experiment
> with a Spring Boot + Angular rewrite, which was eventually archived; that
> transition is presented, fully assembled, in
> [`../hp-jh-transition/`](../hp-jh-transition/). So if `git log` here surfaces
> Java or Angular commits, that is the same HeatPeak repository's history —
> this folder deliberately presents the MERN codebase that came first.

## Architecture

| Component | Technology |
|-----------|-----------|
| Runtime | Node.js 20.x |
| Framework | Express.js 4.x |
| Frontend | React 18.x + Vite |
| Database | MongoDB 6.x + Mongoose |
| Styling | Tailwind CSS + Material Tailwind |
| Security | Helmet.js, CORS |

Key features:

- **Character & Rules Data**: Character sheets, classes with progression, races with traits, and game states, modeled as Mongoose documents
- **AI Reference Images**: AI-generated portraits for characters, races, and states stored in `backend/static/rpg/references/` with MongoDB document integration via `references` field arrays
- **Security Hardening**: Helmet.js headers and CORS configured in `app.js` (note: end-user authentication was scaffolded but never implemented — `Private.jsx` is an empty stub)

## Project Structure

```text
├── backend/
│   ├── app.js                  # Express application with security middleware
│   ├── apiRouter.js            # Central API routing
│   ├── routes/rpg.js           # RPG game mechanics routes
│   ├── controllers/rpg.js      # RPG business logic
│   ├── models/                 # Mongoose schemas (characters, races, classes,
│   │                           #   items, spells, abilities, states)
│   └── static/rpg/references/  # AI-generated reference images
├── frontend/
│   ├── src/
│   │   ├── App.jsx             # Main app with routing
│   │   └── routes/rpg/         # RPG feature components
│   │       ├── Sheets.jsx      # Character sheet management
│   │       ├── Classes.jsx     # Character classes and abilities
│   │       ├── Showcase.jsx    # Races and states display
│   │       └── Private.jsx     # Empty stub (auth was planned, not built)
│   ├── vite.config.js
│   └── tailwind.config.js
├── .github/workflows/main.yml  # CI/CD pipeline
├── LICENSE.md
└── README.md
```

## Getting Started

### Prerequisites

- Node.js 20.x+
- MongoDB 6.x
- npm

### Installation

```bash
git checkout hp-main

# Backend
cd backend && npm install && npm start

# Frontend (separate terminal)
cd frontend && npm install && npm run dev
```

## License

[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/) — For commercial inquiries, contact the development team.

---

<sub>Part of the **[Ragnar TTRPG Platform](../README.md)** monorepo — see the root README for the full evolution across all phases.</sub>
