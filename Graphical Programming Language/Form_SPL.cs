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
        Command_Parser command = new Command_Parser();
        private Boolean syntaxChecked;

        public Form_SPL()
        {
            InitializeComponent();
            g = pnl_Paint.CreateGraphics();
            syntaxChecked = false;
        }

        private void Btn_Syntax_Click(object sender, EventArgs e)
        {
            command.Command = textBox_SingleCmd.Text.ToLower().Trim().Split();
            command.ValidateCommandName();
            command.ValidateParameters();
            syntaxChecked = true;
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {   
            try
            {
                if (syntaxChecked == true)
                {
                    if (command.IsValidCommand && command.IsValidParameters)
                    {
                        command.RunCommand(g);
                    }
                    syntaxChecked = false;
                }

                else
                {
                    throw new Exception("Please verify the syntax before running the code.");
                }
            }
         

            catch(Exception err) 
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.ActiveBorder);
        }
    }
}
