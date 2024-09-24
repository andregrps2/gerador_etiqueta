using Classes.Bases;
using System;
using System.ComponentModel;

namespace App.Gerador.Etiqueta.Classes.Model
{
    public class EtiquetaModelo : BaseModel
    {
        public EtiquetaModelo()
        {
            PreviewLargura = 1366;
            PreviewAltura = 780;
            PreviewNivelZoom = 150;

            ColunaQuantidade = 1;
            LinhaQuantidade = 1;

            Campos = new EtiquetaCampoCollection();
        }

        [DisplayName("Noma da etiqueta")]
        public string Nome { get; set; }

        [DisplayName("Tipo de papel")]
        public string TipoPapel { get; set; }

        [DisplayName("Qtde colunas")]
        public int ColunaQuantidade { get; set; }

        [DisplayName("Qtde linhas")]
        public int LinhaQuantidade { get; set; }

        [DisplayName("Largura preview")]
        public int PreviewLargura { get; set; }

        [DisplayName("Altura preview")]
        public int PreviewAltura { get; set; }

        [DisplayName("Nível zoom preview")]
        public int PreviewNivelZoom { get; set; }

        [DisplayName("Largura página")]
        public decimal PaginaLargura { get; set; }

        [DisplayName("Altura página")]
        public decimal PaginaAltura { get; set; }

        [DisplayName("Largura etiqueta")]
        public decimal EtiquetaLargura { get; set; }

        [DisplayName("Altura etiqueta")]
        public decimal EtiquetaAltura { get; set; }

        [DisplayName("Margem superior")]
        public decimal MargemSuperior { get; set; }

        [DisplayName("Margem inferior")]
        public decimal MargemInferior { get; set; }

        [DisplayName("Margem direita")]
        public decimal MargemDireita { get; set; }

        [DisplayName("Margem esquerda")]
        public decimal MargemEsquerda { get; set; }

        [DisplayName("Remover espaço entre colunas")]
        public bool RemoverEspacoEntreColuna { get; set; }

        [DisplayName("Remover espaço entre linhas")]
        public bool RemoverEspacoEntreLinha { get; set; }

        [DisplayName("Mostrar linha corte tracejada")]
        public bool MostarLinhaCorteTracejada { get; set; }

        public EtiquetaCampoCollection Campos { get; }
    }
}