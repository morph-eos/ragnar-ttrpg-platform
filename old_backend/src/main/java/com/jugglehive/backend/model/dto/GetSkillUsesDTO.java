package com.jugglehive.backend.model.dto;

import lombok.Data;

@Data
public class GetSkillUsesDTO {

    private Long id;
    private String name;
    private Integer totalUses;
    private Integer status;
    private Integer tempUses;
}
