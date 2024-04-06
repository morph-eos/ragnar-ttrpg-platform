FROM eclipse-temurin:17-jdk
WORKDIR /app
COPY backend/target /app
EXPOSE 8080
ENTRYPOINT ["java", "-jar", "/app/com.jugglehive.backend.jar"]