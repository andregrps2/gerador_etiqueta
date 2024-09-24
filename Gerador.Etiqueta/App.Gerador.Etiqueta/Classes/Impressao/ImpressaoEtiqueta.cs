using App.Gerador.Etiqueta.Classes.Model;
using Barcode;
using Extended;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace App.Gerador.Etiqueta.Classes.Impressao
{
    class Accessor
    {
        internal static decimal CentimetersToInches(decimal _cm)
        {
            return (_cm * 0.3937M) * 100M;
        }
    }

    public class ImpressaoEtiqueta
    {
        private readonly Pen CanetaTracejada = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot };

        public EtiquetaModelo Pagina = new EtiquetaModelo();
        public List<EtiquetaCampo> ListaCampos = new List<EtiquetaCampo>();
        public List<EtiquetaItem> ListaItens = new List<EtiquetaItem>();

        public Image LogoEmpresa { get; set; }

        private int Ypos = 0;

        public decimal AjusteVertical = 0M;
        public decimal AlturaDisponivel = 0M;
        public decimal LarguraDisponivel = 0M;

        private int ItemAtual = 1;

        public string NomeDaEtiqueta = "Etiquetas Tag";
        public string TipoPapel = "PaperA4";
        public decimal AlturaPagina = Accessor.CentimetersToInches(27.9M);
        public decimal LarguraPagina = Accessor.CentimetersToInches(21.5M);

        public decimal Page_Margin_Left = Accessor.CentimetersToInches(1.1M);
        public decimal Page_Margin_Top = Accessor.CentimetersToInches(1.25M);
        public decimal Page_Margin_Right = Accessor.CentimetersToInches(1.1M);
        public decimal Page_Margin_Bottom = Accessor.CentimetersToInches(3.8M);

        public int LarguraPreview = 1366; //Pixels
        public int AlturaPreview = 780; //Pixels
        public int Zoom = 107;

        public decimal LarguraEtiqueta = Accessor.CentimetersToInches(4.8M);
        public decimal AlturaEtiqueta = Accessor.CentimetersToInches(4.8M);

        public int QtdDeLinhas = 3;
        public int QtdDeColunas = 4;

        public bool MostrarLinhaCorte = false;

        private bool IsNumericOnly(string _value)
        {
            if (_value == null || string.IsNullOrWhiteSpace(_value))
                return false;

            for (int i = 0; i < _value.Length; i++)
                if ((_value[i] ^ '0') > 9)
                    return false;
            return true;
        }

        private StringAlignment AlinhamentoRetornar(string _alinhamento)
        {
            return (StringAlignment)TypeDescriptor.GetConverter(typeof(StringAlignment)).ConvertFromString(_alinhamento);
        }
        private Color CorRetornar(string _cor)
        {
            return (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(_cor);
        }
        private FontStyle EstiloFonteRetornar(string _estilo)
        {
            return (FontStyle)TypeDescriptor.GetConverter(typeof(FontStyle)).ConvertFromString(_estilo);
        }

        private string ImprimirTexto(string _descricao, string _textoLivre, bool _imprimirAposDescricao)
        {
            string antes = "";
            string depois = "";
            if (!string.IsNullOrWhiteSpace(_textoLivre))
            {
                antes = $"{_textoLivre} ";
                if (_imprimirAposDescricao)
                {
                    antes = "";
                    depois = $" {_textoLivre}";
                }
            }
            return $"{antes}{_descricao}{depois}";
        }

        private string ImprimirTextoAtacado(EtiquetaItem _obj)
        {
            string produtoAtacado = "";
            if (_obj.AtacadoQuantidade1 > 0 || _obj.AtacadoQuantidade2 > 0 || _obj.AtacadoQuantidade3 > 0 || _obj.AtacadoQuantidade4 > 0 || _obj.AtacadoQuantidade5 > 0)
            {
                if (_obj.AtacadoQuantidade1 > 0)
                    produtoAtacado = $"{_obj.AtacadoQuantidade1.ToString("N0")} {_obj.AtacadoUnidade1} {_obj.AtacadoPreco1.ToString("N2")}\r\n";
                else if (_obj.AtacadoQuantidade2 > 0)
                    produtoAtacado = $"{_obj.AtacadoQuantidade2.ToString("N0")} {_obj.AtacadoUnidade2} {_obj.AtacadoPreco2.ToString("N2")}\r\n";
                else if (_obj.AtacadoQuantidade3 > 0)
                    produtoAtacado = $"{_obj.AtacadoQuantidade3.ToString("N0")} {_obj.AtacadoUnidade3} {_obj.AtacadoPreco3.ToString("N2")}\r\n";
                else if (_obj.AtacadoQuantidade4 > 0)
                    produtoAtacado = $"{_obj.AtacadoQuantidade4.ToString("N0")} {_obj.AtacadoUnidade4} {_obj.AtacadoPreco4.ToString("N2")}\r\n";
                else if (_obj.AtacadoQuantidade5 > 0)
                    produtoAtacado = $"{_obj.AtacadoQuantidade5.ToString("N0")} {_obj.AtacadoUnidade5} {_obj.AtacadoPreco5.ToString("N2")}";
            }
            return produtoAtacado;
        }

        private void ImprimirEtiqueta(PrintPageEventArgs e, EtiquetaItem _item, int _linha, int _coluna)
        {
            decimal x = 0M;
            decimal y = 0M;

            if (Pagina.RemoverEspacoEntreColuna)
            {
                //Apertar colunas.
                if (_coluna == 0)
                    x = (LarguraDisponivel / QtdDeColunas) * _coluna;
                else
                {
                    decimal tamanhoRealColunas = Accessor.CentimetersToInches(Pagina.EtiquetaLargura) * QtdDeColunas;
                    decimal espacoSobrando = LarguraDisponivel - tamanhoRealColunas;
                    decimal ajuste = (espacoSobrando / QtdDeColunas);
                    x = (LarguraDisponivel / QtdDeColunas) * _coluna - (_coluna * ajuste);
                }
            }
            else
                x = (LarguraDisponivel / QtdDeColunas) * _coluna;

            if (Pagina.RemoverEspacoEntreLinha)
            {
                //Apertar linhas.
                if (_linha == 0)
                    y = (AlturaDisponivel / QtdDeLinhas) * _linha;
                else
                {
                    decimal tamanhoRealLinhas = (Ypos * QtdDeLinhas);
                    decimal espacoSobrando = AlturaDisponivel - tamanhoRealLinhas;
                    decimal ajuste = (espacoSobrando / QtdDeLinhas);
                    y = (AlturaDisponivel / QtdDeLinhas) * _linha - (_linha * ajuste);
                }
            }
            else
                y = (AlturaDisponivel / QtdDeLinhas) * _linha;

            if (Pagina.MostarLinhaCorteTracejada)
            {
                e.Graphics.DrawLine(CanetaTracejada, Convert.ToSingle(x), 0, Convert.ToSingle(x), Convert.ToSingle(AlturaDisponivel));
                if (_linha == 0)
                    e.Graphics.DrawLine(CanetaTracejada, 0, 0, Convert.ToSingle(LarguraDisponivel), 0);

                if (Pagina.RemoverEspacoEntreLinha)
                {
                    if (_linha == 0)
                        e.Graphics.DrawLine(CanetaTracejada, 0, Convert.ToSingle(AlturaEtiqueta * (_linha + 1)), Convert.ToSingle(LarguraDisponivel), Convert.ToSingle(AlturaEtiqueta * (_linha + 1)));
                    else
                        e.Graphics.DrawLine(CanetaTracejada, 0, Convert.ToSingle(AlturaEtiqueta * (_linha + 1)), Convert.ToSingle(LarguraDisponivel), Convert.ToSingle(AlturaEtiqueta * (_linha + 1)));
                }
                else
                {
                    decimal y2 = (AlturaDisponivel / QtdDeLinhas) * (_linha + 1);
                    e.Graphics.DrawLine(CanetaTracejada, 0, Convert.ToSingle(y2), Convert.ToSingle(LarguraDisponivel), Convert.ToSingle(y2));
                }

                if (Pagina.RemoverEspacoEntreColuna)
                    e.Graphics.DrawLine(CanetaTracejada, Convert.ToSingle(x + LarguraEtiqueta), 0, Convert.ToSingle(x + LarguraEtiqueta), Convert.ToSingle(AlturaDisponivel));
                else
                    e.Graphics.DrawLine(CanetaTracejada, Convert.ToSingle(LarguraDisponivel), 0, Convert.ToSingle(LarguraDisponivel), Convert.ToSingle(AlturaDisponivel));
            }

            foreach (var i in ListaCampos)
            {
                RectangleF rect = new RectangleF(Convert.ToSingle(x + Accessor.CentimetersToInches(i.MargemEsquerda)), Convert.ToSingle(y + Accessor.CentimetersToInches(i.MargemTopo)), Convert.ToSingle(Accessor.CentimetersToInches(i.Largura)), Convert.ToSingle(Accessor.CentimetersToInches(i.Altura)));

                StringFormat style = new StringFormat() { Alignment = AlinhamentoRetornar(i.Text_Align_Horizontal), LineAlignment = AlinhamentoRetornar(i.Text_Align_Vertical) };
                FontStyle fontStyle = EstiloFonteRetornar(i.Font_Style);

                if (i.FonteTamanho == 0M)
                    i.FonteTamanho = 6M;
                Font font = new Font(i.FonteNome, Convert.ToSByte(i.FonteTamanho), fontStyle);

                SolidBrush brush = new SolidBrush(CorRetornar(i.Font_Color));

                switch (i.Campo)
                {
                    case Fixo.CampoEnum.Nenhum:
                        e.Graphics.DrawString(" ", font, brush, rect, style);
                        if (!string.IsNullOrWhiteSpace(i.TextoLivre))
                            e.Graphics.DrawString(i.TextoLivre, font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.CodigoInterno:
                        e.Graphics.DrawString(ImprimirTexto(_item.ProdutoId.ToString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.CodigoDeBarras:
                        if (!IsNumericOnly(_item.CodBarras))
                            e.Graphics.DrawImage(new Barcode128(_item.CodBarras).Desenhar(), rect);
                        else if (_item.CodBarras.Length == 14)
                            e.Graphics.DrawImage(new BarcodeITF14(_item.CodBarras).Desenhar(), rect);
                        else if (_item.CodBarras.Length == 13)
                            e.Graphics.DrawImage(new BarcodeEAN13(_item.CodBarras).Desenhar(), rect);
                        else if (_item.CodBarras.Length == 12)
                            e.Graphics.DrawImage(new BarcodeUPCA(_item.CodBarras).Desenhar(), rect);
                        else if (_item.CodBarras.Length == 8)
                        {
                            rect = CodBarrasDiminuirTamanho(i, rect);
                            e.Graphics.DrawImage(new BarcodeEAN8(_item.CodBarras).Desenhar(), rect);
                        }
                        else
                        {
                            rect = CodBarrasDiminuirTamanho(i, rect);
                            e.Graphics.DrawImage(new Barcode39(_item.CodBarras).Desenhar(), rect);
                        }
                        break;
                    case Fixo.CampoEnum.CodigoDeBarrasNumerico:
                        e.Graphics.DrawString(ImprimirTexto(_item.CodBarras.ToString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.DescricaoCompleta:
                        e.Graphics.DrawString(ImprimirTexto(_item.Descricao, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.DescricaoReduzida:
                        e.Graphics.DrawString(ImprimirTexto(_item.DescricaoReduzida, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.DataAtual:
                        e.Graphics.DrawString(ImprimirTexto(_item.DataAtual.ToShortDateString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.PrecoDataUltimaAlteracao:
                        e.Graphics.DrawString(ImprimirTexto(_item.PrecoDataUltimaAlteracao.ToShortDateString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.Preco1:
                        e.Graphics.DrawString(ImprimirTexto(_item.Preco1.ToString("N2"), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.Preco2:
                        e.Graphics.DrawString(ImprimirTexto(_item.Preco2.ToString("N2"), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.Preco3:
                        e.Graphics.DrawString(ImprimirTexto(_item.Preco3.ToString("N2"), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.Preco4:
                        e.Graphics.DrawString(ImprimirTexto(_item.Preco4.ToString("N2"), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.PromocaoPreco:
                        e.Graphics.DrawString(ImprimirTexto(_item.PromocaoPreco.ToString("N2"), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.PromcaoDataInicioFim:
                        string periodoPromocao = $"DE {_item.PromocaoDataInicio.ToShortDateString()} ATE {_item.PromocaoDataFim.ToShortDateString()}";
                        e.Graphics.DrawString(ImprimirTexto(periodoPromocao, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ClubeDescontoPreco:
                        e.Graphics.DrawString(ImprimirTexto(_item.ClubeDescontoPreco.ToString("N2"), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ClubeDescontoLimitePorCupom:
                        e.Graphics.DrawString(ImprimirTexto(_item.ClubeDescontoLimitePorCupom.ToString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ClubeDescontoDataInicioFim:
                        string periodoClube = $"DE {_item.ClubeDescontoDataInicio.ToShortDateString()} ATE {_item.ClubeDescontoDataFim.ToShortDateString()}";
                        e.Graphics.DrawString(ImprimirTexto(periodoClube, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.GradeTamanho:
                        e.Graphics.DrawString(ImprimirTexto(_item.GradeTamanho, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.GradeCor:
                        e.Graphics.DrawString(ImprimirTexto(_item.GradeCor, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.GradeDescricao:
                        e.Graphics.DrawString(ImprimirTexto(_item.GradeDescricao, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ValidadeDataFabricacao:
                        e.Graphics.DrawString(ImprimirTexto(_item.ValidadeDataFabricacao.ToShortDateString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ValidadeEmDias:
                        e.Graphics.DrawString(ImprimirTexto(_item.ValidadeEmDias.ToString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ValidadeEmMeses:
                        e.Graphics.DrawString(ImprimirTexto(_item.ValidadeEmMeses.ToString(), i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;
                    case Fixo.CampoEnum.ProdutoPrecoAtacado:
                        string textoAtacado = ImprimirTextoAtacado(_item);
                        if (!string.IsNullOrWhiteSpace(textoAtacado))
                            e.Graphics.DrawString(ImprimirTexto(textoAtacado, i.TextoLivre, i.ImprimirAposDescricao), font, brush, rect, style);
                        break;

                    case Fixo.CampoEnum.ImagemEmpresa:
                        if (LogoEmpresa != null)
                            e.Graphics.DrawImage(LogoEmpresa, rect);
                        else
                            e.Graphics.DrawString("", font, brush, rect);
                        break;
                    default:
                        break;
                }

                if (i.BordaMostar)
                    e.Graphics.DrawRectangle(new Pen(CorRetornar(i.Border_Color), i.BordaLargura), Rectangle.Round(rect));
                if (i.LinhaQuebrar)
                    y += Accessor.CentimetersToInches(i.Altura);
            }

            if (_linha == 0)
                Ypos = Convert.ToInt32(y);
        }

        private RectangleF CodBarrasDiminuirTamanho(EtiquetaCampo _campo, RectangleF _rect)
        {
            if (_campo.CodBarrasDiminuirTamanho)
            {
                _rect.X += (_rect.Width / 4);
                _rect.Width = (_rect.Width / 2);
            }
            return _rect;
        }

        private void GerarMatriz(PrintPageEventArgs e)
        {
            int linha = 0;
            int coluna = 0;

            bool etiquetaModeloArgoxGondola = (QtdDeLinhas == 1 && QtdDeColunas == 1);

            if (ItemAtual >= ListaItens.Count)
                ItemAtual = 1;

            for (int y = ItemAtual; y < ListaItens.Count; y++)
            {
                for (linha = 0; linha < QtdDeLinhas; linha++)
                {
                    if (ItemAtual > 1 && !etiquetaModeloArgoxGondola)
                        ItemAtual += 1;

                    for (coluna = 0; coluna < QtdDeColunas; coluna++)
                    {
                        if (ItemAtual <= ListaItens.Count)
                        {
                            EtiquetaItem item = ListaItens[ItemAtual - 1];
                            ImprimirEtiqueta(e, item, linha, coluna);

                            if (!(coluna == QtdDeColunas - 1))
                                ItemAtual += 1;

                            if (etiquetaModeloArgoxGondola)
                                ItemAtual += 1;
                        }
                    }
                }
                if (ItemAtual < ListaItens.Count)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }

        public ImpressaoEtiqueta(EtiquetaModelo _pagina)
        {
            Pagina = _pagina;
            NomeDaEtiqueta = _pagina.Nome;

            TipoPapel = _pagina.TipoPapel;
            LarguraPagina = Accessor.CentimetersToInches(_pagina.PaginaLargura);
            AlturaPagina = Accessor.CentimetersToInches(_pagina.PaginaAltura);

            Page_Margin_Left = Accessor.CentimetersToInches(_pagina.MargemEsquerda);
            Page_Margin_Right = Accessor.CentimetersToInches(_pagina.MargemDireita);
            Page_Margin_Top = Accessor.CentimetersToInches(_pagina.MargemSuperior);
            Page_Margin_Bottom = Accessor.CentimetersToInches(_pagina.MargemInferior);

            LarguraPreview = _pagina.PreviewLargura;
            AlturaPreview = _pagina.PreviewAltura;
            Zoom = _pagina.PreviewNivelZoom;

            LarguraEtiqueta = Accessor.CentimetersToInches(_pagina.EtiquetaLargura);
            AlturaEtiqueta = Accessor.CentimetersToInches(_pagina.EtiquetaAltura);

            QtdDeLinhas = _pagina.LinhaQuantidade;
            QtdDeColunas = _pagina.ColunaQuantidade;

            MostrarLinhaCorte = _pagina.MostarLinhaCorteTracejada;

            ListaCampos = _pagina.Campos.ToList();
        }

        public void GerarEtiquetas(List<EtiquetaItem> _listaItensEtiqueta)
        {
            try
            {
                foreach (EtiquetaItem item in _listaItensEtiqueta)
                {
                    for (int i = 0; i < item.Qtd; i++)
                    {
                        EtiquetaItem obj = item.ShallowCopy();
                        ListaItens.Add(obj);
                    }
                }

                if (ListaItens.Count > 1 && QtdDeColunas == 1 && QtdDeLinhas == 1)
                {
                    EtiquetaItem obj = ListaItens.Last().ShallowCopy();
                    ListaItens.Add(obj);
                }

                PrintPreviewDialogSelectPrinter Preview = new PrintPreviewDialogSelectPrinter
                {
                    Document = new PrintDocument()
                };
                Preview.Document.PrintPage += new PrintPageEventHandler(Etiquetas_PrintPage);
                Preview.Document.PrintController = new StandardPrintController();
                Preview.Document.DefaultPageSettings.PaperSize = new PaperSize(TipoPapel, Convert.ToInt32(LarguraPagina), Convert.ToInt32(AlturaPagina));
                Preview.Document.DefaultPageSettings.Margins = new Margins(Convert.ToInt32(Page_Margin_Left), Convert.ToInt32(Page_Margin_Right), Convert.ToInt32(Page_Margin_Top), Convert.ToInt32(Page_Margin_Bottom));
                Preview.Document.OriginAtMargins = true;

                Preview.Text = NomeDaEtiqueta;
                Preview.Width = LarguraPreview;
                Preview.Height = AlturaPreview;
                Preview.StartPosition = FormStartPosition.CenterScreen;
                Preview.PrintPreviewControl.Zoom = (Zoom / 100.0D);
                Preview.ShowDialog();
            }
            catch
            {
                throw new Exception();
            }
        }

        private void Etiquetas_PrintPage(object sender, PrintPageEventArgs e)
        {
            LarguraDisponivel = Math.Floor((sender as PrintDocument).OriginAtMargins ? e.MarginBounds.Width : e.PageSettings.Landscape ? (decimal)e.PageSettings.PrintableArea.Height : (decimal)e.PageSettings.PrintableArea.Width);
            AlturaDisponivel = Math.Floor((sender as PrintDocument).OriginAtMargins ? e.MarginBounds.Height : e.PageSettings.Landscape ? (decimal)e.PageSettings.PrintableArea.Width : (decimal)e.PageSettings.PrintableArea.Height);
            GerarMatriz(e);
        }
    }
}