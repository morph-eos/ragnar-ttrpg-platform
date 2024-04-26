package com.jugglehive.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.model.entity.Chara;
import com.jugglehive.repository.CharaRepository;

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

}
