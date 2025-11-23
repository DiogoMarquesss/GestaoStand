/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 18:34:00</date>
*	<description></description>
**/
using Dados;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RegrasNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 18:34:00
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasFunc
    {
        #region Attributes
        private ListaFuncionarios funcionarios;
        private  Logs logs;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public RegrasFunc()
        {
            funcionarios = new ListaFuncionarios();
            logs = new Logs();
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
        /// <returns></returns>
        private Funcionario TentaCriarFuncionario(int id, int idSt, string nome, Permi permi, out int CdErro)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                logs.CriaAdicionaLog(-109);
                CdErro = -109;
                return null;
            }
            int a = ValidaCamposFuncionario.ValidaCamposFunc(id, idSt, nome);
            if (a < 0) 
            {
                logs.CriaAdicionaLog(-107);
                CdErro = -107;
                return null;
            }
            Funcionario aux = new Funcionario(nome, idSt, id);
            if (aux == null) 
            {
                logs.CriaAdicionaLog(-107);
                CdErro = -107;
                return aux;
            }
            CdErro = -999;
            return aux;
        }

        /// <summary>
        /// Funcao que tenta adicionar um Funcionario a lista de funcionarios do stand
        /// </summary>
        /// <param name="f">funcioanrio</param>
        /// <returns></returns>
        private int TentaAdicionarFuncionario(Funcionario f)
        {
            int a = ValidaCamposFuncionario.ValidaObjetoFuncionario(f);
            if (a < 0)
            {
                logs.CriaAdicionaLog(-108);
                return -108;
            }
            {
                bool aux = funcionarios.ExisteFuncionario(f.IdFuncionario);
                if (aux == false)
                { 
                    funcionarios.InsereLista(f);
                    return -999;
                }
            }
            logs.CriaAdicionaLog(-110);
            return -110;
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
        public int TentaCriarAdicionarFunc(int id, int idSt, string nome, Permi perm, out int CdErro)
        {
            Funcionario aux = TentaCriarFuncionario(id, idSt, nome, perm, out CdErro);
            if (aux != null)
            {
                logs.CriaAdicionaLog(-106);
                return -106;
            }

            int a = TentaAdicionarFuncionario(aux);
            return a;
        }

        /// <summary>
        /// Funcao que tenta verificar se ja existe um carro no stand
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int TentaEncontarFuncionario(int id)
        {
            int a = ValidaCamposFuncionario.ValidaIdFunc(id);
            if (a < 0)
            {
                logs.CriaAdicionaLog(-111);
                return -111;
            }
            bool aux = funcionarios.ExisteFuncionario(id);
            if (aux == false) 
            {
                logs.CriaAdicionaLog(-112);
                return -112;
            }
            return -999;
        }

        /// <summary>
        /// Tenta encontrar um funciona e devolve o seu nome
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public string TentaEncontrarQualFuncionario(int id, out int CdErro)
        {
            int a = ValidaCamposFuncionario.ValidaIdFunc(id);
            if (a < 0) 
            {
                logs.CriaAdicionaLog(-111);
                CdErro = -111;
                return null;
            }
            bool b = funcionarios.ExisteFuncionario(id);
            if(b == true)
            {
                CdErro = -999;
                string aux = funcionarios.QualNome(id);
                return aux;
            }
            logs.CriaAdicionaLog(-112);
            CdErro = -112;
            return null;

        }

        /// <summary>
        /// tenta remover um funcionaria da lista do stand
        /// </summary>
        /// <param name="id">Funcionario a ser removido</param>
        /// <returns></returns>
        public int TentaRemoverFuncionario(int id, Permi permi)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                logs.CriaAdicionaLog(-109);
                return -109;
            }
            bool a = funcionarios.ExisteFuncionario(id);
            if(a == false)
            {
                logs.CriaAdicionaLog(-112);
                return -112; 
            }
            bool aux = funcionarios.RemoveLista(id);
            if (aux == false) 
            {
                logs.CriaAdicionaLog(-113);
                return -113;
            }

            return -999;
        }

        /// <summary>
        /// Lista os objetos da lista funcionarios
        /// </summary>
        /// <returns></returns>
        public List<int> ListaFuncionario()
        {
            List<int> a = funcionarios.ListaFuncionario();
            return a;
        }


        /// <summary>
        /// Funcao que tenta guardar os dados dos funcionarios do stand num ficheiro binario
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool TentaGuardarFuncionarios(string filepath)
        {
            if (filepath == null) return false;
            funcionarios.GuardaFuncFicheiroBin(filepath);
            return true;
        }
        /// <summary>
        /// Funcao que tenta ler os dados de um ficheiro binario para a lista de funcionario do stand
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public int TentaLerFicheiroFuncionarios(string filepath, Permi permi)
        {
            if (permi == Permi.Baixa || permi == Permi.Media)
            {
                logs.CriaAdicionaLog(-109);
                return -109;
            }
            if (filepath == null) 
            {
                logs.CriaAdicionaLog(-114);
                return -114;
            }

            funcionarios.LeFuncFicheiroBin(filepath);
            return -999;
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
        ~RegrasFunc()
        {
        }
        #endregion

    }
}
