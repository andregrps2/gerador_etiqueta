using App.Gerador.Etiqueta.Classes.Bll;
using App.Gerador.Etiqueta.Classes.Dal;
using App.Gerador.Etiqueta.Classes.Impressao;
using App.Gerador.Etiqueta.Classes.Model;
using Classes.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.Gerador.Etiqueta.Forms
{
    public partial class FrmMenu : Form
    {
        EtiquetaModeloBo etiquetaModeloBo = new EtiquetaModeloBo();

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void impressãoDeEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmGeracaoImpressao frm = new FrmGeracaoImpressao())
                frm.ShowDialog();
            //GerarEtiquetaGondola();
            //GerarEtiqueta3x3();
        }

        private void GerarEtiquetaGondola()
        {
            /*
            EtiquetaModelo modelo = new EtiquetaModelo
            {
                Nome = "ARGOX",
                PaginaLargura = 10.30M,
                PaginaAltura = 3.00M,
                MargemEsquerda = 0.20M,
                MargemDireita = 0.10M,
                MargemSuperior = 0.20M,
                MargemInferior = 0.10M,
                EtiquetaLargura = 9.90M,
                EtiquetaAltura = 2.60M
            };

            EtiquetaCampo campoDescricao = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.DescricaoCompleta,
                Largura = 9.7M,
                Altura = 1M,
                MargemEsquerda = 0.1M,
                FonteNome = "Arial",
                FonteTamanho = 12M,
                FonteEstilo = "Normal",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Topo",
                TextoAlinhamentoHorizontal = "Esquerda",
                LinhaQuebrar = true
            };
            modelo.Campos.Add(campoDescricao);

            EtiquetaCampo campoVazio = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.Nenhum,
                Largura = 0M,
                Altura = 0.10M,
                MargemEsquerda = 0.0M,
                FonteNome = "Arial",
                FonteTamanho = 8M,
                FonteEstilo = "Normal",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Topo",
                TextoAlinhamentoHorizontal = "Esquerda",
                LinhaQuebrar = true
            };
            modelo.Campos.Add(campoVazio);

            EtiquetaCampo campoCodBarras = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.CodigoDeBarras,
                Largura = 4.75M,
                Altura = 0.80M,
                MargemEsquerda = 0.1M,
                FonteNome = "Arial",
                FonteTamanho = 8M,
                FonteEstilo = "Normal",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Topo",
                TextoAlinhamentoHorizontal = "Esquerda",
                LinhaQuebrar = false,
                CodBarrasDiminuirTamanho = true
            };
            modelo.Campos.Add(campoCodBarras);

            EtiquetaCampo campoPreco1 = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.Preco1,
                Largura = 4.90M,
                Altura = 0.80M,
                MargemEsquerda = 5M,
                FonteNome = "Arial",
                FonteTamanho = 18M,
                FonteEstilo = "Negrito",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Centro",
                TextoAlinhamentoHorizontal = "Direita",
                LinhaQuebrar = true
            };
            modelo.Campos.Add(campoPreco1);

            EtiquetaCampo campoCodBarrasNumerico = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.CodigoDeBarrasNumerico,
                Largura = 4.75M,
                Altura = 0.80M,
                MargemEsquerda = 0.1M,
                MargemTopo = 0.05M,
                FonteNome = "Lucida Console",
                FonteTamanho = 7M,
                FonteEstilo = "Negrito",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Topo",
                TextoAlinhamentoHorizontal = "Centro",
                LinhaQuebrar = false,
                ImprimirTextoPadrao = true
            };
            modelo.Campos.Add(campoCodBarrasNumerico);
            */

            var obj = etiquetaModeloBo.RetornarPorId(1);
            etiquetaModeloBo.RetornarCamposPorModelo(obj);

            BaseCollection<EtiquetaItem> etiquetaItens = new BaseCollection<EtiquetaItem>()
            {
                new EtiquetaItem() { Qtd = 1, Descricao = "NESCAFE 50GR ORIGINAL", CodBarras = "78900554", Preco1 = 15.25M},
                new EtiquetaItem() { Qtd = 1, Descricao = "LEITE CONDENSADO MOCA 395G", CodBarras = "7891000100103", Preco1 = 9.90M},
                new EtiquetaItem() { Qtd = 1, Descricao = "PICANHA KG", CodBarras = "275", Preco1 = 45.90M},
                new EtiquetaItem() { Qtd = 1, Descricao = "CERVEJA BRAHMA 350ML DUPLO MALTE COM 12 UN", CodBarras = "7891991294942", Preco1 = 32.90M},
                new EtiquetaItem() { Qtd = 1, Descricao = "CERVEJA IMPERIO 350ML PILSEN LATA COM 12 UN", CodBarras = "17898915949206", Preco1 = 35.99M},
                new EtiquetaItem() { Qtd = 1, Descricao = "TESTE CODIGO DE BARRAS ALFANUMERICO", CodBarras = "A01234567", Preco1 = 1.99M}
            };

            ImpressaoEtiqueta etq = new ImpressaoEtiqueta(obj);
            etq.GerarEtiquetas(etiquetaItens.ToList());
        }
        private void GerarEtiqueta3x3()
        {
            EtiquetaModelo modelo = new EtiquetaModelo
            {
                Nome = "3 x 3",
                PaginaLargura = 10.30M,
                PaginaAltura = 2.10M,
                MargemEsquerda = 0.20M,
                MargemDireita = 0.10M,
                MargemSuperior = 0.20M,
                MargemInferior = 0.10M,
                EtiquetaLargura = 3.20M,
                EtiquetaAltura = 2.70M,
                ColunaQuantidade = 3,
                LinhaQuantidade = 1
            };

            EtiquetaCampo campoDescricao = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.DescricaoCompleta,
                Largura = 3M,
                Altura = 0.7M,
                MargemEsquerda = 0.1M,
                FonteNome = "Arial",
                FonteTamanho = 6M,
                FonteEstilo = "Negrito",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Topo",
                TextoAlinhamentoHorizontal = "Centro",
                LinhaQuebrar = true
            };
            modelo.Campos.Add(campoDescricao);

            EtiquetaCampo campoCodBarras = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.CodigoDeBarras,
                Largura = 2.9M,
                Altura = 0.5M,
                MargemEsquerda = 0.1M,
                FonteNome = "Arial",
                FonteTamanho = 6M,
                FonteEstilo = "Normal",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Topo",
                TextoAlinhamentoHorizontal = "Esquerda",
                LinhaQuebrar = true
            };
            modelo.Campos.Add(campoCodBarras);

            EtiquetaCampo campoPreco1 = new EtiquetaCampo
            {
                Campo = Classes.Fixo.CampoEnum.Preco1,
                Largura = 3M,
                Altura = 0.5M,
                MargemEsquerda = 0.06M,
                FonteNome = "Arial",
                FonteTamanho = 7M,
                FonteEstilo = "Negrito",
                FonteCor = "Preto",
                TextoAlinhamentoVertical = "Centro",
                TextoAlinhamentoHorizontal = "Centro",
                LinhaQuebrar = true
            };
            modelo.Campos.Add(campoPreco1);

            EtiquetaItem obj = new EtiquetaItem() { Qtd = 1, Descricao = "CERVEJA BRAHMA 350ML DUPLO MALTE COM 12 UN", CodBarras = "7891991294942", Preco1 = 32.90M };

            List<EtiquetaItem> etiquetaItens = new List<EtiquetaItem>();
            for (int i = 0; i < 12; i++)
                etiquetaItens.Add(obj.ShallowCopy());

            ImpressaoEtiqueta etq = new ImpressaoEtiqueta(modelo);
            etq.GerarEtiquetas(etiquetaItens);
        }

        private void modeloEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmEtiqueta frm = new FrmEtiqueta())
                frm.ShowDialog();
        }
    }
}
