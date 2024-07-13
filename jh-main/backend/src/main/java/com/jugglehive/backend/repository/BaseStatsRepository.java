package com.jugglehive.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.jugglehive.backend.model.entity.ttrpg.BaseStats;

public interface BaseStatsRepository extends JpaRepository<BaseStats, Long> {

}
