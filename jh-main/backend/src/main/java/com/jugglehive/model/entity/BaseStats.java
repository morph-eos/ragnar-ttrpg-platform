package com.jugglehive.model.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.Data;

@Entity
@Data
public class BaseStats {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Integer id;

  @Column(name = "vitality")
  private Integer vitality;

  @Column(name = "strength")
  private Integer strength;

  @Column(name = "dexterity")
  private Integer dexterity;

  @Column(name = "arcane")
  private Integer arcane;

  @Column(name = "instinct")
  private Integer instinct;

  @Column(name = "charisma")
  private Integer charisma;

  @Column(name = "speed")
  private Integer speed;
}
