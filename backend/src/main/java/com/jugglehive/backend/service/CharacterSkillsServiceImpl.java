package com.jugglehive.backend.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoCharacterSkillsFoundException;
import com.jugglehive.backend.exception.customExceptions.NoSkillsFoundException;
import com.jugglehive.backend.model.dto.GetCharaSkillsByCharacterIdDTO;
import com.jugglehive.backend.model.dto.GetSkillUsesDTO;
import com.jugglehive.backend.model.entity.ttrpg.CharachterSkills;
import com.jugglehive.backend.repository.CharacterSkillsRepository;

@Service
public class CharacterSkillsServiceImpl implements CharacterSkillsService{

    @Autowired
    private CharacterSkillsRepository characterSkillsRepository;

    @Override
    public List<CharachterSkills> getCharaSkillsByCharacterId(Long charaId)
            throws NoCharacterSkillsFoundException, Exception {
        
        if (charaId == null) {

            throw new IllegalArgumentException("Id is null");
        }

        List<CharachterSkills> result = characterSkillsRepository.findAllByCharacterId(charaId);

        if (result.isEmpty()) {

            throw new NoCharacterSkillsFoundException("No character skills found for character id: " + charaId);

        }

        return result;
    }

    @Override
    public GetCharaSkillsByCharacterIdDTO mapCharacterSkillsToGetCharaSkillsByCharacterIdDTO(
            List<CharachterSkills> characterSkillsList) throws NoCharacterSkillsFoundException {
        
        GetCharaSkillsByCharacterIdDTO result = new GetCharaSkillsByCharacterIdDTO();

        if(characterSkillsList.isEmpty()){
            throw new NoCharacterSkillsFoundException("No character skills found for id: ");
        }
        
        result.setCharaId(characterSkillsList.get(0).getCharacter().getId());
        result.setCharaName(characterSkillsList.get(0).getCharacter().getName());
        
        List<GetSkillUsesDTO> skillUsesList = new ArrayList<GetSkillUsesDTO>();

        for (CharachterSkills characterSkills : characterSkillsList) {
            
            if(characterSkills.getId() == null){
                throw new NoSkillsFoundException("No character skills found for id: ");
            }
            
            GetSkillUsesDTO skillUses = new GetSkillUsesDTO();
            skillUses.setId(characterSkills.getId());
            skillUses.setName(characterSkills.getUnlockedSkill().getName());
            skillUses.setStatus(characterSkills.getStatus());
            skillUses.setTotalUses(characterSkills.getTotalUses());
            skillUses.setTempUses(characterSkills.getTempUses());

            skillUsesList.add(skillUses);
        }

        result.setSkillUses(skillUsesList);

        return result;
    }
}
