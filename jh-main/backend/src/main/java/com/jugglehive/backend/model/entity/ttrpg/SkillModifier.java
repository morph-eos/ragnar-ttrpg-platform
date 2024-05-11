package com.jugglehive.backend.model.entity.ttrpg;

import com.jugglehive.backend.model.enums.StatScaling;
import com.jugglehive.backend.model.enums.StatTarget;
import com.jugglehive.backend.model.enums.StatType;
import com.jugglehive.backend.model.enums.TargetType;

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
import jakarta.persistence.Table;
import lombok.Data;

@Entity(name = "skill_modifier")
@Data
@Table(schema = "ttrpg")
public class SkillModifier {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "skill_id", nullable = false)
    private Skill skill;

    @Column(name = "is_malus", nullable = false, columnDefinition = "smallint")
    private Boolean isMalus;

    @Column(name = "is_area", nullable = false, columnDefinition = "smallint")
    private Boolean isArea;

    @Column(name = "target_num", nullable = false, columnDefinition = "int")
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
