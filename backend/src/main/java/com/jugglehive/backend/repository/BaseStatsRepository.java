package com.jugglehive.backend.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.jugglehive.backend.model.entity.ttrpg.BaseStats;

public interface BaseStatsRepository extends JpaRepository<BaseStats, Long> {

    List<BaseStats> findAllByCharacterId(Long charaId);
}
