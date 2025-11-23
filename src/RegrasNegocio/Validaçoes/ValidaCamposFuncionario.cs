/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>19/12/2024 18:35:41</date>
*	<description></description>
**/
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RegrasNegocio
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 19/12/2024 18:35:41
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ValidaCamposFuncionario
    {

        public static int ValidaCamposFunc(int id, int idSt, string nome)
        {
            int a = ValidaNome(nome);
            if (a == -1) return a;
            int b = ValidaIdFunc(id);
            if (b == -2) return b;
            int c = ValidaIdFunSt(idSt);
            if (c == -3) return c;
            return 1;
        }

        public static int ValidaNome(string m)
        {
            if (m == null) return -1;
            return 1;
        }

        public static int ValidaIdFunc(int id)
        {
            if (id <= 0) return -2;
            return 1;
        }

        public static int ValidaIdFunSt(int idSt)
        {
            if (idSt <= 0) return -3;
            return 1;
        }

        public static int ValidaObjetoFuncionario(Funcionario f)
        {
            if (f == null) return -4;
            return 1;
        }

    }
}
