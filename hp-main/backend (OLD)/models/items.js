const mongoose = require('mongoose');

const itemSchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  canstack: {
    type: Boolean,
    default: false
  },
  description: {
    type: String,
    default: ''
  },
  modifiers: [{
    type: {
      type: String,
      default: ''
    },
    scaling: {
      type: String,
      default: ''
    },
    maxscaling: {
      type: Number,
      default: 0
    },
    flat: {
      type: Number,
      default: 0
    }
  }]
});

module.exports = mongoose.model('Item', itemSchema);