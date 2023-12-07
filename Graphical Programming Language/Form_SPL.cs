﻿using System;
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
        private string[] multiCommands;
        private Boolean syntaxChecked;

        public Form_SPL()
        {
            InitializeComponent();
            g = pnl_Paint.CreateGraphics();
            syntaxChecked = false;
        }

        private void Btn_Syntax_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length == 0)
                {
                    command.Command = textBox_SingleCmd.Text.ToLower().Trim().Split();
                    command.ValidateCommandName();
                    command.ValidateParameters();
                    syntaxChecked = true;
                }

                else if (textBox_SingleCmd.Text.Length == 0 && textBox_MultiCmd.Text.Length != 0)
                {
                    throw new Exception("Please enter run to run multi-line commands.");
                }

                else if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length != 0)
                {
                    if (textBox_SingleCmd.Text.ToLower().Equals("run"))
                    {
                        multiCommands = textBox_MultiCmd.Text.ToLower().Trim().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < multiCommands.Length; i++)
                        {
                            command.Command = multiCommands[i].Trim().Split();
                            command.ValidateCommandName();
                            command.ValidateParameters();
                            syntaxChecked = true;
                        }
                    }

                    else
                    {
                        throw new Exception("Please enter run in single line command box to run multi-line commands.");
                    }
                }
            }

            catch (Exception err1)
            {
                MessageBox.Show(err1.Message, "Error");
            }
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            if (syntaxChecked == true)
            {
                if (command.IsValidCommand && command.IsValidParameters)
                {
                    if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length != 0)
                    {
                        for (int i = 0; i < multiCommands.Length; i++)
                        {
                            command.Command = multiCommands[i].Trim().Split();
                            command.ValidateCommandName();
                            command.ValidateParameters();
                            command.RunCommand(g);
                        }
                    }

                    else
                    {
                        command.RunCommand(g);
                    }

                }
                syntaxChecked = false;
            }

            else
            {
                MessageBox.Show("Syntax not checked.");
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.ActiveBorder);
        }
    }
}
