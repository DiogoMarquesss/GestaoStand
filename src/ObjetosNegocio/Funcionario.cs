/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 00:22:26</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ObjetosNegocio
{

    public enum Permi
    {
        Alta = 1,
        Media = 2,
        Baixa = 3
    }
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 00:22:26
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class Funcionario
    {
        #region Attributes
        int id;
        int idStand;
        string nome;
        Permi permissao;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Funcionario(string n, int idS, int idFu)
        {
            nome = n;
            id = idFu;
            idStand = idS;
        }
        public Funcionario()
        {
            nome = "";
            id = -1;
            idStand = -1;
        }
        #endregion

        #region Properties
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int IdStand
        {
            get { return idStand; }
            set { idStand = value; }
        }
        public int IdFuncionario
        {
            get { return id; }
            set { id = value; }
        }
        #endregion


        #endregion

        #region Functions
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Funcionario()
        {
        }
        #endregion


    }
}
