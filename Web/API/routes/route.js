const express = require('express');
const userController = require('../Controller/UserController');
//const pageController = require('../controllers/pageController');
const router = express.Router();

router.get('/api/getUsers', userController.getUsers);
//outer.post('/api/addBook', bookController.addBook);
//outer.put('/api/editBook/:id', bookController.editBook);
//outer.delete('/api/deleteBook/:id', bookController.deleteBook);
//
//outer.get('/api/getPages', pageController.getPages);
//outer.post('/api/addPage', pageController.addPage);
//outer.put('/api/editPage/:id', pageController.editPage);
//outer.delete('/api/deletePage/:id', pageController.deletePage);

module.exports = router;