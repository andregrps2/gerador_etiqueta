using System;
using System.Drawing;

namespace Barcode
{
    internal class BarcodeEAN8 : BarcodeCommon
    {
        private string[] EAN_CodeA = new string[] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private string[] EAN_CodeC = new string[] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100"};

        public BarcodeEAN8(string _value)
        {
            RawData = _value;
        }

        private void CheckDigit()
        {
            if (RawData.Length == 7)
            {
                int even = 0;
                int odd = 0;
                for (int i = 0; i <= 6; i += 2)
                    odd += Convert.ToInt32(RawData.Substring(i, 1)) * 3;
                for (int i = 1; i <= 5; i += 2)
                    even += Convert.ToInt32(RawData.Substring(i, 1));

                int total = even + odd;
                int checksum = total % 10;
                checksum = 10 - checksum;
                if (checksum == 10)
                    checksum = 0;

                RawData += checksum.ToString();
            }
        }

        private string Converter()
        {
            if (RawData.Length != 8 && RawData.Length != 7)
                Error("EEAN8-1: Invalid data length. (7 or 8 numbers only)");
            if (!IsNumericOnly(RawData))
                Error("EEAN8-2: Numeric only.");

            string result = "101";
            for (int i = 0; i < RawData.Length / 2; i++)
                result += EAN_CodeA[Convert.ToInt32(RawData[i].ToString())];

            result += "01010";

            for (int i = RawData.Length / 2; i < RawData.Length; i++)
                result += EAN_CodeC[Convert.ToUInt32(RawData[i].ToString())];

            result += "101";

            return result;
        }
        public Image Desenhar()
        {
            string binary = Converter();
            return DrawBarcode(binary);
        }
    }
}