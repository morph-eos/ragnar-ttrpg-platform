package com.jugglehive.backend.service;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;

public interface BaseStatsService {

    BaseStats getBaseStatsById(Long id) throws NoBaseStatsFoundException, Exception;

    GetBaseStatsByIdDTO mapBaseStatsToGetBaseStatsById(BaseStats baseStats) throws NoBaseStatsFoundException;
}
