const express = require('express');
const sequelize = require('./config/database');
const cors = require('cors');  // Importando o CORS
const userRoutes = require('./routes/userRoutes');

const app = express();

app.use(express.json());
app.use(cors());

app.use('/api', userRoutes);

// Sincroniza o banco de dados antes de iniciar o servidor
sequelize.sync().then(() => {
    console.log('Banco de dados sincronizado');
}).catch((error) => {
    console.error('Erro ao sincronizar o banco de dados:', error);
});

// Configuração do servidor para escutar na porta 3000
const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
    console.log(`Servidor rodando na porta ${PORT}`);
});
