using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GDIDrawer;

namespace JamesMason_CMPE1700ICA6
{
    public partial class Form1 : Form
    {
        Color[,] colorArray = new Color[60,80];
        CDrawer canvas;
        Point position;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            canvas = new CDrawer(bContinuousUpdate:false);
            canvas.Scale = 10;

        }


        private void btnFillColor_Click(object sender, EventArgs e)
        {
            if (cdColor.ShowDialog() == DialogResult.OK)
                lblColor.BackColor = cdColor.Color;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            ClearArray();
            CreateBorders();
            FillArray();

            for (int rows = 0; rows < 60; rows++)
                for (int columns = 0; columns < 80; columns++)
                        canvas.SetBBScaledPixel(columns, rows, colorArray[rows, columns]);

            canvas.Render();

        }

        private void ClearArray()
        {
            for (int x = 0; x < 80; x++)
                for (int y = 0; y < 60; y++)
                    colorArray[y, x] = Color.Black;

        }

        private void CreateBorders()
        {
            for (int y = 0; y < 60; y++)
            {
                colorArray[y, 0] = Color.Red;
                colorArray[y, 79] = Color.Red;
            }

            for (int x = 0; x < 80; x++)
            {
                colorArray[0, x] = Color.Red;
                colorArray[59, x] = Color.Red;
            }

        }
        private void FillArray()
        {
            Random generator = new Random();
            bool success;

            for (int x = 0; x < tbBlocks.Value; x++)
            {
                success = false;
                do
                {
                    int r = generator.Next(0, 60);
                    int c = generator.Next(0, 80);
                    if (colorArray[r, c] != Color.Red)
                    {
                        colorArray[r, c] = Color.Red;
                        success = true;
                    }

                } while (!success);
            }
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            if (cdColor.ShowDialog() == DialogResult.OK)
                lblColor.BackColor = cdColor.Color;
        }

        private void FloodFill(int x, int y, Color targetColor, Color replaceColor)
        {
            if (colorArray[y, x] != targetColor)
                return;
            if (colorArray[y, x] == replaceColor)
                return;
            colorArray[y,x] = replaceColor;
            canvas.SetBBScaledPixel(x, y, replaceColor);
            canvas.Render();
            FloodFill(x + 1, y, targetColor, replaceColor);
            FloodFill(x - 1, y, targetColor, replaceColor);
            FloodFill(x, y - 1, targetColor, replaceColor);
            FloodFill(x, y + 1, targetColor, replaceColor);

            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canvas.GetLastMouseLeftClickScaled(out position))
                FloodFill(position.X, position.Y, Color.Black, lblColor.BackColor);
        }
    }
}
