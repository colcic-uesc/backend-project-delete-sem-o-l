"use client";

import React from "react";
import styles from "./page.module.css";

export default function Home() {
  // Função para lidar com o envio do formulário (substituindo a ação inline do `onsubmit`)
  const handleSubmit = (e: { preventDefault: () => void; }) => {
    e.preventDefault(); // Impede o comportamento padrão do formulário
  };

  return (
    <main className={styles.main}>
      <h1 className={styles.title}>Adicionar</h1>
      <br />

      <form className={styles.form} action="#" method="get" onSubmit={handleSubmit}>
            <input className={styles.formInput} type="text" name="nome" id="nome" placeholder="Nome" required />
            <br />
            <input className={styles.formInput} type="email" name="email" id="email" placeholder="E-mail" required />
            <br />
            <input className={styles.formInput} type="tel" name="telefone" id="telefone" placeholder="Telefone" required />
            <br />

            <select className={styles.selectSexo} name="sexo" id="sexo" required>
                <option value="" disabled selected>Gênero</option>
                <option value="masculino">Masculino</option>
                <option value="feminino">Feminino</option>
            </select>
            <br />

            <fieldset className={styles.formFieldset}>
                <legend className={styles.formLegend}>Experiência:</legend>
                <label>
                    <input className={styles.formRadio} type="radio" name="experiencia" value="junior" required />{" "} Júnior
                </label>
                <br />
                <label>
                    <input className={styles.formRadio} type="radio" name="experiencia" value="pleno" />{" "} Pleno
                </label>
                <br />
                <label>
                    <input className={styles.formRadio} type="radio" name="experiencia" value="senior" />{" "} Sênior
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