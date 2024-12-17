"use client";

import React, { useState, useEffect } from "react";
import { useParams } from "next/navigation"; // Importa o useParams para acessar os parâmetros da rota
import styles from "./page.module.css";

interface User {
  id: number;
  nome: string;
  email: string;
  telefone: string;
  sexo: string;
  experiencia: string;
}

export default function EditUserPage() {
    const { id } = useParams(); // Pega o ID da rota dinâmica
    const userId = id; // Converte para uma variável utilizável

    const [user, setUser] = useState<User | null>(null);
    const [nome, setNome] = useState("");
    const [email, setEmail] = useState("");
    const [telefone, setTelefone] = useState("");
    const [sexo, setSexo] = useState("");
    const [experiencia, setExperiencia] = useState("");

    // Busca os dados do usuário para edição
    useEffect(() => {
        const fetchUser = async () => {
            try {
                const response = await fetch(`http://localhost:3000/api/users/${userId}`);
                if (response.ok) {
                    const data = await response.json();
                    setUser(data);
                    setNome(data.nome);
                    setEmail(data.email);
                    setTelefone(data.telefone);
                    setSexo(data.sexo);
                    setExperiencia(data.experiencia);
                } else {
                    console.error("Erro ao buscar usuário:", response.statusText);
                }
            } catch (error) {
                console.error("Erro de rede:", error);
            }
        };

        if (userId) fetchUser();
    }, [userId]);

    // Função para salvar as alterações
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault(); // Impede o comportamento padrão do formulário

        const updatedUserData = { nome, email, telefone, sexo, experiencia };

        try {
            const response = await fetch(`http://localhost:3000/api/users/${userId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(updatedUserData),
            });

            if (response.ok) {
                alert("Usuário atualizado com sucesso!");
            } else {
                console.error("Erro ao atualizar usuário. Status:", response.status);
            }
        } catch (error) {
            console.error("Erro de rede:", error);
        }
    };

    if (!user) {
        return <p>Carregando dados do usuário...</p>;
    }

    return (
        <main className={styles.main}>
            <h1 className={styles.title}>Editar Usuário</h1>
            <form className={styles.form} onSubmit={handleSubmit}>
                <input
                    className={styles.formInput}
                    type="text"
                    placeholder="Nome"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                    required
                />
                <input
                    className={styles.formInput}
                    type="email"
                    placeholder="E-mail"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <input
                    className={styles.formInput}
                    type="tel"
                    placeholder="Telefone"
                    value={telefone}
                    onChange={(e) => setTelefone(e.target.value)}
                    required
                />
                <select
                    className={styles.selectSexo}
                    value={sexo}
                    onChange={(e) => setSexo(e.target.value)}
                    required
                >
                    <option value="" disabled>Gênero</option>
                    <option value="M">Masculino</option>
                    <option value="F">Feminino</option>
                </select>
                <fieldset className={styles.formFieldset}>
                    <legend className={styles.formLegend}>Experiência:</legend>
                    <label>
                        <input
                            type="radio"
                            value="Junior"
                            checked={experiencia === "Junior"}
                            onChange={(e) => setExperiencia(e.target.value)}
                        />
                        Júnior
                    </label>
                    <label>
                        <input
                            type="radio"
                            value="Pleno"
                            checked={experiencia === "Pleno"}
                            onChange={(e) => setExperiencia(e.target.value)}
                        />
                        Pleno
                    </label>
                    <label>
                        <input
                            type="radio"
                            value="Senior"
                            checked={experiencia === "Senior"}
                            onChange={(e) => setExperiencia(e.target.value)}
                        />
                        Sênior
                    </label>
                </fieldset>
                <button className={styles.formButton} type="submit">
                    Salvar Alterações
                </button>
            </form>
        </main>
    );
}