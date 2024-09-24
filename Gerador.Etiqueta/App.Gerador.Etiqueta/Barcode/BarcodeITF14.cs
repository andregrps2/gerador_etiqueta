using System;
using System.Drawing;

namespace Barcode
{
    internal class BarcodeITF14 : BarcodeCommon
    {
        private readonly string[] ITF14_Code = new string[] { "NNWWN", "WNNNW", "NWNNW", "WWNNN", "NNWNW", "WNWNN", "NWWNN", "NNNWW", "WNNWN", "NWNWN" };

        public BarcodeITF14(string input)
        {
            RawData = input;
            CheckDigit();
        }

        private void CheckDigit()
        {
            if (RawData.Length == 13)
            {
                var total = 0;
                for (var i = 0; i <= RawData.Length - 1; i++)
                {
                    var temp = Convert.ToInt32(RawData.Substring(i, 1));
                    total += temp * ((i == 0 || i % 2 == 0) ? 3 : 1);
                }
                var cs = total % 10;
                cs = 10 - cs;
                if (cs == 10)
                    cs = 0;
                RawData += cs.ToString();
            }
        }

        private string Converter()
        {
            if (RawData.Length > 14 || RawData.Length < 13)
                Error("EITF14-1: Data length invalid. (Length must be 13 or 14)");
            if (!IsNumericOnly(RawData))
                Error("EITF14-2: Numeric data only.");

            var result = "1010";

            for (var i = 0; i < RawData.Length; i += 2)
            {
                var bars = true;
                var patternbars = ITF14_Code[Convert.ToInt32(RawData[i].ToString())];
                var patternspaces = ITF14_Code[Convert.ToInt32(RawData[i + 1].ToString())];
                var patternmixed = "";

                while (patternbars.Length > 0)
                {
                    patternmixed += patternbars[0].ToString() + patternspaces[0].ToString();
                    patternbars = patternbars.Substring(1);
                    patternspaces = patternspaces.Substring(1);
                }

                foreach (var c1 in patternmixed)
                {
                    if (bars)
                        result += (c1 == 'N') ? "1" : "11";
                    else
                        result += (c1 == 'N') ? "0" : "00";
                    bars = !bars;
                }
            }
            result += "1101";
            return result;
        }
        public Image Desenhar()
        {
            string binary = Converter();
            return DrawBarcode(binary);
        }
    }
}