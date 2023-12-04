using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphical_Programming_Language
{
    public partial class Form_SPL : Form
    {
        Graphics g;
        private Boolean syntaxChecked;
        public Form_SPL()
        {
            InitializeComponent();
            g = pnl_Paint.CreateGraphics();
            syntaxChecked = false;
        }

        private void Btn_Syntax_Click(object sender, EventArgs e)
        {
            Command_Parser syntaxCommand = new Command_Parser(textBox_SingleCmd.Text.ToLower());
            syntaxCommand.ProcessCommand();
            syntaxCommand.ValidateCommand();
            syntaxChecked = true;
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {        
            if (syntaxChecked == true)
            {
                Command_Parser runCommand = new Command_Parser(textBox_SingleCmd.Text.ToLower());
                runCommand.ProcessCommand();
                runCommand.ValidateCommand();
                runCommand.RunCommand(g);
                syntaxChecked = false;
            }

            else
            {
                MessageBox.Show("Please verify the syntax before running the code.", "Error");
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
