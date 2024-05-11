package com.jugglehive.backend.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.repository.CharaRepository;

@Service
public class CharaServiceImpl implements CharaService {

    @Autowired
    private CharaRepository charaRepository;

    @Override
    public Chara getCharaById(Long id) throws NoCharactersFoundException, Exception {

        if (id == null) {

            throw new IllegalArgumentException("Id is null");
        }

        Chara result = null;

        result = charaRepository.findById(id).orElse(null);

        if (result == null) {

            throw new NoCharactersFoundException("No characters found for id: " + id);

        }

        return result;

    }

    @Override
    public List<Chara> getAllCharasByUserId(Long userId) throws NoCharactersFoundException, Exception {

        if (userId == null) {

            throw new IllegalArgumentException("userId is null");

        }

        List<Chara> result = null;

        result = charaRepository.findAllByUserId(userId);

        if (result == null) {

            throw new NoCharactersFoundException("No characters found");

        }

        if (result.size() == 0) {

            throw new NoCharactersFoundException("No characters found");

        }

        return result;
    }

    @Override
    public List<Chara> getAllCharas() throws Exception {

        List<Chara> result = null;

        try {

            result = charaRepository.findAll();

            if (result == null) {

                throw new Exception("No charachters found");

            }
        } catch (Exception ex) {

            throw new Exception(ex.getMessage());

        }

        return result;
    }

}
