const mongoose = require('mongoose');

const abilitySchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  type: {
    type: String,
    default: 'Active'
  },
  description: {
    type: String,
    default: 'Active'
  },
  lasting: {
    type: Boolean,
    default: false
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
    activeMod: [{
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
    classCosts: {
      costMiracle: {
        type: Number,
        default: 0
      },
      costKi: {
        type: Number,
        default: 0
      }
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
    },
    cooldown: {
      fastRecharge: {
        type: Boolean,
        default: false
      },
      charges: {
        type: Number,
        default: 0
      },
      maxCharges: {
        type: Number,
        default: 0
      },
      has: {
        type: Boolean,
        default: false
      }
    }
  }],
  classQuirks: {
    isMiracle: {
      type: Boolean,
      default: false
    },
    isKi: {
      type: Boolean,
      default: false
    }
  },
  options: [{
    data: {
      type: String,
      default: false
    },
    type: {
      type: String,
      default: false
    },
    name: {
      type: String,
      default: false
    }
  }]
});

module.exports = mongoose.model('Ability', abilitySchema);