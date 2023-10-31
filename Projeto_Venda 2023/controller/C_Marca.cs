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
    internal class C_Marca: I_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        string sqlApagar = "delete from marca where cod = @Id";
        string sqlTodos = "select * from marca order by nome";
        string sqlInsere = "insert into marca (nome) values (@Nome)";
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
        public List<Marca> carregaDados()
        {
            List<Marca> lista_Marca = new List<Marca>();
            ConectaBanco cb = new ConectaBanco();
            SqlDataReader tabMarca; //Representa uma Tabela Virtual para a leitura de dados

            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlTodos, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                tabMarca = cmd.ExecuteReader();
                while (tabMarca.Read())
                {
                    Marca aux = new Marca();
                    aux.Cod = Int32.Parse(tabMarca["cod"].ToString());
                    aux.Nome = tabMarca["nome"].ToString();
                    lista_Marca.Add(aux);
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
            return lista_Marca;
        }
        public void insereDados(object obj)
        {
            Marca marca = new Marca();
            marca = (Marca)obj;
            ConectaBanco cb = new ConectaBanco();
            con = cb.conectaSqlServer();
            cmd = new SqlCommand(sqlInsere, con);
            cmd.Parameters.AddWithValue("@Nome", marca.Nome);
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
