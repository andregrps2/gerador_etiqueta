namespace App.Gerador.Etiqueta.Forms
{
    partial class FrmGeracaoImpressao
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.etiquetaItemDataGridView = new System.Windows.Forms.DataGridView();
            this.etiquetaItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.etiquetaModeloComboBox = new System.Windows.Forms.ComboBox();
            this.etiquetaModeloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.logoEmpresaPictureBox = new System.Windows.Forms.PictureBox();
            this.gerarButton = new System.Windows.Forms.Button();
            this.logoButton = new System.Windows.Forms.Button();
            this.limparLogoButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaItemDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaModeloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoEmpresaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // etiquetaItemDataGridView
            // 
            this.etiquetaItemDataGridView.AllowUserToAddRows = false;
            this.etiquetaItemDataGridView.AllowUserToDeleteRows = false;
            this.etiquetaItemDataGridView.AllowUserToResizeColumns = false;
            this.etiquetaItemDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.etiquetaItemDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.etiquetaItemDataGridView.AutoGenerateColumns = false;
            this.etiquetaItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.etiquetaItemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn1});
            this.etiquetaItemDataGridView.DataSource = this.etiquetaItemBindingSource;
            this.etiquetaItemDataGridView.Location = new System.Drawing.Point(12, 218);
            this.etiquetaItemDataGridView.MultiSelect = false;
            this.etiquetaItemDataGridView.Name = "etiquetaItemDataGridView";
            this.etiquetaItemDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.etiquetaItemDataGridView.Size = new System.Drawing.Size(776, 297);
            this.etiquetaItemDataGridView.TabIndex = 4;
            // 
            // etiquetaItemBindingSource
            // 
            this.etiquetaItemBindingSource.DataSource = typeof(App.Gerador.Etiqueta.Classes.Model.EtiquetaItem);
            // 
            // etiquetaModeloComboBox
            // 
            this.etiquetaModeloComboBox.DataSource = this.etiquetaModeloBindingSource;
            this.etiquetaModeloComboBox.DisplayMember = "Nome";
            this.etiquetaModeloComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.etiquetaModeloComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaModeloComboBox.FormattingEnabled = true;
            this.etiquetaModeloComboBox.Location = new System.Drawing.Point(12, 36);
            this.etiquetaModeloComboBox.Name = "etiquetaModeloComboBox";
            this.etiquetaModeloComboBox.Size = new System.Drawing.Size(486, 24);
            this.etiquetaModeloComboBox.TabIndex = 1;
            this.etiquetaModeloComboBox.ValueMember = "Id";
            // 
            // etiquetaModeloBindingSource
            // 
            this.etiquetaModeloBindingSource.DataSource = typeof(App.Gerador.Etiqueta.Classes.Model.EtiquetaModelo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o modelo";
            // 
            // logoEmpresaPictureBox
            // 
            this.logoEmpresaPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.logoEmpresaPictureBox.Location = new System.Drawing.Point(12, 66);
            this.logoEmpresaPictureBox.Name = "logoEmpresaPictureBox";
            this.logoEmpresaPictureBox.Size = new System.Drawing.Size(146, 146);
            this.logoEmpresaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoEmpresaPictureBox.TabIndex = 4;
            this.logoEmpresaPictureBox.TabStop = false;
            // 
            // gerarButton
            // 
            this.gerarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gerarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerarButton.Location = new System.Drawing.Point(643, 172);
            this.gerarButton.Name = "gerarButton";
            this.gerarButton.Size = new System.Drawing.Size(144, 39);
            this.gerarButton.TabIndex = 3;
            this.gerarButton.Text = "Gerar Etiquetas";
            this.gerarButton.UseVisualStyleBackColor = true;
            this.gerarButton.Click += new System.EventHandler(this.gerarButton_Click);
            // 
            // logoButton
            // 
            this.logoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoButton.Location = new System.Drawing.Point(164, 66);
            this.logoButton.Name = "logoButton";
            this.logoButton.Size = new System.Drawing.Size(169, 30);
            this.logoButton.TabIndex = 2;
            this.logoButton.Text = "Selecionar Logo Empresa";
            this.logoButton.UseVisualStyleBackColor = true;
            this.logoButton.Click += new System.EventHandler(this.logoButton_Click);
            // 
            // limparLogoButton
            // 
            this.limparLogoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.limparLogoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limparLogoButton.Location = new System.Drawing.Point(164, 102);
            this.limparLogoButton.Name = "limparLogoButton";
            this.limparLogoButton.Size = new System.Drawing.Size(169, 30);
            this.limparLogoButton.TabIndex = 5;
            this.limparLogoButton.Text = "Limpar Logo";
            this.limparLogoButton.UseVisualStyleBackColor = true;
            this.limparLogoButton.Click += new System.EventHandler(this.limparLogoButton_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProdutoId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "ProdutoId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CodBarras";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "CodBarras";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn4.HeaderText = "Descricao";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Preco1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn9.HeaderText = "Preco1";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Qtd";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Qtd.Etq";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // FrmGeracaoImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.limparLogoButton);
            this.Controls.Add(this.logoButton);
            this.Controls.Add(this.gerarButton);
            this.Controls.Add(this.logoEmpresaPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.etiquetaModeloComboBox);
            this.Controls.Add(this.etiquetaItemDataGridView);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGeracaoImpressao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geração / Impressão Etiquetas";
            this.Load += new System.EventHandler(this.FrmImpressao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaItemDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaModeloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoEmpresaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource etiquetaItemBindingSource;
        private System.Windows.Forms.DataGridView etiquetaItemDataGridView;
        private System.Windows.Forms.ComboBox etiquetaModeloComboBox;
        private System.Windows.Forms.BindingSource etiquetaModeloBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox logoEmpresaPictureBox;
        private System.Windows.Forms.Button gerarButton;
        private System.Windows.Forms.Button logoButton;
        private System.Windows.Forms.Button limparLogoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}