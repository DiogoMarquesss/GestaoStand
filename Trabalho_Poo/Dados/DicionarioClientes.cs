/*
*	<copyright file="TrabalhoPratico_Fase2.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 16:34:46</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using ObjetosNegocio;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 18/12/2024 16:34:46
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class DicionarioClientes
    {
        #region Attributes
        const int Max = 11;
        private Dictionary<int, List<Cliente>> clientes;
        int Ncli;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public  DicionarioClientes()
        {
            clientes = new Dictionary<int, List<Cliente>>();
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Adiciona um novo Cliente ao Dicionario
        /// </summary>
        /// <param name="cli"></param>
        /// <returns></returns>
        public  bool AdicionaDicio(Cliente cli)
        {
            int k = CalculaKey(cli.Nome);
            if (!clientes.ContainsKey(k))
            {
                clientes.Add(k, new List<Cliente>());
            }
            clientes[k].Add(cli);
            return true;
        }
        /// <summary>
        ///Calcula uma key com o objetivo de criar colisoes 
        /// </summary>
        /// <param name="atributo"></param>
        /// <returns></returns>
        public  int CalculaKey(string atributo)
        {
            int Key = 0;
            string aux = atributo.ToString();
            foreach (char c in aux)
            {
                Key += c;
            }
            int k = Key % Max;
            return (k);
        }
        /// <summary>
        /// Verifica se um cliente ja existe no dicionario de clientes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public  bool ExisteCliente(int id)
        {
            if (clientes == null) return false;
            string nome = QualNome(id);
            int key = CalculaKey(nome);
            if (clientes.ContainsKey(key))
            {
                foreach (Cliente cli in clientes[key])
                {
                    if (cli.IdCliente == id) return true;
                }
            }
            return false;
        }
         /// <summary>
         /// Funcao que remove um cliente atraves do id
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        public bool RemoveClienteLista(int id)
        {
            if (id < 0) return false;
            if (clientes == null) return false;
            string aux = QualNome(id); 
            int k = CalculaKey(aux);
            foreach(Cliente cli in clientes[k])
            {
                if(cli.IdCliente == id)
                {
                    clientes[k].Remove(cli);
                    if (clientes[k].Count == 0)
                    {
                        clientes.Remove(k);
                        return true;
                    }
                }
            }
            return false ;
        }

        /// <summary>
        /// Atraves de um id diz o nome do cliente associado a esse id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string QualNome(int id)
        {
            foreach(int key in clientes.Keys)
            {
                foreach(Cliente cli in clientes[key])
                {
                    if (cli.IdCliente == id) return cli.Nome;
                }
            }
            return null;
        }

        /// <summary>
        /// procura um cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devolve o cliente caso exista</returns>
        public Cliente QualClienteObj(int id)
        {
            foreach (int key in clientes.Keys)
            {
                foreach (Cliente cli in clientes[key])
                {
                    if (cli.IdCliente == id) return cli;
                }
            }
            return null;
        }
        /// <summary>
        /// Lista todos os clientes da lista
        /// </summary>
        /// <returns></returns>
        public List<int> ListaClientes()
        {
            List<int> lista = new List<int>();
            foreach(int k in clientes.Keys)
            {
                foreach(Cliente cli in clientes[k])
                {
                    lista.Add(cli.IdCliente);
                }
            }
            if (lista.Count > 0)return lista;
            return null;
        }
        /// <summary>
        /// Procura um telemovel atraves do id do cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int QualTelemovel(int id)
        {
            if(id < 0) return -1;
            foreach (int k in clientes.Keys)
            {
                foreach (Cliente cli in clientes[k])
                {
                    return cli.Telemovel;
                }
            }
            return -2;
        }

        /// <summary>
        /// Funcao que guarda a lista de clientes num ficheiro binario
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public  int GuardaCLienteFicheiroBin(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, clientes);
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
        /// Funcao que le para uma lista de clientes um ficheiro binario
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int LeClienteFicheiroBin(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;

            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                clientes = (Dictionary<int, List<Cliente>>)bin.Deserialize(stream);
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
        ~DicionarioClientes()
        {
        }
        #endregion

        #endregion
    }
}
