using Projeto_Venda_2023.conexao;
using Projeto_Venda_2023.controller;
using Projeto_Venda_2023.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.LinkLabel;

namespace Aula_11_08
{
    public partial class frmCadastroCidades : Form
    {
        bool novo;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable cidades;
        SqlDataReader tabCliente;
        DataRow[] linhaAtual;
        int posicao = 0;
      
        //Carrega as informações no DatagridView1 com os dados dos clientes
        public void carregarTabela()
        {
            C_Cidade cc = new C_Cidade();
            DataTable aux = new DataTable();
            aux = cc.buscarTodosNormalizados();
            cidades = aux;
           dataGridView1.DataSource = aux;

        }

        //Construtor da Classe frmCadastroCliente
        public frmCadastroCidades()
        {
            InitializeComponent();
            carregarTabela();
            carregaAcesso();
            
        }

        List<Uf> aux = new List<Uf>();
        public void carregaUf()
        {
            C_Uf cs = new C_Uf();

            aux = new List<Uf>();

            aux = cs.carregaDados();

            comboBox1.DataSource = aux;
            comboBox1.DisplayMember = "sigla";
            comboBox1.ValueMember = "coduf";
        }
        List<Acesso> aux1 = new List<Acesso>();
        public void carregaAcesso()
        {
            C_Acesso cs = new C_Acesso();

            aux1 = new List<Acesso>();

            aux1 = cs.carregaDados();

            comboBox1.DataSource = aux1;
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "cod";
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {

          
        }

        private void limpaCampos()
        {
           
        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            Cidade cidade = new Cidade
            {
                Nomecidade = txtNome.Text
,
                Uf = aux[posicao]
            };

            C_Cidade cc = new C_Cidade();
            cc.insereDados(cidade);
            carregarTabela();
        }

        
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Int32.Parse(txtId.Text.ToString());
            C_Cidade cc = new C_Cidade();
            cc.apagaDados(codigo);
            carregarTabela();

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];


            txtId.Text = selectedRow.Cells[0].Value.ToString();
            //txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
        }

      

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //FrmRelProfessor frmrelprof = new FrmRelProfessor();
            //frmrelprof.ShowDialog();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            posicao = comboBox1.SelectedIndex;
            label3.Text = aux1[posicao].Cod.ToString();
        }
    }
}
