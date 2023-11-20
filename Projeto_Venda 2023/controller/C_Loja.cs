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
    internal class C_Loja : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable lojas;

        string sqlApagar = "delete from loja where cod = @Cod";
        string sqlInsere = "insert into loja (nome, cnpj, nomefantasia, razaosocial) values (@Nome, @Cnpj, @Nomefantasia, @Razaosocial)";
        string sqlEditar = "update loja set nome = @Nome, cnpj = @Cnpj, nomefantasia = @Nomefantasia, razaosocial = @Razaosocial where cod = @Cod";
        string sqlTodos = "select * from loja order by nome";

        public void apagaDados(int cod)
        {
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlApagar, con);
            //Passando parâmetros para a sentença SQL
            cmd.Parameters.AddWithValue("@Cod", cod);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show($"Deletado com sucesso!!!\n Código: {cod}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao apagar!!!\n Erro: {ex.ToString()}");
            }
            finally
            {
                con.Close();
            }
        }
        public void insereDados(object obj)
        {
            Loja loja = new Loja();
            loja = (Loja)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", loja.Nome);
            cmd.Parameters.AddWithValue("@Cnpj", loja.CNPJ);
            cmd.Parameters.AddWithValue("@NomeFantasia", loja.NomeFantasia);
            cmd.Parameters.AddWithValue("@RazaoSocial", loja.RazaoSocial);
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
        public void editaDados(object obj)
        {
            Loja loja = new Loja();
            loja = (Loja)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            cmd.Parameters.AddWithValue("@Cod", loja.Cod);
            cmd.Parameters.AddWithValue("@Nome", loja.Nome);
            cmd.Parameters.AddWithValue("@Cnpj", loja.CNPJ);
            cmd.Parameters.AddWithValue("@NomeFantasia", loja.NomeFantasia);
            cmd.Parameters.AddWithValue("@RazaoSocial", loja.RazaoSocial);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Registro editado com sucesso");
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
        public DataTable buscarTodos()
        {

            ConectaBanco conectaBanco = new ConectaBanco();
            con = conectaBanco.conectaSqlServer();



            //cria o objeto command para executar a instruçao sql
            cmd = new SqlCommand(sqlTodos, con);
            //abre a conexao
            con.Open();
            //define o tipo do comando
            cmd.CommandType = CommandType.Text;
            try
            {
                //cria um dataadapter
                da = new SqlDataAdapter(cmd);
                //cria um objeto datatable
                lojas = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(lojas);
            }
            catch
            {
                lojas = null;
            }
            return lojas;
        }
        public List<Loja> carregaDados()
        {
            List<Loja> lista_Loja = new List<Loja>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabLoja; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabLoja = cmd.ExecuteReader();
                while (tabLoja.Read())
                {
                    Loja aux = new Loja();
                    aux.Cod = Int32.Parse(tabLoja["cod"].ToString());
                    aux.Nome = tabLoja["nome"].ToString();
                    aux.CNPJ = tabLoja["CNPJ"].ToString();
                    aux.NomeFantasia = tabLoja["NomeFantasia"].ToString();
                    aux.RazaoSocial = tabLoja["RazaoSocial"].ToString();
                    lista_Loja.Add(aux);
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
            return lista_Loja;
        }
    }
}
