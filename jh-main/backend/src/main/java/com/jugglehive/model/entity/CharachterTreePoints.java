package com.jugglehive.model.entity;


import jakarta.persistence.Column;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.OneToOne;

public class CharachterTreePoints {
@Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "character_id", nullable = false)
  private Integer characterId;

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "tree_id", nullable = false)
  private Integer treeId;

  @Column(name = "available_points")
  private Integer availablePoints;

  @OneToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "character_id", nullable = false, insertable = false, updatable = false)
  private Chara character;


}
