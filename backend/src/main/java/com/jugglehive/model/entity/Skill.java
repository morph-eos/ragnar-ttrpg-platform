package com.jugglehive.model.entity;

import java.util.List;

import com.jugglehive.model.enums.CostType;
import com.jugglehive.model.enums.SkillType;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class Skill {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "name", length = 50, nullable = false)
    private String name;

    @Column(name = "description", length = 150, nullable = false)
    private String description;

    @Enumerated(EnumType.STRING)
    @Column(name = "type", nullable = false)
    private SkillType type;

    @Column(name = "cost")
    private Integer cost;

    @Enumerated(EnumType.STRING)
    @Column(name = "cost_type")
    private CostType costType;

    @ManyToOne
    @JoinColumn(name = "skill_family_id", nullable = false)
    private SkillFamily skillFamily;

    @Column(name = "skil_family_rank", nullable = false)
    private int skillFamilyRank;

    @ManyToMany(mappedBy = "skills", fetch = FetchType.LAZY)
    private List<Item> items;
}
