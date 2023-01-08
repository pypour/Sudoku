using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class SudokuBoard : UserControl
    {
        public SudokuBoard()
        {
            InitializeComponent();
        }

        private void SudokuBoard_Resize(object sender, EventArgs e)
        {
            panel1.Height = this.Height;
            panel1.Width = this.Width;
        }
    }
}
