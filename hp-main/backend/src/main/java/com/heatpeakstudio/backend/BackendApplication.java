package com.heatpeakstudio.backend;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@SpringBootApplication
public class BackendApplication {

    public static void main(String[] args) {
        SpringApplication.run(BackendApplication.class, args);
    }

    @Configuration
    public class WebConfig implements WebMvcConfigurer {

        @Override
        public void addViewControllers(ViewControllerRegistry registry) {
            registry.addViewController("/{spring:\\w+}")
                    .setViewName("forward:/");
            registry.addViewController("/**/{spring:\\w+}")
                    .setViewName("forward:/");
            registry.addViewController("/{spring:^(?!api$).*$}/**")
                    .setViewName("forward:/");
        }
    }
}