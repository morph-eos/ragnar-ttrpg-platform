const express = require('express');
const router = express.Router();
const path = require('path');

const rpgController = require('../controllers/rpg.js');

router.get('/list', rpgController.list);

router.post('/print', rpgController.print);

router.post('/charaNew', rpgController.charaNew);

router.get('/references/:imgName', (req, res) => {
    res.sendFile(path.join(__dirname, '..', 'static', 'rpg', 'references', req.params.imgName));
});

module.exports = router;