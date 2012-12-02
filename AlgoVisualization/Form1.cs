using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AlgoVisualization
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private static TrackBar trackbar;

        private int x = 1, y = 1, x1 = 1, y1 = 1, x2 = 1, y2 = 1;

        public static int Speed
        {
            get { return trackbar.Value; }
        }

        public Form1()
        {
            InitializeComponent();
            trackbar = trackBar1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thread == null)
            {
                thread = new Thread(startVisualize);
                thread.Start();
            }
            else
            {
                thread = new Thread(startVisualize);
                thread.Start();
            }
        }

        private void startVisualize()
        {
            x = decimal.ToInt32(numericUpDown1.Value);
            y = decimal.ToInt32(numericUpDown2.Value);
            x1 = decimal.ToInt32(numericUpDown3.Value);
            y1 = decimal.ToInt32(numericUpDown4.Value);
            x2 = decimal.ToInt32(numericUpDown5.Value);
            y2 = decimal.ToInt32(numericUpDown6.Value);

            int sx = 502/x;
            int sy = 344/y;
            int w = sx*x;
            int h = sy*y;
            if (w != panel2.Width || h != panel2.Height)
                panel2.Size = new Size(w, h);

            ComputingHelper.panelx = panel2.Width;
            ComputingHelper.panely = panel2.Height;
            ComputingHelper.sizeX = x;
            ComputingHelper.sizeY = y;

            Algorithms.Solve(panel2.CreateGraphics(), x, y, x1, y1, x2, y2);
        }
    }
}
