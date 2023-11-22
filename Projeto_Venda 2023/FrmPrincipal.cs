using Projeto_Venda_2023.controller;
using Projeto_Venda_2023.model;
using Projeto_Venda_2023.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_2023
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }
        public FrmPrincipal(DataTable dt)
        {
            dataGridView1.DataSource = dt;

        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCidades cadcidade = new frmCadastroCidades();
            cadcidade.ShowDialog();
        }

        private void aCESSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcesso frm = new frmAcesso();
            frm.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sEXOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSexo frm = new frmSexo();
            frm.ShowDialog();
        }

        private void bAIRROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBairro frm = new frmBairro();
            frm.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
