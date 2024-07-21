package com.jugglehive.backend.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoCharacterSkillsFoundException;
import com.jugglehive.backend.model.dto.GetCharaSkillsByCharacterIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.CharacterSkills;
import com.jugglehive.backend.service.CharacterSkillsService;

@RestController
@RequestMapping("/api/characterskills")
public class CharacterSkillsController {

    @Autowired
    private CharacterSkillsService characterSkillsService;

    // Method to get a character skills by id
    @GetMapping("/charaId/{charaId}")
    public GetCharaSkillsByCharacterIdDTO getCharaSkillsByCharacterId(@PathVariable Long charaId) throws NoCharacterSkillsFoundException, Exception {

        List<CharacterSkills> characterSkillList = characterSkillsService.getCharaSkillsByCharacterId(charaId);

        // Return a character skills DTO mapped from the character skills
        GetCharaSkillsByCharacterIdDTO result = characterSkillsService.mapCharacterSkillsToGetCharaSkillsByCharacterIdDTO(characterSkillList);

        return result;
    }
}
