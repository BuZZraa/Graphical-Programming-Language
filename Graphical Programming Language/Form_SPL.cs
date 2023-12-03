using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            syntaxChecked = true;
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {        
            if (syntaxChecked == true)
            {
                syntaxChecked = false;
            }

            else
            {
                MessageBox.Show("Please verify the syntax before running the code.", "Error");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
