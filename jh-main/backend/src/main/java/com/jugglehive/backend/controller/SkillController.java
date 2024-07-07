package com.jugglehive.backend.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoSkillsFoundException;
import com.jugglehive.backend.model.dto.GetSkillByIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.Skill;
import com.jugglehive.backend.service.SkillService;

@RestController
@RequestMapping("/api/skill")
public class SkillController {

    @Autowired
    private SkillService skillService;

    // Method to get a skill by id
    @GetMapping("/skillId/{skillId}")
    public GetSkillByIdDTO getSkillById(@PathVariable Long skillId) throws NoSkillsFoundException, Exception {

        Skill skill = skillService.getSkillById(skillId);

        // Return a skill DTO mapped from the skill
        GetSkillByIdDTO result = skillService.mapSkillToGetSkillByIdDTO(skill);

        return result;
    }
}
