/*
*	<copyright file="TrabalhoPratico_Fase2.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 16:35:28</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ObjetosNegocio;

namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 18/12/2024 16:35:28
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class ListaCarros  :IGestaoListas<Carro>, IGestaoObjLista<Carro>
    {
        #region Attributes
        List<Carro> listaCar;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ListaCarros()
        {
            listaCar = new List<Carro>();
        }

        #endregion

        #region Properties
        #endregion

        #region Functions

        #region Funcoes Basicas
        /// <summary>
        /// Insere um carro numa lista do tipo carro
        /// </summary>
        /// <param name="car">carro a ser inserido</param>
        /// <returns></returns>
        public  int InsereLista(Carro car)
        {
            if (car == null) return -1;
            listaCar.Add(car);
            return 1;
        }

        ///// <summary>
        ///// Procura por um detetermindo carro no array atraves da matricula 
        ///// </summary>
        ///// <param name="m">Matricula do carro a ser procurado</param>
        ///// <returns>Caso o carro exista devolve o carro</returns>
        public  Carro ProcuraObj(string m)
        {
            foreach (Carro x in listaCar)
            {
                if (x.Matricula == m) return x;
            }
            return null;
        }

        ///// <summary>
        ///// Verifica se um detetermindo carro no array atraves da matricula
        ///// </summary>
        ///// <param name="m">Matricula do carro a ser procurado</param>
        ///// <returns>caso o carro exista devolve true senaodevolve false</returns>
        public  bool ExisteCarroStand(string m)
        {
            foreach (Carro x in listaCar)
            {
                if (x.Matricula == m) return true;
            }
            return false;
        }


        ///// <summary>
        ///// Procura num stand quais os carros estao abaixo de um determinado preco
        ///// </summary>
        ///// <param name="p">Preco maximo</param>
        ///// <returns></returns>
        public  List<string> PesquisaDetalhadaPrecoStand(int p)
        {
            if (p == 0) return null;
            List<string> aux = new List<string>();
            foreach (Carro car in listaCar)
            {
                if (car.Preco == p)
                {
                    aux.Add(car.Matricula);
                }
            }
            return aux;
        }

        ///// <summary>
        ///// Remove um determinado carro do array
        ///// </summary>
        ///// <param name="m">Matricula do carro a ser removido</param>
        ///// <returns></returns>
        public  bool RemoveLista(string m)
        {
            foreach (Carro car in listaCar)
            {
                if (car.Matricula == m)
                {
                    listaCar.Remove(car);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao que altera os idCli num determinado carro 
        /// </summary>
        /// <param name="id">o novo idcli do carro</param>
        /// <param name="m">matricula do carro a onde o id vai ser alterado</param>
        /// <returns></returns>
        public  bool AlteraIdCliCarroStand(int id, string m)
        {
            Carro aux = ProcuraObj(m);
            aux.IdCliente = id;
            return true;
        }
        #endregion

        #region Perguntas
        /// <summary>
        /// Funcao que retorna o preco de um determinado carro atraves da matricula
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public  int QualPreco(string m)
        {
            foreach (Carro x in listaCar)
            {
                if (x.Matricula == m) return x.Preco;
            }
            return -1;
        }
        
        /// <summary>
        /// Lista todos os carros da lista
        /// </summary>
        /// <returns></returns>
        public List<string> ListaTodosCarros()
        {
            List<string> aux = new List<string>(); 
            foreach (Carro x in listaCar)
            {
                aux.Add(x.Matricula);
            }
            return aux;
        }

        /// <summary>
        /// Devolve a data de um carro atraves da matricula
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public DateTime QualDataCarro(string m)
        {
            foreach (Carro x in listaCar)
            {
                if (x.Matricula == m) return x.DataVenda;
            }
            return DateTime.MinValue;
        }

        public string QualMarcaCarro(string m)
        {
            foreach (Carro x in listaCar)
            {
                if (x.Matricula == m) return x.Marca;
            }
            return string.Empty;
        }
        #region Ficheiros
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public  int GuardaCarroFicheiroBin(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaCar);
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
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public  int LeCarroFicheiroBin(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;
            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                listaCar = (List<Carro>)bin.Deserialize(stream);
                stream.Close();
                return 1;
            }
            catch (IOException)
            {
                throw new CriaExcecao(-301);
            }

            return -1;
        }


        #endregion

        #endregion

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ListaCarros()
        {
        }
        #endregion

        #endregion
    }
    public interface IGestaoListas<T>
    {
         int InsereLista(T item);
         bool RemoveLista(string y);
    }

    public interface IGestaoObjLista<T>
    {
         T ProcuraObj(string y);
    }
}

