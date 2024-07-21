package com.jugglehive.backend.service;

import com.jugglehive.backend.exception.customExceptions.NoBaseStatsFoundException;
import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.dto.GetBaseStatsByCharaIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.BaseStats;
import com.jugglehive.backend.model.entity.ttrpg.Chara;

public interface BaseStatsService {

    BaseStats getBaseStatsByCharaId(Long id) throws NoBaseStatsFoundException, Exception;

    GetBaseStatsByCharaIdDTO mapBaseStatsToGetBaseStatsByCharaIdDTO(Chara character) throws NoBaseStatsFoundException, NoCharactersFoundException;
}
