namespace Minefield.WinForms
{
    partial class MinefieldForm
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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            mni_NewGame = new ToolStripMenuItem();
            mni_LoadGame = new ToolStripMenuItem();
            mni_SaveGame = new ToolStripMenuItem();
            mni_Exit = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            strpLbl_GameTimeLbl = new ToolStripStatusLabel();
            lbl_GameTime = new ToolStripStatusLabel();
            tmr_GameTime = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { mni_NewGame, mni_LoadGame, mni_SaveGame, mni_Exit });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // mni_NewGame
            // 
            mni_NewGame.Name = "mni_NewGame";
            mni_NewGame.Size = new Size(77, 20);
            mni_NewGame.Text = "New Game";
            mni_NewGame.Click += mni_NewGame_Click;
            // 
            // mni_LoadGame
            // 
            mni_LoadGame.Name = "mni_LoadGame";
            mni_LoadGame.Size = new Size(79, 20);
            mni_LoadGame.Text = "Load Game";
            mni_LoadGame.Click += mni_LoadGame_Click;
            // 
            // mni_SaveGame
            // 
            mni_SaveGame.Enabled = false;
            mni_SaveGame.Name = "mni_SaveGame";
            mni_SaveGame.Size = new Size(77, 20);
            mni_SaveGame.Text = "Save Game";
            mni_SaveGame.Click += mni_SaveGame_Click;
            // 
            // mni_Exit
            // 
            mni_Exit.Name = "mni_Exit";
            mni_Exit.Size = new Size(38, 20);
            mni_Exit.Text = "Exit";
            mni_Exit.Click += mni_Exit_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { strpLbl_GameTimeLbl, lbl_GameTime });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // strpLbl_GameTimeLbl
            // 
            strpLbl_GameTimeLbl.Name = "strpLbl_GameTimeLbl";
            strpLbl_GameTimeLbl.Size = new Size(73, 17);
            strpLbl_GameTimeLbl.Text = "Game Time: ";
            // 
            // lbl_GameTime
            // 
            lbl_GameTime.Name = "lbl_GameTime";
            lbl_GameTime.Size = new Size(43, 17);
            lbl_GameTime.Text = "0:00:00";
            // 
            // tmr_GameTime
            // 
            tmr_GameTime.Enabled = false;
            tmr_GameTime.Interval = 1000;
            tmr_GameTime.Tick += tmr_GameTime_Tick;
            // 
            // MinefieldForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MinefieldForm";
            Text = "Minefield 2023 Ultimate";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel strpLbl_GameTimeLbl;
        private ToolStripStatusLabel lbl_GameTime;
        private ToolStripMenuItem mni_NewGame;
        private ToolStripMenuItem mni_LoadGame;
        private ToolStripMenuItem mni_SaveGame;
        private ToolStripMenuItem mni_Exit;
        private System.Windows.Forms.Timer tmr_GameTime;
    }
}