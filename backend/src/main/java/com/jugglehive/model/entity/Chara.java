package com.jugglehive.model.entity;

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
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToOne;
import lombok.Data;

@Entity
@Data
public class Chara {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Long id;

  @OneToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "info_id", nullable = false)
  private CharacterInfo info;

  @Column(name = "age", nullable = false)
  private Integer age;

  @Column(name = "name", nullable = false, length = 50)
  private String name;

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "region_id", nullable = false)
  private Region region;

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "race_id", nullable = false)
  private Race race;

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "lvl_up_stat_id", nullable = false)
  private BaseStats lvlUpStat;

  @ManyToMany(fetch = FetchType.LAZY)
  @JoinTable(name = "character_classes",
      joinColumns = @JoinColumn(name = "character_id", nullable = false),
      inverseJoinColumns = @JoinColumn(name = "class_id", nullable = false))
  private List<ClassEntity> classes;

  // Getters and Setters
}
