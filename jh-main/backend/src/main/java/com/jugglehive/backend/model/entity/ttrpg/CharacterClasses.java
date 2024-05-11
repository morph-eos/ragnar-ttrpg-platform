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

@Entity(name = "character_class")
@Data
@Table(name = "character_classes", schema = "ttrpg")
public class CharacterClasses {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Long id;

  @ManyToOne
  @JoinColumn(name = "character_id", nullable = false)
  private Chara chara;

  @ManyToOne
  @JoinColumn(name = "class_id", nullable = false)
  private ClassEntity classEntity;

  // Potresti voler aggiungere altri attributi specifici della relazione qui
}
