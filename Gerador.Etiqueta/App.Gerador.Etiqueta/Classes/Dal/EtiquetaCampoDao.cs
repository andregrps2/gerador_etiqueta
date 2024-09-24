using App.Gerador.Etiqueta.Classes.Model;
using Classes;
using Classes.Repositorio;
using Dapper;
using System;

namespace App.Gerador.Etiqueta.Classes.Dal
{
    public class EtiquetaCampoDao : RepositorioAbstrato<EtiquetaCampo>
    {
        private readonly Sessao sessao;

        public EtiquetaCampoDao(Sessao _sessao)
            : base(_sessao)
        {
            sessao = _sessao;
            CriarTabela();
        }

        const string colunas = @"Id,EtiquetaId,Descricao,Campo,TextoLivre,Largura,Altura,MargemEsquerda,MargemTopo,FonteNome,FonteTamanho,FonteEstilo,FonteCor,TextoAlinhamentoVertical,TextoAlinhamentoHorizontal
            ,BordaLargura,BordaCor,BordaMostar,LinhaQuebrar,ImprimirAposDescricao,CodBarrasDiminuirTamanho,2 DataObjectState";

        protected override string InsertQuery => @"
            insert into EtiquetaCampo(EtiquetaId,Descricao,Campo,TextoLivre,Largura,Altura,MargemEsquerda,MargemTopo,FonteNome,FonteTamanho,FonteEstilo,FonteCor,TextoAlinhamentoVertical,TextoAlinhamentoHorizontal
            ,BordaLargura,BordaCor,BordaMostar,LinhaQuebrar,ImprimirAposDescricao,CodBarrasDiminuirTamanho)
            values(@EtiquetaId,@Descricao,@Campo,@TextoLivre,@Largura,@Altura,@MargemEsquerda,@MargemTopo,@FonteNome,@FonteTamanho,@FonteEstilo,@FonteCor,@TextoAlinhamentoVertical,@TextoAlinhamentoHorizontal
            ,@BordaLargura,@BordaCor,@BordaMostar,@LinhaQuebrar,@ImprimirAposDescricao,@CodBarrasDiminuirTamanho) ";
        protected override string UpdateQuery => @"
            update EtiquetaCampo set EtiquetaId=@EtiquetaId,Descricao=@Descricao,Campo=@Campo,TextoLivre=@TextoLivre,Largura=@Largura,Altura=@Altura,MargemEsquerda=@MargemEsquerda,MargemTopo=@MargemTopo,FonteNome=@FonteNome
                ,FonteTamanho=@FonteTamanho,FonteEstilo=@FonteEstilo,FonteCor=@FonteCor,TextoAlinhamentoVertical=@TextoAlinhamentoVertical,TextoAlinhamentoHorizontal=@TextoAlinhamentoHorizontal
                ,BordaLargura=@BordaLargura,BordaCor=@BordaCor,BordaMostar=@BordaMostar,LinhaQuebrar=@LinhaQuebrar,ImprimirAposDescricao=@ImprimirAposDescricao,CodBarrasDiminuirTamanho=@CodBarrasDiminuirTamanho
            where Id=@Id ";
        protected override string DeleteQuery => "delete from EtiquetaCampo where Id=@Id ";
        protected override string SelectAllQuery => "select " + colunas + " from EtiquetaCampo order by Descricao ";
        protected override string SelectByIdQuery => "select " + colunas + " from EtiquetaCampo where Id=@Id ";
        protected override string SelectByParamQuery => @"
            select " + colunas + @" 
               from EtiquetaCampo 
              where (Id           = @Id               or @Id        is 0)
                and (Descricao like @Descricao || '%' or @Descricao is null) 
             order by Descricao ";

        private void CriarTabela()
        {
            try
            {
                if (sessao.Connection.State != System.Data.ConnectionState.Open)
                    sessao.Connection.Open();

                sessao.Connection.Query(@"
                    create table if not exists EtiquetaCampo(
                        Id                         Integer  not null primary key autoincrement,
						EtiquetaId                 Integer default 0,
                        Descricao                  Varchar(100), 
						Campo                      Varchar(50), 
                        TextoLivre                 Varchar(100), 
						Largura                    Numeric default 0.00,
						Altura                     Numeric default 0.00,
						MargemEsquerda             Numeric default 0.00,
						MargemTopo                 Numeric default 0.00,
						FonteNome                  Varchar(50), 
						FonteTamanho               Numeric default 0.00,
						FonteEstilo                Varchar(50), 
						FonteCor                   Varchar(50), 
						TextoAlinhamentoVertical   Varchar(50), 
						TextoAlinhamentoHorizontal Varchar(50), 
                        BordaCor                   Varchar(50),
                        BordaLargura               Integer default 0,
                        BordaMostar                Integer(1) default 0,
                        LinhaQuebrar               Integer(1) default 0,
                        ImprimirAposDescricao      Integer(1) default 0,
                        CodBarrasDiminuirTamanho   Integer(1) default 0
                    ) ");
            }
            catch
            {
                throw;
            }
        }

        public void RetornarPorModelo(EtiquetaModelo _obj)
        {
            string cmd = "select " + colunas + " from EtiquetaCampo where EtiquetaId=@Id ";
            try
            {
                IniciarConexao();
                _obj.Campos.AddEnumerable(sessao.Connection.Query<EtiquetaCampo>(cmd, _obj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FinalizarConexao();
            }
        }
    }
}
