package com.jugglehive.backend.model.entity.ttrpg;


import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(name = "characters_tree_points", schema = "ttrpg")
public class CharactersTreePoints {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Long id;

  @ManyToOne
  @JoinColumn(name = "character_id", nullable = false)
  private Chara character;

  @ManyToOne
  @JoinColumn(name = "tree_id", nullable = false)
  private TreeEntity tree;

  @Column(name = "available_points")
  private Integer availablePoints;

}
