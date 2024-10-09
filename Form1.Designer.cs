
namespace LewisSudokuProjectv2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckInput = new System.Windows.Forms.Button();
            this.ClearInput = new System.Windows.Forms.Button();
            this.NewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 426);
            this.panel1.TabIndex = 0;
            // 
            // CheckInput
            // 
            this.CheckInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CheckInput.Location = new System.Drawing.Point(824, 61);
            this.CheckInput.Name = "CheckInput";
            this.CheckInput.Size = new System.Drawing.Size(161, 94);
            this.CheckInput.TabIndex = 1;
            this.CheckInput.Text = "CheckInput";
            this.CheckInput.UseVisualStyleBackColor = false;
            this.CheckInput.Click += new System.EventHandler(this.CheckInput_Click);
            // 
            // ClearInput
            // 
            this.ClearInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClearInput.Location = new System.Drawing.Point(824, 186);
            this.ClearInput.Name = "ClearInput";
            this.ClearInput.Size = new System.Drawing.Size(161, 89);
            this.ClearInput.TabIndex = 2;
            this.ClearInput.Text = "ClearInput";
            this.ClearInput.UseVisualStyleBackColor = false;
            this.ClearInput.Click += new System.EventHandler(this.ClearInput_Click);
            // 
            // NewGame
            // 
            this.NewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NewGame.Location = new System.Drawing.Point(824, 381);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(161, 29);
            this.NewGame.TabIndex = 3;
            this.NewGame.Text = "New Game";
            this.NewGame.UseVisualStyleBackColor = false;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1077, 450);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.ClearInput);
            this.Controls.Add(this.CheckInput);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CheckInput;
        private System.Windows.Forms.Button ClearInput;
        private System.Windows.Forms.Button NewGame;
    }
}

