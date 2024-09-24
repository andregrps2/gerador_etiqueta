using App.Gerador.Etiqueta.Classes.Fixo;
using Classes.Bases;
using System;
using System.ComponentModel;

namespace App.Gerador.Etiqueta.Classes.Model
{
    public class EtiquetaCampoCollection : BaseCollection<EtiquetaCampo>
    { }

    public class EtiquetaCampo : BaseModel
    {
        public EtiquetaCampo()
        {
            FonteNome = "Arial";
            FonteEstilo = "Normal";
            FonteCor = "Preto";
            TextoAlinhamentoVertical = "Topo";
            TextoAlinhamentoHorizontal = "Esquerda";
            BordaCor = "Nenhuma";
        }

        [DisplayName("Etiqueta modelo")]
        public long EtiquetaId { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Campo")]
        public CampoEnum Campo { get; set; }

        [DisplayName("Texto livre")]
        public string TextoLivre { get; set; }

        [DisplayName("Largura")]
        public decimal Largura { get; set; }

        [DisplayName("Altura")]
        public decimal Altura { get; set; }

        [DisplayName("Margem esquerda")]
        public decimal MargemEsquerda { get; set; }

        [DisplayName("Margem topo")]
        public decimal MargemTopo { get; set; }

        [DisplayName("Tipo de fonte")]
        public string FonteNome { get; set; }

        [DisplayName("Tam. da fonte")]
        public decimal FonteTamanho { get; set; }

        [DisplayName("Estilo da fonte")]
        public string FonteEstilo { get; set; }

        [DisplayName("Cor da fonte")]
        public string FonteCor { get; set; }

        [DisplayName("Alinhamento do texto na vertical")]
        public string TextoAlinhamentoVertical { get; set; }

        [DisplayName("Alinhamento do texto na horizontal")]
        public string TextoAlinhamentoHorizontal { get; set; }

        [DisplayName("Largura da borda")]
        public int BordaLargura { get; set; }

        [DisplayName("Cor da borda")]
        public string BordaCor { get; set; }

        [DisplayName("Mostar borda")]
        public bool BordaMostar { get; set; }

        [DisplayName("Quebrar linha")]
        public bool LinhaQuebrar { get; set; }

        [DisplayName("Impr. após descrição")]
        public bool ImprimirAposDescricao { get; set; }

        [DisplayName("Reduzir tam. GTIN")]
        public bool CodBarrasDiminuirTamanho { get; set; }

        public string Text_Align_Vertical
        {
            get
            {
                string alinhamento = "Near";
                switch (TextoAlinhamentoVertical)
                {
                    case "Inferior":
                        alinhamento = "Far";
                        break;
                    case "Centro":
                        alinhamento = "Center";
                        break;
                    default:
                        break;
                }
                return alinhamento;
            }
        }
        public string Text_Align_Horizontal
        {
            get
            {
                string alinhamento = "Near";
                switch (TextoAlinhamentoHorizontal)
                {
                    case "Direita":
                        alinhamento = "Far";
                        break;
                    case "Centro":
                        alinhamento = "Center";
                        break;
                    default:
                        break;
                }
                return alinhamento;
            }
        }
        public string Font_Style
        {
            get
            {
                string estilo = "Regular";
                switch (FonteEstilo)
                {
                    case "Negrito":
                        estilo = "Bold";
                        break;
                    case "Italico":
                        estilo = "Italic";
                        break;
                    case "Sublinhado":
                        estilo = "Underline";
                        break;
                    default:
                        break;
                }
                return estilo;
            }
        }
        public string Font_Color
        {
            get
            {
                string cor = "Transparent";
                switch (FonteCor)
                {
                    case "Branco":
                        cor = "White";
                        break;
                    case "Preto":
                        cor = "Black";
                        break;
                    case "Azul":
                        cor = "Blue";
                        break;
                    case "Vermelho":
                        cor = "Red";
                        break;
                    case "Amarelo":
                        cor = "Yellow";
                        break;
                    case "Verde":
                        cor = "Green";
                        break;
                    case "Marrom":
                        cor = "Brown";
                        break;
                    case "Laranja":
                        cor = "Orange";
                        break;
                    case "Roxo":
                        cor = "Purple";
                        break;
                    default:
                        break;
                }
                return cor;
            }
        }
        public string Border_Color
        {
            get
            {
                string cor = "Transparent";
                switch (BordaCor)
                {
                    case "Branco":
                        cor = "White";
                        break;
                    case "Preto":
                        cor = "Black";
                        break;
                    case "Azul":
                        cor = "Blue";
                        break;
                    case "Vermelho":
                        cor = "Red";
                        break;
                    case "Amarelo":
                        cor = "Yellow";
                        break;
                    case "Verde":
                        cor = "Green";
                        break;
                    case "Marrom":
                        cor = "Brown";
                        break;
                    case "Laranja":
                        cor = "Orange";
                        break;
                    case "Roxo":
                        cor = "Purple";
                        break;
                    default:
                        break;
                }
                return cor;
            }
        }
    }
}