/*
 * RPG Controller - Legacy TTRPG Game Mechanics
 * 
 * This controller handles all TTRPG-related operations for the original HeatPeak Studio
 * platform. It manages characters, classes, races, abilities, spells, and game states
 * using MongoDB as the data store. This represents the initial implementation of the
 * TTRPG system before the evolution to the modern PostgreSQL-based architecture.
 * 
 * Key Features:
 * - Character management (CRUD operations)
 * - Class and race system management
 * - Spell and ability system handling
 * - Game state management
 * - MongoDB document-based data modeling
 * 
 * Architecture Notes:
 * - Uses Mongoose ODM for MongoDB interactions
 * - Single controller approach (later refactored into multiple controllers)
 * - Direct database access (later abstracted through service layer)
 * 
 * Historical Context:
 * This code represents the original "Ragnar" TTRPG concept implementation,
 * showcasing the progression from prototype to enterprise architecture.
 */

const Ability = require('../models/abilities.js');
const Character = require('../models/characters.js');
const Class = require('../models/classes.js');
const Race = require('../models/races.js');
const State = require('../models/states.js');
const Spell = require('../models/spells.js');
const { ObjectId } = require('mongoose').Types;

module.exports = {

  /**
   * Generic list endpoint for retrieving collections of game entities
   * Supports multiple entity types through query parameter switching
   * @param {Object} req - Express request object with query.type parameter
   * @param {Object} res - Express response object
   */
  list: async (req, res) => {
    try {
      let all;
      // Dynamic entity type selection based on query parameter
      switch (req.query.type) {
        case 'characters':
          all = await Character.find({});
          break;
        case 'classes':
          all = await Class.find({});
          break;
        case 'states':
          all = await State.find({});
          break;
        case 'races':
          all = await Race.find({});
          break;
        default:
          break;
      }
      
      // Transform full documents to lightweight name/id pairs for UI dropdowns
      const names = [];
      all.forEach(one => {
        //if (one.name !== 'NULL'){  // Legacy filtering logic
          names.push({name: one.name, id: one._id});
        //}
      });
      res.status(200).json(names);
    } catch (error) {
      console.error('Error while retrieving the list:', error);
      return res.status(500).json({ message: 'Error while retrieving the list' });
    }
  },

  print: async (req, res) => {
    try {
      const {id, type} = req.body;
      let found;
      switch (type) {
        case 'characters':
          found = await Character.findOne({_id: id})
            .populate('race')
            .populate('class')
            .populate('from')
            .populate('abilities.items')
            .populate('spells.items');
          break;
        case 'classs':
          found = await Class.findOne({_id: id});
          break;
        case 'states':
          found = await State.findOne({_id: id})
          .populate('races');
          break;
        case 'races':
          found = await Race.findOne({_id: id})
          .populate('abilities.items');
          break;
        default:
          break;
      }
      res.status(200).json(found);
    } catch (error) {
      console.error('Error while retrieving the data:', error);
      return res.status(500).json({ message: 'Error while retrieving the data' });
    }
  },

  charaNew: async (req, res) => {
    try {
      const {name, lvl, race, classId, style, from} = req.body;
      const {gender, age, eyes, hairs, height, skin, weight, lore, references} = req.body;
      const {constitution, strength, dexterity, intelligence, wisdom, charisma} = req.body;
      const {abilities, spells, inventory} = req.body;

      const classObj = await Class.find({_id: classId});
      let ki = 0;
      let miracles = 0;
      if (classObj.name === "Paladin") {
        miracles = 2;
      } else if (classObj.name === "Monk") {
        ki = 2;
      }
      
      let newAbilities;
      if (abilities) {
        newAbilities = abilities.map((abilityId) => ({id: abilityId}));
      }
      let newSpells;
      if (spells) {
        newSpells = abilities.map((spellId) => ({id: spellId}));
      }
      let newItems;
      if (items) {
        newItems = items.map((item) => ({item: item}));
      }
      
      const newCharacter = new Character({
        name: name,
        lvl: lvl,
        race: new ObjectId (race),
        classId: new ObjectId (classId),
        style: style,
        from: new ObjectId (from),
        description: {
          gender: gender,
          age: age,
          eyes: eyes,
          hairs: hairs,
          height: height,
          skin: skin,
          weight: weight,
          lore: lore,
          references: references
        },
        statistics: {
          constitution: constitution,
          strength: strength,
          dexterity: dexterity,
          intelligence: intelligence,
          wisdom: wisdom,
          charisma: charisma,
          HP: (classObj.statistics.baseHP + constitution),
          HPmax: (classObj.statistics.baseHP + constitution),
          MP: (intelligence*10),
          ki: ki,
          miracles: miracles
        },
        abilities: newAbilities,
        spells: newSpells,
        inventory: newItems
      });

      // Salva il nuovo personaggio nel database
      await newCharacter.save();

      // Invia una risposta di successo al client
      res.status(200).json({ message: 'New character created successfully', character: newCharacter });
    } catch (error) {
      console.error('Error while creating and sending to db a new chatacter:', error);
      return res.status(500).json({ message: 'Error while creating and sending to db a new chatacter' });
    }
  }
  
};