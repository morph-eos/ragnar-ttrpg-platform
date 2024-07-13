package com.jugglehive.backend.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.service.BaseStatsService;

@RestController
@RequestMapping("/api/basestats")
public class BaseStatsController {

    @Autowired
    private BaseStatsService baseStatsService;

    // Method to get a baseStats by id
    @GetMapping("/basestatsId/{baseStatsId}")
    public GetBaseStatsByIdDTO getBaseStatsById(@PathVariable Long baseStatsId) throws NoBaseStatsFoundException, Exception {

        BaseStats baseStats = baseStatsService.getBaseStatsById(baseStatsId);

        // Return a baseStats DTO mapped from the baseStats
        GetBaseStatsByIdDTO result = baseStatsService.mapBaseStatsToGetBaseStatsById(baseStats);

        return result;
    }
}
