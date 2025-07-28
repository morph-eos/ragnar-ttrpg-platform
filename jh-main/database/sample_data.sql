-- Sample Data for Ragnar TTRPG Platform
-- This file contains test/example data for development and testing purposes
-- Run this after creating the database schema with ttrpg_postgres.sql
-- 
-- Usage: Execute these INSERT statements to populate the database with sample entities
--        for testing the TTRPG game mechanics and application functionality

-- Insert into skill_family
INSERT INTO ttrpg.skill_family (id) VALUES (1), (2), (3);

-- Insert into skill
INSERT INTO ttrpg.skill (id, name, description, type, cost, cost_type, skill_family_id, skill_family_rank) VALUES
(1, 'Skill 1', 'Description 1', 'Type A', 10, 'CostType1', 1, 1),
(2, 'Skill 2', 'Description 2', 'Type B', 20, 'CostType2', 2, 2),
(3, 'Skill 3', 'Description 3', 'Type C', 30, 'CostType3', 3, 3);

-- Insert into region
INSERT INTO ttrpg.region (id, name, description) VALUES
(1, 'Region 1', 'Description 1'),
(2, 'Region 2', 'Description 2'),
(3, 'Region 3', 'Description 3');

-- Insert into base_stats
INSERT INTO ttrpg.base_stats (id, vitality, strength, dexterity, arcane, instinct, charisma, speed) VALUES
(1, 10, 15, 20, 25, 30, 35, 40),
(2, 12, 18, 22, 28, 32, 38, 42),
(3, 14, 20, 24, 30, 34, 40, 44);

-- Insert into tree_entity
INSERT INTO ttrpg.tree_entity (id, name, description) VALUES
(1, 'Tree 1', 'Description 1'),
(2, 'Tree 2', 'Description 2'),
(3, 'Tree 3', 'Description 3');

-- Insert into class
INSERT INTO ttrpg.class (id, name, description, tree_id, stats_id) VALUES
(1, 'Class 1', 'Description 1', 1, 1),
(2, 'Class 2', 'Description 2', 2, 2),
(3, 'Class 3', 'Description 3', 3, 3);

-- Insert into character_info
INSERT INTO ttrpg.character_info (id, lvl, current_hp, shield, max_hp, current_mp, current_ki, current_fury, current_miracles, current_metamorphs) VALUES
(1, 1, 100, 50, 200, 30, 20, 10, 5, 3),
(2, 2, 150, 75, 250, 40, 25, 15, 8, 5),
(3, 3, 200, 100, 300, 50, 30, 20, 10, 7);





-- Insert into allowed_item
INSERT INTO ttrpg.allowed_item (id, class_id, item_type) VALUES
(1, 1, 'ItemType1'),
(2, 2, 'ItemType2'),
(3, 3, 'ItemType3');

-- Insert into tree_skills
INSERT INTO ttrpg.tree_skills (id, tree_id, skill_family_id, parent_skill_family_id) VALUES
(1, 1, 1, NULL),
(2, 2, 2, 1),
(3, 3, 3, 2);

-- Insert into skill_modifier
INSERT INTO ttrpg.skill_modifier (id, skill_id, is_malus, is_area, target_num, target_type, stat_target, stat_flat, stat_scaling, stat_max_scaling, stat_type) VALUES
(1, 1, 1, 0, 1, 'TargetType1', 'StatTarget1', 10, 'StatScaling1', 100, 'StatType1'),
(2, 2, 0, 1, 2, 'TargetType2', 'StatTarget2', 20, 'StatScaling2', 200, 'StatType2'),
(3, 3, 1, 1, 3, 'TargetType3', 'StatTarget3', 30, 'StatScaling3', 300, 'StatType3');

-- Insert into skill_modifier_dices
INSERT INTO ttrpg.skill_modifier_dices (id, times, faces, skill_modifier_id) VALUES
(1, 2, 6, 1),
(2, 3, 8, 2),
(3, 4, 10, 3);


-- Insert into item
INSERT INTO ttrpg.item (id, name, description, type, weight, stackable, main_skill_id) VALUES
(1, 'Item 1', 'Description 1', 'Type 1', 1.1, TRUE, 1),
(2, 'Item 2', 'Description 2', 'Type 2', 2.2, FALSE, 2),
(3, 'Item 3', 'Description 3', 'Type 3', 3.3, TRUE, 3);

-- Insert into race
INSERT INTO ttrpg.race (id, name, description, stat_id, level_up_hp) VALUES
(1, 'Race 1', 'Description for Race 1', 1, 100),
(2, 'Race 2', 'Description for Race 2', 2, 200),
(3, 'Race 3', 'Description for Race 3', 3, 300);


-- Insert into race_skill
INSERT INTO ttrpg.race_skill (id, race_id, skill_tree_id, slot) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 3);

-- Insert into item_skill
INSERT INTO ttrpg.item_skill (item_id, skill_id) VALUES
(1, 1),
(2, 2),
(3, 3);

-- Insert into race_region
INSERT INTO ttrpg.race_region (race_id, region_id) VALUES
(1, 1),
(2, 2),
(3, 3);



-- Insert into chara
INSERT INTO ttrpg.chara (id, user_id, info_id, age, name, region_id, race_id, lvl_up_stat_id) VALUES
(1, 1, 1, 25, 'Chara 1', 1, 1, 1),
(2, 1, 2, 30, 'Chara 2', 2, 2, 2),
(3, 1, 3, 35, 'Chara 3', 3, 3, 3);


-- Insert into inventory
INSERT INTO ttrpg.inventory (id, equipped, stacks, character_id) VALUES
(1, TRUE, 1, 1),
(2, FALSE, 2, 2),
(3, TRUE, 3, 3);

-- Insert into inventory_item
INSERT INTO ttrpg.inventory_item (inventory_id, item_id) VALUES
(1, 1),
(2, 2),
(3, 3);

-- Insert into character_classes
INSERT INTO ttrpg.character_classes (id, character_id, class_id) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3);

-- Insert into characters_tree_points
INSERT INTO ttrpg.characters_tree_points (id, character_id, tree_id, available_points) VALUES
(1, 1, 1, 10),
(2, 2, 2, 20),
(3, 3, 3, 30);

-- Insert into character_skills
INSERT INTO ttrpg.character_skills (id, character_id, total_uses, status, unlocked_skill_id, temp_uses) VALUES
(1, 1, 5, 1, 1, 2),
(2, 2, 10, 2, 2, 3),
(3, 3, 15, 3, 3, 4);
