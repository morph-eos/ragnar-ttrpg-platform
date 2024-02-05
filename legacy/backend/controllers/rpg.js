const Ability = require('../models/abilities.js');
const Character = require('../models/characters.js');
const Class = require('../models/classes.js');
const Race = require('../models/races.js');
const State = require('../models/states.js');
const Spell = require('../models/spells.js');
const { ObjectId } = require('mongoose').Types;

module.exports = {

  list: async (req, res) => {
    try {
      let all;
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
      const names = [];
      all.forEach(one => {
        //if (one.name !== 'NULL'){
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