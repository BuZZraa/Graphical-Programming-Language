using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Form_SPL class to represent the Graphical Programming Language UI and its features.
    /// </summary>
    public partial class Form_SPL : Form
    {
        /// <summary>
        /// Class variable for a Graphics object on which the drawing is done.
        /// </summary>
        private Graphics g;

        /// <summary>
        /// Instance of the CommandParser class created to pass the commands provided in textbox of the form.
        /// Instance of DisplayMessageBox as a argument to CommandParser constructor for creating MessageBox for error messages.
        /// </summary>
        private CommandParser command;

        /// <summary>
        /// List to store all the drawn shapes and persist it in the panel.
        /// </summary>
        private List<Shape> Shapes;

        /// <summary>
        /// Array to store multiple commands provided by the user.
        /// </summary>
        private string[] multiCommands;

        /// <summary>
        /// Variable to set the flag of syntax button being clicked.
        /// </summary>
        private Boolean syntaxChecked;

        /// <summary>
        /// Empty Constructor to initialize on instance of the Form_SPL class.
        /// Creates graphic object of drawing on the panel and sets the syntaxChecked to false each time the class is initialized.
        /// </summary>
        public Form_SPL()
        {
            InitializeComponent();
            g = pnl_Paint.CreateGraphics();
            syntaxChecked = false;
            command = new CommandParser(new DisplayMessageBox());
        }


        /// <summary>
        /// Panel paint event listener to draw and persist the drawing in the panel.
        /// </summary>
        /// <param name="sender">The object that triggered the event of syntax button being clicked.</param>
        /// <param name="e">The arguments of the syntax button click event.</param>
        private void Pnl_Paint_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(SystemColors.ActiveBorder);

            Shapes = command.GetShapes();
            for (int i =0; i < Shapes.Count; i++)
            {
                Shapes[i].Draw(g);
            }
        }

        /// <summary>
        /// Method to split the string command and return it in an array.
        /// </summary>
        /// <param name="command">The command in string.</param>
        /// <returns>Splits the string and returns it in an array.</returns>
        private string[] SplitCommand(string command)
        {
            return command.ToLower().Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Syntax button click event handler to check the event of syntax button being clicked.
        /// When button is clicked it checks which textbox has input and according to it validates the command name and parameters.
        /// Calls ValidateCommandName() and ValidateParameters() from CommandParser to validate the command name and parameters once the button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of syntax button being clicked.</param>
        /// <param name="e">The arguments of the syntax button click event.</param>
        private void Btn_Syntax_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length == 0)
                {
                    command.Command = SplitCommand(textBox_SingleCmd.Text);
                    command.ValidateCommandName();
                    command.ValidateParameters();
                    syntaxChecked = true;
                }

                else if (textBox_SingleCmd.Text.Length == 0 && textBox_MultiCmd.Text.Length != 0)
                {
                    throw new Exception("Please enter run to run multi-line commands.");
                }

                else if(textBox_SingleCmd.Text.Length == 0 && textBox_MultiCmd.Text.Length == 0)
                {
                    throw new Exception("Please enter a command.");
                }

                else if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length != 0)
                {
                    if (textBox_SingleCmd.Text.ToLower().Equals("run"))
                    {
                        multiCommands = textBox_MultiCmd.Text.ToLower().Trim().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < multiCommands.Length; i++)
                        {
                            command.Command = SplitCommand(multiCommands[i]);
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

        /// <summary>
        /// Run button click event handler to run the commands when the run button is clicked. 
        /// Run button event handler only runs the command if the syntax button is clicked and also
        /// if the command name and parameters are valid. 
        /// Run button works if command is written in single or multi-line textbox. 
        /// </summary>
        /// <param name="sender">The object that triggered the event of run button being clicked.</param>
        /// <param name="e">The arguments of the run button click event.</param>
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
                                command.Command = multiCommands[i].ToLower().Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
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

        /// <summary>
        /// Event handler for the event of exit menu option being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of exit menu option being clicked.</param>
        /// <param name="e">The arguments of the exit menu option click event.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Event handler for the event of new menu option being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of new menu option being clicked.</param>
        /// <param name="e">The arguments of the new menu option click event.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.ActiveBorder);
            Shapes.Clear();
        }

        /// <summary>
        /// Event handler for the event of save menu option being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of save menu option being clicked.</param>
        /// <param name="e">The arguments of the save menu option click event.</param>
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

        /// <summary>
        /// Event handler for the event of load menu option being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of load menu option being clicked.</param>
        /// <param name="e">The arguments of the load menu option click event.</param>
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

        /// <summary>
        /// Event handler for the event of about menu option being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of about menu option being clicked.</param>
        /// <param name="e">The arguments of the about menu option click event.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By : Prashant Muni Bajracharya \n " +
                "© All Rights Reserved.", "About", MessageBoxButtons.OK);
        }    
    }
}