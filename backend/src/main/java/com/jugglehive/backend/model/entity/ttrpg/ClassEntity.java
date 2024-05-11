package com.jugglehive.backend.model.entity.ttrpg;

import java.util.List;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity(name = "class")
@Data
@Table(schema = "ttrpg")
public class ClassEntity {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Long id;

  @Column(name = "name", nullable = false, length = 50)
  private String name;

  @Column(name = "description", nullable = false, length = 150)
  private String description;

  @OneToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "tree_id", nullable = false)
  private TreeEntity tree;

  @OneToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "stats_id", nullable = false)
  private BaseStats stats;

  @ManyToMany(mappedBy = "classes", fetch = FetchType.LAZY)
  private List<Chara> characters;

}

