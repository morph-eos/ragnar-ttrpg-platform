package com.jugglehive.backend.service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.entity.ttrpg.Chara;
import com.jugglehive.backend.model.entity.ttrpg.CharacterClasses;
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


    //#TODO: gestione errori
    @Override
     public Map<String, Integer> calculateCurrentStats(Chara chara) {



        Map<String, Integer> stats = new HashMap<>();

        ///non vanno moltiplicati per il livello
        chara.getLvlUpStat().getStats().forEach((key, value) -> stats.merge(key, value * chara.getInfo().getLevel(), Integer::sum));

        chara.getRace().getStats().getStats().forEach((key, value) -> stats.merge(key, value, Integer::sum));

        chara.getClasses().stream()
                .map(CharacterClasses::getClassEntity)
                .map(classEntity -> (Map<String, Integer>) classEntity.getStats().getStats())
                .map(Map::entrySet)
                .forEach(entrySet -> entrySet.forEach(entry -> stats.merge(entry.getKey(), entry.getValue(), Integer::sum)));

        return stats;
    }



      //#TODO: gestione errori
    @Override
    public List<String> getClassesNames(Chara chara) {
        List<String> names = new ArrayList<>();

        for (CharacterClasses characterClasses : chara.getClasses()) {
            names.add(characterClasses.getClassEntity().getName());
        }

        return names;
    }

}
