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
public class AllowedItem {

    @Id
    @Column(name = "class_id", nullable = false)
    private Integer classId;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "class_id", nullable = false, insertable = false, updatable = false)
    private ClassEntity classVar; //ClassEntity / classVar
    //class si riferisce a class id ma usa clazz per non usare class come nome di variabile (che è una keyword di java)

    @Column(name = "item_type", nullable = false, length = 255)
    private String itemType;

}
