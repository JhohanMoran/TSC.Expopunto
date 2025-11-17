namespace TSC.Expopunto.Common
{
    public static class Util
    {
        public static string ConvertirMontoEnLetras(decimal monto)
        {
            // Separar parte entera y decimal
            long entero = (long)Math.Floor(monto);
            int decimales = (int)((monto - entero) * 100);

            string letrasEntero = NumeroEnLetras(entero);

            return $"{letrasEntero} Y {decimales:00}/100";
        }

        // ---------------- MÉTODO INTERNO ----------------
        private static string NumeroEnLetras(long valor)
        {
            if (valor == 0) return "CERO";

            if (valor < 0) return "MENOS " + NumeroEnLetras(Math.Abs(valor));

            string palabras = "";

            if ((valor / 1000000) > 0)
            {
                palabras += NumeroEnLetras(valor / 1000000) + " MILLONES ";
                valor %= 1000000;
            }

            if ((valor / 1000) > 0)
            {
                if ((valor / 1000) == 1)
                    palabras += "MIL ";
                else
                    palabras += NumeroEnLetras(valor / 1000) + " MIL ";

                valor %= 1000;
            }

            if ((valor / 100) > 0)
            {
                switch (valor / 100)
                {
                    case 1: palabras += (valor % 100 == 0) ? "CIEN " : "CIENTO "; break;
                    case 2: palabras += "DOSCIENTOS "; break;
                    case 3: palabras += "TRESCIENTOS "; break;
                    case 4: palabras += "CUATROCIENTOS "; break;
                    case 5: palabras += "QUINIENTOS "; break;
                    case 6: palabras += "SEISCIENTOS "; break;
                    case 7: palabras += "SETECIENTOS "; break;
                    case 8: palabras += "OCHOCIENTOS "; break;
                    case 9: palabras += "NOVECIENTOS "; break;
                }
                valor %= 100;
            }

            if (valor > 0)
            {
                string[] unidades = {
            "CERO","UNO","DOS","TRES","CUATRO","CINCO","SEIS","SIETE","OCHO","NUEVE",
            "DIEZ","ONCE","DOCE","TRECE","CATORCE","QUINCE",
            "DIECISÉIS","DIECISIETE","DIECIOCHO","DIECINUEVE"
        };
                string[] decenas = {
            "CERO","DIEZ","VEINTE","TREINTA","CUARENTA",
            "CINCUENTA","SESENTA","SETENTA","OCHENTA","NOVENTA"
        };

                if (valor < 20)
                {
                    palabras += unidades[valor];
                }
                else
                {
                    palabras += decenas[valor / 10];
                    if ((valor % 10) > 0)
                        palabras += " Y " + unidades[valor % 10];
                }
            }

            return palabras.Trim();
        }

    }
}
