/*
*	<copyright file="Dados.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>21/12/2024 13:17:38</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 21/12/2024 13:17:38
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Excecoes
    {
        public static class DicionarioExcecoes
        {
            private static readonly Dictionary<int, string> excecoes = new Dictionary<int, string>()
            {
                { -300, "Erro ao Guardar o Ficheiro" },
                { -301, "Erro ao Ler o Ficheiro" }
            };

            public static bool ExistesExcecao(int code)
            {
                return excecoes.ContainsKey(code);
            }

            public static string ProcuraCodigoExcecao(int code)
            {
                if (ExistesExcecao(code))
                {
                    return excecoes[code];
                }
                return string.Empty;
            }
        }
    }
}
