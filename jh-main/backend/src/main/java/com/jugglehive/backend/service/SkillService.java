package com.jugglehive.backend.service;

import com.jugglehive.backend.exception.customExceptions.NoSkillsFoundException;
import com.jugglehive.backend.model.dto.GetSkillByIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.Skill;

public interface SkillService {

    Skill getSkillById(Long skillId) throws NoSkillsFoundException, Exception;

    GetSkillByIdDTO mapSkillToGetSkillByIdDTO(Skill skill);
}
