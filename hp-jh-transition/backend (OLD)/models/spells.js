const mongoose = require('mongoose');

const spellSchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  levels: [{
    modifiers: [{
      type: {
        type: String,
        default: ''
      },
      flat: {
        type: Number,
        default: 0
      },
      scaling: {
        type: String,
        default: ''
      },
      maxScaling: {
        type: Number,
        default: 0
      }
    }],
    cost: {
      type: Number,
      default: 0
    },
    dices: [{
      faces: {
        type: Number,
        default: 0
      },
      type: {
        type: String,
        default: ''
      },
      flat: {
        type: Number,
        default: 0
      },
      times: {
        type: Number,
        default: 1
      }
    }],
    newDescription: {
      type: String,
      default: ''
    }
  }],
  description: {
    type: String,
    default: 'Active'
  },
  lasting: {
    type: Boolean,
    default: false
  }
});

module.exports = mongoose.model('Spell', spellSchema);