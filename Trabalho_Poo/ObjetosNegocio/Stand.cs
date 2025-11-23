/*
*	<copyright file="TrabalhoPratico_Fase2.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 16:36:47</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjetosNegocio;

namespace ObjetosNegocio

{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 18/12/2024 16:36:47
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Stand
    {
        #region Attributes
        int idStand;
        string localidade;
        #endregion

        #region Methods

        #region Constructors
        public Stand()
        {
            idStand = 0;
            localidade = "";
        }

        public Stand(int id, string local)
        {
            idStand = id;
            localidade = local;
 
        }
        #endregion

        #region Properties
        public int IdStand
        {
            get { return idStand; }
            set { idStand = value; }
        }

        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }
        #endregion

        #region Functions

        #region Overrides
        #endregion
        #endregion
        #endregion
    }
}
