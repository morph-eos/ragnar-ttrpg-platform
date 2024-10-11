package com.jugglehive.backend.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByCharaIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.service.BaseStatsService;
import com.jugglehive.backend.service.CharaService;

@RestController
@RequestMapping("/api/basestats")
public class BaseStatsController {

    @Autowired
    private CharaService charaService;
    @Autowired
    private BaseStatsService baseStatsService;

    // Method to get a baseStats by id
    @GetMapping("/charaId/{charaId}")
    public GetBaseStatsByCharaIdDTO getBaseStatsById(@PathVariable Long charaId) throws NoBaseStatsFoundException, Exception {

        Chara character = charaService.getCharaById(charaId);

        // Return a baseStats DTO mapped from the baseStats
        GetBaseStatsByCharaIdDTO result = baseStatsService.mapBaseStatsToGetBaseStatsByCharaIdDTO(character);

        return result;
    }
}
