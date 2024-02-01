const mongoose = require('mongoose');

const stateSchema = new mongoose.Schema({
  _id: {
    type: mongoose.Schema.Types.ObjectId,
    auto: true
  },
  name: {
    type: String,
    required: true,
    default: ''
  },
  races: [{
    type: mongoose.Schema.Types.ObjectId,
    ref: 'Race',
    default: new mongoose.Types.ObjectId('64dcbeb278d5abc32e6161f7')
  }],
  languages: {
    type: String,
    default: ''
  },
  references: {
    type: [String],
    default: []
  }
});

module.exports = mongoose.model('State', stateSchema);