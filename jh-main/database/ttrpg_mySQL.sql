-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: ttrpg
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `allowed_item`
--

DROP TABLE IF EXISTS `allowed_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `allowed_item` (
  `class_id` int NOT NULL,
  `item_type` enum('Heavy Armor','Medium Armor','Light Armor','Consumables','One-Handed Sword','Two-Handed Sword','Shield','Axe','Spear','Staff','Bow','Crossbow','Hammer','Club','Dagger','Musical Instrument','Spellbook') NOT NULL,
  PRIMARY KEY (`class_id`),
  CONSTRAINT `FK_allowed_item_class_id` FOREIGN KEY (`class_id`) REFERENCES `class` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `base_stats`
--

DROP TABLE IF EXISTS `base_stats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `base_stats` (
  `id` int NOT NULL,
  `vitality` int DEFAULT NULL,
  `strength` int DEFAULT NULL,
  `dexterity` int DEFAULT NULL,
  `arcane` int DEFAULT NULL,
  `instinct` int DEFAULT NULL,
  `charisma` int DEFAULT NULL,
  `speed` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chara`
--

DROP TABLE IF EXISTS `chara`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chara` (
  `id` int NOT NULL,
  `info_id` int NOT NULL,
  `age` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `region_id` int NOT NULL,
  `race_id` int NOT NULL,
  `lvl_up_stat_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_chara_info_id` (`info_id`),
  KEY `FK_chara_region_id` (`region_id`),
  KEY `FK_chara_race_id` (`race_id`),
  KEY `FK_chara_lvl_up_stat_id` (`lvl_up_stat_id`),
  CONSTRAINT `FK_chara_info_id` FOREIGN KEY (`info_id`) REFERENCES `character_info` (`id`),
  CONSTRAINT `FK_chara_lvl_up_stat_id` FOREIGN KEY (`lvl_up_stat_id`) REFERENCES `base_stats` (`id`),
  CONSTRAINT `FK_chara_race_id` FOREIGN KEY (`race_id`) REFERENCES `race` (`id`),
  CONSTRAINT `FK_chara_region_id` FOREIGN KEY (`region_id`) REFERENCES `region` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `character_classes`
--

DROP TABLE IF EXISTS `character_classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `character_classes` (
  `character_id` int NOT NULL,
  `class_id` int NOT NULL,
  PRIMARY KEY (`character_id`,`class_id`),
  KEY `FK_character_classes_class_id` (`class_id`),
  CONSTRAINT `FK_character_classes_character_id` FOREIGN KEY (`character_id`) REFERENCES `chara` (`id`),
  CONSTRAINT `FK_character_classes_class_id` FOREIGN KEY (`class_id`) REFERENCES `class` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `character_info`
--

DROP TABLE IF EXISTS `character_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `character_info` (
  `id` int NOT NULL,
  `lvl` int DEFAULT NULL,
  `current_hp` int DEFAULT NULL,
  `shield` int DEFAULT NULL,
  `max_hp` int DEFAULT NULL,
  `current_mp` int DEFAULT NULL,
  `current_ki` int DEFAULT NULL,
  `current_fury` int DEFAULT NULL,
  `current_miracles` int DEFAULT NULL,
  `current_metamorphs` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `character_skills`
--

DROP TABLE IF EXISTS `character_skills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `character_skills` (
  `character_id` int NOT NULL,
  `total_uses` int NOT NULL DEFAULT '0',
  `status` int DEFAULT NULL,
  `unlocked_skill_id` int DEFAULT NULL,
  `temp_uses` int DEFAULT NULL,
  PRIMARY KEY (`character_id`),
  KEY `FK_character_skills_unlocked_skill_id` (`unlocked_skill_id`),
  CONSTRAINT `FK_character_skills_character_id` FOREIGN KEY (`character_id`) REFERENCES `chara` (`id`),
  CONSTRAINT `FK_character_skills_unlocked_skill_id` FOREIGN KEY (`unlocked_skill_id`) REFERENCES `skill` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `characters_tree_points`
--

DROP TABLE IF EXISTS `characters_tree_points`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characters_tree_points` (
  `character_id` int NOT NULL,
  `tree_id` int NOT NULL,
  `available_points` int DEFAULT NULL,
  PRIMARY KEY (`character_id`,`tree_id`),
  KEY `FK_characters_tree_points_tree_id` (`tree_id`),
  CONSTRAINT `FK_characters_tree_points_character_id` FOREIGN KEY (`character_id`) REFERENCES `chara` (`id`),
  CONSTRAINT `FK_characters_tree_points_tree_id` FOREIGN KEY (`tree_id`) REFERENCES `tree` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class` (
  `id` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(150) NOT NULL,
  `tree_id` int NOT NULL,
  `stats_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_class_tree_id` (`tree_id`),
  KEY `FK_class_stats_id` (`stats_id`),
  CONSTRAINT `FK_class_stats_id` FOREIGN KEY (`stats_id`) REFERENCES `base_stats` (`id`),
  CONSTRAINT `FK_class_tree_id` FOREIGN KEY (`tree_id`) REFERENCES `tree` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `character_id` int NOT NULL,
  `item_id` int NOT NULL,
  `equipped` tinyint(1) NOT NULL DEFAULT '0',
  `stacks` int DEFAULT NULL,
  PRIMARY KEY (`character_id`),
  KEY `FK_inventory_item_id` (`item_id`),
  CONSTRAINT `FK_inventory_character_id` FOREIGN KEY (`character_id`) REFERENCES `chara` (`id`),
  CONSTRAINT `FK_inventory_item_id` FOREIGN KEY (`item_id`) REFERENCES `item` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item` (
  `id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `type` enum('Heavy Armor','Medium Armor','Light Armor','Consumables','One-Handed Sword','Two-Handed Sword','Shield','Axe','Spear','Staff','Bow','Crossbow','Hammer','Club','Dagger','Musical Instrument','Spellbook') NOT NULL,
  `main_skill_id` int DEFAULT NULL,
  `weight` double NOT NULL,
  `stackable` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FK_item_main_skill_id` (`main_skill_id`),
  CONSTRAINT `FK_item_main_skill_id` FOREIGN KEY (`main_skill_id`) REFERENCES `skill` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `item_skill`
--

DROP TABLE IF EXISTS `item_skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item_skill` (
  `item_id` int NOT NULL,
  `skill_id` int NOT NULL,
  PRIMARY KEY (`item_id`,`skill_id`),
  KEY `FK_item_skill_skill_id` (`skill_id`),
  CONSTRAINT `FK_item_skill_item_id` FOREIGN KEY (`item_id`) REFERENCES `item` (`id`),
  CONSTRAINT `FK_item_skill_skill_id` FOREIGN KEY (`skill_id`) REFERENCES `skill` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `race`
--

DROP TABLE IF EXISTS `race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `race` (
  `id` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(150) NOT NULL,
  `stat_id` int NOT NULL,
  `level_up_hp` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `race_region`
--

DROP TABLE IF EXISTS `race_region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `race_region` (
  `race_id` int NOT NULL,
  `region_id` int NOT NULL,
  PRIMARY KEY (`race_id`,`region_id`),
  KEY `FK_race_region_region_id` (`region_id`),
  CONSTRAINT `FK_race_region_race_id` FOREIGN KEY (`race_id`) REFERENCES `race` (`id`),
  CONSTRAINT `FK_race_region_region_id` FOREIGN KEY (`region_id`) REFERENCES `region` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `race_skill`
--

DROP TABLE IF EXISTS `race_skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `race_skill` (
  `race_id` int NOT NULL,
  `skill_tree_id` int NOT NULL,
  `slot` int DEFAULT NULL,
  PRIMARY KEY (`race_id`,`skill_tree_id`),
  KEY `FK_race_skill_skill_tree_id` (`skill_tree_id`),
  CONSTRAINT `FK_race_skill_race_id` FOREIGN KEY (`race_id`) REFERENCES `race` (`id`),
  CONSTRAINT `FK_race_skill_skill_tree_id` FOREIGN KEY (`skill_tree_id`) REFERENCES `tree` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `region`
--

DROP TABLE IF EXISTS `region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `region` (
  `id` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `skill`
--

DROP TABLE IF EXISTS `skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skill` (
  `id` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(150) NOT NULL,
  `type` enum('Passive','Active','UnlockTree') NOT NULL,
  `cost` int DEFAULT NULL,
  `cost_type` enum('Mana','Uses','Stacks','1','3','5') DEFAULT NULL,
  `skill_family_id` int NOT NULL,
  `skil_family_rank` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `skill_family_id` (`skill_family_id`),
  CONSTRAINT `skill_ibfk_1` FOREIGN KEY (`skill_family_id`) REFERENCES `skill_family` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `skill_family`
--

DROP TABLE IF EXISTS `skill_family`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skill_family` (
  `id` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `skill_modifier`
--

DROP TABLE IF EXISTS `skill_modifier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skill_modifier` (
  `id` int NOT NULL,
  `skill_id` int NOT NULL,
  `is_malus` tinyint NOT NULL DEFAULT '0',
  `is_area` tinyint NOT NULL DEFAULT '1',
  `target_num` int NOT NULL DEFAULT '1',
  `target_type` enum('Enemy','Ally','All','Self') NOT NULL,
  `stat_target` enum('Armor','Vitality','Strength','Dexterity','Arcane','Instinct','Charisma','Speed','HP','Mana','Damage') DEFAULT NULL,
  `stat_flat` int DEFAULT NULL,
  `stat_scaling` enum('Armor','Vitality','Strength','Dexterity','Arcane','Instinct','Charisma','Speed','HP','Mana','Level','Base Skill','Damage') DEFAULT NULL,
  `stat_max_scaling` int DEFAULT NULL,
  `stat_type` enum('Sum','Product','Fraction') DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_skill_modifier_skill_id` (`skill_id`),
  CONSTRAINT `FK_skill_modifier_skill_id` FOREIGN KEY (`skill_id`) REFERENCES `skill` (`id`),
  CONSTRAINT `skill_modifier_ibfk_1` FOREIGN KEY (`skill_id`) REFERENCES `skill` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `skill_modifier_dices`
--

DROP TABLE IF EXISTS `skill_modifier_dices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skill_modifier_dices` (
  `skill_modifier_id` int NOT NULL,
  `times` int NOT NULL DEFAULT '1',
  `faces` int NOT NULL,
  PRIMARY KEY (`skill_modifier_id`),
  CONSTRAINT `skill_modifier_dices_ibfk_1` FOREIGN KEY (`skill_modifier_id`) REFERENCES `skill_modifier` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tree`
--

DROP TABLE IF EXISTS `tree`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tree` (
  `id` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tree_skills`
--

DROP TABLE IF EXISTS `tree_skills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tree_skills` (
  `tree_id` int NOT NULL,
  `skill_family_id` int NOT NULL,
  `parent_skill_family_id` int DEFAULT NULL,
  PRIMARY KEY (`tree_id`),
  KEY `FK_tree_skills_skill_family_id` (`skill_family_id`),
  CONSTRAINT `FK_tree_skills_skill_family_id` FOREIGN KEY (`skill_family_id`) REFERENCES `skill_family` (`id`),
  CONSTRAINT `FK_tree_skills_tree_id` FOREIGN KEY (`tree_id`) REFERENCES `tree` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-10  2:06:06
