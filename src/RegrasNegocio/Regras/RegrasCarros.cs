/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 15:38:42</date>
*	<description></description>
**/
using Dados;
using ObjetosNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace RegrasNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 15:38:42
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasCarros
    {
        #region Attributes
        ListaCarros carros;
        Logs logsCarros;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public RegrasCarros()
        {
            carros = new ListaCarros();
            logsCarros = new Logs();
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Funcao que tenta criar um novo carro
        /// </summary>
        /// <param name="m">matricula</param>
        /// <param name="data">data do carro</param>
        /// <param name="pre">preco</param>
        /// <param name="mar">marca</param>
        /// <param name="comb">tipo combustivel</param>
        /// <returns>Devolve -106 quando ano consegue criar um carro, se conseguir criar um carro
        /// devolve </returns>
        public Carro TentaCriarCarro(string m, string data, int pre, string mar, COMBUS comb, out int CdErro, Permi permi)
        {
            if(permi == Permi.Baixa)
            {
                CdErro = -109;
                logsCarros.CriaAdicionaLog(-109);
                return null;
            }
            int a = ValidaCarros.ValidaCamposCarro(m, mar, pre, data, comb);
            if (a < 0)
            {
                CdErro = -106;
                logsCarros.CriaAdicionaLog(-106);
                return null;
            }
            bool aux2 = carros.ExisteCarroStand(m);
            if (aux2 == true) 
            {
                CdErro = -106;
                logsCarros.CriaAdicionaLog(-106);
                return null;
            } 
            Carro aux = new Carro(m, data, pre, mar, comb);
            if (aux == null)
            {
                CdErro = -106;
                logsCarros.CriaAdicionaLog(-106);
                return null;
            }
            CdErro = -999;
            return aux;
        }

        /// <summary>
        /// Funcao que tenta adicionar um novo carro ao Stand
        /// </summary>
        /// <param name="carro">Carro a ser adicionado</param>
        /// <returns>Devolve 1 se conseguiu insereir o carro, senao devolve -105 que indica que o
        /// objeto que entrou como parametro nao e valido</returns>
        private int TentaAdicionarCarro(Carro carro)
        {
            int a = ValidaCarros.ValidaObjetoCarro(carro);
            if (a < 0) 
            {
                logsCarros.CriaAdicionaLog(-105);
                return -105;
            }
                carros.InsereLista(carro);
            return 1;
        }

        /// <summary>
        /// Funcao que tenta criar e adicionar um novo carro ao stand
        /// </summary>
        /// <param name="m"></param>
        /// <param name="data"></param>
        /// <param name="pre"></param>
        /// <param name="mar"></param>
        /// <param name="comb"></param>
        /// <returns></returns>
        public int TentaCriarAdicionarCarro(string m, string data, int pre, string mar, COMBUS comb, Permi perm, out int CdErro)
        {
            Carro aux = TentaCriarCarro(m, data, pre, mar, comb, out CdErro ,perm);
            if (aux == null)
            {
                logsCarros.CriaAdicionaLog(-106);
                return -106;
            }
            int a = TentaAdicionarCarro(aux);
            if (a < 0) return a;
            return 1;
        }

        /// <summary>
        /// Funcao que tenta verificar se ja existe um carro no stand
        /// </summary>
        /// <param name="m">matricula do carro </param>
        /// <returns>Devolve -100 caso a matricula seja invalida,devolve -108 caso
        /// nao exista o carro, senao devolve 1 dizendo que o carro existe</returns>
        public int TentaEncontarCarro(string m)
        {
            int a = ValidaCarros.ValidaMatriculaCarro(m);
            if (a < 0) 
            {
                logsCarros.CriaAdicionaLog(-100);
                return -100;
            }
            bool aux = carros.ExisteCarroStand(m);
            if (aux == false)
            {
                logsCarros.CriaAdicionaLog(-108);
                return -108;
            }
            
            return 1;
        }

        /// <summary>
        /// Tenta encontrar um carro no stand e se encontar develove-o
        /// </summary>
        /// <param name="m">Matricula do carro</param>
        /// <returns>Caso a matricula seja invalida devolve -100, caso o carro nao exista na lista devolve -108,
        /// caso o carro exista devolve -999 e devolve o carro</returns>
        public Carro TentaEncontrarQualCarro(string m, out int Cderro)
        {
            int a = ValidaCarros.ValidaMatriculaCarro(m);
            if (a < 0)
            {
                Cderro = -100;
                logsCarros.CriaAdicionaLog(-100);
                return null;
            }
            Carro aux = carros.ProcuraObj(m);
            if (aux == null)
            {
                Cderro = -108;
                logsCarros.CriaAdicionaLog(-108);
                return null;
            }
            Cderro = -999;
            return aux;
        }

        /// <summary>
        /// Tenta alterar os id de um cliente associado a um carro
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <param name="m">matricula do carro</param>
        /// <returns>Devolve -101 caso a matricula seja invalida, devolve -130 caso o id seja invalido
        /// devolve -108 caso o carro nao exista, devolve 1 se conseguir alterar o id.</returns>
        public int TenteAlterarIdCliente(int id, string m, Permi permi)
        {
            if (permi == Permi.Baixa)
            {
                logsCarros.CriaAdicionaLog(-109);
                return  -109;
            }
            int a = ValidaCarros.ValidaMarcaCarro(m);
            if (a < 0) 
            {
                logsCarros.CriaAdicionaLog(-101);
                return -101;
            } 
            int b = ValidaCampos.ValidaIdCliente(id);
            if (b < 0)
            {
                logsCarros.CriaAdicionaLog(-130);
                return -130;
            }
            bool aux = carros.AlteraIdCliCarroStand(id, m);
            if (aux == false) 
            {
                logsCarros.CriaAdicionaLog(-108);
                return -108;
            }
            return 1;
        }

        /// <summary>
        /// Funcao que tenta remover um carro do stand
        /// </summary>
        /// <param name="m">matricula do carro</param>
        /// <returns>Devolve -100 se a matricula for invalida senao se consegiu remover 
        /// o carro devolve 1</returns>
        public int TentaRemoverCarro(string m, Permi permi)
        {
            if (permi == Permi.Baixa)
            {
                logsCarros.CriaAdicionaLog(-109);
                return -109;
            }
            bool aux = carros.RemoveLista(m);
            if (aux == false)
            {
                logsCarros.CriaAdicionaLog(-100);
                return -100;
            }
            return 1;
        }

        /// <summary>
        /// Tenta encontrar os carros ate um determinado preco
        /// </summary>
        /// <param name="p">preco maximo de procura</param>
        /// <param name="CdErro">Codigo de erro</param>
        /// <returns>Devolve -102 caso o preco seja invalido ou nao exista carros ate esse valor
        /// devolve -999 e uma lista com a matriculas caso o existam carros ate esse valor</returns>
        public List<string> TentaEncontraCarroPreco(int p, out int CdErro)
        {   
            List<string> aux = carros.PesquisaDetalhadaPrecoStand(p);
            if (aux.Count == 0) 
            {
                CdErro = -102;
                logsCarros.CriaAdicionaLog(-102);
                return null;
            }
            CdErro = -999;
            return aux;
        }

        /// <summary>
        /// Devolve a marca de um carro associado a matricula
        /// </summary>
        /// <param name="m">matricula do carro</param>
        /// <param name="CdErro"></param>
        /// <returns></returns>
        public string QualMarca(string m, out int CdErro)
        {
            int a = ValidaCarros.ValidaMatriculaCarro(m);
            if (a < 0)
            {
                CdErro = -100;
                logsCarros.CriaAdicionaLog(-100);
                return string.Empty;
            }
            bool aux = carros.ExisteCarroStand(m);
            if(aux == false)
            {
                CdErro = -108;
                logsCarros.CriaAdicionaLog(-108);
                return string.Empty;
            }
            string s = carros.QualMarcaCarro(m);
            if(s == string.Empty)
            {
                CdErro = -101;
                logsCarros.CriaAdicionaLog(-101);
                return string.Empty;
            }
            CdErro = -999;
            return s;
        }

        /// <summary>
        /// Atraves da matricula procura a data do carro
        /// </summary>
        /// <param name="m"></param>
        /// <param name="CdErro"></param>
        /// <returns></returns>
        public DateTime QualDataCarro(string m, out int CdErro)
        {
            int a = ValidaCarros.ValidaMatriculaCarro(m);
            if (a < 0)
            {
                CdErro = -100;
                logsCarros.CriaAdicionaLog(-100);
                return DateTime.MinValue;
            }
            DateTime aux = carros.QualDataCarro(m);
            if(aux == DateTime.MinValue)
            {
                CdErro = -108;
                logsCarros.CriaAdicionaLog(-108);
                return DateTime.MinValue;
            }
            CdErro = -999;
            return aux;

        }

        /// <summary>
        /// Lista todas as matriculas dos carros presentes no stand
        /// </summary>
        /// <param name="CdErro">Codigo Erro</param>
        /// <returns>Devolove -108 caso nao existao carros, senao devolve -999 e uma lista
        /// com as matriculas</returns>
        public List<string> ListaTodosCarros(out int CdErro)
        {
            List<string> aux =  carros.ListaTodosCarros();
            if (aux == null)
            {
                CdErro = -108;
                logsCarros.CriaAdicionaLog(-108);
                return null;
            }
            CdErro = -999;
            return aux;
            
        }

        /// <summary>
        /// Diz o preco de um determinado carro
        /// </summary>
        /// <param name="m">matricula do carro</param>
        /// <returns>Devolve -100 caso a matricula seja invalida,mdevolve -108 caso o carro nao exista,
        /// devolve -1 caso nao exista carros ate ao preco em questao, senao devolve o preco</returns>
        public int QualPrecoCarro(string m)
        {
            int a =ValidaCarros.ValidaMatriculaCarro(m);
            if (a < 0)
            {
                logsCarros.CriaAdicionaLog(-100);
                return -100;
            }
            bool aux = carros.ExisteCarroStand(m);
            if (aux == false)
            {
                logsCarros.CriaAdicionaLog(-108);
                return -108;
            }
            int b = carros.QualPreco(m);
            if (b < 0) return -1;
            return b;
        }
        #region Ficheiros
        /// <summary>
        /// Funcao que tenta guardar os dados dos carros do stand num ficheiro binario
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool TentaGuardarCarros(string filepath)
        {
            if (filepath == null) return false;
            carros.GuardaCarroFicheiroBin(filepath);
            return true;
        }
        /// <summary>
        /// Funcao que tenta ler os dados de um ficheiro binario para o dicionario clientes de um stand
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public int TentaLerFicheiroCarros(string filepath)
        {
            int b = ValidacoesGerais.VerificaSeEString(filepath);
            if (b < 0) return -1;
            int a =carros.LeCarroFicheiroBin(filepath);
            return a;
        }
        /// <summary>
        /// Tenta guardar os erros ocorridos num ficheiro
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public int TentaCriarLogs(string filepath)
        {
            logsCarros.GuardaErros(filepath);
            return 1;
        }
        #endregion

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~RegrasCarros()
        {
        }
        #endregion

        #endregion
    }
}
