using Classes.Bases;
using System;
using System.Collections.Generic;
using System.Data;

namespace Classes.Repositorio
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : class
    {
        void IniciarTransacao();
        void FinalizarTransacao(bool _status);

        void IniciarConexao();
        void FinalizarConexao();

        IEnumerable<TEntidade> RetornarTodos(IDbTransaction _trans = null);
        IEnumerable<TEntidade> RetornarPorParametros(object _objOrParams, IDbTransaction _trans = null);

        TEntidade RetornarPorId(object _id, IDbTransaction _trans = null);

        bool Inserir(BaseModel _obj, IDbTransaction _trans, object _params = null);
        bool Alterar(BaseModel _obj, IDbTransaction _trans, object _params = null);
        bool Excluir(object _id, IDbTransaction _trans);
    }
}
