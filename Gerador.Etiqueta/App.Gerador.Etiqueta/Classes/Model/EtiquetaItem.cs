using System;

namespace App.Gerador.Etiqueta.Classes.Model
{
    public class EtiquetaItem
    {
        public EtiquetaItem()
        {
            DataAtual = DateTime.Now;
            PrecoDataUltimaAlteracao = DataAtual;
        }

        public int Qtd { get; set; }
        public int ProdutoId { get; set; }
        public string CodBarras { get; set; }
        public string Descricao { get; set; }
        public string DescricaoReduzida { get; set; }
        public string Unidade { get; set; }
        public DateTime DataAtual { get; set; }
        public DateTime PrecoDataUltimaAlteracao { get; set; }
        public decimal Preco1 { get; set; }
        public decimal Preco2 { get; set; }
        public decimal Preco3 { get; set; }
        public decimal Preco4 { get; set; }
        public decimal PromocaoPreco { get; set; }
        public DateTime PromocaoDataInicio { get; set; }
        public DateTime PromocaoDataFim { get; set; }
        public decimal ClubeDescontoPreco { get; set; }
        public int ClubeDescontoLimitePorCupom { get; set; }
        public DateTime ClubeDescontoDataInicio { get; set; }
        public DateTime ClubeDescontoDataFim { get; set; }
        public string GradeDescricao { get; set; }
        public string GradeTamanho { get; set; }
        public string GradeCor { get; set; }
        public DateTime ValidadeDataFabricacao { get; set; }
        public int ValidadeEmDias { get; set; }
        public int ValidadeEmMeses { get; set; }
        public decimal AtacadoQuantidade1 { get; set; }
        public decimal AtacadoPreco1 { get; set; }
        public string AtacadoUnidade1 { get; set; }
        public decimal AtacadoQuantidade2 { get; set; }
        public decimal AtacadoPreco2 { get; set; }
        public string AtacadoUnidade2 { get; set; }
        public decimal AtacadoQuantidade3 { get; set; }
        public decimal AtacadoPreco3 { get; set; }
        public string AtacadoUnidade3 { get; set; }
        public decimal AtacadoQuantidade4 { get; set; }
        public decimal AtacadoPreco4 { get; set; }
        public string AtacadoUnidade4 { get; set; }
        public decimal AtacadoQuantidade5 { get; set; }
        public decimal AtacadoPreco5 { get; set; }
        public string AtacadoUnidade5 { get; set; }
        public string TipoPeso { get; set; }
        public bool EtiquetaEmGramas { get; set; }
        public bool PesoVariavel { get; set; }

        public EtiquetaItem ShallowCopy()
        {
            return (EtiquetaItem)MemberwiseClone();
        }
    }
}