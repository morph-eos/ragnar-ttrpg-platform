package com.jugglehive.backend.model.entity.ttrpg;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.jugglehive.backend.model.entity.login.User;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity(name = "chara")
@Data
@Table(schema = "ttrpg")
public class Chara {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Long id;

  @OneToOne(fetch = FetchType.EAGER)
  @JoinColumn(name = "user_id", nullable = false)
  private User user;

  @OneToOne(fetch = FetchType.EAGER)
  @JoinColumn(name = "info_id", nullable = false)
  private CharacterInfo info;

  @Column(name = "age", nullable = false)
  private Integer age;

  @Column(name = "name", nullable = false, length = 50)
  private String name;

  @ManyToOne(fetch = FetchType.EAGER)
  @JoinColumn(name = "region_id", nullable = false)
  private Region region;

  @ManyToOne(fetch = FetchType.EAGER)
  @JoinColumn(name = "race_id", nullable = false)
  private Race race;

  @ManyToOne(fetch = FetchType.EAGER)
  @JoinColumn(name = "lvl_up_stat_id", nullable = false)
  private BaseStats lvlUpStat;

  @OneToMany(mappedBy = "chara")
  private List<CharacterClasses> classes = new ArrayList<>();


}
