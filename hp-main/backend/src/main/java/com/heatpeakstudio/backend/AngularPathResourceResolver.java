package com.heatpeakstudio.backend;

import org.springframework.core.io.ClassPathResource;
import org.springframework.core.io.Resource;
import org.springframework.web.servlet.resource.PathResourceResolver;
import org.springframework.web.servlet.resource.ResourceResolverChain;

import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.util.List;

public class AngularPathResourceResolver extends PathResourceResolver {

    private static final String API_PATH = "/api";

    @Override
    protected Resource getResource(String resourcePath, Resource location) throws IOException {
        if (resourcePath.startsWith(API_PATH)) {
            return null;
        }

        return location.createRelative(resourcePath);
    }

    @Override
    protected void doResolveResource(HttpServletRequest request, String requestPath, List<? extends Resource> locations, ResourceResolverChain chain) throws IOException {
        if (requestPath.startsWith(API_PATH)) {
            chain.resolveResource(request, requestPath.substring(API_PATH.length() + 1), locations);
            return;
        }

        super.doResolveResource(request, requestPath, locations, chain);
    }
}