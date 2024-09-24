using System.Collections.Generic;

namespace App.Gerador.Etiqueta.Classes.Fixo
{
    public class Campo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class Campos
    {
        public static List<Campo> Retornar()
        {
            return new List<Campo>()
            {
                new Campo() { Descricao = "Nenhum", Id = 0 },
                new Campo() { Descricao = "CodigoInterno", Id = 1 },
                new Campo() { Descricao = "CodigoDeBarras", Id = 2 },
                new Campo() { Descricao = "CodigoDeBarrasNumerico", Id = 3 },
                new Campo() { Descricao = "DescricaoCompleta", Id = 4 },
                new Campo() { Descricao = "DescricaoReduzida", Id = 5 },
                new Campo() { Descricao = "DataAtual", Id = 6 },
                new Campo() { Descricao = "PrecoDataUltimaAlteracao", Id = 7 },
                new Campo() { Descricao = "Preco1", Id = 8 },
                new Campo() { Descricao = "Preco2", Id = 9 },
                new Campo() { Descricao = "Preco3", Id = 10 },
                new Campo() { Descricao = "Preco4", Id = 11 },
                new Campo() { Descricao = "PromocaoPreco", Id = 12 },
                new Campo() { Descricao = "PromcaoDataInicioFim", Id = 13 },
                new Campo() { Descricao = "ClubeDescontoPreco", Id = 14 },
                new Campo() { Descricao = "ClubeDescontoLimitePorCupom", Id = 15 },
                new Campo() { Descricao = "ClubeDescontoDataInicio", Id = 16 },
                new Campo() { Descricao = "ClubeDescontoDataInicioFim", Id = 17 },
                new Campo() { Descricao = "GradeTamanho", Id = 18 },
                new Campo() { Descricao = "GradeCor", Id = 19 },
                new Campo() { Descricao = "GradeDescricao", Id = 20 },
                new Campo() { Descricao = "ValidadeDataFabricacao", Id = 21 },
                new Campo() { Descricao = "ValidadeEmDias", Id = 22 },
                new Campo() { Descricao = "ValidadeEmMeses", Id = 23 },
                new Campo() { Descricao = "AtacadoQuantidade1", Id = 24 },
                new Campo() { Descricao = "AtacadoPreco1", Id = 25 },
                new Campo() { Descricao = "AtacadoQuantidade2", Id = 26 },
                new Campo() { Descricao = "AtacadoPreco2", Id = 27 },
                new Campo() { Descricao = "AtacadoQuantidade3", Id = 28 },
                new Campo() { Descricao = "AtacadoPreco3", Id = 29 },
                new Campo() { Descricao = "AtacadoQuantidade4", Id = 30 },
                new Campo() { Descricao = "AtacadoPreco4", Id = 31 },
                new Campo() { Descricao = "AtacadoQuantidade5", Id = 32 },
                new Campo() { Descricao = "AtacadoPreco5", Id = 33 }
            };
        }
    }

    public enum CampoEnum
    {
        Nenhum = 0,
        CodigoInterno = 1,
        CodigoDeBarras = 2,
        CodigoDeBarrasNumerico = 3,
        DescricaoCompleta = 4,
        DescricaoReduzida = 5,
        DataAtual = 6,
        PrecoDataUltimaAlteracao = 7,
        Preco1 = 8,
        Preco2 = 9,
        Preco3 = 10,
        Preco4 = 11,
        PromocaoPreco = 12,
        PromcaoDataInicioFim = 13,
        ClubeDescontoPreco = 14,
        ClubeDescontoLimitePorCupom = 15,
        ClubeDescontoDataInicioFim = 16,
        GradeTamanho = 17,
        GradeCor = 18,
        GradeDescricao = 19,
        ValidadeDataFabricacao = 20,
        ValidadeEmDias = 21,
        ValidadeEmMeses = 22,
        ProdutoPrecoAtacado = 23,
        ImagemProduto = 24,
        ImagemEmpresa = 25
    }
}