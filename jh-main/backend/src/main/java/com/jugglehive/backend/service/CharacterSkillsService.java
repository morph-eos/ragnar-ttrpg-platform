package com.jugglehive.backend.service;

import java.util.List;

import com.jugglehive.backend.exception.customExceptions.NoCharacterSkillsFoundException;
import com.jugglehive.backend.model.dto.GetCharaSkillsByCharacterIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.CharachterSkills;

public interface CharacterSkillsService {

    List<CharachterSkills> getCharaSkillsByCharacterId(Long charaId) throws NoCharacterSkillsFoundException, Exception;

    GetCharaSkillsByCharacterIdDTO mapCharacterSkillsToGetCharaSkillsByCharacterIdDTO(List<CharachterSkills> characterSkills);
}
