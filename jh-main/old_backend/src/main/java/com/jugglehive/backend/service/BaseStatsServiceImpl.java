package com.jugglehive.backend.service;

import java.util.HashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByCharaIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.repository.BaseStatsRepository;

@Service
public class BaseStatsServiceImpl implements BaseStatsService {

    @Autowired
    private BaseStatsRepository baseStatsRepository;

    @Override
    public BaseStats getBaseStatsByCharaId(Long id) throws NoBaseStatsFoundException, Exception {
        
        if (id == null) {

            throw new IllegalArgumentException("Id is null");
        }

        BaseStats result = null;

        result = baseStatsRepository.findBaseStatsByCharacterId(id);

        if (result == null) {

            throw new NoBaseStatsFoundException("No baseStats found for id: " + id);

        }

        return result;
    }

    @Override
    public GetBaseStatsByCharaIdDTO mapBaseStatsToGetBaseStatsByCharaIdDTO(Chara character) throws NoBaseStatsFoundException, NoCharactersFoundException {
        
        GetBaseStatsByCharaIdDTO result = new GetBaseStatsByCharaIdDTO();

        if(character == null){
            throw new NoCharactersFoundException("No character found");
        }

        if(character.getId() == null) {
            throw new NoCharactersFoundException("No character found");
        }

        if(character.getLvlUpStat() == null){
            throw new NoBaseStatsFoundException("No basestats found");
        }

        if(character.getLvlUpStat().getId() == null) {
            throw new NoBaseStatsFoundException("No basestats found");
        }

        Map<String, Integer> baseStatsMap = new HashMap<String, Integer>();
        baseStatsMap.put("Vitality", character.getLvlUpStat().getVitality());
        baseStatsMap.put("Dexterity", character.getLvlUpStat().getDexterity());
        baseStatsMap.put("Arcane", character.getLvlUpStat().getArcane());
        baseStatsMap.put("Charisma", character.getLvlUpStat().getCharisma());
        baseStatsMap.put("Instinct", character.getLvlUpStat().getInstinct());
        baseStatsMap.put("Speed", character.getLvlUpStat().getSpeed());
        baseStatsMap.put("Strength", character.getLvlUpStat().getStrength());

        result.setCharaId(character.getId());
        result.setCharaName(character.getName());
        result.setBaseStats(baseStatsMap);

        return result;
    }

}
