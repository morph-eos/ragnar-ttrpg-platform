package com.jugglehive.backend.model.entity.ttrpg;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(schema = "ttrpg")
public class CharacterInfo {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "lvl")
    private Integer level;

    @Column(name = "current_hp")
    private Integer currentHp;

    @Column(name = "shield")
    private Integer shield;

    @Column(name = "max_hp")
    private Integer maxHp;

    @Column(name = "current_mp")
    private Integer currentMp;

    @Column(name = "current_ki")
    private Integer currentKi;

    @Column(name = "current_fury")
    private Integer currentFury;

    @Column(name = "current_miracles")
    private Integer currentMiracles;

    @Column(name = "current_metamorphs")
    private Integer currentMetamorphs;

}
