package com.jugglehive.backend.service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.jugglehive.backend.exception.customExceptions.NoCharactersFoundException;
import com.jugglehive.backend.model.dto.GetCharaLightDTO;
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


    public GetCharaLightDTO mapCharaToGetCharaLightDTO(Chara chara){

        GetCharaLightDTO result = new GetCharaLightDTO();

        if(chara == null){
            throw new NoCharactersFoundException("No characters found for id: ");

        }

        if(chara.getId() == null){

            throw new NoCharactersFoundException("No characters found for id: " );

        }


        result.setId(chara.getId());
        result.setUserId(chara.getUser().getId());
        result.setName(chara.getName());
        result.setAge(chara.getAge());
        result.setRegion(chara.getRegion().getName());
        result.setCurrentStats(calculateCurrentStats(chara));
        result.setClasses(getClassesNames(chara));
        result.setRace(chara.getRace().getName());
        result.setLevel(chara.getInfo().getLevel());
        result.setUrlImage("https://media-assets.wired.it/photos/638a19c0ddcebfa81a71fbad/16:9/w_1280,c_limit/Troll.jpg");


        return result;

    }

    @Override
     public Map<String, Integer> calculateCurrentStats(Chara chara) {

        if(chara == null) {
            throw new IllegalArgumentException("Chara is null");
        }

        if(chara.getId() == null) {
            throw new IllegalArgumentException("Chara id is null");
        }

        



        Map<String, Integer> stats = new HashMap<>();

        chara.getLvlUpStat().getStats().forEach((key, value) -> stats.merge(key, value, Integer::sum));

        chara.getRace().getStats().getStats().forEach((key, value) -> stats.merge(key, value, Integer::sum));

        chara.getClasses().stream()
                .map(CharacterClasses::getClassEntity)
                .map(classEntity -> (Map<String, Integer>) classEntity.getStats().getStats())
                .map(Map::entrySet)
                .forEach(entrySet -> entrySet.forEach(entry -> stats.merge(entry.getKey(), entry.getValue(), Integer::sum)));

        return stats;
    }



    @Override
    public List<String> getClassesNames(Chara chara) {
        
        if(chara == null) {
            throw new IllegalArgumentException("Chara is null");
        }

        if(chara.getId() == null) {
            throw new IllegalArgumentException("Chara id is null");
        }
        List<String> names = new ArrayList<>();

        for (CharacterClasses characterClasses : chara.getClasses()) {
            names.add(characterClasses.getClassEntity().getName());
        }

        return names;
    }

}
