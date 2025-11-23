/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 15:47:51</date>
*	<description></description>
**/
using Dados;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace RegrasNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 15:47:51
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasCarrosVendidos
    {
        #region Attributes
        private DicionarioCarrosVendidos carrosVendidos;
        private static Logs logs;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public RegrasCarrosVendidos()
        {
            carrosVendidos = new DicionarioCarrosVendidos();
            logs = new Logs();
        }

        #endregion

        #region Properties
        #endregion

        #region Functions

        #region Functions
        /// <summary>
        /// Funcao que tenta criar um novo carro
        /// </summary>
        /// <param name="m">matricula</param>
        /// <param name="data">data do carro</param>
        /// <param name="pre">preco</param>
        /// <param name="mar">marca</param>
        /// <param name="comb">tipo combustivel</param>
        /// <returns></returns>
        public Carro TentaCriarCarroVendido(string m, string data, int pre, string mar, COMBUS comb, out int CdErro, Permi permi)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                CdErro = -109;
                logs.CriaAdicionaLog(-109);
                return null;
            }
            int a = ValidaCarros.ValidaCamposCarro(m, mar, pre, data, comb);
            if (a < 0)
            {
                logs.CriaAdicionaLog(-106);
                CdErro = -106;
                return null;
            }
            bool aux2 = carrosVendidos.ExisteCarroVendido(m);
            if (aux2 == true)
            {
                logs.CriaAdicionaLog(-106);
                CdErro = -106;
                return null;
            }
            Carro aux = new Carro(m, data, pre, mar, comb);
            if (aux == null)
            {
                logs.CriaAdicionaLog(-106);
                CdErro = -106;
                return null;
            }
            CdErro = -999;
            return aux;
        }

        /// <summary>
        /// Funcao que tenta adicionar um novo carro a lista de carros vendidos
        /// </summary>
        /// <param name="carro">Carro a ser adicionado</param>
        /// <returns>Devolve 1 se conseguiu insereir o carro, senao devolve -105 que indica que o
        /// objeto que entrou como parametro nao e valido</returns>
        private int TentaAdicionarCarroVendido(Carro carro, Permi permi)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                logs.CriaAdicionaLog(-109);
                return -109;

            }
            int a = ValidaCarros.ValidaObjetoCarro(carro);
            if (a < 0)
            {
                logs.CriaAdicionaLog(-105);
                return -105; 
            }
            if (a > 0)
            {
                carrosVendidos.InsereCarroVendido(carro);
            }
            return 1;
        }

        /// <summary>
        /// Funcao que tenta criar e adicionar um novo carro a lista de carros vendidos
        /// </summary>
        /// </summary>
        /// <param name="m">matricula</param>
        /// <param name="data">data</param>
        /// <param name="pre">preco</param>
        /// <param name="mar">marca</param>
        /// <param name="comb">combustivel</param>
        /// <returns></returns>
        public int TentaCriarAdicionarCarroVendido(string m, string data, int pre, string mar, COMBUS comb, Permi perm, out int CdErro)
        {
            Carro aux = TentaCriarCarroVendido(m, data, pre, mar, comb, out CdErro, perm);
            if (aux == null)
            {
                logs.CriaAdicionaLog(-106);
                return -106;

            }
            int a = TentaAdicionarCarroVendido(aux, perm);
            if (a < 0) return a;
            return 1;
        }
        
        /// <summary>
        /// Funcao que tenta encontar um carro no dicionario de carros vendidos 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int TentaEncontarCarroVendido(string m, Permi permi)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                logs.CriaAdicionaLog(-109);
                return -109;
            }
            int a = ValidaCarros.ValidaMatriculaCarro(m);
            bool aux = carrosVendidos.ExisteCarroVendido(m);
            if(aux == false) return -108;
            return 1;   
        }

        public List<string> TentaListarCarrosVendidos(out int CdErro)
        {
            List<string> list = carrosVendidos.ListaCarrosVendidos();
            if (list.Count == 0)
            {
                logs.CriaAdicionaLog(-200);
                CdErro = -200;
                return list;
            }
            CdErro = -999;
            return list;
            
        }
        /// <summary>
        /// Funcao que procura a data de venda de um determinado carro
        /// </summary>
        /// <param name="m">matricula do carro</param>
        /// <returns></returns>
        public DateTime TentaVerificarDataVenda(string m, Permi permi, out int CdErro)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                logs.CriaAdicionaLog(-109);
                CdErro = -109;
                return DateTime.MinValue;
            }
            bool b= carrosVendidos.ExisteCarroVendido(m);
            if(b == false)
            {
                logs.CriaAdicionaLog(-132);
                CdErro = -132;
                return DateTime.MinValue;
            }
            DateTime aux = carrosVendidos.DataVenda(m);
            CdErro = -999;
            return aux;
        }

        /// <summary>
        /// Funcao que tenta guardar os dados do cliente do stand num ficheiro binario
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool TentaGuardarCarrosVendidos(string filepath)
        {
            if (filepath == null) return false;
            carrosVendidos.GuardaCarrosVendidosFicheiroBin(filepath);
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
            carrosVendidos.LeCarrosVendidosFicheiroBin(filepath);
            return true;
        }

        public int TentaCriaLogs(string filepath)
        {
            logs.GuardaErros(filepath);
            return 0;
        }

        #endregion
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~RegrasCarrosVendidos()
        {
        }
        #endregion

        #endregion
    }
}
