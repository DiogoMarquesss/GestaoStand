/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>Diogo</author>
*   <date>18/12/2024 21:55:19</date>
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
    /// Created on: 18/12/2024 21:55:19
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class ValidaCarros
    {
        public static int ValidaCamposCarro(string mt, string mar, int pre, string dat, COMBUS combus)
        {
            int a = ValidaMatriculaCarro(mt);
            if (a == -1 || a == -2) return a;
            int b = ValidaMarcaCarro(mar);
            if (b == -3) return b;
            int c = ValidaPrecoCarro(pre);
            if (c == -4) return c;
            int d = ValidaDataCarro(dat);
            if (d == -5 || d == -6) return d;
            int e = ValidaCombusCarro(combus);
            if (e == -7) return e;
            return 1;
        }

        public static int ValidaMatriculaCarro(string m)
        {
            if (m == null) return -1;
            if (m.Length > 10) return -2;
            return 1;
        }

        public static int ValidaMarcaCarro(string m)
        {
            if (m == null) return -3;
            return 1;
        }

        public static int ValidaPrecoCarro(int p)
        {
            if (p <= 0) return -4;
            return 1;
        }

        public static int ValidaDataCarro(string data)
        {
            if (data == null) return -5;
            return 1;
        }

        public static int ValidaCombusCarro(COMBUS combus)
        {
            if (combus == COMBUS.Gas || combus == COMBUS.Gasoli || combus == COMBUS.Gasol || combus == COMBUS.Ele) return 1;
            return -7;
        }
        public static int ValidaObjetoCarro(Carro carro)
        {
            if (carro == null) return -11;
            return 1;
        }
    }
}
