package com.jugglehive.backend.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByCharaIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.repository.BaseStatsRepository;

public class BaseStatsServiceImpl implements BaseStatsService {

    @Autowired
    private BaseStatsRepository baseStatsRepository;

    @Override
    public List<BaseStats> getBaseStatsByCharaId(Long id) throws NoBaseStatsFoundException, Exception {
        
        if (id == null) {

            throw new IllegalArgumentException("Id is null");
        }

        List<BaseStats> result = null;

        result = baseStatsRepository.findAllByCharacterId(id);

        if (result == null) {

            throw new NoBaseStatsFoundException("No baseStats found for id: " + id);

        }

        return result;
    }

    @Override
    public GetBaseStatsByCharaIdDTO mapBaseStatsToGetBaseStatsByCharaIdDTO(Chara character, BaseStats baseStats) throws NoBaseStatsFoundException {
        
        GetBaseStatsByCharaIdDTO result = new GetBaseStatsByCharaIdDTO();

        if(baseStats == null){
            throw new NoBaseStatsFoundException("No baseStats found");

        }

        if(baseStats.getId() == null){

            throw new NoBaseStatsFoundException("No baseStats found" );

        }

        if(character == null){
            throw new NoCharactersFoundException("No character found");
        }

        if(character.getId() == null) {
            throw new NoCharactersFoundException("No character found");
        }

        Map<String, Integer> baseStatsMap = new HashMap<String, Integer>();
        baseStatsMap.put("Vitality", baseStats.getVitality());
        baseStatsMap.put("Dexterity", baseStats.getDexterity());
        baseStatsMap.put("Arcane", baseStats.getArcane());
        baseStatsMap.put("Charisma", baseStats.getCharisma());
        baseStatsMap.put("Instinct", baseStats.getInstinct());
        baseStatsMap.put("Speed", baseStats.getSpeed());
        baseStatsMap.put("Strength", baseStats.getStrength());

        result.setCharaId(character.getId());
        result.setCharaName(character.getName());
        result.setBaseStats(baseStatsMap);

        return result;
    }

}
