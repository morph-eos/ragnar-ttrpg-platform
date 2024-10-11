package com.jugglehive.backend.model.dto;

import java.util.List;
import java.util.Map;


import lombok.Data;

@Data
public class GetCharaLightDTO {

    private Long id;
    private Long userId;
    private String name;
    private Integer age;
    private String region;
    private Map<String, Integer> currentStats;
    private List<String> classes;
    private String race;
    private Integer level;
    private String urlImage;

}
