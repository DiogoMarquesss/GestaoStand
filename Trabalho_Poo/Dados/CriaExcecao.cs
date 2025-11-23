/*
*	<copyright file="Dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>21/12/2024 13:39:33</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Dados.Excecoes;

namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 21/12/2024 13:39:33
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class CriaExcecao : ApplicationException
    {
        public int errorCode;

        public int ErrorCode
        {
            get { return errorCode; }
        }

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public CriaExcecao() : base("Erro")
        {

        }

        public CriaExcecao(string g) : base(g) { }

        public CriaExcecao(int cod)
        {
            string m = DicionarioExcecoes.ProcuraCodigoExcecao(cod);    
            Console.WriteLine("Error " + cod + m);
        }
    }
}
