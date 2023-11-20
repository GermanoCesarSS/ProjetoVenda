namespace Projeto_Venda_2023
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCESSOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sEXOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bAIRROToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.baseToolStripMenuItem1});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.sairToolStripMenuItem.Text = "SAIR";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // baseToolStripMenuItem1
            // 
            this.baseToolStripMenuItem1.Name = "baseToolStripMenuItem1";
            this.baseToolStripMenuItem1.Size = new System.Drawing.Size(127, 26);
            this.baseToolStripMenuItem1.Text = "BASE";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCESSOToolStripMenuItem,
            this.cidadesToolStripMenuItem,
            this.sEXOToolStripMenuItem,
            this.bAIRROToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // aCESSOToolStripMenuItem
            // 
            this.aCESSOToolStripMenuItem.Name = "aCESSOToolStripMenuItem";
            this.aCESSOToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aCESSOToolStripMenuItem.Text = "ACESSO";
            this.aCESSOToolStripMenuItem.Click += new System.EventHandler(this.aCESSOToolStripMenuItem_Click);
            // 
            // cidadesToolStripMenuItem
            // 
            this.cidadesToolStripMenuItem.Name = "cidadesToolStripMenuItem";
            this.cidadesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cidadesToolStripMenuItem.Text = "CIDADE";
            this.cidadesToolStripMenuItem.Click += new System.EventHandler(this.cidadesToolStripMenuItem_Click);
            // 
            // sEXOToolStripMenuItem
            // 
            this.sEXOToolStripMenuItem.Name = "sEXOToolStripMenuItem";
            this.sEXOToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sEXOToolStripMenuItem.Text = "SEXO";
            this.sEXOToolStripMenuItem.Click += new System.EventHandler(this.sEXOToolStripMenuItem_Click);
            // 
            // bAIRROToolStripMenuItem
            // 
            this.bAIRROToolStripMenuItem.Name = "bAIRROToolStripMenuItem";
            this.bAIRROToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.bAIRROToolStripMenuItem.Text = "BAIRRO";
            this.bAIRROToolStripMenuItem.Click += new System.EventHandler(this.bAIRROToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 554);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aCESSOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sEXOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bAIRROToolStripMenuItem;
    }
}

