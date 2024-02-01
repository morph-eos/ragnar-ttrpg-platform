# Use the official OpenJDK 17 image as the base image
FROM eclipse-temurin:17-jdk

# Set the working directory inside the container
WORKDIR /app

# Copy the JAR file to the container
COPY backend/target /app

# Copy the frontend build to the container
COPY frontend/dist /app/src/main/resources/static

# Expose the port that the Spring Boot application listens on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["java", "-jar", "/app/backend.jar"]