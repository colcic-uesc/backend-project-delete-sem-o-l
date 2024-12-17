"use client";

import React, { useState } from "react";
import styles from "./page.module.css";

export default function Home() {
    const [nome, setNome] = useState("");
    const [email, setEmail] = useState("");
    const [telefone, setTelefone] = useState("");
    const [sexo, setSexo] = useState("");
    const [experiencia, setExperiencia] = useState("");

    // Função para lidar com o envio do formulário
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault(); // Impede o comportamento padrão do formulário

        const userData = { nome, email, telefone, sexo, experiencia };

        try {
            const response = await fetch("http://localhost:3000/api/users", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(userData),
            });

            if (response.ok) {
                const data = await response.json();
                console.log("Usuário criado:", data);
            } else {
                console.error("Erro ao criar usuário. Status:", response.status); // Verifica o status
                const errorData = await response.json();
                console.error("Detalhes do erro:", errorData);
            }
        } catch (error) {
            console.error("Erro de rede:", error);
        }
    };

    return (
        <main className={styles.main}>
            <h1 className={styles.title}>Adicionar</h1>
            <br />

            <form className={styles.form} onSubmit={handleSubmit}>
                <input
                    className={styles.formInput}
                    type="text"
                    name="nome"
                    id="nome"
                    placeholder="Nome"
                    required
                    value={nome}
                    onChange={(e) => setNome(e.target.value)} // Atualiza o estado
                />
                <br />
                <input
                    className={styles.formInput}
                    type="email"
                    name="email"
                    id="email"
                    placeholder="E-mail"
                    required
                    value={email}
                    onChange={(e) => setEmail(e.target.value)} // Atualiza o estado
                />
                <br />
                <input
                    className={styles.formInput}
                    type="tel"
                    name="telefone"
                    id="telefone"
                    placeholder="Telefone"
                    required
                    value={telefone}
                    onChange={(e) => setTelefone(e.target.value)} // Atualiza o estado
                />
                <br />

                <select
                    className={styles.selectSexo}
                    name="sexo"
                    id="sexo"
                    required
                    value={sexo}
                    onChange={(e) => setSexo(e.target.value)} // Atualiza o estado
                >
                    <option value="" disabled>Gênero</option>
                    <option value="M">Masculino</option>
                    <option value="F">Feminino</option>
                </select>
                <br />

                <fieldset className={styles.formFieldset}>
                    <legend className={styles.formLegend}>Experiência:</legend>
                    <label>
                        <input
                            className={styles.formRadio}
                            type="radio"
                            name="experiencia"
                            value="Junior"
                            required
                            onChange={(e) => setExperiencia(e.target.value)} // Atualiza o estado
                        />
                        {" "} Júnior
                    </label>
                    <br />
                    <label>
                        <input
                            className={styles.formRadio}
                            type="radio"
                            name="experiencia"
                            value="Pleno"
                            onChange={(e) => setExperiencia(e.target.value)} // Atualiza o estado
                        />
                        {" "} Pleno
                    </label>
                    <br />
                    <label>
                        <input
                            className={styles.formRadio}
                            type="radio"
                            name="experiencia"
                            value="Senior"
                            onChange={(e) => setExperiencia(e.target.value)} // Atualiza o estado
                        />
                        {" "} Sênior
                    </label>
                    <br />
                </fieldset>
                <br />

                <button className={styles.formButton} type="submit">
                    <span className={styles.buttonText}>Enviar dados</span>
                </button>
            </form>
        </main>
    );
}