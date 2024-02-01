FROM openjdk:17

COPY target/backend-0.0.1-SNAPSHOT.jar ./backend.jar

COPY ./frontend/dist ./frontend

ENTRYPOINT ["java", "-jar", "backend.jar"]