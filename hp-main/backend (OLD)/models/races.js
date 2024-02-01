const mongoose = require('mongoose');

const raceSchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  statistics: {
    constitution: {
      type: Number,
      default: 0
    },
    strength: {
      type: Number,
      default: 0
    },
    dexterity: {
      type: Number,
      default: 0
    },
    intelligence: {
      type: Number,
      default: 0
    },
    wisdom: {
      type: Number,
      default: 0
    },
    charisma: {
      type: Number,
      default: 0
    }
  },
  abilities: {
    items: [{
      type: mongoose.Schema.Types.ObjectId,
      ref: 'Ability',
    }],
    lvlsToGet: {
      type: [Number],
      default: []
    }
  },
  description: {
    type: String,
    default: ''
  },
  references: {
    type: [String],
    default: []
  }
});

module.exports = mongoose.model('Race', raceSchema);