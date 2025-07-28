/**
 * RAGNAR TTRPG PLATFORM - SPRING BOOT WEB ROUTING CONFIGURATION
 * =============================================================
 * 
 * File: WebRoutingConfig.java
 * Purpose: Configure web routing and error handling for Angular SPA integration
 * 
 * SPA ROUTING INTEGRATION:
 * This configuration solves the common issue with Single Page Applications (SPAs)
 * where client-side routes need to be handled properly by the Spring Boot backend.
 * When users navigate directly to Angular routes or refresh the page, the server
 * needs to serve the index.html file instead of returning 404 errors.
 * 
 * TRANSITION ARCHITECTURE PATTERN:
 * This approach demonstrates the evolution from:
 * - Legacy (hp-main): Express.js with static file middleware
 * - Transition (hp-jh-transition): Spring Boot with Angular SPA support
 * - Modern (jh-main): .NET Core with Angular integration and Azure hosting
 * 
 * ERROR HANDLING STRATEGY:
 * The configuration implements a fallback mechanism where any 404 error
 * is redirected to /urlNotFound, which then forwards to /index.html,
 * allowing Angular's router to handle the routing client-side.
 * 
 * SPRING MVC INTEGRATION:
 * Uses Spring MVC's WebMvcConfigurer interface to customize the web layer
 * without disabling Spring Boot's auto-configuration capabilities.
 * 
 * Team: HeatPeak Studio (Transition Phase)
 */
package com.heatpeakstudio.backend;

import org.springframework.boot.web.server.ErrorPage;
import org.springframework.boot.web.server.WebServerFactoryCustomizer;
import org.springframework.boot.web.servlet.server.ConfigurableServletWebServerFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpStatus;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

/**
 * WEB ROUTING CONFIGURATION CLASS
 * 
 * The @Configuration annotation indicates this class provides Spring configuration.
 * Implementing WebMvcConfigurer allows customization of Spring MVC configuration
 * without disabling auto-configuration.
 */
@Configuration 
public class WebRoutingConfig implements WebMvcConfigurer { 
 
  /**
   * VIEW CONTROLLER REGISTRATION
   * 
   * Adds a simple view controller that forwards requests from /urlNotFound
   * to /index.html. This is the fallback mechanism for SPA routing support.
   * 
   * The forward: prefix ensures the request is forwarded internally
   * without changing the client's URL, allowing Angular to handle routing.
   */
  @Override 
  public void addViewControllers(@SuppressWarnings("null") ViewControllerRegistry registry) { 
      registry.addViewController("/urlNotFound")
      .setViewName("forward:/index.html");
  } 
 
  /**
   * CUSTOM ERROR PAGE CONFIGURATION
   * 
   * Creates a WebServerFactoryCustomizer bean that configures the embedded
   * Tomcat server to redirect 404 errors to /urlNotFound.
   * 
   * ROUTING FLOW:
   * 1. User requests Angular route (e.g., /character/123)
   * 2. Spring Boot doesn't find a matching controller
   * 3. Server returns 404 status
   * 4. Custom error page redirects to /urlNotFound
   * 5. View controller forwards to /index.html
   * 6. Angular router takes over and handles the route
   * 
   * This pattern is essential for SPAs where client-side routing
   * needs to work with server-side resource serving.
   */
  @Bean 
  public WebServerFactoryCustomizer<ConfigurableServletWebServerFactory> containerCustomizer() { 
     return container -> { 
       container.addErrorPages(new ErrorPage(HttpStatus.NOT_FOUND, 
         "/urlNotFound")); 
     }; 
  } 
}