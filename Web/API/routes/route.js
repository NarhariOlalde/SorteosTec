const express = require('express');
const userController = require('../Controller/UserController');
//const pageController = require('../controllers/pageController');
const router = express.Router();

router.get('/api/getUsers', userController.getUsers);
router.post("/api/createUser", userController.createUser);
router.post("/api/updateMaxScore", userController.updateMaxScore);


module.exports = router;