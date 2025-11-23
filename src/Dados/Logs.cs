/*
*	<copyright file="Dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>20/12/2024 15:53:33</date>
*	<description></description>
**/
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 20/12/2024 15:53:33
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Logs
    {
        #region Attributes
        List<Log> logs;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Logs()
        {
            logs = new List<Log>();
            //errosCarros = new DicionarioErrosCarros();
        }

        #endregion

        #region Properties


        #endregion

        #region Functions
        /// <summary>
        /// Cria um objeto do tipo log
        /// </summary>
        /// <param name="cod"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Log CriaLog(int cod, string nome)
        {
            if (cod < 0 && nome != "")
            {
                Log aux = new Log(cod, nome);
                return aux;
            }
            return null;
        }

        /// <summary>
        /// Funcao que insere um log na lista de logs
        /// </summary>
        /// <param name="cod"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public int InsereLogs(Log x)
        {
            if (x != null)
            {
                logs.Add(x);
                return 1;
            }
            return -1;
        }
        
        /// <summary>
        /// Cria e adiciona um erro a lista de erros
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        public int CriaAdicionaLog(int cod)
        {
            if (cod > 0) return cod;
            string aux = DicionarioErrosCarros.ProcuraDescricao(cod);
            Log x = CriaLog(cod, aux);
            InsereLogs(x);
            return 1;
        }

        /// <summary>
        /// Guarda os erros existentes no programa num ficheiro XML
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardaErros(string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Log>));
                TextWriter textWriter = new StreamWriter(fileName);
                serializer.Serialize(textWriter, logs);
                textWriter.Close();
                return true;
            }
            catch (IOException e)
            {
                //Console.Write("ERRO:" + e.Message);
                throw e;
            }
        }
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Logs()
        {
        }
        #endregion

        #endregion
    }
}
