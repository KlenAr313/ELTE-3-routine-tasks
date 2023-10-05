namespace ShitShow
{
    partial class ShitShowDialog
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileDialogToolStripMenuItem = new ToolStripMenuItem();
            calculateStatisticToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            ListBox = new ListBox();
            CharacterCount = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileDialogToolStripMenuItem, calculateStatisticToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openFileDialogToolStripMenuItem
            // 
            openFileDialogToolStripMenuItem.Name = "openFileDialogToolStripMenuItem";
            openFileDialogToolStripMenuItem.Size = new Size(164, 22);
            openFileDialogToolStripMenuItem.Text = "OpenFileDialog";
            // 
            // calculateStatisticToolStripMenuItem
            // 
            calculateStatisticToolStripMenuItem.Name = "calculateStatisticToolStripMenuItem";
            calculateStatisticToolStripMenuItem.Size = new Size(164, 22);
            calculateStatisticToolStripMenuItem.Text = "CalculateStatistic";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 24);
            textBox1.Name = "Texbox";
            textBox1.Size = new Size(178, 23);
            textBox1.TabIndex = 1;
            // 
            // ListBox
            // 
            ListBox.FormattingEnabled = true;
            ListBox.ItemHeight = 15;
            ListBox.Location = new Point(390, 27);
            ListBox.Name = "ListBox";
            ListBox.Size = new Size(120, 94);
            ListBox.TabIndex = 2;
            // 
            // CharacterCount
            // 
            CharacterCount.AutoSize = true;
            CharacterCount.Location = new Point(76, 210);
            CharacterCount.Name = "CharacterCount";
            CharacterCount.Size = new Size(38, 15);
            CharacterCount.TabIndex = 3;
            CharacterCount.Text = "CharacterCount";
            // 
            // ShitShowDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CharacterCount);
            Controls.Add(ListBox);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ShitShowDialog";
            Text = "ShitShowDialog";
            Load += ShitShowDialog_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileDialogToolStripMenuItem;
        private ToolStripMenuItem calculateStatisticToolStripMenuItem;
        private TextBox textBox1;
        private ListBox ListBox;
        private Label CharacterCount;
    }
}