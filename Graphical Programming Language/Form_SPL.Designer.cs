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
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.helpToolStripMenuItem});
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
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            // 
            // Form_SPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 468);
            this.Controls.Add(this.btn_Syntax);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.textBox_SingleCmd);
            this.Controls.Add(this.pnl_Paint);
            this.Controls.Add(this.textBox_MultiCmd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_SPL";
            this.Text = "Simple Programming Language";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

