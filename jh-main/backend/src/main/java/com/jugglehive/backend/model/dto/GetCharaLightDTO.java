package com.jugglehive.backend.model.dto;

import java.util.List;
import java.util.Map;

import com.jugglehive.backend.model.entity.ttrpg.Chara;

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



  

    public void mapCharaToDTO(Chara chara){


        this.setId(chara.getId());
        this.setUserId(chara.getUser().getId());
        this.setName(chara.getName());
        this.setAge(chara.getAge());
        this.setRegion(chara.getRegion().getName());
        this.setCurrentStats(chara.getCurrentStats());
        this.setClasses(chara.getClassesNames());
        this.setRace(chara.getRace().getName());
        this.setLevel(chara.getInfo().getLevel());
        this.setUrlImage("https://media-assets.wired.it/photos/638a19c0ddcebfa81a71fbad/16:9/w_1280,c_limit/Troll.jpg");

    }
}
