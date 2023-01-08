namespace SudokuSolver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_NewGame = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Solve = new System.Windows.Forms.Button();
            this.btn_FillFromClipboard = new System.Windows.Forms.Button();
            this.tip_Clipboard = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_NewGame
            // 
            this.btn_NewGame.Location = new System.Drawing.Point(12, 301);
            this.btn_NewGame.Name = "btn_NewGame";
            this.btn_NewGame.Size = new System.Drawing.Size(92, 23);
            this.btn_NewGame.TabIndex = 0;
            this.btn_NewGame.Text = "New Game";
            this.btn_NewGame.UseVisualStyleBackColor = true;
            this.btn_NewGame.Click += new System.EventHandler(this.btn_NewGame_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(357, 301);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(92, 23);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Solve
            // 
            this.btn_Solve.Location = new System.Drawing.Point(242, 301);
            this.btn_Solve.Name = "btn_Solve";
            this.btn_Solve.Size = new System.Drawing.Size(92, 23);
            this.btn_Solve.TabIndex = 1;
            this.btn_Solve.Text = "Solve Game";
            this.btn_Solve.UseVisualStyleBackColor = true;
            this.btn_Solve.Click += new System.EventHandler(this.btn_Solve_Click);
            // 
            // btn_FillFromClipboard
            // 
            this.btn_FillFromClipboard.Location = new System.Drawing.Point(127, 301);
            this.btn_FillFromClipboard.Name = "btn_FillFromClipboard";
            this.btn_FillFromClipboard.Size = new System.Drawing.Size(92, 23);
            this.btn_FillFromClipboard.TabIndex = 1;
            this.btn_FillFromClipboard.Text = "Fill By Clipboard";
            this.tip_Clipboard.SetToolTip(this.btn_FillFromClipboard, "You must have 9 row that seperated by new line and each row must be comma seperat" +
        "ed.\r\nIn finally you must have 9 row with 9 number.\r\nPoint: Empty cells can be 0 " +
        "or empty.");
            this.btn_FillFromClipboard.UseVisualStyleBackColor = true;
            this.btn_FillFromClipboard.Click += new System.EventHandler(this.btn_FillFromClipboard_Click);
            // 
            // tip_Clipboard
            // 
            this.tip_Clipboard.AutoPopDelay = 10000;
            this.tip_Clipboard.InitialDelay = 200;
            this.tip_Clipboard.ReshowDelay = 100;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 295);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_Solve;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(476, 329);
            this.Controls.Add(this.btn_FillFromClipboard);
            this.Controls.Add(this.btn_Solve);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_NewGame);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.Name = "Form1";
            this.Text = "SudokuSolver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_NewGame;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Solve;
        private System.Windows.Forms.Button btn_FillFromClipboard;
        private System.Windows.Forms.ToolTip tip_Clipboard;
        private System.Windows.Forms.Panel panel1;
    }
}

