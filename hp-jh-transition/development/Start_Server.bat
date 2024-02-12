@echo off

REM Starting Docker Desktop
echo Starting Docker Desktop...
start /min "" "C:\Program Files\Docker\Docker\Docker Desktop.exe"

REM Wait for Docker Desktop to start
:WAIT_FOR_DESKTOP
timeout /t 5 >nul
tasklist /FI "IMAGENAME eq Docker Desktop.exe" | find /i "Docker Desktop.exe" >nul
if not errorlevel 1 goto WAIT_FOR_ENGINE

REM Wait for Docker Engine to start
:WAIT_FOR_ENGINE
timeout /t 5 >nul
sc query docker | find "STATE" | find "RUNNING" >nul
if %errorlevel% neq 0 goto STARTNOW

:STARTNOW
REM Remove existing container with the same name if exists
docker rm -f db >nul 2>&1

REM Run Docker container once Docker Engine is ready
echo Starting Database...
docker run -d ^
  --name HPS-PostgreSQL ^
  -p 5432:5432 ^
  -e POSTGRES_USER=hps ^
  -e POSTGRES_PASSWORD=example ^
  -v %cd%/db:/var/lib/postgresql/data ^
  postgres:16

echo Starting actual Backend...
REM Navigate to the backend directory
cd ../backend/

REM Build and run the Spring Boot application
mvn clean package
java -jar target/backend.jar