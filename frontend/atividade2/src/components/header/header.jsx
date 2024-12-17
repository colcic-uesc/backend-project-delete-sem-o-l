"use client";

import React, { useState, useEffect } from "react";
import Link from "next/link"; // Importa o Link do Next.js
import styles from "./header.module.css";

const Header = () => {
  const [isMenuActive, setIsMenuActive] = useState(false);

  // Função que faz a animação dos links
  const animateLinks = () => {
    const navLinks = document.querySelectorAll(`.${styles.links}`);
    navLinks.forEach((link, index) => {
      link.style.animation
        ? (link.style.animation = "")
        : (link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7 + 0.3}s`);
    });
  };

  // Função que controla a ativação do menu mobile
  const handleMenuClick = () => {
    setIsMenuActive(!isMenuActive);
    animateLinks(); // Chama a animação dos links quando o menu é ativado
  };

  // UseEffect para manipular a classe do body e a animação
  useEffect(() => {
    if (isMenuActive) {
      document.body.classList.add(styles.noScroll); // Adiciona a classe quando o menu está ativo
    } else {
      document.body.classList.remove(styles.noScroll); // Remove quando o menu está inativo
    }

    return () => {
      document.body.classList.remove(styles.noScroll); // Limpeza da classe ao desmontar o componente
    };
  }, [isMenuActive]);

  return (
    <header className={styles.header}>
      <nav className={styles.navBar}>
        <h1 className={styles.headerTitle}>Atividade-front-1</h1>
        <div
          className={`${styles.mobileMenu} ${isMenuActive ? styles.active : ""}`}
          onClick={handleMenuClick}
        >
          <div className={styles.line1}></div>
          <div className={styles.line2}></div>
          <div className={styles.line3}></div>
        </div>
        <ul className={`${styles.navLinks} ${isMenuActive ? styles.active : ""}`}>
          <li>
            <Link href="/" className={styles.links}> {/* Usando Link do Next.js */}
              Listagem
            </Link>
          </li>
          <li>
            <Link href="/views/adicionar" className={styles.links}> {/* Caminho correto para a página de formulário */}
              Adicionar
            </Link>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;