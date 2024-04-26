package com.jugglehive.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.jugglehive.model.entity.Chara;
import com.jugglehive.service.CharaService;

@RestController
@RequestMapping("/api/chara/")
public class CharaController {
    @Autowired
    private CharaService charaService;

    @GetMapping("getCharaById/{id}")
    public ResponseEntity<?> getCharaById(@PathVariable Long id) {
        Chara responseBody = null;
        try {
            responseBody = charaService.getCharaById(id);
            if(responseBody == null){
                return new ResponseEntity<>("Chara not found", HttpStatus.NOT_FOUND);
            }
        } catch (Exception e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR);
        }

        return new ResponseEntity<Chara>(responseBody, HttpStatus.OK);

    }

}
