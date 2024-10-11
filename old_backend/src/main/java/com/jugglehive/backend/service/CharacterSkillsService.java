package com.jugglehive.backend.service;

import java.util.List;

import com.jugglehive.backend.exception.customExceptions.NoCharacterSkillsFoundException;
import com.jugglehive.backend.model.dto.GetCharaSkillsByCharacterIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.CharacterSkills;

public interface CharacterSkillsService {

    List<CharacterSkills> getCharaSkillsByCharacterId(Long charaId) throws NoCharacterSkillsFoundException, Exception;

    GetCharaSkillsByCharacterIdDTO mapCharacterSkillsToGetCharaSkillsByCharacterIdDTO(List<CharacterSkills> characterSkills) throws NoCharacterSkillsFoundException;
}
