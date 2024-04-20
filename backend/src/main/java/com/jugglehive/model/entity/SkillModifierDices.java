package com.jugglehive.model.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.OneToOne;
import lombok.Data;

@Entity
@Data
public class SkillModifierDices {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "times", nullable = false)
    private Integer times;

    @Column(name = "faces", nullable = false)
    private Integer faces;

    @OneToOne
    @JoinColumn(name = "skill_modifier_id")
    private SkillModifier skillModifier;
}
