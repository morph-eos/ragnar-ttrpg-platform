using Microsoft.EntityFrameworkCore;

namespace JuggleHiveWebapp.Server.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllowedItem> AllowedItems { get; set; }

    public virtual DbSet<BaseStat> BaseStats { get; set; }

    public virtual DbSet<Chara> Charas { get; set; }

    public virtual DbSet<CharacterClass> CharacterClasses { get; set; }

    public virtual DbSet<CharacterInfo> CharacterInfos { get; set; }

    public virtual DbSet<CharacterSkill> CharacterSkills { get; set; }

    public virtual DbSet<CharactersTreePoint> CharactersTreePoints { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceSkill> RaceSkills { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillFamily> SkillFamilies { get; set; }

    public virtual DbSet<SkillModifier> SkillModifiers { get; set; }

    public virtual DbSet<SkillModifierDix> SkillModifierDices { get; set; }

    public virtual DbSet<TreeEntity> TreeEntities { get; set; }

    public virtual DbSet<TreeSkill> TreeSkills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth");

        modelBuilder.Entity<AllowedItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("allowed_item_pkey");

            entity.ToTable("allowed_item", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ItemType)
                .HasMaxLength(255)
                .HasColumnName("item_type");

            entity.HasOne(d => d.Class).WithMany(p => p.AllowedItems)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("allowed_item_class_id_fkey");
        });

        modelBuilder.Entity<BaseStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("base_stats_pkey");

            entity.ToTable("base_stats", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Arcane).HasColumnName("arcane");
            entity.Property(e => e.Charisma).HasColumnName("charisma");
            entity.Property(e => e.Dexterity).HasColumnName("dexterity");
            entity.Property(e => e.Instinct).HasColumnName("instinct");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Strength).HasColumnName("strength");
            entity.Property(e => e.Vitality).HasColumnName("vitality");
        });

        modelBuilder.Entity<Chara>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("chara_pkey");

            entity.ToTable("chara", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.InfoId).HasColumnName("info_id");
            entity.Property(e => e.LvlUpStatId).HasColumnName("lvl_up_stat_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Info).WithMany(p => p.Charas)
                .HasForeignKey(d => d.InfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chara_info_id_fkey");

            entity.HasOne(d => d.LvlUpStat).WithMany(p => p.Charas)
                .HasForeignKey(d => d.LvlUpStatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chara_lvl_up_stat_id_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.Charas)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chara_race_id_fkey");

            entity.HasOne(d => d.Region).WithMany(p => p.Charas)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chara_region_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Charas)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chara_user_id_fkey");
        });

        modelBuilder.Entity<CharacterClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("character_classes_pkey");

            entity.ToTable("character_classes", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterClasses)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_classes_character_id_fkey");

            entity.HasOne(d => d.Class).WithMany(p => p.CharacterClasses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_classes_class_id_fkey");
        });

        modelBuilder.Entity<CharacterInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("character_info_pkey");

            entity.ToTable("character_info", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrentFury).HasColumnName("current_fury");
            entity.Property(e => e.CurrentHp).HasColumnName("current_hp");
            entity.Property(e => e.CurrentKi).HasColumnName("current_ki");
            entity.Property(e => e.CurrentMetamorphs).HasColumnName("current_metamorphs");
            entity.Property(e => e.CurrentMiracles).HasColumnName("current_miracles");
            entity.Property(e => e.CurrentMp).HasColumnName("current_mp");
            entity.Property(e => e.Lvl).HasColumnName("lvl");
            entity.Property(e => e.MaxHp).HasColumnName("max_hp");
            entity.Property(e => e.Shield).HasColumnName("shield");
        });

        modelBuilder.Entity<CharacterSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("character_skills_pkey");

            entity.ToTable("character_skills", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TempUses).HasColumnName("temp_uses");
            entity.Property(e => e.TotalUses).HasColumnName("total_uses");
            entity.Property(e => e.UnlockedSkillId).HasColumnName("unlocked_skill_id");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterSkills)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_skills_character_id_fkey");

            entity.HasOne(d => d.UnlockedSkill).WithMany(p => p.CharacterSkills)
                .HasForeignKey(d => d.UnlockedSkillId)
                .HasConstraintName("character_skills_unlocked_skill_id_fkey");
        });

        modelBuilder.Entity<CharactersTreePoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("characters_tree_points_pkey");

            entity.ToTable("characters_tree_points", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailablePoints).HasColumnName("available_points");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.TreeId).HasColumnName("tree_id");

            entity.HasOne(d => d.Character).WithMany(p => p.CharactersTreePoints)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("characters_tree_points_character_id_fkey");

            entity.HasOne(d => d.Tree).WithMany(p => p.CharactersTreePoints)
                .HasForeignKey(d => d.TreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("characters_tree_points_tree_id_fkey");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("class_pkey");

            entity.ToTable("class", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StatsId).HasColumnName("stats_id");
            entity.Property(e => e.TreeId).HasColumnName("tree_id");

            entity.HasOne(d => d.Stats).WithMany(p => p.Classes)
                .HasForeignKey(d => d.StatsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_stats_id_fkey");

            entity.HasOne(d => d.Tree).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("class_tree_id_fkey");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_pkey");

            entity.ToTable("inventory", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Equipped).HasColumnName("equipped");
            entity.Property(e => e.Stacks).HasColumnName("stacks");

            entity.HasOne(d => d.Character).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_character_id_fkey");

            entity.HasMany(d => d.Items).WithMany(p => p.Inventories)
                .UsingEntity<Dictionary<string, object>>(
                    "InventoryItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("inventory_item_item_id_fkey"),
                    l => l.HasOne<Inventory>().WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("inventory_item_inventory_id_fkey"),
                    j =>
                    {
                        j.HasKey("InventoryId", "ItemId").HasName("inventory_item_pkey");
                        j.ToTable("inventory_item", "ttrpg");
                        j.IndexerProperty<long>("InventoryId").HasColumnName("inventory_id");
                        j.IndexerProperty<long>("ItemId").HasColumnName("item_id");
                    });
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_pkey");

            entity.ToTable("item", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MainSkillId).HasColumnName("main_skill_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Stackable).HasColumnName("stackable");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.MainSkill).WithMany(p => p.Items)
                .HasForeignKey(d => d.MainSkillId)
                .HasConstraintName("item_main_skill_id_fkey");

            entity.HasMany(d => d.Skills).WithMany(p => p.ItemsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "ItemSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("item_skill_skill_id_fkey"),
                    l => l.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("item_skill_item_id_fkey"),
                    j =>
                    {
                        j.HasKey("ItemId", "SkillId").HasName("item_skill_pkey");
                        j.ToTable("item_skill", "ttrpg");
                        j.IndexerProperty<long>("ItemId").HasColumnName("item_id");
                        j.IndexerProperty<long>("SkillId").HasColumnName("skill_id");
                    });
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("news_pkey");

            entity.ToTable("news", "menu");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("character varying")
                .HasColumnName("content");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.FlImportant)
                .HasDefaultValue(0)
                .HasColumnName("fl_important");
            entity.Property(e => e.Link)
                .HasColumnType("character varying")
                .HasColumnName("link");
            entity.Property(e => e.Summary)
                .HasColumnType("character varying")
                .HasColumnName("summary");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_pkey");

            entity.ToTable("race", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.LevelUpHp).HasColumnName("level_up_hp");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StatId).HasColumnName("stat_id");

            entity.HasOne(d => d.Stat).WithMany(p => p.Races)
                .HasForeignKey(d => d.StatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("race_stat_id_fkey");

            entity.HasMany(d => d.Regions).WithMany(p => p.Races)
                .UsingEntity<Dictionary<string, object>>(
                    "RaceRegion",
                    r => r.HasOne<Region>().WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("race_region_region_id_fkey"),
                    l => l.HasOne<Race>().WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("race_region_race_id_fkey"),
                    j =>
                    {
                        j.HasKey("RaceId", "RegionId").HasName("race_region_pkey");
                        j.ToTable("race_region", "ttrpg");
                        j.IndexerProperty<long>("RaceId").HasColumnName("race_id");
                        j.IndexerProperty<long>("RegionId").HasColumnName("region_id");
                    });
        });

        modelBuilder.Entity<RaceSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_skill_pkey");

            entity.ToTable("race_skill", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.SkillTreeId).HasColumnName("skill_tree_id");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceSkills)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("race_skill_race_id_fkey");

            entity.HasOne(d => d.SkillTree).WithMany(p => p.RaceSkills)
                .HasForeignKey(d => d.SkillTreeId)
                .HasConstraintName("race_skill_skill_tree_id_fkey");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("region_pkey");

            entity.ToTable("region", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skill_pkey");

            entity.ToTable("skill", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.CostType)
                .HasMaxLength(255)
                .HasColumnName("cost_type");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SkillFamilyId).HasColumnName("skill_family_id");
            entity.Property(e => e.SkillFamilyRank).HasColumnName("skill_family_rank");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.SkillFamily).WithMany(p => p.Skills)
                .HasForeignKey(d => d.SkillFamilyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("skill_skill_family_id_fkey");
        });

        modelBuilder.Entity<SkillFamily>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skill_family_pkey");

            entity.ToTable("skill_family", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<SkillModifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skill_modifier_pkey");

            entity.ToTable("skill_modifier", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsArea).HasColumnName("is_area");
            entity.Property(e => e.IsMalus).HasColumnName("is_malus");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.StatFlat).HasColumnName("stat_flat");
            entity.Property(e => e.StatMaxScaling).HasColumnName("stat_max_scaling");
            entity.Property(e => e.StatScaling)
                .HasMaxLength(255)
                .HasColumnName("stat_scaling");
            entity.Property(e => e.StatTarget)
                .HasMaxLength(255)
                .HasColumnName("stat_target");
            entity.Property(e => e.StatType)
                .HasMaxLength(255)
                .HasColumnName("stat_type");
            entity.Property(e => e.TargetNum).HasColumnName("target_num");
            entity.Property(e => e.TargetType)
                .HasMaxLength(255)
                .HasColumnName("target_type");

            entity.HasOne(d => d.Skill).WithMany(p => p.SkillModifiers)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("skill_modifier_skill_id_fkey");
        });

        modelBuilder.Entity<SkillModifierDix>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skill_modifier_dices_pkey");

            entity.ToTable("skill_modifier_dices", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Faces).HasColumnName("faces");
            entity.Property(e => e.SkillModifierId).HasColumnName("skill_modifier_id");
            entity.Property(e => e.Times).HasColumnName("times");

            entity.HasOne(d => d.SkillModifier).WithMany(p => p.SkillModifierDices)
                .HasForeignKey(d => d.SkillModifierId)
                .HasConstraintName("skill_modifier_dices_skill_modifier_id_fkey");
        });

        modelBuilder.Entity<TreeEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tree_entity_pkey");

            entity.ToTable("tree_entity", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TreeSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tree_skills_pkey");

            entity.ToTable("tree_skills", "ttrpg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParentSkillFamilyId).HasColumnName("parent_skill_family_id");
            entity.Property(e => e.SkillFamilyId).HasColumnName("skill_family_id");
            entity.Property(e => e.TreeId).HasColumnName("tree_id");

            entity.HasOne(d => d.ParentSkillFamily).WithMany(p => p.TreeSkillParentSkillFamilies)
                .HasForeignKey(d => d.ParentSkillFamilyId)
                .HasConstraintName("tree_skills_parent_skill_family_id_fkey");

            entity.HasOne(d => d.SkillFamily).WithMany(p => p.TreeSkillSkillFamilies)
                .HasForeignKey(d => d.SkillFamilyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tree_skills_skill_family_id_fkey");

            entity.HasOne(d => d.Tree).WithMany(p => p.TreeSkills)
                .HasForeignKey(d => d.TreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tree_skills_tree_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user", "login");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
