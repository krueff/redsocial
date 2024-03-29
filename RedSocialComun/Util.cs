﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RedSocialComun
{
    public class Util
    {
        private Util()
        {
        }

        public static DateTime ObtenerFecha(int anio, int mes)
        {
            try
            {
                return new DateTime(anio, mes, 1);
            }
            catch
            {
                throw new FechaInvalidaExcepcion();
            }
        }

        public static bool EsEmail(string email)
        {
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase);
        }
    }
}

