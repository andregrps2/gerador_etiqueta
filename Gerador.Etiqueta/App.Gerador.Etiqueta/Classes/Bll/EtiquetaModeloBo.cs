using App.Gerador.Etiqueta.Classes.Dal;
using App.Gerador.Etiqueta.Classes.Model;
using Classes;
using Classes.Bases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Gerador.Etiqueta.Classes.Bll
{
    public class EtiquetaModeloBo
    {
        private static Sessao sessao;

        class Accessor
        {
            static EtiquetaModeloDao etiquetaModeloDao;
            internal static EtiquetaModeloDao EtiquetaModeloDao
            {
                get
                {
                    try
                    {
                        if (etiquetaModeloDao == null)
                        {
                            if (sessao == null)
                                sessao = new Sessao();
                            etiquetaModeloDao = new EtiquetaModeloDao(sessao);
                        }
                        return etiquetaModeloDao;
                    }
                    catch (Exception err)
                    {
                        throw new Exception(err.Message);
                    }
                }
            }

            static EtiquetaCampoDao etiquetaCampoDao;
            internal static EtiquetaCampoDao EtiquetaCampoDao
            {
                get
                {
                    try
                    {
                        if (etiquetaCampoDao == null)
                        {
                            if (sessao == null)
                                sessao = new Sessao();
                            etiquetaCampoDao = new EtiquetaCampoDao(sessao);
                        }
                        return etiquetaCampoDao;
                    }
                    catch (Exception err)
                    {
                        throw new Exception(err.Message);
                    }
                }
            }
        }

        public bool Validar(EtiquetaModelo _obj)
        {
            bool sts = true;
            _obj.MensagemValidacao = "";

            if (sts && string.IsNullOrWhiteSpace(_obj.Nome))
            {
                sts = false;
                _obj.MensagemValidacao = "Nome não pode ficar em branco.";
            }

            return sts;
        }

        public bool Salvar(EtiquetaModelo _obj)
        {
            try
            {
                bool sts = false;
                if (_obj.DataObjectState == DataObjectStateEnum.Confirmed)
                    sts = true;

                Accessor.EtiquetaModeloDao.IniciarTransacao();

                if (!sts)
                {
                    if (_obj.DataObjectState == DataObjectStateEnum.Added)
                        sts = Accessor.EtiquetaModeloDao.Inserir(_obj, sessao.Transaction);
                    else
                        sts = Accessor.EtiquetaModeloDao.Alterar(_obj, sessao.Transaction);
                }

                if (sts && _obj.Campos.Count > 0)
                {
                    foreach (EtiquetaCampo item in _obj.Campos.DeletedItems)
                        RemoverCampo(item.Id, sessao);

                    foreach (EtiquetaCampo item in _obj.Campos)
                    {
                        item.EtiquetaId = _obj.Id;
                        sts = AdicionarCampo(item, sessao);
                        if (!sts)
                        {
                            _obj.MensagemValidacao = $" ({item.Descricao} - Campo da Etiqueta)";
                            break;
                        }
                    }
                }

                Accessor.EtiquetaModeloDao.FinalizarTransacao(sts);
                return sts;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Excluir(long _id)
        {
            try
            {
                Accessor.EtiquetaModeloDao.IniciarTransacao();
                bool sts = Accessor.EtiquetaModeloDao.Excluir(_id, sessao.Transaction);
                Accessor.EtiquetaModeloDao.FinalizarTransacao(sts);
                return sts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EtiquetaModelo RetornarPorId(long _id)
        {
            try
            {
                return Accessor.EtiquetaModeloDao.RetornarPorId(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EtiquetaModelo> RetornarPorParametros(EtiquetaModelo _obj)
        {
            try
            {
                return Accessor.EtiquetaModeloDao.RetornarPorParametros(_obj).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<EtiquetaModelo> RetornarTodos(bool _inserirOpcaoNaoSelecionado = false)
        {
            try
            {
                List<EtiquetaModelo> lst = Accessor.EtiquetaModeloDao.RetornarTodos().ToList();
                if (_inserirOpcaoNaoSelecionado)
                {
                    if (lst == null)
                        lst = new List<EtiquetaModelo>();
                    lst.Insert(0, new EtiquetaModelo() { Id = 0, Nome = "NAO SELECIONADA" });
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RetornarCamposPorModelo(EtiquetaModelo _obj)
        {
            try
            {
                Accessor.EtiquetaCampoDao.RetornarPorModelo(_obj);
            }
            catch
            {
                throw;
            }
        }

        public bool ValidarCampo(EtiquetaCampo _obj)
        {
            bool sts = true;
            _obj.MensagemValidacao = "";

            if (sts && string.IsNullOrWhiteSpace(_obj.Descricao))
            {
                sts = false;
                _obj.MensagemValidacao = "Descrição não pode ficar em branco.";
            }

            return sts;
        }

        private bool AdicionarCampo(EtiquetaCampo _obj, Sessao _sessao)
        {
            try
            {
                if (_obj.DataObjectState == DataObjectStateEnum.Confirmed)
                    return true;
                bool sts;
                if (_obj.DataObjectState == DataObjectStateEnum.Added)
                    sts = Accessor.EtiquetaCampoDao.Inserir(_obj, _sessao.Transaction);
                else
                    sts = Accessor.EtiquetaCampoDao.Alterar(_obj, _sessao.Transaction);
                return sts;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool RemoverCampo(long _id, Sessao _sessao)
        {
            try
            {
                return Accessor.EtiquetaCampoDao.Excluir(_id, _sessao.Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SalvarCampo(EtiquetaCampo _obj)
        {
            try
            {
                if (_obj.DataObjectState == DataObjectStateEnum.Confirmed)
                    return true;

                Accessor.EtiquetaCampoDao.IniciarTransacao();
                bool sts;
                if (_obj.DataObjectState == DataObjectStateEnum.Added)
                    sts = Accessor.EtiquetaCampoDao.Inserir(_obj, sessao.Transaction);
                else
                    sts = Accessor.EtiquetaCampoDao.Alterar(_obj, sessao.Transaction);
                Accessor.EtiquetaCampoDao.FinalizarTransacao(sts);
                return sts;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ExcluirCampo(long _id)
        {
            try
            {
                Accessor.EtiquetaCampoDao.IniciarTransacao();
                bool sts = Accessor.EtiquetaCampoDao.Excluir(_id, sessao.Transaction);
                Accessor.EtiquetaCampoDao.FinalizarTransacao(sts);
                return sts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EtiquetaCampo RetornarCampoPorId(long _id)
        {
            try
            {
                return Accessor.EtiquetaCampoDao.RetornarPorId(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EtiquetaCampo> RetornarCampoPorParametros(EtiquetaCampo _obj)
        {
            try
            {
                return Accessor.EtiquetaCampoDao.RetornarPorParametros(_obj).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<EtiquetaCampo> RetornarCampoTodos(bool _inserirOpcaoNaoSelecionado = false)
        {
            try
            {
                List<EtiquetaCampo> lst = Accessor.EtiquetaCampoDao.RetornarTodos().ToList();
                if (_inserirOpcaoNaoSelecionado)
                {
                    if (lst == null)
                        lst = new List<EtiquetaCampo>();
                    lst.Insert(0, new EtiquetaCampo() { Id = 0, Descricao = "NAO SELECIONADO" });
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}