@echo off

REM Opening the URL
start http://localhost:4200/

REM Navigate to the frontend directory
cd ../frontend/

REM Build and run the Angular application
echo Starting the frontend...
ng serve