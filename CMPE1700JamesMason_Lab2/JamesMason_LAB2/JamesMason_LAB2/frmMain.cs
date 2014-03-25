//*************************************************************************************************************
//Program:      Lab2
//Description:  Minesweeper
//Lab:          2
//Date:         March 25, 2014
//Author:       James Mason
//Course:       CMPE1700
//Class:        2D
//Instructor:   JD Silver
//*************************************************************************************************************
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
        CDrawer canvas; //Create a cdrawer variable
        SCell[,] gameArray; // Create 2D array

        enum Estate { Invisible, Guess, Visible }; // Create an enum with 3 different states

        //**************************************************************************************************
        //Method:       struct SCell
        //Purpose:      Create a struct which will hold a value and state
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        struct SCell 
        {
            public string Value; //Declaring variable for the constructor 
            public Estate State; //Declaring variable for the constructor

            //**************************************************************************************************
            //Method:       public SCell(string Value = " ", Estate State = Estate.Invisible)
            //Purpose:      Create the constructor and initialize the variables
            //Parameters:   None        
            //Returns:      None
            //**************************************************************************************************
            public SCell(string Value = " ", Estate State = Estate.Invisible)
            {
                this.Value = Value; // Sets the value
                this.State = State; // Sets the state
            }
        }

        int mines = 10; // int that stores how many mines there are
        Point leftPosition; // point that will contain a position of the mouse
        Point rightPosition; // point that will contain a position of the mouse

        //**************************************************************************************************
        //Method:       public frmMain()
        //Purpose:      Initialize the form
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        public frmMain()
        {
            InitializeComponent(); // Initializes the form
        }

        //**************************************************************************************************
        //Method:       private void NewGame()
        //Purpose:      Create a new game
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private void NewGame()
        {
            ClearGame(); // Calls the ClearGame method
            mines = 10; // Resets the mine integer to 10

            Random generator = new Random(); // Creates/Initializes a random number generator
            bool success = false; // Creates/Initializes a boolean to false
            int x, y; // Create two int variables

            canvas.Clear(); // Clears the canvas

            for (int t = 0; t < 10; t++) // For loop that will iterate 10 times
            {
                
                success = false; // Sets success to false
                do // Do/While loop
                {
                    x = generator.Next(0, 10); // Randoms a x position
                    y = generator.Next(0, 10); // Randoms a y position
                    if (gameArray[x, y].Value != "M") // Checks to see if the position in the array contains an M
                    {
                        gameArray[x, y].Value = "M"; // Puts an M in the array position
                        success = true; // Sets success to true
                    }
                } while (!success); // Repeats the do loop if it wasn't successful in placing an M

            }

            lblMines.Text = mines.ToString(); // Sets the label on the form to display how many mines are left

            int count, up, down, left, right; // Create 5 int variables

            for (int r = 0; r < 10; r++) // First step of a double for loop that will cycle through an array
            {
                for (int c = 0; c < 10; c++) // Second step of a double for loop that will cycle through an array
                {
                    if (gameArray[c, r].Value != "M") // Checks to see if the position in the array does not contain an M
                    {
                        count = 0; // Sets count to 0
                        up = r - 1; // Initializes up one position in the array
                        down = r + 1; // Initializes down one position in the array
                        left = c - 1; // Initializes left one position in the array
                        right = c + 1; // Inititalizes right one position in the array
                        
                        //Checks to see if the top left pixel is in bounds and if its equal to M
                        if (left >= 0 && up >= 0 && gameArray[left, up].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the top pixel is in bounds and if its equal to M
                        if (up >= 0 && gameArray[c, up].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the top right pixel is in bounds and if its equal to M
                        if (up >= 0 && right <= 9 && gameArray[right, up].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the right pixel is in bounds and if its equal to M
                        if (right <= 9 && gameArray[right, r].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the right bottom pixel is in bounds and if its equal to M
                        if (right <= 9 && down <= 9 && gameArray[right, down].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the bottom pixel is in bounds and if its equal to M
                        if (down <= 9 && gameArray[c, down].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the bottom left pixel is in bounds and if its equal to M
                        if (down <= 9 && left >= 0 && gameArray[left, down].Value == "M")
                            count += 1; // Increases count by 1

                        //Checks to see if the left pixel is in bounds and if its equal to M
                        if (left >= 0 && gameArray[left, r].Value == "M")
                            count += 1; // Increases count by 1

                        // Checks to see if count is equal to 0
                        if (count == 0)
                            gameArray[c, r].Value = " "; // If count is 0, puts a blank space in that array location
                        else
                            gameArray[c, r].Value = count.ToString(); // If count is not 0, converts count to a string and places it in the array location

                    }
                }
            }
            DisplayGame(); // Calls the display game method
            timer1.Enabled = true; // Turns the timer on
        }

        //**************************************************************************************************
        //Method:       private void DisplayGame(bool debug = false)
        //Purpose:      Displays the game on the canvas
        //Parameters:   bool debug = false      
        //Returns:      None
        //**************************************************************************************************
        private void DisplayGame(bool debug = false)
        {
            canvas.Clear(); // Clears the canvas

            for (int g = 0; g <= canvas.ScaledWidth; g++) // Runs a for loop that draws a grid on the canvas
            {
                canvas.AddLine(g, 0, g, canvas.ScaledHeight, Color.Gray); // Creates a line
                canvas.AddLine(0, g, canvas.ScaledWidth, g, Color.Gray); // Creates a line
            }


                for (int x = 0; x < 10; x++) // For loop that iterates 10 times checking each position in the array
                    for (int y = 0; y < 10; y++) // For loop that iterates 10 times checking each position in the array
                    {
                        //Checks if debug is equal to true or the state of the position is visible
                        if (debug || gameArray[x,y].State == Estate.Visible)
                        {
                            canvas.SetBBScaledPixel(x, y, Color.Black); // Changes the pixel background to black
                            canvas.AddText(gameArray[x, y].Value, 30, x, y, 1, 1, Color.Red); // Draws the value from this position in the array to the canvas
                        }
                        else // If debug is note true and the cell is not visible
                        {
                            if (gameArray[x, y].State == Estate.Guess) // Checks to see if the state of the cell is guess
                            {
                                canvas.AddText("M", 30, x, y, 1, 1, Color.Green); // If it is, draws a green M
                                canvas.SetBBScaledPixel(x, y, Color.Beige); // Sets the background pixel to beige
                            }

                            if (gameArray[x,y].State == Estate.Invisible) // Checks to see if the cell state is invisible
                                canvas.SetBBScaledPixel(x, y, Color.Beige); // Sets the background to beige
                        }

                        
                    }
                canvas.Render(); // Renders everything to the canvas
        }

        //**************************************************************************************************
        //Method:       private void frmMain_Load(object sender, EventArgs e)
        //Purpose:      Performs on the form load
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private void frmMain_Load(object sender, EventArgs e)
        {
            canvas = new CDrawer(500, 500, bContinuousUpdate:false); // Initializes the canvas
            canvas.Scale = 50; // Sets the canvas scale
            gameArray = new SCell[10, 10]; // Creates a 10x10 SCell array
            cbDebug.Enabled = false; // Turns off the debug box
            canvas.RedundaMouse = true; // Sets redundamouse to true
        }

        //**************************************************************************************************
        //Method:       private void cbDebug_CheckedChanged(object sender, EventArgs e)
        //Purpose:      Event handler for each time debug is checked
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDebug.Checked) // Checks if the check box is checked
                DisplayGame(true); // Calls the DisplayGame method and sends in a true boolean
            else // If the checkbox is not checked
                DisplayGame(); // Calls the DisplayGame method
        }

        //**************************************************************************************************
        //Method:       private void btnNewGame_Click(object sender, EventArgs e)
        //Purpose:      Event handler when the New Game button is clicked
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame(); // Calls the NewGame method
            cbDebug.Enabled = true; // Enables the debug check box
            btnNewGame.Enabled = false; // Disables the new game button
        }

        //**************************************************************************************************
        //Method:       private void ClearGame()
        //Purpose:      Clears the game
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private void ClearGame()
        {
            for (int j = 0; j < 10; j++) // Iterates through each cell in the array
                for (int k = 0; k < 10; k++) // Iterates through each cell in the array
                    gameArray[j, k] = new SCell(" ", Estate.Invisible); // Sets cell location to a blank and invisible
        }

        //**************************************************************************************************
        //Method:       private void ExposeEmpty(int x, int y)
        //Purpose:      Exposes an empty cell
        //Parameters:   int x, int y -> Reads a position from the canvas and references to a cell in the array   
        //Returns:      None
        //**************************************************************************************************
        private void ExposeEmpty(int x, int y)
        {
            //Checks to see if the position is in the array
            if (x < 0 || y < 0 || x > canvas.ScaledWidth - 1 || y > canvas.ScaledHeight - 1)
                return; // Returns
            
            //Checks to see if the position's state is set to guess
            if (gameArray[x, y].State == Estate.Guess)
                return; // Returns

            //Checks to see if the position's state is visible
            if (gameArray[x, y].State == Estate.Visible)
                return; // Returns

            gameArray[x, y].State = Estate.Visible; // Sets the position to visible

            // Checks to see if if the value at the position is equal to M or a space
            if (gameArray[x, y].Value == "M" || gameArray[x, y].Value != " ")
                return; // Returns

            ExposeEmpty(x - 1, y); // Recursively calls the ExposeEmpty method with new parameters
            ExposeEmpty(x + 1, y); // Recursively calls the ExposeEmpty method with new parameters
            ExposeEmpty(x, y - 1); // Recursively calls the ExposeEmpty method with new parameters
            ExposeEmpty(x, y + 1); // Recursively calls the ExposeEmpty method with new parameters
            
            return; // Returns
        }

        //**************************************************************************************************
        //Method:       private void timer1_Tick(object sender, EventArgs e)
        //Purpose:      Performs this method each time the timer ticks
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canvas.GetLastMouseLeftClickScaled(out leftPosition)) // Checks to see if the left mouse button is clicked and outs the position to a point variable
            {
                if (gameArray[leftPosition.X, leftPosition.Y].Value == " ") // Checks to see if the position clicked has a blank space in it
                {
                    ExposeEmpty(leftPosition.X, leftPosition.Y); // Calls the ExposeEmpty method
                    DisplayGame(); // Calls the DisplayGame method
                }

                if (gameArray[leftPosition.X, leftPosition.Y].Value != "M" && gameArray[leftPosition.X, leftPosition.Y].Value != " ") // Checks to see if the position clicked does not contain an M or a blank space
                {
                    gameArray[leftPosition.X, leftPosition.Y].State = Estate.Visible; // Changes the cells state to visible
                    DisplayGame(); // Calls the DisplayGame method
                }

                if (gameArray[leftPosition.X, leftPosition.Y].Value == "M")  // Checks to see if the position contains an M
                {
                    DisplayGame(true); // Calls the DisplayGame and sends a true boolean value
                    canvas.AddText("BOOM", 50, Color.White); // Adds the word BOOM to the canvas
                    canvas.Render(); // Renders the canvas
                    btnNewGame.Enabled = true; // Enables the new game button
                    timer1.Enabled = false; // Disables the timer
                }

                

                
            }

            if (canvas.GetLastMouseRightClickScaled(out rightPosition)) // Checks to see if the right button has been clicked and outs the position to a point variable
            {
                if (gameArray[rightPosition.X, rightPosition.Y].State == Estate.Invisible) // Checks to see the state is invisible
                {
                    if (mines > 0) // Checks to see if mines are greater than 0
                    {
                        mines -= 1; // Subtracts 1 from mines
                        lblMines.Text = mines.ToString(); // Updates the label on the form
                        gameArray[rightPosition.X, rightPosition.Y].State = Estate.Guess; // Changes the state to a guess
                    }
                    
                }else
                {
                    if (mines < 10) // Checks to see if mines are less than 10
                    {
                        mines += 1; // Adds 1 to mines
                        lblMines.Text = mines.ToString(); // Updates the label on the form
                        if (gameArray[rightPosition.X, rightPosition.Y].State != Estate.Visible) // Checks to see if the position is not equal to visible
                            gameArray[rightPosition.X, rightPosition.Y].State = Estate.Invisible; // Changes the state to invisible
                    }
                }

                DisplayGame(); // Calls the DisplayGame method

                if (mines == 0) // Checks to see if mines is equal to 0
                    if (CheckWin()) // Calls the CheckWin method and checks to see if it returns true
                    {
                        canvas.AddText("YOU WIN", 50, Color.Blue); // Adds YOU WIN in blue to the canvas
                        canvas.Render(); // Renders the canvas
                        btnNewGame.Enabled = true; // Enables the new game button
                        timer1.Enabled = false; // Disbales the timer
                    }  
            }
            
        }

        //**************************************************************************************************
        //Method:       private bool CheckWin()
        //Purpose:      Checks to see if the user has won 
        //Parameters:   None        
        //Returns:      None
        //**************************************************************************************************
        private bool CheckWin()
        {
            bool success = true; // Sets a boolean to true

            for (int x = 0; x < 10; x++) // For loop that iterates through all x values in the array
                for (int y = 0; y < 10; y++) // For loop that iterates through all y values in the array
                {
                    if (gameArray[x, y].State == Estate.Guess) // Checks to see if the cell has a guess state
                        if (gameArray[x, y].Value != "M") // Checks to see if the cell does not contain an M
                            success = false; // Sets success to false
                }

            return success; // Returns the boolean value success
        }
    }
}
