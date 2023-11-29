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
        SqlDataAdapter da;
        DataTable acessos;

        string sqlApagar = "delete from acesso where cod = @Cod";
        string sqlInsere = "insert into acesso (nome) values (@Nome)";
        string sqlEditar = "update acesso set nome = @Nome where cod = @Cod";
        string sqlTodos = "select * from acesso order by cod";
        
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
            }catch(Exception ex)
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
            Acesso acesso = new Acesso();
            try
            {
                acesso = (Acesso)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", acesso.Nome);
            cmd.CommandType = CommandType.Text;
            con.Open();
            
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
            Acesso acesso = new Acesso();
            acesso = (Acesso)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlEditar, con);
            cmd.Parameters.AddWithValue("@Cod", acesso.Cod);
            cmd.Parameters.AddWithValue("@Nome", acesso.Nome);
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
                acessos = new DataTable();
                //preenche o datatable via dataadapter
                da.Fill(acessos);
            }
            catch
            {
                acessos = null;
            }
            return acessos;
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
    }
}
