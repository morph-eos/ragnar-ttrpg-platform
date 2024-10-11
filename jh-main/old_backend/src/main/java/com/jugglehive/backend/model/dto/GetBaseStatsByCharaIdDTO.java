package com.jugglehive.backend.model.dto;

import java.util.Map;

import lombok.Data;

@Data
public class GetBaseStatsByCharaIdDTO {

    private Long charaId;
    private String charaName;
    private Map<String, Integer> baseStats;
}
