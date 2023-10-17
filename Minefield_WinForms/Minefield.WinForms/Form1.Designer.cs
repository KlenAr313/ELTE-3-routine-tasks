namespace Minefield.WinForms
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
            menuStrip = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuFileNewGame = new ToolStripMenuItem();
            menuFileLoadGame = new ToolStripMenuItem();
            menuFileSaveGame = new ToolStripMenuItem();
            menuFileExit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuFile });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuFileNewGame, toolStripSeparator1, menuFileLoadGame, menuFileSaveGame, toolStripSeparator2, menuFileExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(37, 20);
            menuFile.Text = "File";
            // 
            // menuFileNewGame
            // 
            menuFileNewGame.Name = "menuFileNewGame";
            menuFileNewGame.Size = new Size(180, 22);
            menuFileNewGame.Text = "New Game";
            // 
            // menuFileLoadGame
            // 
            menuFileLoadGame.Name = "menuFileLoadGame";
            menuFileLoadGame.Size = new Size(180, 22);
            menuFileLoadGame.Text = "Load Game";
            // 
            // menuFileSaveGame
            // 
            menuFileSaveGame.Name = "menuFileSaveGame";
            menuFileSaveGame.Size = new Size(180, 22);
            menuFileSaveGame.Text = "Save game";
            menuFileSaveGame.Enabled = false;
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            menuFileExit.Size = new Size(180, 22);
            menuFileExit.Text = "Exit";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Form1";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuFileNewGame;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuFileLoadGame;
        private ToolStripMenuItem menuFileSaveGame;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem menuFileExit;
    }
}