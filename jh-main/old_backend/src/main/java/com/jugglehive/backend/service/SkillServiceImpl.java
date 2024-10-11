package com.jugglehive.backend.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoSkillsFoundException;
import com.jugglehive.backend.model.dto.GetSkillByIdDTO;
import com.jugglehive.backend.model.entity.ttrpg.Skill;
import com.jugglehive.backend.repository.SkillRepository;

@Service
public class SkillServiceImpl implements SkillService{

    @Autowired
    private SkillRepository skillRepository;

    @Override
    public Skill getSkillById(Long skillId) throws NoSkillsFoundException, Exception{
        
        if (skillId == null) {

            throw new IllegalArgumentException("Id is null");
        }

        Skill result = skillRepository.findById(skillId).orElse(null);

        if (result == null) {

            throw new NoSkillsFoundException("No characters found for id: " + skillId);

        }

        return result;
    }

    @Override
    public GetSkillByIdDTO mapSkillToGetSkillByIdDTO(Skill skill) throws NoSkillsFoundException {
        
        GetSkillByIdDTO result = new GetSkillByIdDTO();

        if(skill == null){
            throw new NoSkillsFoundException("No skills found for id: ");
        }

        if(skill.getId() == null){
            throw new NoSkillsFoundException("No skills found for id: ");
        }

        result.setId(skill.getId());
        result.setName(skill.getName());
        result.setDescription(skill.getDescription());
        result.setType(skill.getType().toString());
        result.setRank(skill.getSkillFamilyRank());
        result.setCost(skill.getCost());
        result.setCostType(skill.getCostType().toString());

        return result;
    }

}
