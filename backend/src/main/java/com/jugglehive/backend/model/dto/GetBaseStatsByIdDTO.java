package com.jugglehive.backend.model.dto;

import lombok.Data;

@Data
public class GetBaseStatsByIdDTO {

    private Long id;
    private Integer vitality;
    private Integer strength;
    private Integer dexterity;
    private Integer arcane;
    private Integer instinct;
    private Integer charisma;
    private Integer speed;
}
