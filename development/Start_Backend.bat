@echo off

REM Navigate to the backend directory
cd ../backend/

REM Build and run the Spring Boot application
echo Building the backend...
call mvn clean install
echo Starting the backend...
java -jar target/backend.jar