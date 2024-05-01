package com.jugglehive.backend.model.entity;

import java.util.List;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.JoinTable;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(schema = "ttrpg")
public class Race {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "name", nullable = false, length = 50)
    private String name;

    @Column(name = "description", nullable = false, length = 150)
    private String description;

    @OneToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "stat_id", nullable = false)
    private BaseStats stats;

    @Column(name = "level_up_hp", nullable = false)
    private Integer levelUpHp;

    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(name = "race_region",
      joinColumns = @JoinColumn(name = "race_id", nullable = false),
      inverseJoinColumns = @JoinColumn(name = "region_id", nullable = false))
    private List<Region> regions;
}
