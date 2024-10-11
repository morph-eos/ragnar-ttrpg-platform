package com.jugglehive.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.jugglehive.backend.model.entity.ttrpg.Chara;

import java.util.List;


public interface CharaRepository extends JpaRepository<Chara, Long>{

    List<Chara> findAllByUserId(Long userId);


}
