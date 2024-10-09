using System.Windows.Forms;

namespace sudoku
{
    class SudokuCell : Button //define sudokucell which is a subclass of button class
    {
        public int Value { get; set; } //a property which represents the value of the cell
        public bool IsLocked { get; set; } //a property that indicates if the cell is locked
        public int X { get; set; } // represents the X coordinate of the cell
        public int Y { get; set; }// represents the Y coordinate of the cell

        public void Clear() //this is a method which is used to clear the value of the cell
        {
            this.Text = string.Empty; //which sets the text property to an empty string
            this.IsLocked = false; //and sets the locked property to false
        }
    }
}
