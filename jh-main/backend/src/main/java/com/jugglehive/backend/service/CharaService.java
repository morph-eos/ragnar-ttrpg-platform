package com.jugglehive.backend.service;

import java.util.List;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.entity.Chara;

public interface CharaService {

    Chara getCharaById(Long id);

    List<Chara> getAllCharas () throws Exception;

    List<Chara> getAllCharas (Long userId) throws NoCharactersFoundException, Exception;
}
