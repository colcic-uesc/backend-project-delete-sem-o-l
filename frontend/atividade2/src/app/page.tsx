"use client";

import React, { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import styles from "./page.module.css";

export default function Home() {
    const [users, setUsers] = useState<any[]>([]);
    const router = useRouter();

    // Função para buscar os usuários
    const fetchUsers = async () => {
        try {
            const response = await fetch("http://localhost:3000/api/users");
            if (response.ok) {
                const data = await response.json();
                setUsers(data);
            } else {
                console.error("Erro ao buscar usuários:", response.statusText);
            }
        } catch (error) {
            console.error("Erro de rede:", error);
        }
    };

    // Função para excluir um usuário
    const deleteUser = async (userId: string) => {
        try {
            const response = await fetch(`http://localhost:3000/api/users/${userId}`, {
                method: "DELETE",
            });
            if (response.ok) {
                setUsers((prevUsers) => prevUsers.filter((user) => user.id !== userId));
                console.log(`Usuário com ID ${userId} excluído com sucesso!`);
            } else {
                console.error("Erro ao excluir o usuário:", response.statusText);
            }
        } catch (error) {
            console.error("Erro de rede ao excluir o usuário:", error);
        }
    };

    // Função para redirecionar para a página de edição
    const editUser = (userId: string) => {
        router.push(`/views/editar/${userId}`); // Navega para a rota de edição com o ID
    };

    useEffect(() => {
        fetchUsers();
    }, []);

    return (
        <main className={styles.mainHome}>
            <table className={styles.tabelaHome}>
                <thead>
                    <tr>
                        <th className={styles.tdTabela}>Nome</th>
                        <th className={styles.tdTabela}>Email</th>
                        <th className={styles.tdTabela}>Telefone</th>
                        <th className={styles.tdTabela}>Sexo</th>
                        <th className={styles.tdTabela}>Experiência</th>
                        <th className={styles.tdTabela}>Ação</th> {/* Coluna para ações */}
                    </tr>
                </thead>
                <tbody>
                    {users.map((user) => (
                        <tr key={user.id}>
                            <td className={styles.tdTabela}>{user.nome}</td>
                            <td className={styles.tdTabela}>{user.email}</td>
                            <td className={styles.tdTabela}>{user.telefone}</td>
                            <td className={styles.tdTabela}>{user.sexo}</td>
                            <td className={styles.tdTabela}>{user.experiencia}</td>
                            <td className={styles.tdTabela}>
                                {/* Botão de editar */}
                                <button
                                    className={styles.btnEditar}
                                    onClick={() => editUser(user.id)}
                                >
                                    Editar
                                </button>
                                {/* Botão de excluir */}
                                <button
                                    className={styles.btnExcluir}
                                    onClick={() => deleteUser(user.id)}
                                >
                                    Excluir
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </main>
    );
}