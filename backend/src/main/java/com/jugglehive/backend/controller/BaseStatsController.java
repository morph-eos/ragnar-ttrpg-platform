package com.jugglehive.backend.controller;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByCharaIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.service.BaseStatsService;
import com.jugglehive.backend.service.CharaService;

@RestController
@RequestMapping("/api/basestats")
public class BaseStatsController {

    @Autowired
    private BaseStatsService baseStatsService;
    private CharaService charaService;

    // Method to get a baseStats by id
    @GetMapping("/basestatsId/{baseStatsId}")
    public List<GetBaseStatsByCharaIdDTO> getBaseStatsById(@PathVariable Long charaId) throws NoBaseStatsFoundException, Exception {

        Chara character = charaService.getCharaById(charaId);

        List<BaseStats> baseStatsList = baseStatsService.getBaseStatsByCharaId(charaId);

        List<GetBaseStatsByCharaIdDTO> result = new ArrayList<GetBaseStatsByCharaIdDTO>();

        for ( BaseStats baseStats : baseStatsList) {
            // Return a baseStats DTO mapped from the baseStats
            GetBaseStatsByCharaIdDTO dto = baseStatsService.mapBaseStatsToGetBaseStatsByCharaIdDTO(character, baseStats);
            result.add(dto);
        }

        return result;
    }
}
