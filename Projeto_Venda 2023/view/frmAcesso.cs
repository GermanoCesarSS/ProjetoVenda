﻿using Projeto_Venda_2023.controller;
using Projeto_Venda_2023.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Venda_2023.view
{
    public partial class frmAcesso : Form
    {
        DataTable acessos;
        bool novo = false;
        //funções
        public void carregarTabela()
        {
            C_Acesso cc = new C_Acesso();
            DataTable aux = new DataTable();
            aux = cc.buscarTodosNormalizados();
            acessos = aux;
            dataGridView1.DataSource = aux;
        }
        //
        public frmAcesso()
        {
            InitializeComponent();
            carregarTabela();
            txtNome.Focus();
            txtNome.Enabled = false;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
        }
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                Acesso acesso = new Acesso
                {
                    Nome = txtNome.Text
                };

                C_Acesso cc = new C_Acesso();
                cc.insereDados(acesso);
            }
            else
            {
                Acesso acesso = new Acesso();
                acesso.Cod = Int32.Parse(txtId.Text);
                acesso.Nome = txtNome.Text;

                C_Acesso c_acesso = new C_Acesso();
                c_acesso.editaDados(acesso);
            }
            carregarTabela();
            txtNome.Enabled = false;
            txtNome.Text = "";
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            txtId.Text = "";
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            novo = true;

            txtNome.Focus();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = false;
            txtNome.Text = "";
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;

        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            C_Acesso cc = new C_Acesso();
            cc.apagaDados(int.Parse(txtId.Text));
            carregarTabela();
            txtNome.Enabled = false;
            txtNome.Text = "";
            txtId.Text = "0";
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbNovo.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];


            txtId.Text = selectedRow.Cells[0].Value.ToString();
            //txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tsbNovo.Enabled = false;
            tsbCancelar.Enabled = true;
            tsbSalvar.Enabled = true;
            tsbExcluir.Enabled = true;
            txtNome.Enabled = true;
            novo = false;
            txtNome.Focus();
        }
    }
}
