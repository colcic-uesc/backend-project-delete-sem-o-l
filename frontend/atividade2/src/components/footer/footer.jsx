import React from "react";
import styles from "./footer.module.css"

const Footer = () =>{
    return (
        <footer className={styles.footer}>
            <p className={styles.footerText}>&copy; 2024 DELLETE sem o L. Todos os direitos reservados.</p>
        </footer>
    )
}

export default Footer;