/*
*	<copyright file="TrabalhoPratico_Fase2.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 16:32:44</date>
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
    /// Created on: 18/12/2024 16:32:44
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class Cliente
    {
        #region Attributes
        string nome;
        int ncc;
        int tel;
        int idCli;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Cliente()
        {
            nome = "";
            ncc = -1;
            tel = -1;
            idCli = -1;
        }
        public Cliente(string no, int nc, int telemovel, int id)
        {
            nome = no;
            ncc = nc;
            tel = telemovel;
            idCli = id;
        }


        #endregion

        #region Properties
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Ncc
        {
            get { return ncc; }
            set { ncc = value; }
        }
        #endregion

        public int Telemovel
        {
            get { return tel; }
            set { tel = value; }
        }

        public int IdCliente
        {
            get { return idCli; }
            set { idCli = value; }
        }
        #endregion

        #region Functions
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            Cliente c = obj as Cliente;
            if (c == null) return false;
            return this.idCli == c.idCli;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        //~Cliente()
        //{
        //}
        #endregion
    }
}
