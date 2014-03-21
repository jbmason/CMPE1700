using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GDIDrawer;

namespace JamesMason_LAB2
{
    public partial class frmMain : Form
    {
        CDrawer canvas;
        SCell[,] gameArray;

        enum Estate { Invisible, Guess, Visible };

        struct SCell
        {
            public string Value;
            public Estate State;

            public SCell(string Value = " ", Estate State = Estate.Invisible)
            {
                this.Value = Value;
                this.State = State;
            }
        }

        int mines = 10;
        Point leftPosition;
        Point rightPosition;


        public frmMain()
        {
            InitializeComponent();
        }

        private void NewGame()
        {
            ClearGame();
            mines = 10;

            Random generator = new Random();
            bool success = false;
            int x, y;

            canvas.Clear();

            for (int t = 0; t < 10; t++)
            {
                
                success = false;
                do
                {
                    x = generator.Next(0, 10);
                    y = generator.Next(0, 10);
                    if (gameArray[x, y].Value != "M")
                    {
                        gameArray[x, y].Value = "M";
                        success = true;
                    }
                } while (!success);

            }

            lblMines.Text = mines.ToString();

            int count, up, down, left, right;

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (gameArray[c, r].Value != "M")
                    {
                        count = 0;
                        up = r - 1;
                        down = r + 1;
                        left = c - 1;
                        right = c + 1;

                        if (left >= 0 && up >= 0 && gameArray[left, up].Value == "M")
                            count += 1;

                        if (up >= 0 && gameArray[c, up].Value == "M")
                            count += 1;

                        if (up >= 0 && right <= 9 && gameArray[right, up].Value == "M")
                            count += 1;

                        if (right <= 9 && gameArray[right, r].Value == "M")
                            count += 1;

                        if (right <= 9 && down <= 9 && gameArray[right, down].Value == "M")
                            count += 1;

                        if (down <= 9 && gameArray[c, down].Value == "M")
                            count += 1;

                        if (down <= 9 && left >= 0 && gameArray[left, down].Value == "M")
                            count += 1;

                        if (left >= 0 && gameArray[left, r].Value == "M")
                            count += 1;

                        if (count == 0)
                            gameArray[c, r].Value = " ";
                        else
                            gameArray[c, r].Value = count.ToString();

                    }
                }
            }
            DisplayGame();
            timer1.Enabled = true;
        }

        private void DisplayGame(bool debug = false)
        {
            canvas.Clear();

            for (int g = 0; g <= canvas.ScaledWidth; g++)
            {
                canvas.AddLine(g, 0, g, canvas.ScaledHeight, Color.Gray);
                canvas.AddLine(0, g, canvas.ScaledWidth, g, Color.Gray);
            }


                for (int x = 0; x < 10; x++)
                    for (int y = 0; y < 10; y++)
                    {
                        if (debug || gameArray[x,y].State == Estate.Visible)
                        {
                            canvas.SetBBScaledPixel(x, y, Color.Black);
                            canvas.AddText(gameArray[x, y].Value, 30, x, y, 1, 1, Color.Red);
                        }
                        else
                        {
                            if (gameArray[x, y].State == Estate.Guess)
                            {
                                canvas.AddText("M", 30, x, y, 1, 1, Color.Green);
                                canvas.SetBBScaledPixel(x, y, Color.Beige);
                            }

                            if (gameArray[x,y].State == Estate.Invisible)
                                canvas.SetBBScaledPixel(x, y, Color.Beige);
                        }

                        
                    }
                canvas.Render();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            canvas = new CDrawer(500, 500, bContinuousUpdate:false);
            canvas.Scale = 50;
            gameArray = new SCell[10, 10];
            cbDebug.Enabled = false;
            canvas.RedundaMouse = true;
        }

        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDebug.Checked)
                DisplayGame(true);
            else
                DisplayGame();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
            cbDebug.Enabled = true;
            btnNewGame.Enabled = false;
        }

        private void ClearGame()
        {
            for (int j = 0; j < 10; j++)
                for (int k = 0; k < 10; k++)
                    gameArray[j, k] = new SCell(" ", Estate.Invisible);
        }

        private void ExposeEmpty(int x, int y)
        {
            if (x < 0 || y < 0 || x > canvas.ScaledWidth - 1 || y > canvas.ScaledHeight - 1)
                return;

            if (gameArray[x, y].State == Estate.Guess)
                return;

            if (gameArray[x, y].State == Estate.Visible)
                return;

            gameArray[x, y].State = Estate.Visible;

            if (gameArray[x, y].Value == "M" || gameArray[x, y].Value != " ")
                return;

            ExposeEmpty(x - 1, y);
            ExposeEmpty(x + 1, y);
            ExposeEmpty(x, y - 1);
            ExposeEmpty(x, y + 1);
            
            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canvas.GetLastMouseLeftClickScaled(out leftPosition))
            {
                if (gameArray[leftPosition.X, leftPosition.Y].Value == " ")
                {
                    ExposeEmpty(leftPosition.X, leftPosition.Y);
                    DisplayGame();
                }

                if (gameArray[leftPosition.X, leftPosition.Y].Value != "M" && gameArray[leftPosition.X, leftPosition.Y].Value != " ")
                {
                    gameArray[leftPosition.X, leftPosition.Y].State = Estate.Visible;
                    DisplayGame();
                }

                if (gameArray[leftPosition.X, leftPosition.Y].Value == "M")
                {
                    DisplayGame(true);
                    canvas.AddText("BOOM", 50, Color.White);
                    canvas.Render();
                    btnNewGame.Enabled = true;
                    timer1.Enabled = false;
                }

                

                
            }

            if (canvas.GetLastMouseRightClickScaled(out rightPosition))
            {
                if (gameArray[rightPosition.X, rightPosition.Y].State == Estate.Invisible)
                {
                    if (mines > 0)
                    {
                        mines -= 1;
                        lblMines.Text = mines.ToString();
                        gameArray[rightPosition.X, rightPosition.Y].State = Estate.Guess;
                    }
                    
                }else
                {
                    if (mines < 10)
                    {
                        mines += 1;
                        lblMines.Text = mines.ToString();
                        if (gameArray[rightPosition.X, rightPosition.Y].State != Estate.Visible)
                            gameArray[rightPosition.X, rightPosition.Y].State = Estate.Invisible;
                    }
                }

                DisplayGame();

                if (mines == 0)
                    if (CheckWin())
                    {
                        canvas.AddText("YOU WIN", 50, Color.Blue);
                        canvas.Render();
                        btnNewGame.Enabled = true;
                        timer1.Enabled = false;
                    }  
            }
            
        }

        private bool CheckWin()
        {
            bool success = true;

            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    if (gameArray[x, y].State == Estate.Guess)
                        if (gameArray[x, y].Value != "M")
                            success = false;
                }

            return success;
        }
    }
}
