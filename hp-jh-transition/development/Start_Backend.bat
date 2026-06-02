@REM RAGNAR TTRPG PLATFORM - SPRING BOOT BACKEND STARTUP SCRIPT
@REM ===========================================================
@REM 
@REM File: Start_Backend.bat  
@REM Purpose: Windows batch script for starting Spring Boot backend during transition phase
@REM 
@REM DEVELOPMENT WORKFLOW:
@REM This script automates the backend startup process during the transition from
@REM MERN stack to Spring Boot architecture, providing developers with a simple
@REM way to build and run the Java backend application.
@REM 
@REM MAVEN BUILD PROCESS:
@REM 1. mvn clean install: Cleans target directory and builds the application
@REM 2. Downloads dependencies defined in pom.xml
@REM 3. Compiles Java source code and runs tests
@REM 4. Packages the application as a JAR file (backend.jar)
@REM 5. Installs the artifact in local Maven repository
@REM 
@REM EXECUTION FLOW:
@REM 1. Navigate to backend directory containing pom.xml
@REM 2. Execute Maven clean install command
@REM 3. Run the packaged JAR file with Java 17+
@REM 4. Spring Boot starts embedded Tomcat server on port 8080
@REM 
@REM TRANSITION CONTEXT:
@REM This script bridges the gap between:
@REM - Legacy (hp-main): Node.js with npm start
@REM - Transition (hp-jh-transition): Java with Maven
@REM - Modern (jh-main): .NET Core with dotnet run
@REM 
@REM Team: HeatPeak Studio (Transition Phase)
@echo off

@REM Navigate to the backend directory containing Maven project
cd ../backend/

@REM Build and run the Spring Boot application
echo Building the backend...
@REM Clean install: Removes old build artifacts and creates fresh build
@REM This ensures all dependencies are up to date and code is properly compiled
call mvn clean install

echo Starting the backend...
@REM Execute the packaged JAR file
@REM Spring Boot creates an executable JAR with embedded Tomcat server
@REM Application will be available at http://localhost:8080
java -jar target/backend.jar