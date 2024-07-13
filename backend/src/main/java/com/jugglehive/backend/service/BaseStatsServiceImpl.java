package com.jugglehive.backend.service;

import org.springframework.beans.factory.annotation.Autowired;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.repository.BaseStatsRepository;

public class BaseStatsServiceImpl implements BaseStatsService {

    @Autowired
    private BaseStatsRepository baseStatsRepository;

    @Override
    public BaseStats getBaseStatsById(Long id) throws NoBaseStatsFoundException, Exception {
        
        if (id == null) {

            throw new IllegalArgumentException("Id is null");
        }

        BaseStats result = null;

        result = baseStatsRepository.findById(id).orElse(null);

        if (result == null) {

            throw new NoBaseStatsFoundException("No baseStats found for id: " + id);

        }

        return result;
    }

    @Override
    public GetBaseStatsByIdDTO mapBaseStatsToGetBaseStatsById(BaseStats baseStats) throws NoBaseStatsFoundException {
        
        GetBaseStatsByIdDTO result = new GetBaseStatsByIdDTO();

        if(baseStats == null){
            throw new NoBaseStatsFoundException("No baseStats found for id: ");

        }

        if(baseStats.getId() == null){

            throw new NoBaseStatsFoundException("No baseStats found for id: " );

        }

        result.setId(baseStats.getId());
        result.setVitality(baseStats.getVitality());
        result.setDexterity(baseStats.getDexterity());
        result.setArcane(baseStats.getArcane());
        result.setCharisma(baseStats.getCharisma());
        result.setInstinct(baseStats.getInstinct());
        result.setSpeed(baseStats.getSpeed());
        result.setStrength(baseStats.getStrength());

        return result;
    }

}
