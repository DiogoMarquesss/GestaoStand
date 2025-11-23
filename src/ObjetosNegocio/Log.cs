/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>20/12/2024 15:52:09</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 20/12/2024 15:52:09
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Log
    {
        #region Attributes
        int codigo;
        string erro;
        DateTime dataErro;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Log()
        {
            codigo = 0;
            erro = "";
            dataErro = DateTime.Now;
        }

        public Log(int codigo, string erro)
        {
            this.codigo = codigo;
            this.erro = erro;
            dataErro = DateTime.Now;
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Log()
        {
        }
        #endregion

        #endregion
    }
}
