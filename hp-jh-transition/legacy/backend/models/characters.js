const mongoose = require('mongoose');

const characterSchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  lvl: {
    type: Number,
    default: 1
  },
  race: {
    type: mongoose.Schema.Types.ObjectId,
    ref: 'Race',
    default: new mongoose.Types.ObjectId('6509e03ca44ab0dcb1afb522')
  },
  class: {
    type: mongoose.Schema.Types.ObjectId,
    ref: 'Class',
    default: new mongoose.Types.ObjectId('64dcc80f78d5abc32e6161fc')
  },
  style: {
    type: String,
    default: ''
  },
  from: {
    type: mongoose.Schema.Types.ObjectId,
    ref: 'State',
    default: new mongoose.Types.ObjectId('65002cc6a6930460e8fc3830')
  },
  description: {
    gender: {
      type: String,
      default: 'Non binario'
    },
    age: {
      type: Number,
      default: 0
    },
    eyes: {
      type: String,
      default: ''
    },
    hairs: {
      type: String,
      default: ''
    },
    height: {
      type: Number,
      default: 0
    },
    skin: {
      type: String,
      default: ''
    },
    weight: {
      type: Number,
      default: 0
    },
    lore: {
      type: String,
      default: ''
    },
    references: {
      type: [String],
      default: []
    }
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
    },
    HP: {
      type: Number,
      default: 0
    },
    HPmax: {
      type: Number,
      default: 0
    },
    MP: {
      type: Number,
      default: 0
    },
    ki: {
      type: Number,
      default: 0
    },
    miracles: {
      type: Number,
      default: 0
    }
  },
  abilities: {
    items: [{
      type: mongoose.Schema.Types.ObjectId,
      ref: 'Ability',
    }],
    uses: {
      type: [Number],
      default: []
    },
    statuses: {
      type: [Boolean],
      default: []
    }
  },
  spells: {
    items: [{
      type: mongoose.Schema.Types.ObjectId,
      ref: 'Spell'
    }],
    uses: {
      type: [Number],
      default: []
    },
    statuses: {
      type: [Boolean],
      default: []
    }
  },
  inventory: [{
    item: {
      type: mongoose.Schema.Types.ObjectId,
      ref: 'Item'
    },
    stacks: {
      type: Number,
      default: 0
    }
  }],
  upgradePoints: {
    type: Number,
    default: 0
  }
});

module.exports = mongoose.model('Character', characterSchema);