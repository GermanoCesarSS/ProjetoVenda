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
    internal class C_Bairro : I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        string sqlApagar = "delete from bairro where cod = @Id";
        string sqlTodos = "select * from bairro order by nome";
        string sqlInsere = "insert into bairro (nome) values (@Nome)";
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
        public List<Bairro> carregaDados()
        {
            List<Bairro> lista_Bairro = new List<Bairro>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabBairro; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabBairro = cmd.ExecuteReader();
                while (tabBairro.Read())
                {
                    Bairro aux = new Bairro();
                    aux.Cod = Int32.Parse(tabBairro["cod"].ToString());
                    aux.Nome = tabBairro["nome"].ToString();
                    lista_Bairro.Add(aux);
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
            return lista_Bairro;
        }
        public void insereDados(object obj)
        {
            Bairro bairro = new Bairro();
            bairro = (Bairro)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", bairro.Nome);
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
