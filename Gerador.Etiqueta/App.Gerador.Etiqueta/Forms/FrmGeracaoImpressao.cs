using App.Gerador.Etiqueta.Classes.Bll;
using App.Gerador.Etiqueta.Classes.Impressao;
using App.Gerador.Etiqueta.Classes.Model;
using Classes.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace App.Gerador.Etiqueta.Forms
{
    public partial class FrmGeracaoImpressao : Form
    {
        EtiquetaModeloBo etiquetaModeloBo = new EtiquetaModeloBo();
        BaseCollection<EtiquetaItem> LstEtiquetaItens { get; set; }
        public FrmGeracaoImpressao()
        {
            InitializeComponent();
        }

        private void FrmImpressao_Load(object sender, EventArgs e)
        {
            etiquetaModeloBindingSource.DataSource = etiquetaModeloBo.RetornarTodos(true);
            etiquetaModeloBindingSource.ResetBindings(false);

            LstEtiquetaItens = new BaseCollection<EtiquetaItem>()
            {
                new EtiquetaItem() { Qtd = 1, ProdutoId = 1, Descricao = "NESCAFE 50GR ORIGINAL", CodBarras = "78900554", Preco1 = 15.25M},
                new EtiquetaItem() { Qtd = 1, ProdutoId = 2, Descricao = "LEITE CONDENSADO MOCA 395G", CodBarras = "7891000100103", Preco1 = 9.90M},
                new EtiquetaItem() { Qtd = 1, ProdutoId = 3, Descricao = "PICANHA KG", CodBarras = "275", Preco1 = 45.90M},
                new EtiquetaItem() { Qtd = 1, ProdutoId = 4, Descricao = "CERVEJA BRAHMA 350ML DUPLO MALTE COM 12 UN", CodBarras = "7891991294942", Preco1 = 32.90M},
                new EtiquetaItem() { Qtd = 1, ProdutoId = 5, Descricao = "CERVEJA IMPERIO 350ML PILSEN LATA COM 12 UN", CodBarras = "17898915949206", Preco1 = 35.99M},
                new EtiquetaItem() { Qtd = 1, ProdutoId = 6, Descricao = "TESTE CODIGO DE BARRAS ALFANUMERICO", CodBarras = "A01234567", Preco1 = 1.99M}
            };

            etiquetaItemBindingSource.DataSource = LstEtiquetaItens;
            etiquetaItemBindingSource.ResetBindings(false);
        }

        private void logoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Files|*.jpg;*.jpeg;*.png;*.bmp;";
                if (ofd.ShowDialog() == DialogResult.OK)
                    logoEmpresaPictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void limparLogoButton_Click(object sender, EventArgs e)
        {
            try
            {
                logoEmpresaPictureBox.Image = null;
            }
            catch { }
        }

        private void gerarButton_Click(object sender, EventArgs e)
        {
            if (etiquetaModeloBindingSource.Current is EtiquetaModelo obj)
            {
                if (obj.Id <= 0)
                {
                    MessageBox.Show("Selecionar um modelo de etiqueta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    etiquetaModeloComboBox.Focus();
                    return;
                }

                etiquetaModeloBo.RetornarCamposPorModelo(obj);

                ImpressaoEtiqueta etq = new ImpressaoEtiqueta(obj);
                etq.LogoEmpresa = logoEmpresaPictureBox.Image;
                etq.GerarEtiquetas(LstEtiquetaItens.ToList());
            }
        }
    }
}