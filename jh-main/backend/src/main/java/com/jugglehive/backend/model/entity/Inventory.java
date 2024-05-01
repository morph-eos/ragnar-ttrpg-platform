package com.jugglehive.backend.model.entity;

import java.util.List;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.JoinTable;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(schema = "ttrpg")
public class Inventory {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "equipped", nullable = false)
    private Boolean equipped;

    @Column(name = "stacks")
    private Integer stacks;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "character_id", nullable = false)
    private Chara character;

    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(name = "inventory_item",
      joinColumns = @JoinColumn(name = "inventory_id", nullable = false),
      inverseJoinColumns = @JoinColumn(name = "item_id", nullable = false))
      private List<Item> items;
}