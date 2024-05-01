package com.jugglehive.backend.model.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(schema = "ttrpg")
public class TreeSkills {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;
    
    @ManyToOne
    @JoinColumn(name = "tree_id", nullable = false)
    private TreeEntity tree;

    @ManyToOne
    @JoinColumn(name = "skill_family_id", nullable = false)
    private SkillFamily skillFamily;

    @ManyToOne
    @JoinColumn(name = "parent_skill_family_id")
    private SkillFamily parentSkill;
}
