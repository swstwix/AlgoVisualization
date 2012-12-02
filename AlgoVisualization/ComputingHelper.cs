using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace AlgoVisualization
{
    public static class ComputingHelper
    {
        static Random g = new Random();
        const int max = 128;
        public static int panelx;
        public static int panely;
        public static int sizeX;
        public static int sizeY;

        public static Brush getRandomBrush()
        {
            Color color = Color.FromArgb(g.Next(max)+max, g.Next(max)+max, g.Next(max)+max);
            return new SolidBrush(color);
        }

        public static void FillRectangleWithNumeric(Graphics g, int x, int y ,int w, int h, string text, string upperText)
        {
            g.FillRectangle(ComputingHelper.getRandomBrush(), x, y ,w, h);
            g.DrawRectangle(Pens.Black, x, y, w, h);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, x + w / 2, y + h / 2);
            g.DrawString(upperText, SystemFonts.DefaultFont, Brushes.Black, x, y );
        }

        public static void Visualizate(Graphics g, int x, int y, int w, int h, int n)
        {
            int sx = panelx/sizeX;
            int sy = panely / sizeY;
            var text = string.Format("{0}", n);
            var upperText = string.Format("[{0}, {1}]", w, h);
            FillRectangleWithNumeric(g, (w-1)*sx, (h-1)*sy, x*sx, y * sy, text, upperText) ;
            Thread.CurrentThread.Join(Form1.Speed);
        }
    }
}
