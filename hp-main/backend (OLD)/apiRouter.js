const express = require('express');
const router = express.Router();

const rpgRouter = require('./routes/rpg.js');

router.use('/rpg', rpgRouter);

router.get('/', (req, res) => {
  res.send('Router per il funzionamento delle API');
});

module.exports = router;