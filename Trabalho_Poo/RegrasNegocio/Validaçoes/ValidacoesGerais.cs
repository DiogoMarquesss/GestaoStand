/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>21/12/2024 13:49:06</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RegrasNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 21/12/2024 13:49:06
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ValidacoesGerais
    {
        /// <summary>
        /// Verifica se e uma string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int VerificaSeEString(string str)
        {
            if (string.IsNullOrEmpty(str)) return -1;
            else return 1;
        }
    }
}
