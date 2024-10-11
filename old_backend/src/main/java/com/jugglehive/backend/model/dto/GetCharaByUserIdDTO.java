package com.jugglehive.backend.model.dto;

import com.jugglehive.backend.model.entity.ttrpg.Chara;

import lombok.Data;

@Data
public class GetCharaByUserIdDTO {


    private Long id;
    private Long userId;
    private String name;
    private String race;
    private Integer level;
    private String urlImage;



    public GetCharaByUserIdDTO mapCharaToDTO(Chara chara){

        GetCharaByUserIdDTO result = new GetCharaByUserIdDTO();

        result.setId(chara.getId());
        result.setUserId(chara.getUser().getId());
        result.setName(chara.getName());
        result.setRace(chara.getRace().getName());
        result.setLevel(chara.getInfo().getLevel());
        result.setUrlImage("https://media-assets.wired.it/photos/638a19c0ddcebfa81a71fbad/16:9/w_1280,c_limit/Troll.jpg");


        return result;  
    }


}
