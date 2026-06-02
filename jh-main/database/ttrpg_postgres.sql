CREATE SCHEMA IF NOT EXISTS ttrpg;

CREATE TABLE ttrpg.skill_family (
    id BIGSERIAL PRIMARY KEY
);
CREATE TABLE ttrpg.base_stats (
    id BIGSERIAL PRIMARY KEY,
    vitality INTEGER,
    strength INTEGER,
    dexterity INTEGER,
    arcane INTEGER,
    instinct INTEGER,
    charisma INTEGER,
    speed INTEGER
);

CREATE TABLE ttrpg.skill (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(150) NOT NULL,
    type VARCHAR(255) NOT NULL,
    cost INTEGER,
    cost_type VARCHAR(255),
    skill_family_id BIGINT NOT NULL,
    skill_family_rank INTEGER NOT NULL,
    FOREIGN KEY (skill_family_id) REFERENCES ttrpg.skill_family(id)
);

CREATE TABLE ttrpg.region (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(150) NOT NULL
);

CREATE TABLE ttrpg.race (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(150) NOT NULL,
    stat_id BIGINT NOT NULL,
    level_up_hp INTEGER NOT NULL,
    FOREIGN KEY (stat_id) REFERENCES ttrpg.base_stats(id)
);



CREATE TABLE ttrpg.tree_entity (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(150) NOT NULL
);

CREATE TABLE ttrpg.class (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(150) NOT NULL,
    tree_id BIGINT NOT NULL,
    stats_id BIGINT NOT NULL,
    FOREIGN KEY (tree_id) REFERENCES ttrpg.tree_entity(id),
    FOREIGN KEY (stats_id) REFERENCES ttrpg.base_stats(id)
);

CREATE TABLE ttrpg.character_info (
    id BIGSERIAL PRIMARY KEY,
    lvl INTEGER,
    current_hp INTEGER,
    shield INTEGER,
    max_hp INTEGER,
    current_mp INTEGER,
    current_ki INTEGER,
    current_fury INTEGER,
    current_miracles INTEGER,
    current_metamorphs INTEGER
);

CREATE TABLE ttrpg.chara (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT NOT NULL,
    info_id BIGINT NOT NULL,
    age INTEGER NOT NULL,
    name VARCHAR(50) NOT NULL,
    region_id BIGINT NOT NULL,
    race_id BIGINT NOT NULL,
    lvl_up_stat_id BIGINT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES login.user(id),
    FOREIGN KEY (info_id) REFERENCES ttrpg.character_info(id),
    FOREIGN KEY (region_id) REFERENCES ttrpg.region(id),
    FOREIGN KEY (race_id) REFERENCES ttrpg.race(id),
    FOREIGN KEY (lvl_up_stat_id) REFERENCES ttrpg.base_stats(id)
);

CREATE TABLE ttrpg.character_classes (
    id BIGSERIAL PRIMARY KEY,
    character_id BIGINT NOT NULL,
    class_id BIGINT NOT NULL,
    FOREIGN KEY (character_id) REFERENCES ttrpg.chara(id),
    FOREIGN KEY (class_id) REFERENCES ttrpg.class(id)
);

CREATE TABLE ttrpg.characters_tree_points (
    id BIGSERIAL PRIMARY KEY,
    character_id BIGINT NOT NULL,
    tree_id BIGINT NOT NULL,
    available_points INTEGER,
    FOREIGN KEY (character_id) REFERENCES ttrpg.chara(id),
    FOREIGN KEY (tree_id) REFERENCES ttrpg.tree_entity(id)
);

CREATE TABLE ttrpg.character_skills (
    id BIGSERIAL PRIMARY KEY,
    character_id BIGINT NOT NULL,
    total_uses INTEGER NOT NULL,
    status INTEGER,
    unlocked_skill_id BIGINT,
    temp_uses INTEGER,
    FOREIGN KEY (character_id) REFERENCES ttrpg.chara(id),
    FOREIGN KEY (unlocked_skill_id) REFERENCES ttrpg.skill(id)
);

CREATE TABLE ttrpg.allowed_item (
    id BIGSERIAL PRIMARY KEY,
    class_id BIGINT NOT NULL,
    item_type VARCHAR(255) NOT NULL,
    FOREIGN KEY (class_id) REFERENCES ttrpg.class(id)
);

CREATE TABLE ttrpg.tree_skills (
    id BIGSERIAL PRIMARY KEY,
    tree_id BIGINT NOT NULL,
    skill_family_id BIGINT NOT NULL,
    parent_skill_family_id BIGINT,
    FOREIGN KEY (tree_id) REFERENCES ttrpg.tree_entity(id),
    FOREIGN KEY (skill_family_id) REFERENCES ttrpg.skill_family(id),
    FOREIGN KEY (parent_skill_family_id) REFERENCES ttrpg.skill_family(id)
);

CREATE TABLE ttrpg.skill_modifier (
    id BIGSERIAL PRIMARY KEY,
    skill_id BIGINT NOT NULL,
    is_malus SMALLINT NOT NULL,
    is_area SMALLINT NOT NULL,
    target_num INTEGER NOT NULL,
    target_type VARCHAR(255) NOT NULL,
    stat_target VARCHAR(255),
    stat_flat INTEGER,
    stat_scaling VARCHAR(255),
    stat_max_scaling INTEGER,
    stat_type VARCHAR(255),
    FOREIGN KEY (skill_id) REFERENCES ttrpg.skill(id)
);

CREATE TABLE ttrpg.skill_modifier_dices (
    id BIGSERIAL PRIMARY KEY,
    times INTEGER NOT NULL,
    faces INTEGER NOT NULL,
    skill_modifier_id BIGINT,
    FOREIGN KEY (skill_modifier_id) REFERENCES ttrpg.skill_modifier(id)
);

CREATE TABLE ttrpg.inventory (
    id BIGSERIAL PRIMARY KEY,
    equipped BOOLEAN NOT NULL,
    stacks INTEGER,
    character_id BIGINT NOT NULL,
    FOREIGN KEY (character_id) REFERENCES ttrpg.chara(id)
);

CREATE TABLE ttrpg.item (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    type VARCHAR(255) NOT NULL,
    weight DOUBLE PRECISION NOT NULL,
    stackable BOOLEAN NOT NULL,
    main_skill_id BIGINT,
    FOREIGN KEY (main_skill_id) REFERENCES ttrpg.skill(id)
);

CREATE TABLE ttrpg.race_skill (
    id BIGSERIAL PRIMARY KEY,
    race_id BIGINT,
    skill_tree_id BIGINT,
    slot INTEGER,
    FOREIGN KEY (race_id) REFERENCES ttrpg.race(id),
    FOREIGN KEY (skill_tree_id) REFERENCES ttrpg.tree_entity(id)
);

CREATE TABLE ttrpg.item_skill (
    item_id BIGINT NOT NULL,
    skill_id BIGINT NOT NULL,
    PRIMARY KEY (item_id, skill_id),
    FOREIGN KEY (item_id) REFERENCES ttrpg.item(id),
    FOREIGN KEY (skill_id) REFERENCES ttrpg.skill(id)
);

CREATE TABLE ttrpg.race_region (
    race_id BIGINT NOT NULL,
    region_id BIGINT NOT NULL,
    PRIMARY KEY (race_id, region_id),
    FOREIGN KEY (race_id) REFERENCES ttrpg.race(id),
    FOREIGN KEY (region_id) REFERENCES ttrpg.region(id)
);

CREATE TABLE ttrpg.inventory_item (
    inventory_id BIGINT NOT NULL,
    item_id BIGINT NOT NULL,
    PRIMARY KEY (inventory_id, item_id),
    FOREIGN KEY (inventory_id) REFERENCES ttrpg.inventory(id),
    FOREIGN KEY (item_id) REFERENCES ttrpg.item(id)
);
