import Image from "next/image";
import styles from "./page.module.css";

export default function Home() {
    return (
        <main className={styles.mainHome}>
            <button className={styles.btn1}>Listar</button>
            <button className={styles.btn2}>Editar</button>
            <button className={styles.btn3}>Excluir</button>

            <table className={styles.tabelaHome}>
                <tr>
                    <td className={styles.tdTabela}>A1</td>
                    <td className={styles.tdTabela}>B1</td>
                    <td className={styles.tdTabela}>C1</td>
                    <td className={styles.tdTabela}>D1</td>
                    <td className={styles.tdTabela}>E1</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A2</td>
                    <td className={styles.tdTabela}>B2</td>
                    <td className={styles.tdTabela}>C2</td>
                    <td className={styles.tdTabela}>D2</td>
                    <td className={styles.tdTabela}>E2</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A3</td>
                    <td className={styles.tdTabela}>B3</td>
                    <td className={styles.tdTabela}>C3</td>
                    <td className={styles.tdTabela}>D3</td>
                    <td className={styles.tdTabela}>E3</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A4</td>
                    <td className={styles.tdTabela}>B4</td>
                    <td className={styles.tdTabela}>C4</td>
                    <td className={styles.tdTabela}>D4</td>
                    <td className={styles.tdTabela}>E4</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A5</td>
                    <td className={styles.tdTabela}>B5</td>
                    <td className={styles.tdTabela}>D5</td>
                    <td className={styles.tdTabela}>C5</td>
                    <td className={styles.tdTabela}>E5</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A6</td>
                    <td className={styles.tdTabela}>B6</td>
                    <td className={styles.tdTabela}>D6</td>
                    <td className={styles.tdTabela}>C6</td>
                    <td className={styles.tdTabela}>E6</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A7</td>
                    <td className={styles.tdTabela}>B7</td>
                    <td className={styles.tdTabela}>D7</td>
                    <td className={styles.tdTabela}>C7</td>
                    <td className={styles.tdTabela}>E7</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A8</td>
                    <td className={styles.tdTabela}>B8</td>
                    <td className={styles.tdTabela}>D8</td>
                    <td className={styles.tdTabela}>C8</td>
                    <td className={styles.tdTabela}>E8</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A9</td>
                    <td className={styles.tdTabela}>B9</td>
                    <td className={styles.tdTabela}>D9</td>
                    <td className={styles.tdTabela}>C9</td>
                    <td className={styles.tdTabela}>E9</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A10</td>
                    <td className={styles.tdTabela}>B10</td>
                    <td className={styles.tdTabela}>D10</td>
                    <td className={styles.tdTabela}>C10</td>
                    <td className={styles.tdTabela}>E10</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A11</td>
                    <td className={styles.tdTabela}>B11</td>
                    <td className={styles.tdTabela}>D11</td>
                    <td className={styles.tdTabela}>C11</td>
                    <td className={styles.tdTabela}>E11</td>
                </tr>
                <tr>
                    <td className={styles.tdTabela}>A12</td>
                    <td className={styles.tdTabela}>B12</td>
                    <td className={styles.tdTabela}>D12</td>
                    <td className={styles.tdTabela}>C12</td>
                    <td className={styles.tdTabela}>E12</td>
                </tr>
            </table>
        </main>
    );
}