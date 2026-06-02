/**
 * RAGNAR TTRPG PLATFORM - SPRING BOOT TRANSITION APPLICATION
 * ==========================================================
 * 
 * File: BackendApplication.java
 * Purpose: Main Spring Boot application entry point for transition phase
 * 
 * TRANSITION PHASE CONTEXT:
 * This file represents the backend implementation during the transition from
 * the MERN stack (hp-main) to the modern Spring Boot architecture, before
 * the final evolution to .NET Core (jh-main) by JuggleHive team.
 * 
 * ARCHITECTURAL EVOLUTION:
 * - Legacy (hp-main): Node.js/Express with MongoDB
 * - Transition (hp-jh-transition): Spring Boot with PostgreSQL 
 * - Modern (jh-main): .NET Core Web API with Entity Framework
 * 
 * SPRING BOOT CONFIGURATION:
 * This minimal configuration demonstrates the simplicity of Spring Boot
 * auto-configuration, requiring only the @SpringBootApplication annotation
 * to enable component scanning, auto-configuration, and configuration properties.
 * 
 * DATABASE INTEGRATION:
 * While this main class is minimal, the application.properties file configures:
 * - PostgreSQL database connection (transition from MongoDB)
 * - JPA/Hibernate for ORM (replacing Mongoose ODM)
 * - Spring Data repositories for data access
 * 
 * TRANSITION BENEFITS:
 * - Type safety with Java vs JavaScript
 * - Relational data modeling vs document-based
 * - Enterprise-grade dependency injection
 * - Built-in security and testing frameworks
 * - Better integration with enterprise systems
 * 
 * Team: HeatPeak Studio (Transition Phase)
 * Target Architecture: JuggleHive (.NET Core implementation)
 */
package com.heatpeakstudio.backend;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/**
 * SPRING BOOT MAIN APPLICATION CLASS
 * 
 * The @SpringBootApplication annotation is a meta-annotation that combines:
 * - @Configuration: Indicates this class provides Spring configuration
 * - @EnableAutoConfiguration: Enables Spring Boot's auto-configuration mechanism
 * - @ComponentScan: Enables component scanning for dependency injection
 * 
 * AUTO-CONFIGURATION FEATURES:
 * Spring Boot automatically configures:
 * - Embedded Tomcat server for web applications
 * - JPA/Hibernate configuration for database access
 * - Jackson for JSON serialization/deserialization
 * - CORS configuration for cross-origin requests
 * - Error handling and logging frameworks
 */
@SpringBootApplication
public class BackendApplication {

	/**
	 * MAIN METHOD - APPLICATION ENTRY POINT
	 * 
	 * SpringApplication.run() method:
	 * 1. Creates an ApplicationContext
	 * 2. Registers all auto-configuration classes
	 * 3. Starts the embedded Tomcat server
	 * 4. Initializes all Spring beans and components
	 * 
	 * The application will be available at http://localhost:8080
	 * unless configured otherwise in application.properties
	 */
	public static void main(String[] args) {
		SpringApplication.run(BackendApplication.class, args);
	}

}
