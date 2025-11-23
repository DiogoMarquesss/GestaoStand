/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>20/12/2024 11:22:50</date>
*	<description></description>
**/
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 20/12/2024 11:22:50
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class DicionarioErrosCarros
    {
        static Dictionary<int, string> errosCarros = new Dictionary<int, string>()
        {
            {-100, "Matricula Invalida" },
            {-101, "Marca Invalida" },
            {-102,"Preco Invalido" },
            {-103, "Data Invalida" },
            {-104, "Combustivel Invalido" },
            {-105, "Objeto Invalido" },
            {-106, "Falha na Criacao" },
            {-107, "Falha na Adicao" },
            {-108, "Nao Existe Objeto"},
            {-109, "Nao tem permissao" },
            {-110, "Ja Existe Funcionario" },
            {-111, "Id Funcionario Invalido" },
            {-112, "Nao Existe Funcionario" },
            {-113, "Falha a Remover Funcionario" },
            {-114, "Nome do Ficehiro Invalido" },
            {-115, "Falha ao Adcionar Cliente"},
            {-116, "Id Cliente Invalido" },
            {-117, "Falha Remover Cliente"},
            {-118, "Falha ao Criar Cliente" },
            {-130, "Id Cliente Invalido" },
            {-131, "Venda Incompleta" },
            {-132, "Nao Existe Carro" },
            {-200, "Falha ao listar" }
        };

        /// <summary>
        /// Atraves de un codigo erro ve qual e a sua descricao
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        public static string ProcuraDescricao(int cod)
        {
            if (ExisteErro(cod))
            {
                return errosCarros[cod];
            }
            return string.Empty;
        }
         /// <summary>
         /// 
         /// </summary>
         /// <param name="cod"></param>
         /// <returns></returns>
        public static bool ExisteErro(int cod)
        {
            if(cod > 0) return true;
            if(errosCarros.ContainsKey(cod)) return true;
            return false;
        }
    }
}