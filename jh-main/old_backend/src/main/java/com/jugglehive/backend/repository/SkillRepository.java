package com.jugglehive.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.jugglehive.backend.model.entity.ttrpg.Skill;

public interface SkillRepository extends JpaRepository<Skill, Long>{

}
