// models/user.js
const { DataTypes } = require("sequelize");
const sequelize = require("../config/database"); // Importa o Sequelize configurado

const User = sequelize.define('User', {
    nome: {
        type: DataTypes.STRING(50),
        allowNull: false
    },
    email: {
        type: DataTypes.STRING,
        allowNull: false
    },
    telefone: {
        type: DataTypes.STRING(11),
        allowNull: false
    },
    sexo: {
        type: DataTypes.ENUM('M','F'),
        allowNull: false
    },
    experiencia: {
        type: DataTypes.ENUM('Junior','Pleno','Senior'),
        allowNull: false
    }
}, {
    tableName: 'users',
    timestamps: true,
});

module.exports = User;
