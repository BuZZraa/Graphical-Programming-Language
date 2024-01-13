namespace Graphical_Programming_Language
{
    partial class Form_SPL
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
            this.textBox_MultiCmd = new System.Windows.Forms.TextBox();
            this.pnl_Paint = new System.Windows.Forms.Panel();
            this.textBox_SingleCmd = new System.Windows.Forms.TextBox();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_Syntax = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_PenColour = new System.Windows.Forms.Button();
            this.btn_CanvasColour = new System.Windows.Forms.Button();
            this.penSizes = new System.Windows.Forms.ComboBox();
            this.currentPosition = new System.Windows.Forms.Label();
            this.xAxis = new System.Windows.Forms.Label();
            this.yAxis = new System.Windows.Forms.Label();
            this.xValue = new System.Windows.Forms.NumericUpDown();
            this.yValue = new System.Windows.Forms.NumericUpDown();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_MultiCmd
            // 
            this.textBox_MultiCmd.Location = new System.Drawing.Point(27, 30);
            this.textBox_MultiCmd.Multiline = true;
            this.textBox_MultiCmd.Name = "textBox_MultiCmd";
            this.textBox_MultiCmd.Size = new System.Drawing.Size(451, 356);
            this.textBox_MultiCmd.TabIndex = 0;
            // 
            // pnl_Paint
            // 
            this.pnl_Paint.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_Paint.Location = new System.Drawing.Point(503, 30);
            this.pnl_Paint.Name = "pnl_Paint";
            this.pnl_Paint.Size = new System.Drawing.Size(451, 356);
            this.pnl_Paint.TabIndex = 1;
            this.pnl_Paint.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_Paint_Paint);
            // 
            // textBox_SingleCmd
            // 
            this.textBox_SingleCmd.Location = new System.Drawing.Point(27, 407);
            this.textBox_SingleCmd.Name = "textBox_SingleCmd";
            this.textBox_SingleCmd.Size = new System.Drawing.Size(451, 20);
            this.textBox_SingleCmd.TabIndex = 2;
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(27, 433);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(61, 23);
            this.btn_Run.TabIndex = 3;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // btn_Syntax
            // 
            this.btn_Syntax.Location = new System.Drawing.Point(104, 433);
            this.btn_Syntax.Name = "btn_Syntax";
            this.btn_Syntax.Size = new System.Drawing.Size(75, 23);
            this.btn_Syntax.TabIndex = 4;
            this.btn_Syntax.Text = "Syntax";
            this.btn_Syntax.UseVisualStyleBackColor = true;
            this.btn_Syntax.Click += new System.EventHandler(this.Btn_Syntax_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.duplicateProgramToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // duplicateProgramToolStripMenuItem
            // 
            this.duplicateProgramToolStripMenuItem.Name = "duplicateProgramToolStripMenuItem";
            this.duplicateProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.duplicateProgramToolStripMenuItem.Text = "Duplicate Program";
            this.duplicateProgramToolStripMenuItem.Click += new System.EventHandler(this.DuplicateProgramToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // btn_PenColour
            // 
            this.btn_PenColour.Location = new System.Drawing.Point(621, 402);
            this.btn_PenColour.Name = "btn_PenColour";
            this.btn_PenColour.Size = new System.Drawing.Size(75, 23);
            this.btn_PenColour.TabIndex = 7;
            this.btn_PenColour.Text = "Pen Colour";
            this.btn_PenColour.UseVisualStyleBackColor = true;
            this.btn_PenColour.Click += new System.EventHandler(this.Btn_PenColour_Click);
            // 
            // btn_CanvasColour
            // 
            this.btn_CanvasColour.Location = new System.Drawing.Point(715, 402);
            this.btn_CanvasColour.Name = "btn_CanvasColour";
            this.btn_CanvasColour.Size = new System.Drawing.Size(88, 23);
            this.btn_CanvasColour.TabIndex = 8;
            this.btn_CanvasColour.Text = "Canvas Colour";
            this.btn_CanvasColour.UseVisualStyleBackColor = true;
            this.btn_CanvasColour.Click += new System.EventHandler(this.Btn_CanvasColour_Click);
            // 
            // penSizes
            // 
            this.penSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.penSizes.FormattingEnabled = true;
            this.penSizes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.penSizes.Location = new System.Drawing.Point(820, 402);
            this.penSizes.Name = "penSizes";
            this.penSizes.Size = new System.Drawing.Size(69, 21);
            this.penSizes.TabIndex = 9;
            // 
            // currentPosition
            // 
            this.currentPosition.AutoSize = true;
            this.currentPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPosition.Location = new System.Drawing.Point(500, 402);
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.Size = new System.Drawing.Size(100, 16);
            this.currentPosition.TabIndex = 10;
            this.currentPosition.Text = "Current Position";
            // 
            // xAxis
            // 
            this.xAxis.AutoSize = true;
            this.xAxis.Location = new System.Drawing.Point(501, 420);
            this.xAxis.Name = "xAxis";
            this.xAxis.Size = new System.Drawing.Size(36, 13);
            this.xAxis.TabIndex = 13;
            this.xAxis.Text = "X-Axis";
            // 
            // yAxis
            // 
            this.yAxis.AutoSize = true;
            this.yAxis.Location = new System.Drawing.Point(550, 420);
            this.yAxis.Name = "yAxis";
            this.yAxis.Size = new System.Drawing.Size(36, 13);
            this.yAxis.TabIndex = 14;
            this.yAxis.Text = "Y-Axis";
            // 
            // xValue
            // 
            this.xValue.Location = new System.Drawing.Point(503, 436);
            this.xValue.Maximum = new decimal(new int[] {
            451,
            0,
            0,
            0});
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(40, 20);
            this.xValue.TabIndex = 15;
            this.xValue.ValueChanged += new System.EventHandler(this.XValue_ValueChanged);
            // 
            // yValue
            // 
            this.yValue.Location = new System.Drawing.Point(553, 436);
            this.yValue.Maximum = new decimal(new int[] {
            356,
            0,
            0,
            0});
            this.yValue.Name = "yValue";
            this.yValue.Size = new System.Drawing.Size(40, 20);
            this.yValue.TabIndex = 16;
            this.yValue.ValueChanged += new System.EventHandler(this.YValue_ValueChanged);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Form_SPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 468);
            this.Controls.Add(this.yValue);
            this.Controls.Add(this.xValue);
            this.Controls.Add(this.yAxis);
            this.Controls.Add(this.xAxis);
            this.Controls.Add(this.currentPosition);
            this.Controls.Add(this.penSizes);
            this.Controls.Add(this.btn_CanvasColour);
            this.Controls.Add(this.btn_PenColour);
            this.Controls.Add(this.btn_Syntax);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.textBox_SingleCmd);
            this.Controls.Add(this.pnl_Paint);
            this.Controls.Add(this.textBox_MultiCmd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_SPL";
            this.Text = "Simple Programming Language";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_SPL_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_MultiCmd;
        private System.Windows.Forms.Panel pnl_Paint;
        private System.Windows.Forms.TextBox textBox_SingleCmd;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_Syntax;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateProgramToolStripMenuItem;
        private System.Windows.Forms.Button btn_PenColour;
        private System.Windows.Forms.Button btn_CanvasColour;
        private System.Windows.Forms.ComboBox penSizes;
        private System.Windows.Forms.Label currentPosition;
        private System.Windows.Forms.Label xAxis;
        private System.Windows.Forms.Label yAxis;
        private System.Windows.Forms.NumericUpDown xValue;
        private System.Windows.Forms.NumericUpDown yValue;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

