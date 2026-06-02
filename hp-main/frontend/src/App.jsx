/**
 * RAGNAR TTRPG PLATFORM - LEGACY FRONTEND APPLICATION (HP-MAIN BRANCH)
 * =====================================================================
 * 
 * File: App.jsx
 * Purpose: Root application component for legacy React frontend
 * 
 * ARCHITECTURAL OVERVIEW:
 * This file represents the main application entry point for the HeatPeak Studio
 * legacy implementation of the Ragnar TTRPG Platform. This version uses React
 * with React Router for client-side routing, Material Tailwind for UI components,
 * and Axios for HTTP communication with the Node.js/Express backend.
 * 
 * LEGACY CONTEXT:
 * - Frontend Framework: React with functional components and hooks
 * - Routing: React Router DOM v6 for single-page application navigation
 * - Backend Integration: Communicates with Node.js/Express API at /api routes
 * - State Management: Component-level state using useState and useEffect hooks
 * - Styling: Tailwind CSS with custom button components and Material Tailwind
 * 
 * EVOLUTION PATH:
 * This legacy implementation was later modernized to use:
 * - Angular 18 (jh-main branch) with TypeScript
 * - .NET Core Web API backend with Entity Framework
 * - PostgreSQL database instead of MongoDB
 * - Azure cloud integration for file storage and deployment
 * 
 * NAVIGATION STRUCTURE:
 * - Root path (/): Landing page with construction notice
 * - RPG section (/rpg): Main TTRPG application with character sheets, classes, races
 * - Dynamic routing (/rpg/:button/*): Nested routing for different RPG features
 * 
 * Team: HeatPeak Studio (Legacy Implementation)
 * Modern Implementation: JuggleHive Team (jh-main branch)
 * Last Updated: Legacy version preserved for architectural reference
 */

import { Routes, Route, Link } from 'react-router-dom';
import Main from './Main';
import NotFoundPage from './NotFoundPage';
import Rpg from './routes/Rpg';

/**
 * MAIN APPLICATION COMPONENT
 * Provides the root layout with navigation bar and routing configuration
 * 
 * NAVIGATION BAR:
 * - Simple header with logo linking back to home page
 * - Fixed positioning with basic styling
 * - Logo served from public directory (/logo.png)
 * 
 * ROUTING CONFIGURATION:
 * - "/" : Main landing page (construction notice)
 * - "/rpg" : RPG application hub
 * - "/rpg/:button/*" : Dynamic routing for RPG subsections (sheets, classes, races, etc.)
 * - "*" : Catch-all route for 404 pages
 * 
 * LEGACY ARCHITECTURE NOTES:
 * This uses React Router v6 pattern with nested routing for the RPG section.
 * The modern Angular implementation (jh-main) uses Angular Router with guards
 * and lazy loading for better performance and security.
 */
export default function App() {
  return (
    <div className="App">
      {/* Navigation Header - Simple logo-based navigation */}
      <div id="navbar">
        <Link to="/">
          <img src="/logo.png" alt="Logo" />
        </Link>
        {/* Note: Additional navbar elements would be added here in production */}
      </div>
      
      {/* Main Application Routing */}
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path="/rpg" element={<Rpg />} />
        <Route path="/rpg/:button/*" element={<Rpg />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </div>
  );
};