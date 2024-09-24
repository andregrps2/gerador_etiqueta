using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Barcode
{
    internal class BarcodeCommon
    {
        public string RawData { get; protected set; } = "";
        public List<string> Errors { get; } = new List<string>();

        internal static bool IsNumericOnly(string s)
        {
            if (s == null || s == "") return false;

            for (int i = 0; i < s.Length; i++)
                if ((s[i] ^ '0') > 9)
                    return false;
            return true;
        }

        protected void Error(string errorMessage)
        {
            Errors.Add(errorMessage);
            throw new Exception(errorMessage);
        }

        protected Image DrawBarcode(string binario)
        {
            int width = 2;

            using (Bitmap folha = new Bitmap(binario.Count() * width, 50))
            {
                using (Graphics desenhador = Graphics.FromImage(folha))
                {
                    Pen canetaPreta = new Pen(Color.Black, width);
                    Pen canetaBranca = new Pen(Color.White, width);
                    int i = 1;

                    foreach (char c in binario)
                    {
                        desenhador.DrawLine((c == '0' ? canetaBranca : canetaPreta), new Point(i, 0), new Point(i, 100));
                        i += width;
                    }
                    Image myImage = folha.Clone() as Image;
                    return myImage;
                }
            }
        }
    }
}