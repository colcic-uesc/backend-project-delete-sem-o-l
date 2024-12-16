const User = require('../models/user');

// Criar um novo usuário
exports.createUser = async (req, res) => {
  try {
    const { nome, email, telefone, sexo, experiencia } = req.body;
    const newUser = await User.create({ nome, email, telefone, sexo, experiencia });
    res.status(201).json(newUser);
  } catch (error) {
    res.status(400).json({ error: 'Erro ao criar usuário', details: error.message });
  }
};

// Buscar todos os usuários
exports.getAllUsers = async (req, res) => {
  try {
    const users = await User.findAll();
    res.json(users);
  } catch (error) {
    res.status(500).json({ error: 'Erro ao buscar usuários' });
  }
};

// Buscar usuário por ID
exports.getUserById = async (req, res) => {
  try {
    const { id } = req.params;
    const user = await User.findByPk(id);
    if (!user) return res.status(404).json({ error: 'Usuário não encontrado' });
    res.json(user);
  } catch (error) {
    res.status(500).json({ error: 'Erro ao buscar usuário' });
  }
};

// Atualizar usuário por ID
exports.updateUser = async (req, res) => {
  try {
    const { id } = req.params;
    const { nome, email, telefone, sexo, experiencia } = req.body;
    const user = await User.findByPk(id);

    if (!user) return res.status(404).json({ error: 'Usuário não encontrado' });

    await user.update({ nome, email, telefone, sexo, experiencia });
    res.json(user);

  } catch (error) {
    res.status(400).json({ error: 'Erro ao atualizar usuário', details: error.message });
  }
};

// Deletar usuário por ID
exports.deleteUser = async (req, res) => {
  try {
    const { id } = req.params;
    const user = await User.findByPk(id);

    if (!user) return res.status(404).json({ error: 'Usuário não encontrado' });

    await user.destroy();
    res.json({ message: 'Usuário deletado com sucesso' });
  } catch (error) {
    res.status(500).json({ error: 'Erro ao deletar usuário' });
  }
};
