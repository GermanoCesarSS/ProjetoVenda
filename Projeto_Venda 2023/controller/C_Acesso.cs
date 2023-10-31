﻿using Projeto_Venda_2023.conexao;
using Projeto_Venda_2023.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_2023.controller
{
    internal class C_Acesso : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        string sqlApagar = "delete from acesso where cod = @Id";
        string sqlTodos = "select * from acesso order by nome";
        string sqlInsere = "insert into acesso (nome) values (@Nome)";
        public void apagaDados(int cod)
        {
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlApagar, con);
            //Passando parâmetros para a sentença SQL
            cmd.Parameters.AddWithValue("@Id", cod);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show($"Deletado com sucessp!!!\n Código: {cod}");
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"Erro ao apagar!!!\n Erro: {ex.ToString()}");
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable buscarTodos()
        {
            throw new NotImplementedException();
        }
        public List<Acesso> carregaDados()
        {
            List<Acesso> lista_Acesso = new List<Acesso>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabAcesso; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabAcesso = cmd.ExecuteReader();
                while (tabAcesso.Read())
                {
                    Acesso aux = new Acesso();
                    aux.Cod = Int32.Parse(tabAcesso["cod"].ToString());
                    aux.Nome = tabAcesso["nome"].ToString();
                    lista_Acesso.Add(aux);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados!\nErro:" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return lista_Acesso;
        }
        public void insereDados(object obj)
        {
            Acesso acesso = new Acesso();
            acesso = (Acesso)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", acesso.Nome);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Registro incluído com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
