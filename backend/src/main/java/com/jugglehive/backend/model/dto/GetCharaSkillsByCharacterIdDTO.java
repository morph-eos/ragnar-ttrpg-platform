package com.jugglehive.backend.model.dto;

import java.util.List;

import lombok.Data;

@Data
public class GetCharaSkillsByCharacterIdDTO {

    private Long charaId;
    private String charaName;
    List<GetSkillUsesDTO> skillUses;
}
