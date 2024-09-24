using App.Gerador.Etiqueta.Classes.Model;
using Classes;
using Classes.Repositorio;
using Dapper;

namespace App.Gerador.Etiqueta.Classes.Dal
{
    public class EtiquetaModeloDao : RepositorioAbstrato<EtiquetaModelo>
    {
        private readonly Sessao sessao;

        public EtiquetaModeloDao(Sessao _sessao)
            : base(_sessao)
        {
            sessao = _sessao;
            CriarTabela();
        }

        const string colunas = @"
            Id,Nome,TipoPapel,ColunaQuantidade,LinhaQuantidade,PreviewLargura,PreviewAltura,PreviewNivelZoom,PaginaLargura,PaginaAltura,EtiquetaLargura,EtiquetaAltura
            ,MargemSuperior,MargemInferior,MargemDireita,MargemEsquerda,RemoverEspacoEntreColuna,RemoverEspacoEntreLinha,MostarLinhaCorteTracejada,2 DataObjectState";

        protected override string InsertQuery => @"
            insert into EtiquetaModelo(Nome,TipoPapel,ColunaQuantidade,LinhaQuantidade,PreviewLargura,PreviewAltura,PreviewNivelZoom,PaginaLargura,PaginaAltura,EtiquetaLargura
            ,EtiquetaAltura,MargemSuperior,MargemInferior,MargemDireita,MargemEsquerda,RemoverEspacoEntreColuna,RemoverEspacoEntreLinha,MostarLinhaCorteTracejada) 
            values(@Nome,@TipoPapel,@ColunaQuantidade,@LinhaQuantidade,@PreviewLargura,@PreviewAltura,@PreviewNivelZoom,@PaginaLargura,@PaginaAltura,@EtiquetaLargura
            ,@EtiquetaAltura,@MargemSuperior,@MargemInferior,@MargemDireita,@MargemEsquerda,@RemoverEspacoEntreColuna,@RemoverEspacoEntreLinha,@MostarLinhaCorteTracejada) ";
        protected override string UpdateQuery => @"
            update EtiquetaModelo set
                Nome=@Nome,TipoPapel=@TipoPapel,ColunaQuantidade=@ColunaQuantidade,LinhaQuantidade=@LinhaQuantidade,PreviewLargura=@PreviewLargura,PreviewAltura=@PreviewAltura
                ,PreviewNivelZoom=@PreviewNivelZoom,PaginaLargura=@PaginaLargura,PaginaAltura=@PaginaAltura,EtiquetaLargura=@EtiquetaLargura,EtiquetaAltura=@EtiquetaAltura
                ,MargemSuperior=@MargemSuperior,MargemInferior=@MargemInferior,MargemDireita=@MargemDireita,MargemEsquerda=@MargemEsquerda,RemoverEspacoEntreColuna=@RemoverEspacoEntreColuna
                ,RemoverEspacoEntreLinha=@RemoverEspacoEntreLinha,MostarLinhaCorteTracejada=@MostarLinhaCorteTracejada
            where Id=@Id ";
        protected override string DeleteQuery => "delete from EtiquetaModelo where Id = @Id ";
        protected override string SelectAllQuery => "select " + colunas + " from EtiquetaModelo order by Nome ";
        protected override string SelectByIdQuery => "select " + colunas + " from EtiquetaModelo where Id = @Id ";
        protected override string SelectByParamQuery => @"
            select " + colunas + @" 
               from EtiquetaModelo 
              where (Id      = @Id          or @Id   is 0)
                and (Nome like @Nome || '%' or @Nome is null) 
             order by Nome ";

        public void CriarTabela()
        {
            try
            {
                if (sessao.Connection.State != System.Data.ConnectionState.Open)
                    sessao.Connection.Open();

                sessao.Connection.Query(@"
                    create table if not exists EtiquetaModelo(
                        Id                        Integer  not null primary key autoincrement,
                        Nome                      Varchar(100), 
                        TipoPapel                 Varchar(30), 
                        ColunaQuantidade          Integer default 0,
                        LinhaQuantidade           Integer default 0,
                        PreviewLargura            Integer default 0,
                        PreviewAltura             Integer default 0,
                        PreviewNivelZoom          Integer default 0,
                        PaginaLargura             Numeric default 0.00,
                        PaginaAltura              Numeric default 0.00,
                        EtiquetaLargura           Numeric default 0.00,
                        EtiquetaAltura            Numeric default 0.00,
                        MargemSuperior            Numeric default 0.00,
                        MargemInferior            Numeric default 0.00,
                        MargemDireita             Numeric default 0.00,
                        MargemEsquerda            Numeric default 0.00,
                        RemoverEspacoEntreColuna  Integer(1) default 0,
                        RemoverEspacoEntreLinha   Integer(1) default 0,
                        MostarLinhaCorteTracejada Integer(1) default 0
                    ) ");
            }
            catch
            {
                throw;
            }
        }
    }
}
