package com.jugglehive.backend.model.dto;


import lombok.Data;

@Data
public class GetSkillByIdDTO {

    private Long id;
    private String name;
    private String description;
    private String type;
    private Integer cost;
    private String costType;
    private Integer rank;
}
