package com.jugglehive.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.jugglehive.backend.model.entity.ttrpg.BaseStats;

public interface BaseStatsRepository extends JpaRepository<BaseStats, Long> {

    @Query("SELECT bs FROM BaseStats bs WHERE bs.id = (SELECT c.lvlUpStat.id FROM chara c where c.id = :characterId)")
    BaseStats findBaseStatsByCharacterId(@Param("characterId") Long characterId);
}
