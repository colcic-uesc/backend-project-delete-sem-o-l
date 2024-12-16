const express = require('express');
const router = express.Router();
const userController = require('../controllers/userController');

// Rotas CRUD
router.post('/users', userController.createUser);         // Criar usuário
router.get('/users', userController.getAllUsers);         // Buscar todos os usuários
router.get('/users/:id', userController.getUserById);     // Buscar usuário por ID
router.put('/users/:id', userController.updateUser);      // Atualizar usuário
router.delete('/users/:id', userController.deleteUser);   // Deletar usuário

module.exports = router;
