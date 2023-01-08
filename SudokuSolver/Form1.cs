using System;
using System.Linq;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        private readonly Board _board;
        public Form1()
        {
            InitializeComponent();
            var panel = Controls.OfType<Panel>().First();
            _board = new Board(panel);
        }

        private void StartNewGame()
        {
            _board.GenerateBoard();
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btn_Solve_Click(object sender, EventArgs e)
        {
            var panel = Controls.OfType<Panel>().First();
            
            if (!_board.Solve(out var message))
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Can not solve this board!";
                }
                ShowError(message);
            };
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_FillFromClipboard_Click(object sender, EventArgs e)
        {
            var panel = Controls.OfType<Panel>().First();
            
            if(!_board.FillFromClipboard(panel, out var message))
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = "Invalid input";
                }

                ShowError(message);
            }
        }
    }
}