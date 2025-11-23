/*
*	<copyright file="Dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 18:21:52</date>
*	<description></description>
**/
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public enum Permi
{
    Alta = 1,
    Media = 2,
    Baixa = 3
}
namespace Dados 
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 18:21:52
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class ListaFuncionarios 
    {
        #region Attributes
        List<Funcionario> funcionarios;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ListaFuncionarios()
        {
            funcionarios = new List<Funcionario>();
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int InsereLista(Funcionario f)
        {
            if (f == null) return -1;
            funcionarios.Add(f);
            return 1;
        }

        /// <summary>
        /// Procura por um detetermindo funcionario na lista atraves do id
        /// </summary>
        /// <param name="id">id do funcionario</param>
        /// <returns>Funcionario caso exista</returns>
        public Funcionario ProcuraObjFunc(int id)
        {
            foreach (Funcionario x in funcionarios)
            {
                if (x.IdFuncionario == id) return x;
            }
            return null;
        }

        /// <summary>
        /// Procura por um detetermindo funcionario na lista atraves do id
        /// </summary>
        /// <param name="id">id do funcionario</param>
        /// <returns>Verdadeiro ou falso</returns>
        public bool ExisteFuncionario(int id)
        {
            foreach (Funcionario x in funcionarios)
            {
                if (x.IdFuncionario == id) return true;
            }
            return false;
        }


        /// <summary>
        /// Devolve uma lista de inteiros com os ids de todos os funcionarios no stand
        /// </summary>
        /// <returns></returns>
        public List<int> ListaFuncionario()
        {
            List<int> aux = new List<int>();
            foreach (Funcionario f in funcionarios)
            {
                 aux.Add(f.IdFuncionario);
            }
            return aux;
        }

        /// <summary>
        /// Remove um cliente da lista 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveLista(int id)
        {
            foreach (Funcionario f in funcionarios)
            {
                if (f.IdFuncionario == id)
                {
                    funcionarios.Remove(f);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Perguntas
        /// <summary>
        /// Devolve o nome de um funcionario atraves do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string QualNome(int id)
        {
            foreach (Funcionario f in funcionarios)
            {
                if (f.IdFuncionario == id) return f.Nome;
            }
            return "";
        }

        #region Ficheiros
        /// <summary>
        /// Gurada os dados dos funcionarios num ficheiro binario
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int GuardaFuncFicheiroBin(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, funcionarios);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new CriaExcecao(-300);
            }
            return 0;
        }

        /// <summary>
        /// Le um ficheiro binario para uma lista de funcionarios
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int LeFuncFicheiroBin(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;
            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                funcionarios = (List<Funcionario>)bin.Deserialize(stream);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new CriaExcecao(-301);
            }

            return -1;
        }
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ListaFuncionarios()
        {
        }
        #endregion

        #endregion
    }
}
#endregion