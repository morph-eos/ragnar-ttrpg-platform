# Use the official OpenJDK 17 image as the base image
FROM adoptopenjdk:17-jdk-hotspot

# Set the working directory inside the container
WORKDIR /app

# Copy the JAR file and any necessary dependencies to the container
COPY target /app

# Expose the port that the Spring Boot application listens on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["java", "-jar", "/app/backend.jar"]