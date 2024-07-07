package com.jugglehive.backend.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.jugglehive.backend.model.entity.ttrpg.CharachterSkills;

public interface CharacterSkillsRepository extends JpaRepository<CharachterSkills, Long> {

    List<CharachterSkills> findAllByCharacterId(Long charaId);
}
