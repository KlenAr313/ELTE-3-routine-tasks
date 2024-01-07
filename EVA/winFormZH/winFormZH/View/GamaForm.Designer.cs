namespace winFormZH
{
    partial class GamaForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            btnLoadGame = new Button();
            btnSaveGame = new Button();
            btnNewGame = new Button();
            numericColumns = new NumericUpDown();
            label2 = new Label();
            numericRows = new NumericUpDown();
            label1 = new Label();
            tableLayoutGrid = new TableLayoutPanel();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericRows).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutGrid, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoadGame);
            groupBox1.Controls.Add(btnSaveGame);
            groupBox1.Controls.Add(btnNewGame);
            groupBox1.Controls.Add(numericColumns);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericRows);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(770, 52);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Size";
            // 
            // btnLoadGame
            // 
            btnLoadGame.Location = new Point(568, 22);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(75, 23);
            btnLoadGame.TabIndex = 6;
            btnLoadGame.Text = "Load Game";
            btnLoadGame.UseVisualStyleBackColor = true;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // btnSaveGame
            // 
            btnSaveGame.Location = new Point(468, 22);
            btnSaveGame.Name = "btnSaveGame";
            btnSaveGame.Size = new Size(75, 23);
            btnSaveGame.TabIndex = 5;
            btnSaveGame.Text = "Save Game";
            btnSaveGame.UseVisualStyleBackColor = true;
            btnSaveGame.Click += btnSaveGame_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(366, 22);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(75, 23);
            btnNewGame.TabIndex = 4;
            btnNewGame.Text = "NewGame";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // numericColumns
            // 
            numericColumns.Location = new Point(239, 24);
            numericColumns.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericColumns.Name = "numericColumns";
            numericColumns.Size = new Size(70, 23);
            numericColumns.TabIndex = 3;
            numericColumns.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 26);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Columns:";
            // 
            // numericRows
            // 
            numericRows.Location = new Point(59, 24);
            numericRows.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericRows.Name = "numericRows";
            numericRows.Size = new Size(70, 23);
            numericRows.TabIndex = 1;
            numericRows.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 26);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Rows:";
            // 
            // tableLayoutGrid
            // 
            tableLayoutGrid.ColumnCount = 2;
            tableLayoutGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutGrid.Dock = DockStyle.Fill;
            tableLayoutGrid.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutGrid.Location = new Point(4, 61);
            tableLayoutGrid.Margin = new Padding(4, 3, 4, 3);
            tableLayoutGrid.Name = "tableLayoutGrid";
            tableLayoutGrid.RowCount = 2;
            tableLayoutGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutGrid.Size = new Size(792, 389);
            tableLayoutGrid.TabIndex = 1;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Game (*.json)|*.json";
            openFileDialog.Title = "Load Game";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Game (*.json)|*.json";
            // 
            // GamaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "GamaForm";
            Text = "GameForm";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericRows).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label label1;
        private NumericUpDown numericRows;
        private NumericUpDown numericColumns;
        private Label label2;
        private Button btnNewGame;
        private Button btnSaveGame;
        private Button btnLoadGame;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private TableLayoutPanel tableLayoutGrid;
    }
}
