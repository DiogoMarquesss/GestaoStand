/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 15:32:06</date>
*	<description></description>
**/
using Dados;
using ObjetosNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace RegrasNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 15:32:06
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasClientes
    {
        #region Attributes
        private DicionarioClientes clientes;
        private  Logs logs;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public RegrasClientes()
        {
            clientes = new DicionarioClientes();
            logs = new Logs();  
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        #region Clientes
        /// <summary>
        /// Funcao que tenta adicionar um cliente a dicionario de clientes
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        private int TentaAdicionarCliente(Cliente cliente)
        {
            int aux = ValidaCampos.ValidaCamposCliente(cliente);
            if (aux < 0) 
            {
                logs.CriaAdicionaLog(-107);
                return -107;
            }
            bool a = clientes.AdicionaDicio(cliente);
            if(a == false)
            {
                logs.CriaAdicionaLog(-115);
                return -115;
            }
            return 1;
        }

        public Cliente TentaEncontarObjCliente(int id, out int CdErro)
        {
            int a = ValidaCampos.ValidaIdCliente(id);
            if (a < 0) 
            {
                logs.CriaAdicionaLog(-116);
                CdErro = -116;
                return null;
            } 
            Cliente cliente = clientes.QualClienteObj(id);
            CdErro = -999;
            return cliente;
        }
        /// <summary>
        /// Funcao que tenta criar um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="ncc"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        private Cliente TentaCriarCliente(int id, string nome, int ncc, int tel, out int CdErro)
        {
            int aux = ValidaCampos.ValidaCriacaoCliente(id, nome, ncc, tel);
            if (aux < 0)
            {
                logs.CriaAdicionaLog(-118);
                CdErro = -118;
                return null;
            }
            Cliente cliente = new Cliente(nome, ncc, tel, id);
            if(cliente == null)
            {
                logs.CriaAdicionaLog(-118);
                CdErro = -118;
                return null;
            }
            CdErro = -999;
            return cliente;

            return null;
        }

        /// <summary>
        /// Tenta criar e adicionar um novo cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="ncc"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public int TenteaCriarAdiconaNovoCLiente(int id, string nome, int ncc, int tel, Permi p, out int CdErro)
        {
            
            if (p == Permi.Baixa || p == Permi.Media) 
            {
                logs.CriaAdicionaLog(-109);
                CdErro = -109;
                return -109;
            }
            Cliente aux = TentaCriarCliente(id, nome, ncc, tel, out CdErro);
            TentaAdicionarCliente(aux);
            return -999;
        }

        /// <summary>
        /// Tenta encontrar um cliente atraves do id e do nome
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <param name="nome">nome cliente</param>
        /// <returns></returns>
        public int TentaEncontrarCliente(int id)
        {
            int a = ValidaCampos.ValidaIdCliente(id);
            if (a < 0)
            {
                logs.CriaAdicionaLog(-116);
                return -116;
            }
            bool aux = clientes.ExisteCliente(id);
            if (aux == true) return -999;
            return 1;
        }

        /// <summary>
        /// Tenta remover um Cliente da lista de clientes do stand atraves do id
        /// </summary>
        /// <param name="id">i do cliente</param>
        /// <returns></returns>
        public int TentaRemoverCliente(int id, Permi Permi)
        {
            int aux = ValidaCampos.ValidaIdCliente(id);
            if (aux < 0)
            {
                logs.CriaAdicionaLog(-116);
                return -116;
            }
            bool a = clientes.RemoveClienteLista(id);
            if(a == false)
            {
                logs.CriaAdicionaLog(-117);
                return -117;
            }
            return -999;
        }

        /// <summary>
        /// Lista todos os clientes da lista clientes
        /// </summary>
        /// <returns></returns>
        public List<int> TentaListarClientes()
        {
            List<int> l = clientes.ListaClientes();
            return l;
        }

        /// <summary>
        /// Tentar ver um nome do cliente atraves do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string TentaVerNome(int id)
        {
            string aux = clientes.QualNome(id);
            return aux;
        }

        /// <summary>
        /// Tentar ver um telemovel de um  cliente atraves do id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <param name="p">permissao</param>
        /// <returns></returns>
        public int TentaVerTelemovel(int id, Permi p)
        {
            if (p == Permi.Baixa)
            {
                logs.CriaAdicionaLog(-109);
                return -109;
            }
            int a = ValidaCampos.ValidaIdCliente(id);
            if (a < 0) return -116;
            int aux = clientes.QualTelemovel(id);
            return aux;
        }

        /// <summary>
        /// Funcao que tenta guardar os dados do cliente do stand num ficheiro binario
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool TentaGuardarClientes(string filepath)
        {
            if (filepath == null) return false;
            clientes.GuardaCLienteFicheiroBin(filepath);
            return true;
        }
        /// <summary>
        /// Funcao que tenta ler os dados de um ficheiro binario para o dicionario clientes de um stand
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool TentaLerFicheiroClientes(string filepath)
        {
            if (filepath == null) return false;
            clientes.LeClienteFicheiroBin(filepath);
            return true;
        }
         
        /// <summary>
        /// tenta criar um ficheiro com os erros
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool TentaCriarLogsClientes(string filepath)
        {
            if (filepath == null) return false;
            logs.GuardaErros(filepath);
            return true;
        }
        #endregion
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~RegrasClientes()
        {
        }
        #endregion

        #endregion
    }
}
