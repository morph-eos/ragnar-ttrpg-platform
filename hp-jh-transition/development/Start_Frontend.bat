@REM RAGNAR TTRPG PLATFORM - ANGULAR FRONTEND STARTUP SCRIPT
@REM =======================================================
@REM 
@REM File: Start_Frontend.bat
@REM Purpose: Windows batch script for starting Angular frontend during transition phase
@REM 
@REM DEVELOPMENT WORKFLOW:
@REM This script automates the Angular frontend startup process, providing developers
@REM with browser auto-opening and live development server during the transition
@REM from React to Angular architecture.
@REM 
@REM ANGULAR CLI INTEGRATION:
@REM Uses Angular CLI (ng serve) to:
@REM 1. Start the Webpack development server
@REM 2. Enable hot module replacement for live reloading
@REM 3. Serve the application on http://localhost:4200
@REM 4. Watch for file changes and rebuild automatically
@REM 5. Provide source maps for debugging
@REM 
@REM BROWSER AUTOMATION:
@REM Opens the default browser automatically to improve developer experience
@REM and reduce manual steps in the development workflow.
@REM 
@REM TRANSITION CONTEXT:
@REM This script represents the evolution from:
@REM - Legacy (hp-main): npm run dev with Vite (React)
@REM - Transition (hp-jh-transition): ng serve with Angular CLI
@REM - Modern (jh-main): Azure-hosted Angular with CI/CD pipeline
@REM 
@REM Team: HeatPeak Studio (Transition Phase)
@echo off

@REM Auto-open browser to application URL
@REM Improves developer experience by automatically navigating to the app
start http://localhost:4200/

@REM Navigate to the frontend directory containing Angular project
cd ../frontend/

@REM Build and run the Angular application
echo Starting the frontend...
@REM ng serve command:
@REM - Starts Angular development server with live reload
@REM - Enables hot module replacement for instant updates
@REM - Watches TypeScript files for changes and recompiles
@REM - Serves application on http://localhost:4200 by default
@REM - Provides detailed error messages and debugging information
ng serve