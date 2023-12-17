namespace fakeTetris
{
    partial class fakeTetris
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
            NextGrid = new TableLayoutPanel();
            label1 = new Label();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(450, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // NextGrid
            // 
            NextGrid.ColumnCount = 2;
            NextGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            NextGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            NextGrid.Location = new Point(578, 162);
            NextGrid.Name = "NextGrid";
            NextGrid.RowCount = 2;
            NextGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            NextGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            NextGrid.Size = new Size(150, 150);
            NextGrid.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(575, 380);
            label1.Name = "label1";
            label1.Size = new Size(114, 30);
            label1.TabIndex = 2;
            label1.Text = "Ain't good";
            label1.Visible = false;
            // 
            // fakeTetris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 489);
            Controls.Add(label1);
            Controls.Add(NextGrid);
            Controls.Add(tableLayoutPanel1);
            Name = "fakeTetris";
            Text = "fakeTetris";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel NextGrid;
        private Label label1;
    }
}
