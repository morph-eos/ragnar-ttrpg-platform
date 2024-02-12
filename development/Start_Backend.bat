@echo off

REM Starting Docker Desktop
echo Starting Docker Desktop...
start /min "" "C:\Program Files\Docker\Docker\Docker Desktop.exe"

REM Remove existing container with the same name if exists
:STARTCHECK
timeout 3
docker rm -f HPS-PostgreSQL >nul 2>&1 || (
	goto STARTCHECK
)

REM Run Docker container once Docker Engine is ready
echo Starting Database...
docker run -d ^
  --name HPS-PostgreSQL ^
  -p 5432:5432 ^
  -e POSTGRES_USER=hps ^
  -e POSTGRES_PASSWORD=example ^
  postgres:16

echo Building the actual Backend...
REM Navigate to the backend directory
cd ../backend/

REM Build and run the Spring Boot application
call mvn clean install
echo Starting the actual Backend...
java -jar target/backend.jar