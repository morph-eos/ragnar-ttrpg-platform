package com.jugglehive.model.entity;

import java.util.List;

import com.jugglehive.model.enums.ItemType;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.JoinTable;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class Item {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "name", nullable = false, length = 255)
    private String name;

    @Column(name = "description", nullable = false, length = 255)
    private String description;

    @Enumerated(EnumType.STRING)
    @Column(name = "type", nullable = false, length = 255)
    private ItemType type;

    @Column(name = "weight", nullable = false)
    private Double weight;

    @Column(name = "stackable", nullable = false)
    private Boolean stackable;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "main_skill_id")
    private Skill mainSkill;

    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(name = "item_skill",
        joinColumns = @JoinColumn(name = "item_id", nullable = false),
        inverseJoinColumns = @JoinColumn(name = "skill_id", nullable = false))
    private List<Skill> skills; 

    @ManyToMany(mappedBy = "items", fetch = FetchType.LAZY)
    private List<Inventory> inventories;
}
