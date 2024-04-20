package com.jugglehive.model.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class TreeSkills {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;
    
    @JoinColumn(name = "tree_id", nullable = false)
    private TreeEntity tree;

    @ManyToOne
    @JoinColumn(name = "skill_family_id", nullable = false)
    private SkillFamily skillFamily;

    @ManyToOne
    @JoinColumn(name = "parent_skill_family_id")
    private SkillFamily parentSkill;
}
