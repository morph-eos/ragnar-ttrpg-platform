package com.jugglehive.backend.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.jugglehive.backend.model.entity.ttrpg.CharacterSkills;

public interface CharacterSkillsRepository extends JpaRepository<CharacterSkills, Long> {

    List<CharacterSkills> findAllByCharacterId(Long charaId);
}
