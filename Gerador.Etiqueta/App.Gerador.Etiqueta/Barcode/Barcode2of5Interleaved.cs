using System;
using System.Drawing;

namespace Barcode
{
    internal class Barcode2of5Interleaved : BarcodeCommon
    {
        private readonly string[] _i25Code = new string[] { "NNWWN", "WNNNW", "NWNNW", "WWNNN", "NNWNW", "WNWNN", "NWWNN", "NNNWW", "WNNWN", "NWNWN" };
        private readonly bool CheckDigit;

        internal Barcode2of5Interleaved(string input, bool checkDigit = false)
        {
            CheckDigit = checkDigit;
            RawData = input;
        }

        private int CalculateMod10CheckDigit()
        {
            var sum = 0;
            var even = true;
            for (var i = RawData.Length - 1; i >= 0; --i)
            {
                sum += (RawData[i] - '0') * (even ? 3 : 1);
                even = !even;
            }

            return (10 - sum % 10) % 10;
        }

        private string Converter()
        {
            if (RawData.Length % 2 != (CheckDigit ? 1 : 0))
                Error("EI25-1: Data length invalid.");
            if (!IsNumericOnly(RawData))
                Error("EI25-2: Numeric Data Only");

            var result = "1010";
            var data = RawData + (CheckDigit ? CalculateMod10CheckDigit().ToString() : "");

            for (int i = 0; i < data.Length; i += 2)
            {
                var bars = true;
                var patternbars = _i25Code[(int)char.GetNumericValue(data, i)];
                var patternspaces = _i25Code[(int)char.GetNumericValue(data, i + 1)];
                var patternmixed = "";

                while (patternbars.Length > 0)
                {
                    patternmixed += patternbars[0].ToString() + patternspaces[0].ToString();
                    patternbars = patternbars.Substring(1);
                    patternspaces = patternspaces.Substring(1);
                }

                foreach (char c1 in patternmixed)
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