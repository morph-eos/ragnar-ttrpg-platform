package com.jugglehive.model.entity;

import java.util.List;

import org.antlr.v4.runtime.tree.Tree;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.JoinTable;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.OneToOne;
import lombok.Data;

@Entity(name = "class")
@Data
public class ClassEntity {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Column(name = "id", nullable = false)
  private Integer id;

  @Column(name = "name", nullable = false, length = 50)
  private String name;

  @Column(name = "description", nullable = false, length = 150)
  private String description;

  @OneToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "tree_id", nullable = false)
  private Tree tree;

  @OneToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "stats_id", nullable = false)
  private BaseStats stats;

  @ManyToMany(fetch = FetchType.LAZY)
  @JoinTable(name = "allowed_item",
      joinColumns = @JoinColumn(name = "class_id", nullable = false),
      inverseJoinColumns = @JoinColumn(name = "item_type", nullable = false))
  private List<String> allowedItems;

}

