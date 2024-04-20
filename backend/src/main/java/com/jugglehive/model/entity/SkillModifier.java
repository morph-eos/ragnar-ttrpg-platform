package com.jugglehive.model.entity;

import com.jugglehive.model.enums.StatScaling;
import com.jugglehive.model.enums.StatTarget;
import com.jugglehive.model.enums.StatType;
import com.jugglehive.model.enums.TargetType;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class SkillModifier {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "skill_id", nullable = false)
    private Skill skill;

    @Column(name = "is_malus", nullable = false, columnDefinition = "tinyint(1) default 0")
    private Boolean isMalus;

    @Column(name = "is_area", nullable = false, columnDefinition = "tinyint(1) default 1")
    private Boolean isArea;

    @Column(name = "target_num", nullable = false, columnDefinition = "int default 1")
    private Integer targetNum;

    @Enumerated(EnumType.STRING)
    @Column(name = "target_type", nullable = false)
    private TargetType targetType;

    @Enumerated(EnumType.STRING)
    @Column(name = "stat_target")
    private StatTarget statTarget;

    @Column(name = "stat_flat")
    private Integer statFlat;

    @Enumerated(EnumType.STRING)
    @Column(name = "stat_scaling")
    private StatScaling statScaling;

    @Column(name = "stat_max_scaling")
    private Integer statMaxScaling;

    @Enumerated(EnumType.STRING)
    @Column(name = "stat_type")
    private StatType statType;
}
