using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public static class StaticBitmap
    {
        public static Bitmap Bitmap { get; set; }

        public static void SetPixel(int x, int y, Color color)
        {
            if(x >= 0 && x < Bitmap.Width && y >= 0 && y < Bitmap.Height)
            {
                Bitmap.SetPixel(x, y, color);
            }
        }
    }
}
