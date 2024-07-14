package com.jugglehive.backend.service;

import java.util.List;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByCharaIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.model.entity.ttrpg.Chara;

public interface BaseStatsService {

    List<BaseStats> getBaseStatsByCharaId(Long id) throws NoBaseStatsFoundException, Exception;

    GetBaseStatsByCharaIdDTO mapBaseStatsToGetBaseStatsByCharaIdDTO(Chara character, BaseStats baseStats) throws NoBaseStatsFoundException;
}
