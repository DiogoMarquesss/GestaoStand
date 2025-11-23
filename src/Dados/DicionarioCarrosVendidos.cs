/*
*	<copyright file="TrabalhoPratico_Fase2.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 16:34:07</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using ObjetosNegocio;
using System.IO;

namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 18/12/2024 16:34:07
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class DicionarioCarrosVendidos
    {
        #region Attributes

        private Dictionary<int, List<Carro>> carrosVendidos;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public DicionarioCarrosVendidos()
        {
            carrosVendidos = new Dictionary<int, List<Carro>>();
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Adiciona um novo carro ao Dicionario
        /// </summary>
        /// <param name="cli"></param>
        /// <returns></returns>
        public bool InsereCarroVendido(Carro car)
        {
            int k = CalculaKey(car.Matricula);
            if (!carrosVendidos.ContainsKey(k))
            {
                carrosVendidos.Add(k, new List<Carro>());
            }
            car.DataVenda = DateTime.Now;
            carrosVendidos[k].Add(car);
            return true;
        }
        /// <summary>
        ///Calcula uma key com o objetivo de criar colisoes 
        /// </summary>
        /// <param name="atributo"></param>
        /// <returns></returns>
        public int CalculaKey(string atributo)
        {
            int Key = 0;
            string aux = atributo.ToString();
            foreach (char c in aux)
            {
                Key += c;
            }
            int k = Key % 11;
            return (k);
        }
        /// <summary>
        /// Verifica se um carro ja existe no dicionario de carros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool ExisteCarroVendido(string matricula)
        {
            int key = CalculaKey(matricula);
            if (carrosVendidos.ContainsKey(key))
            {
                foreach (Carro car in carrosVendidos[key])
                {
                    if (car.Matricula == matricula) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Funcao que retorna a data venda de um carro ataves da matricula
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public DateTime DataVenda(string m)
        {
            int key = CalculaKey(m);
            if (carrosVendidos.ContainsKey(key))
            {
                foreach (Carro car in carrosVendidos[key])
                {
                    if (car.Matricula == m) return car.DataVenda;
                }
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Lista todos os carros vendidos
        /// </summary>
        /// <returns></returns>
        public List<string> ListaCarrosVendidos()
        {
            List<string> lista = new List<string>();
            foreach(int k in carrosVendidos.Keys)
            {
                foreach(Carro car in carrosVendidos[k])
                {
                    lista.Add(car.Matricula);
                }
            }
            return lista;
        }

        #region Ficheiros

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int GuardaCarrosVendidosFicheiroBin(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, carrosVendidos);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new CriaExcecao(-300);
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int LeCarrosVendidosFicheiroBin(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;

            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                carrosVendidos = (Dictionary<int, List<Carro>>)bin.Deserialize(stream);
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
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~DicionarioCarrosVendidos()
        {
        }
        #endregion

        #endregion
    }
}

