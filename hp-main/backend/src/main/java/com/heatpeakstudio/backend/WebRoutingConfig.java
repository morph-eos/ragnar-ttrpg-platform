package com.heatpeakstudio.backend;

import org.springframework.boot.web.server.ErrorPage;
import org.springframework.boot.web.server.WebServerFactoryCustomizer;
import org.springframework.boot.web.servlet.server.ConfigurableServletWebServerFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpStatus;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@Configuration 
public class WebRoutingConfig implements WebMvcConfigurer { 
 
  @Override 
  public void addViewControllers(@SuppressWarnings("null") ViewControllerRegistry registry) { 
      registry.addViewController("/urlNotFound")
      .setViewName("forward:/index.html");
  } 
 
  @Bean 
  public WebServerFactoryCustomizer<ConfigurableServletWebServerFactory> containerCustomizer() { 
     return container -> { 
       container.addErrorPages(new ErrorPage(HttpStatus.NOT_FOUND, 
         "/urlNotFound")); 
     }; 
  } 
}