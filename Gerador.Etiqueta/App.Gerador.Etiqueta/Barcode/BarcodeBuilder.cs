using System.Drawing;
using System.Linq;

namespace Barcode
{
    public class BarcodeBuilder
    {
        public Image DrawBarcode(string binario)
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