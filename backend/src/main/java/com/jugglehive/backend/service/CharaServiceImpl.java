package com.jugglehive.backend.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.entity.Chara;
import com.jugglehive.backend.repository.CharaRepository;

@Service
public class CharaServiceImpl implements CharaService {

    @Autowired
    private CharaRepository charaRepository;

    @Override
    public Chara getCharaById(Long id) {
        if (id == null) {
            System.out.println("id is null");
            return null;
        }
        return charaRepository.findById(id).orElse(null);
    }

    @Override
    public List<Chara> getAllCharas() throws Exception {

        List<Chara> result = null;

        try {

            result = charaRepository.findAll();

            if(result == null){

                throw new Exception("No charachters found");

            }
        } catch (Exception ex) {
            
            throw new Exception(ex.getMessage());

        }

        return result;
    }

    @Override
    public List<Chara> getAllCharas(Long userId) throws NoCharactersFoundException, Exception {


        if(userId == null){

           throw new IllegalArgumentException("userId is null");

        }

        List<Chara> result = null;

        result = charaRepository.findAllByUserId(userId);

            if(result == null){

                throw new NoCharactersFoundException("No characters found");

            }

            if(result.size() == 0){

                throw new NoCharactersFoundException("No characters found");

            }

        return result;
    }

}
