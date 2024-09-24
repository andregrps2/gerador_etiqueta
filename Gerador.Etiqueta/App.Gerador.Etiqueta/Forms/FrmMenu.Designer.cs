namespace App.Gerador.Etiqueta.Forms
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impressãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impressãoDeEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.impressãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeloEtiquetasToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // modeloEtiquetasToolStripMenuItem
            // 
            this.modeloEtiquetasToolStripMenuItem.Name = "modeloEtiquetasToolStripMenuItem";
            this.modeloEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modeloEtiquetasToolStripMenuItem.Text = "Modelo Etiquetas";
            this.modeloEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.modeloEtiquetasToolStripMenuItem_Click);
            // 
            // impressãoToolStripMenuItem
            // 
            this.impressãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.impressãoDeEtiquetasToolStripMenuItem});
            this.impressãoToolStripMenuItem.Name = "impressãoToolStripMenuItem";
            this.impressãoToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.impressãoToolStripMenuItem.Text = "Impressão";
            // 
            // impressãoDeEtiquetasToolStripMenuItem
            // 
            this.impressãoDeEtiquetasToolStripMenuItem.Name = "impressãoDeEtiquetasToolStripMenuItem";
            this.impressãoDeEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.impressãoDeEtiquetasToolStripMenuItem.Text = "Impressão de Etiquetas";
            this.impressãoDeEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.impressãoDeEtiquetasToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeloEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impressãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impressãoDeEtiquetasToolStripMenuItem;
    }
}