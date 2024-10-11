package com.jugglehive.backend.model.entity.ttrpg;

import java.util.HashMap;
import java.util.Map;

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
public class BaseStats {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Long id;

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

  public Map<String, Integer> getStats() {

    Map<String, Integer> stats = new HashMap<>();

    stats.put("vitality", vitality);
    stats.put("strength", strength);
    stats.put("dexterity", dexterity);
    stats.put("arcane", arcane);
    stats.put("instinct", instinct);
    stats.put("charisma", charisma);
    stats.put("speed", speed);
    
    return stats;
  }
}
