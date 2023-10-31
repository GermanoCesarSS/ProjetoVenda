using Projeto_Venda_2023.conexao;
using Projeto_Venda_2023.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
        string sqlApagar = "delete from loja where cod = @Id";
        string sqlTodos = "select * from loja order by nome";
        string sqlInsere = "insert into loja (nome, cnpj, nomefantasia, razaosocial) values (@Nome, @Cnpj, @NomeFantasia, @RazaoSocial)";
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

        public DataTable buscarTodos()
        {
            throw new NotImplementedException();
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
                    aux.CNPJ = tabLoja["cnpj"].ToString();
                    aux.NomeFantasia = tabLoja["nomefantasia"].ToString();
                    aux.RazaoSocial = tabLoja["razaosocial"].ToString();
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
    }
}
