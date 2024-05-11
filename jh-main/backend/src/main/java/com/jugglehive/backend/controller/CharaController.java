package com.jugglehive.backend.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.service.CharaService;

@RestController
@RequestMapping("/api/chara")
public class CharaController {
    
    @Autowired
    private CharaService charaService;


    //Method to get all characters by user id
    @GetMapping("/{userId}")
    public List<Chara> getAllCharachtersByUserId(@PathVariable Long userId) throws NoCharactersFoundException, Exception{

       return charaService.getAllCharas(userId);

    }


}
