const mongoose = require('mongoose');

const classSchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  description: {
    type: String,
    default: ''
  },
  styles: [{
    name: {
      type: String,
      default: ''
    },
    description: {
      type: String,
      default: ''
    },
    abilities: {
      type: [mongoose.Schema.Types.ObjectId],
      ref: 'Ability'
    }
  }],
  paths: [{
    name: {
      type: String,
      default: ''
    },
    abilities: [{
      tier: {
        type: String,
        default: ''
      },
      id: {
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Ability',
      }
    }]
  }],
  statistics:{
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
    },
    baseHP: {
      type: Number,
      default: 0
    }
  }
});

module.exports = mongoose.model('Class', classSchema);