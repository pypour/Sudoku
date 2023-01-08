using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SudokuSolver
{
    internal class Board
    {
        private const int Offset = 10;
        private const int numbericWidth = 50;
        private const int numbericHeight = 30;
        private readonly int _rowCount = 3;
        private readonly Sudoku _sudoku = new Sudoku();
        private readonly Panel _panel;
        private readonly Color _backColor = Color.Black;
        private readonly Color _foreColor = Color.SlateGray;
        private readonly Color _solvedColor = Color.GreenYellow;
        private string _clipboardSampleData = $"5,3,0,0,7,0,0,0,0{Environment.NewLine}" +
                                                       $"6,0,0,1,9,5,0,0,0{Environment.NewLine}" +
                                                       $"0,9,8,0,0,0,0,6,0{Environment.NewLine}" +
                                                       $"8,0,0,0,6,0,0,0,3{Environment.NewLine}" +
                                                       $"4,0,0,8,0,3,0,0,1{Environment.NewLine}" +
                                                       $"7,0,0,0,2,0,0,0,6{Environment.NewLine}" +
                                                       $"0,6,0,0,0,0,2,8,0{Environment.NewLine}" +
                                                       $"0,0,0,4,1,9,0,0,5{Environment.NewLine}" +
                                                       $"0,0,0,0,8,0,0,7,9";
        private int _size => _rowCount * _rowCount;

        public Board(Panel panel)
        {
            _panel = panel;
        }

        private string GetElementName(int row, int col)
        {
            return $"element_{row}_{col}";
        }

        internal void GenerateBoard()
        {
            _panel.Controls.Clear();
            var colOffset = 0;
            var rowOffset = 0;

            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    var textBox = new TextBox
                    {
                        Name = GetElementName(row, col),
                        Text = "0",
                        BackColor = _backColor,
                        Location = new Point(col * numbericWidth + colOffset, row * numbericHeight + rowOffset),
                        Width = numbericWidth,
                        Height = numbericHeight,
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Microsoft Sans Serif", 15),
                        ForeColor = _foreColor,
                        MaxLength = 1,
                    };
                    textBox.KeyPress += KeyPress;
                    textBox.Enter += Enter;
                    textBox.Click += Click;
                    _panel.Controls.Add(textBox);
                    colOffset = CalculateOffset(col);
                }
                rowOffset = CalculateOffset(row);
                colOffset = 0;
            }
        }

        private int CalculateOffset(int value)
        {
            return (value + 1) / _rowCount * Offset;
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                if (char.GetNumericValue(e.KeyChar) == -1)
                {
                    ((TextBox)sender).Text = "0";
                    ((TextBox)sender).SelectAll();
                    e.Handled = true;
                }
            }
        }

        private void Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void Click(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private Dictionary<int, Dictionary<int, int>> GetValues()
        {
            var values = new Dictionary<int, Dictionary<int, int>>();

            for (int row = 0; row < _size; row++)
            {
                values.Add(row, new Dictionary<int, int>());
                for (int col = 0; col < _size; col++)
                {
                    var textBox = _panel.Controls.Find(GetElementName(row, col), false).OfType<TextBox>().First();
                    if (!int.TryParse(textBox.Text, out var value))
                    {
                        throw new ArgumentException(GetElementName(row, col));
                    }
                    values[row].Add(col, value);
                }
            }

            return values;
        }

        private void FillBoard(Dictionary<int, Dictionary<int, int>> values, Color foreColor)
        {
            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    var textBox = _panel.Controls.Find(GetElementName(row, col), false).OfType<TextBox>().First();
                    if (textBox.Text != values[row][col].ToString())
                    {
                        textBox.Text = values[row][col].ToString();
                        textBox.ForeColor = foreColor;
                    }
                }
            }
        }
        internal bool Solve(out string message)
        {
            var values = GetValues();
            var result = _sudoku.Solve(values, out message);
            if (result)
            {
                FillBoard(values, _solvedColor);
            }

            return result;
        }

        internal bool FillFromClipboard(Panel panel, out string errorMessage)
        {
            GenerateBoard();
            try
            {
                errorMessage = string.Empty;
                var data = Clipboard.GetText().Replace(Environment.NewLine, "\n").Replace("\n\n", "\n").Trim('\n', '\t', '\r');
                var counter = 0;
                while (data.Contains("\n\n") && counter < 10)
                {
                    data = data.Replace("\n\n", "\n");
                    counter++;
                }

                if (data.Contains("\n\n"))
                {
                    errorMessage = $"Invalid Data!{Environment.NewLine}" +
                        $"Sample Data: {Environment.NewLine}{_clipboardSampleData}";
                    return false;
                }

                var values = new Dictionary<int, Dictionary<int, int>>();
                var row = 0;
                foreach (var d in data.Split('\n'))
                {
                    var col = 0;
                    IEnumerable<string> numbers = d.Split(',');
                    values.Add(row++, numbers.ToDictionary(x => col++, x => string.IsNullOrWhiteSpace(x) ? 0 : Convert.ToInt32(x)));
                }
                FillBoard(values, _foreColor);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Invalid Data!{Environment.NewLine}" +
                    $"Sample Data: {Environment.NewLine}{_clipboardSampleData}";

                return false;
            }
        }
    }
}
