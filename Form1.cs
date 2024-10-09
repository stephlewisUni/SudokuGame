using sudoku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LewisSudokuProjectv2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            createCells();
            startNewGame();
        }
        
        SudokuCell[,] cells = new SudokuCell[9, 9];

        private void createCells() //the method name
        {
            for (int i = 0; i < 9; i++) //a nested loop which goes through 9x9 cells in a 2D array
            {
                for (int j = 0; j < 9; j++)
                {
                    
                    cells[i, j] = new SudokuCell(); //a new sudokucell object is made
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20); //adding properties to each cell this is font
                    cells[i, j].Size = new Size(40, 40); //this is size
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark; //this is foreground colour
                    cells[i, j].Location = new Point(i * 40, j * 40);// this is location
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray; //this property means that 4 of the 3x3 grids will be light grey 
                                                                                                            //this makes it easier for the user to identify which cells are in which smaller grid
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i; //the x and y coords are set based on what the variables are in the loop
                    cells[i, j].Y = j;

                    
                    cells[i, j].KeyPress += cell_keyPressed; // an event is added to the keypress event

                    panel1.Controls.Add(cells[i, j]); //the cell is added to controls collection of the panel
                }
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e) // the event is triggered when a cell is pressed
        {                           //two arguments sender is the object that raised th event and e an object  that contains data
            var cell = sender as SudokuCell; //casts sender to a sudoku cell and assigns the sudokucell object to a variable cell

            // if the cell is locked method returns asap without doing anything
            if (cell.IsLocked)
                return;

            int value;

            // checks if key press is a number (validation)
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // clears the cell value if pressed key is zero (validation)
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString(); //the text property is set to the string of the value

                cell.ForeColor = SystemColors.ControlDarkDark; //forecolour is changed
            }
        }
        private void startNewGame()
        {
            loadValues();
            showRandomValues(45); //shows 45/81 values of the puzzle
        }
        

        private void showRandomValues(int hintsCount)
        {
            
            
            for (int i = 0; i < hintsCount; i++)
            {
                var rX = random.Next(9); //set random cells x and y values
                var rY = random.Next(9);

                
                
                cells[rX, rY].Text = cells[rX, rY].Value.ToString();
                cells[rX, rY].ForeColor = Color.Black; // make the set values a different colour
                cells[rX, rY].IsLocked = true; // make sure the player can't edit the value
            }
        }

        private void loadValues()
        {
            //this clears all the cells
            foreach (var cell in cells)
            {
                cell.Value = 0;
                cell.Clear();
            }

            //this method is called until it can find a value for each cell
            findValueForCell(0, -1);
            
        }

        Random random = new Random(); //to find random values

        private bool findValueForCell(int i, int j)
        {
            //increases the i and j values to move to the next cell
            
            if (++j > 8)
            {
                j = 0;  //when the collumn ends then move to the next row

                //to finish once the values end
                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //created the values that can be in the row/collumn/3x3

            //enters a do-while loop which generates a new value by randomly selecting an element from numsLeft and assigning it to the cell
            do
            {
                
                if (numsLeft.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return false;
                }

                
                value = numsLeft[random.Next(0, numsLeft.Count)];
                cells[i, j].Value = value;

                
                numsLeft.Remove(value);
            }
            while (!isValidNumber(value, i, j) || !findValueForCell(i, j));

            //if the new value is not valid, the code continues to loop, generating new values until a valid value is found
           
           // cells[i, j].Text = value.ToString(); (for testing)
            return true;
        }
        //function which checks if the value is already present in the same row, column, or 3x3 grid as the cell
        private bool isValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
               
                if (i != y && cells[x, i].Value == value)
                    return false;

                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void CheckInput_Click(object sender, EventArgs e)
        {
            var wrongCells = new List<SudokuCell>();

            
            foreach (var cell in cells)
            {
                if (!string.Equals(cell.Value.ToString(), cell.Text)) //this compares the answers inputed to the check made comparing the values 
                {                                                     //to the list of correct values in each column, row nd 3x3
                    wrongCells.Add(cell);
                }
            }

             
            if (wrongCells.Any())   //if there are wrong inputs the player wins
            {
               
                wrongCells.ForEach(x => x.ForeColor = Color.Red); //this highlights the wrong cells
                MessageBox.Show("Wrong inputs");
            }
            else
            {
                MessageBox.Show("You Wins");
            }
        }

        private void ClearInput_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                
                if (cell.IsLocked == false) //only clear the cells which aren't locked
                    cell.Clear();
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            startNewGame();
        }
    }   
}

    

