
namespace HangMan
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
            this.StartGame = new System.Windows.Forms.Button();
            this.StopGame = new System.Windows.Forms.Button();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.ScoreBoard = new System.Windows.Forms.ListBox();
            this.IncorrectGuesses = new System.Windows.Forms.ListBox();
            this.WordwithUnderscoreorAst = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(143, 469);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(107, 37);
            this.StartGame.TabIndex = 0;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // StopGame
            // 
            this.StopGame.Location = new System.Drawing.Point(480, 469);
            this.StopGame.Name = "StopGame";
            this.StopGame.Size = new System.Drawing.Size(107, 37);
            this.StopGame.TabIndex = 1;
            this.StopGame.Text = "Close Game";
            this.StopGame.UseVisualStyleBackColor = true;
            this.StopGame.Click += new System.EventHandler(this.StopGame_Click);
            // 
            // UserInput
            // 
            this.UserInput.Location = new System.Drawing.Point(143, 298);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(100, 20);
            this.UserInput.TabIndex = 2;
            this.UserInput.TextChanged += new System.EventHandler(this.UserInput_TextChanged);
            // 
            // ScoreBoard
            // 
            this.ScoreBoard.FormattingEnabled = true;
            this.ScoreBoard.Location = new System.Drawing.Point(143, 95);
            this.ScoreBoard.Name = "ScoreBoard";
            this.ScoreBoard.Size = new System.Drawing.Size(120, 95);
            this.ScoreBoard.TabIndex = 3;
            this.ScoreBoard.SelectedIndexChanged += new System.EventHandler(this.ScoreBoard_SelectedIndexChanged);
            // 
            // IncorrectGuesses
            // 
            this.IncorrectGuesses.FormattingEnabled = true;
            this.IncorrectGuesses.Location = new System.Drawing.Point(480, 95);
            this.IncorrectGuesses.Name = "IncorrectGuesses";
            this.IncorrectGuesses.Size = new System.Drawing.Size(120, 95);
            this.IncorrectGuesses.TabIndex = 4;
            this.IncorrectGuesses.SelectedIndexChanged += new System.EventHandler(this.IncorrectGuesses_SelectedIndexChanged);
            // 
            // WordwithUnderscoreorAst
            // 
            this.WordwithUnderscoreorAst.AutoSize = true;
            this.WordwithUnderscoreorAst.Location = new System.Drawing.Point(487, 305);
            this.WordwithUnderscoreorAst.Name = "WordwithUnderscoreorAst";
            this.WordwithUnderscoreorAst.Size = new System.Drawing.Size(52, 13);
            this.WordwithUnderscoreorAst.TabIndex = 5;
            this.WordwithUnderscoreorAst.Text = "DISPLAY";
            this.WordwithUnderscoreorAst.Click += new System.EventHandler(this.WordwithUnderscoreorAst_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(108, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(594, 77);
            this.button1.TabIndex = 6;
            this.button1.Text = "HANGMAN";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(866, 589);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WordwithUnderscoreorAst);
            this.Controls.Add(this.IncorrectGuesses);
            this.Controls.Add(this.ScoreBoard);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.StopGame);
            this.Controls.Add(this.StartGame);
            this.Name = "Form1";
            this.Text = "HangMan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button StopGame;
        private System.Windows.Forms.TextBox UserInput;
        private System.Windows.Forms.ListBox ScoreBoard;
        private System.Windows.Forms.ListBox IncorrectGuesses;
        private System.Windows.Forms.Label WordwithUnderscoreorAst;
        private System.Windows.Forms.Button button1;
    }
}

