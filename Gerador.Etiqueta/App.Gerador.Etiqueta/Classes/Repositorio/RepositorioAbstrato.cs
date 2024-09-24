using Classes.Bases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Classes.Repositorio
{
    public abstract class RepositorioAbstrato<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        protected abstract string InsertQuery { get; }
        protected abstract string UpdateQuery { get; }
        protected abstract string DeleteQuery { get; }
        protected abstract string SelectByIdQuery { get; }
        protected abstract string SelectByParamQuery { get; }
        protected abstract string SelectAllQuery { get; }

        private readonly Sessao sessao;

        public RepositorioAbstrato(Sessao _sessao)
        {
            sessao = _sessao;
        }

        public void IniciarTransacao()
        {
            if (sessao.Connection.State != ConnectionState.Open)
                sessao.Connection.Open();
            sessao.Transaction = sessao.Connection.BeginTransaction();
        }
        public void FinalizarTransacao(bool _status)
        {
            try
            {
                if (_status)
                    sessao.Transaction.Commit();
                else
                    sessao.Transaction.Rollback();

                if (sessao.Connection?.State == ConnectionState.Open)
                    sessao.Connection.Close();
            }
            catch { }
        }

        public void IniciarConexao()
        {
            if (sessao.Connection.State != ConnectionState.Open)
                sessao.Connection.Open();
        }
        public void FinalizarConexao()
        {
            try
            {
                sessao.Connection?.Close();
            }
            catch { }
        }

        public IEnumerable<TEntidade> RetornarTodos(IDbTransaction _trans = null)
        {
            IEnumerable<TEntidade> lst;
            try
            {
                if (_trans == null)
                    IniciarConexao();
                lst = sessao.Connection.Query<TEntidade>(SelectAllQuery, _trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_trans == null)
                    FinalizarConexao();
            }
            return lst;
        }
        public IEnumerable<TEntidade> RetornarPorParametros(object _objOrParams, IDbTransaction _trans = null)
        {
            IEnumerable<TEntidade> lst;
            try
            {
                if (_trans == null)
                    IniciarConexao();
                lst = sessao.Connection.Query<TEntidade>(SelectByParamQuery, _objOrParams, _trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_trans == null)
                    FinalizarConexao();
            }
            return lst;
        }

        public TEntidade RetornarPorId(object _id, IDbTransaction _trans = null)
        {
            TEntidade obj;
            try
            {
                if (_trans == null)
                    IniciarConexao();
                object parametros = new { Id = _id };
                obj = sessao.Connection.QueryFirstOrDefault<TEntidade>(SelectByIdQuery, parametros, _trans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_trans == null)
                    FinalizarConexao();
            }
            return obj;
        }

        public bool Inserir(BaseModel _obj, IDbTransaction _trans, object _params = null)
        {
            long id;
            try
            {
                if (_params == null)
                    _params = _obj;
                id = _obj.Id = sessao.Connection.QueryFirst<long>(InsertQuery + ";select last_insert_rowid();", _params, _trans);
                if (id > 0)
                    _obj.SetConfirmed();
            }
            catch (Exception)
            {
                throw;
            }
            return id > 0;
        }
        public bool Alterar(BaseModel _obj, IDbTransaction _trans, object _params = null)
        {
            int sts;
            try
            {
                if (_params == null)
                    _params = _obj;
                sts = sessao.Connection.Execute(UpdateQuery, _params, _trans);
                if (sts > 0)
                    _obj.SetConfirmed();
            }
            catch (Exception)
            {
                throw;
            }
            return sts > 0;
        }
        public bool Excluir(object _id, IDbTransaction _trans)
        {
            int sts;
            try
            {
                object parametros = new { Id = _id };
                sts = sessao.Connection.Execute(DeleteQuery, parametros, _trans);
            }
            catch (Exception)
            {
                throw;
            }
            return sts > 0;
        }

        public void Dispose()
        {
            sessao?.Transaction?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
