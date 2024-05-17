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

  // Method that calculates the total stats of the character
  // chara.lvlupstats da moltiplicare per il livello (credo)
  // chara.classes da sommare le stats
  // chara.race sommare le stats
  // #TODO Implement the method
  public Map<String, Integer> getCurrentStats() {
    
    Map<String, Integer> stats = new HashMap<>();

    for (Map.Entry<String, Integer> entry : lvlUpStat.getStats().entrySet()) {
      stats.put(entry.getKey(), stats.getOrDefault(entry.getKey(), 0) + entry.getValue() * info.getLevel());
  }

    for (Map.Entry<String, Integer> entry : race.getStats().getStats().entrySet()) {
        stats.put(entry.getKey(), stats.getOrDefault(entry.getKey(), 0) + entry.getValue());
    }

    for (CharacterClasses characterClasses : classes) {
        Map<String, Integer> classStats = characterClasses.getClassEntity().getStats().getStats();
        for (Map.Entry<String, Integer> entry : classStats.entrySet()) {
            stats.put(entry.getKey(), stats.getOrDefault(entry.getKey(), 0) + entry.getValue());
        }
      }
      
      return stats;
      
      
      // Aggiungere o sommare il valore per la chiave "strength"
      // stats.put("strength", stats.getOrDefault("strength", 0) + 9000); // Aggiunge 9000
      // stats.put("strength", stats.getOrDefault("strength", 0) + 200);  // Somma 200
}


  public Map<String, Integer> getCurrentStats2() {

    Map<String, Integer> stats = new HashMap<>();

    for (Map.Entry<String, Integer> entry : lvlUpStat.getStats().entrySet()) {
      stats.merge(entry.getKey(), entry.getValue() * info.getLevel(), Integer::sum);
    }

    for (Map.Entry<String, Integer> entry : race.getStats().getStats().entrySet()) {
      stats.merge(entry.getKey(), entry.getValue(), Integer::sum);
    }

    for (CharacterClasses characterClasses : classes) {
      Map<String, Integer> classStats = characterClasses.getClassEntity().getStats().getStats();
      for (Map.Entry<String, Integer> entry : classStats.entrySet()) {
          stats.merge(entry.getKey(), entry.getValue(), Integer::sum);
      }
    }

    return stats;

  }

  public Map<String, Integer> getCurrentStats3() {
    
    Map<String, Integer> stats = new HashMap<>();

    lvlUpStat.getStats().forEach((key, value) -> stats.merge(key, value * info.getLevel(), Integer::sum));

    race.getStats().getStats().forEach((key, value) -> stats.merge(key, value, Integer::sum));

    classes.stream()
           .map(CharacterClasses::getClassEntity)
           .map(classEntity -> (Map<String, Integer>) classEntity.getStats().getStats())
           .map(Map::entrySet)
           .forEach(entrySet -> entrySet.forEach(entry -> stats.merge(entry.getKey(), entry.getValue(), Integer::sum)));

    return stats;
  }
  
  // Method that returns the names of the classes of the character
  public List<String> getClassesNames() {

    List<String> names = new ArrayList<>();

    for (CharacterClasses characterClasses : this.classes) {
      names.add(characterClasses.getClassEntity().getName());
    }

    System.out.println(names);
    return names;
  }
}
