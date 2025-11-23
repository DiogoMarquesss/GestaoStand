/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 21:43:23</date>
*	<description></description>
**/
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace RegrasNegocio
{

     
    /// <summary>
    /// Purpose:
    /// Created by: Diogo
    /// Created on: 18/12/2024 21:18:04
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class ValidaCampos
    {

        public static int ValidaCamposCliente(Cliente cli)
        {
            int e = ValidaObjetoCliente(cli);
            if(e == -5) return -5;
            int a = ValidaIdCliente(cli.IdCliente);
            if(a == -1) return -1;
            int b = ValidaClienteNome(cli.Nome);
            if(b == -2) return -2;
            int c = ValidaClienteNcc(cli.Ncc);
            if(c == -3) return -3;
            int d = ValidaClienteTelemovel(cli.Telemovel);
            if(d == -4) return -4;
            
            return 1;
        }

        public static int ValidaCriacaoCliente(int IdCliente, string Nome, int Ncc, int Telemovel)
        {
            int a = ValidaIdCliente(IdCliente);
            if (a == -1) return -1;
            int b = ValidaClienteNome(Nome);
            if (b == -2) return -2;
            int c = ValidaClienteNcc(Ncc);
            if (c == -3) return -3;
            int d = ValidaClienteTelemovel(Telemovel);
            if (d == -4) return -4;

            return 1;
        }

        public static int ValidaIdCliente(int id)
        {
            if(id <= 0) return -1;
            return id;
        }

        public static int ValidaClienteNome(string nome)
        {
            if (nome == null) return -2;
            return 1;
        }
        
        public static int ValidaClienteNcc(int ncc)
        {
            if(ncc <= 0) return -3;
            return 1;
        }

        public static int ValidaClienteTelemovel(int  telemovel)
        {
            if (telemovel < 0) return -4;
            return 1;
        }

        public static int ValidaObjetoCliente(Cliente cli)
        {
            if (cli == null) return -5;
            return 1;
        }
    }
}
