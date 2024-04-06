package com.jugglehive.model.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class CharacterClasses {

  @Id
  @Column(name = "character_id", nullable = false)
  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "character_id", nullable = false, insertable = false, updatable = false)
  private Chara character;

  @Id
  @Column(name = "class_id", nullable = false)
  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "class_id", nullable = false, insertable = false, updatable = false)
  private ClassEntity classVar;

}

