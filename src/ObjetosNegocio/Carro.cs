/*
*	<copyright file="TrabalhoPratico_Fase2.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 16:31:20</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace ObjetosNegocio
{
    public enum COMBUS
    {
        Gasoli = 1,
        Gasol = 2,
        Gas = 3,
        Ele = 4
    }
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 18/12/2024 16:31:20
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class Carro
    {
        #region Attributes
        string matricula;
        DateTime data;
        DateTime dataVenda;
        int preco;
        string marca;
        int IdCli;
        COMBUS comb;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        /// 

        public Carro()
        {
            matricula = "";
            data = new DateTime(1800, 01, 01);
            dataVenda = new DateTime(1800, 01, 01);
            preco = -1;
            marca = "";
            IdCli = -1;
            comb = new COMBUS();
        }

        public Carro(string mat, string data, int pre, string mar, COMBUS comb)
        {
            matricula = mat;
            this.data = DateTime.Parse(data).Date;
            dataVenda = DateTime.MinValue;
            preco = pre; ;
            marca = mar;
            IdCli = 0;
            this.comb = comb;
        }

        #endregion

        #region Properties
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set
            {
                DateTime aux = (DateTime)value;
                if (aux.Date > DateTime.Now)
                {
                    data = DateTime.Now;
                }
                else
                {
                    data = value;
                }
            }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public int Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public COMBUS Combustivel
        {
            get { return comb; }
            set { comb = value; }
        }

        public int IdCliente
        {
            get { return IdCli; }
            set { IdCli = value; }
        }

        public DateTime DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }
        #endregion

        #region Functions
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            Carro c = obj as Carro;
            if (c == null) return false;
            return this.matricula == c.matricula;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        //~Carro()
        //{
        //}
        #endregion

        #endregion
    }
}
