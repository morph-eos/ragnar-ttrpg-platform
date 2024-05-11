package com.jugglehive.backend.service;

import java.util.List;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.entity.ttrpg.Chara;

public interface CharaService {

    Chara getCharaById(Long id) throws NoCharactersFoundException, Exception;

    List<Chara> getAllCharas() throws Exception;

    List<Chara> getAllCharasByUserId(Long userId) throws NoCharactersFoundException, Exception;
}
