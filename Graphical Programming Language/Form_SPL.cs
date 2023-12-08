using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                MessageBox.Show(err1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            try
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
                    throw new Exception ("Please check syntax before running the file.");
                }
            }

            catch(Exception err2)
            {
                MessageBox.Show(err2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("commands.txt", textBox_MultiCmd.Text);
                MessageBox.Show("Commands saved to commands.txt.", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception err3)
            {
                MessageBox.Show("An error occured: " + err3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string commandsFile = File.ReadAllText("commands.txt");
                textBox_MultiCmd.Text = commandsFile;
                MessageBox.Show("Commands loaded from commands.txt.", "File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception err4)
            {
                MessageBox.Show("An error occured: " + err4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By : Prashant Muni Bajracharya \n " +
                "© All Rights Reserved.", "About", MessageBoxButtons.OK);
        }
    }
}
