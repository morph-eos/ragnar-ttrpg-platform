package com.jugglehive.backend.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.dto.GetCharaByUserIdDTO;
import com.jugglehive.backend.model.dto.GetCharaLightDTO;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.service.CharaService;

@RestController
@RequestMapping("/api/chara")
public class CharaController {

    @Autowired
    private CharaService charaService;

    // Method to get all characters by user id
    @GetMapping("/userId/{userId}")
    public List<GetCharaByUserIdDTO> getAllCharachtersByUserId(@PathVariable Long userId)
            throws NoCharactersFoundException, Exception {

        // Return a list of characters DTO mapped from the characters

        return charaService.getAllCharasByUserId(userId)
                .stream()
                .map(chara -> new GetCharaByUserIdDTO()
                        .mapCharaToDTO(chara))
                .toList();

    }

    // Method to get a characters by id
    @GetMapping("/charaId/{charaId}")
    public GetCharaLightDTO getCharachterById(@PathVariable Long charaId) throws NoCharactersFoundException, Exception {

        GetCharaLightDTO result = new GetCharaLightDTO();

        Chara chara = charaService.getCharaById(charaId);

        // Return a character DTO mapped from the character
        result.mapCharaToDTO(chara);

        return result;

    }

}
