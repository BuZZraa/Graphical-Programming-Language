using Graphical_Programming_Language.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace Graphical_Programming_Language
{

    /// <summary>
    /// Form_SPL class to represent the Graphical Programming Language UI and its features.
    /// </summary>
    public partial class Form_SPL : Form
    {
        /// <summary>
        /// Delegate to define a method to update the drawing from child thread to main thread. 
        /// </summary>
        /// <param name="shape"></param>
        public delegate void UpdateDrawingDelegate(Shape shape);

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
        /// Instance of ColorDialog class to create a color dialogue box and store the pen color value.
        /// </summary>
        private ColorDialog penColour;

        /// <summary>
        /// Instance of ColorDialog class to create a color dialogue box and store the canvas color value.
        /// </summary>
        private ColorDialog canvasColour;

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
        /// Instance of Form_SPL or main form class for child thread.
        /// </summary>
        private Form_SPL Form_SPL_Form2;

        /// <summary>
        /// Static variable to store the number of forms created by child thread.
        /// </summary>
        private static int formCount = 1;

        /// <summary>
        /// Static variable which stores an object used for thread safe access to a single form.
        /// </summary>
        private static readonly object formMonitor = new object();

        /// <summary>
        /// List to store the commands inside if command block.
        /// </summary>
        private List<string> ifConditionTrueCommands = new List<string>();

        /// <summary>
        /// Array to store the commands to be run inside if command block.
        /// </summary>
        private string[] runIfConditionTrueCommand;

        /// <summary>
        /// List to store the commands inside while command block.
        /// </summary>
        private List<string> whileConditionTrueCommands = new List<string>();

        /// <summary>
        /// Array to store the commands to be run inside while command block.
        /// </summary>
        private string[] runWhileConditionTrueCommand;

        /// <summary>
        /// List to store the commands inside method command block.
        /// </summary>
        private List<string> methodCommands= new List<string>();

        /// <summary>
        /// Array to store the commands to be run inside while command block.
        /// </summary>
        private string[] runMethodCommands;

        /// <summary>
        /// Empty Constructor to initialize on instance of the Form_SPL class.
        /// Creates graphic object of drawing on the panel and sets the syntaxChecked to false each time the class is initialized.
        /// </summary>
        public Form_SPL()
        {
            InitializeComponent();
            g = pnl_Paint.CreateGraphics();
            syntaxChecked = false;
            command = new CommandParser(new DisplayMessageBox(), this);
            canvasColour = new ColorDialog();
            canvasColour.Color = SystemColors.ActiveBorder;
            penSizes.SelectedItem = "1";
            xValue.Text = Convert.ToString(command.XPos);
            yValue.Text = Convert.ToString(command.YPos);
            btn_PenColour.BackColor = Color.Black;
        }

        /// <summary>
        /// Panel paint event listener to draw and persist the drawing in the panel.
        /// </summary>
        /// <param name="sender">The object that triggered the event of syntax button being clicked.</param>
        /// <param name="e">The arguments of the syntax button click event.</param>
        private void Pnl_Paint_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(canvasColour.Color);

            Shapes = command.GetShapes();
            for (int i = 0; i < Shapes.Count; i++)
            {
                Shapes[i].Draw(g);
            }
        }

        /// <summary>
        /// Method to split the string command and return it in an array.
        /// </summary>
        /// <param name="command">The command in string.</param>
        /// <returns>Splits the string and returns it in an array.</returns>
        public string[] SplitCommand(string command)
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
                    command.IsMultiLine = false;
                    command.Is_A_Variable();
                    command.Is_Method_Called();
                    command.ValidateCommandName();
                    command.ValidateParameters();
                    syntaxChecked = true;
                }

                else if (textBox_SingleCmd.Text.Length == 0 && textBox_MultiCmd.Text.Length != 0)
                {
                    throw new MissingRunException("Please enter run in single line command box to run multi-line commands.");
                }

                else if (textBox_SingleCmd.Text.Length == 0 && textBox_MultiCmd.Text.Length == 0)
                {
                    throw new EmptyCommandsException("Please enter a command.");
                }

                else if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length != 0)
                {
                    if (textBox_SingleCmd.Text.ToLower().Equals("run"))
                    {
                        multiCommands = textBox_MultiCmd.Text.ToLower().Trim().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < multiCommands.Length; i++)
                        {
                            command.Command = SplitCommand(multiCommands[i]);
                            command.IsMultiLine = true;
                            command.Is_A_Variable();
                            command.Is_A_If_Statement();
                            command.Is_A_EndIf_Statement();
                            command.Is_A_While_Loop();
                            command.Is_A_End_Loop();
                            command.Is_A_Method();
                            command.Is_A_End_Method();
                            command.Is_Method_Called();
                            command.ValidateCommandName();
                            command.ValidateParameters();
                        }
                        syntaxChecked = true;
                    }

                    else
                    {
                        throw new MissingRunException("Please enter run in single line command box to run multi-line commands.");
                    }
                }
            }

            catch (Exception error1)
            {
                MessageBox.Show(error1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Boolean isIfTrue = false;
                Boolean isWhileTrue = false;
                Boolean isMethodTrue = false;
                if (syntaxChecked == true)
                {
                    if (command.IsValidCommand && command.IsValidParameters)
                    {

                        if (textBox_SingleCmd.Text.Length != 0 && textBox_MultiCmd.Text.Length != 0)
                        {
                            command.IsMultiLine = true;
                            for (int i = 0; i < multiCommands.Length; i++)
                            {
                                command.Command = SplitCommand(multiCommands[i]);
                                command.Is_A_If_Statement();
                                command.Is_A_EndIf_Statement();
                                command.Is_A_While_Loop();
                                command.Is_A_End_Loop();
                                command.Is_A_Method();
                                command.Is_A_End_Method();
                                command.Is_Method_Called();


                                if (command.Is_A_If_Statement())
                                {
                                    isIfTrue = true;
                                }

                                else if (command.Is_A_EndIf_Statement())
                                {
                                    isIfTrue = false;
                                    runIfConditionTrueCommand = ifConditionTrueCommands.ToArray();
                                    if (command.IsIfConditionTrue)
                                    {
                                        for (int j = 1; j < runIfConditionTrueCommand.Length; j++)
                                        {
                                            command.Command = SplitCommand(runIfConditionTrueCommand[j]);
                                            command.Is_A_Variable();
                                            command.Is_A_If_Statement();
                                            command.Is_A_EndIf_Statement();
                                            command.Is_A_While_Loop();
                                            command.Is_A_End_Loop();
                                            command.Is_A_Method();
                                            command.Is_A_End_Method();
                                            command.Is_Method_Called();
                                            command.ValidateCommandName();
                                            command.ValidateParameters();
                                            command.RunCommand(g, Convert.ToInt32(penSizes.Text));
                                        }
                                    }
                                    ifConditionTrueCommands.Clear();
                                }

                                if (command.Is_A_While_Loop())
                                {
                                    isWhileTrue = true;
                                }


                                else if (command.Is_A_End_Loop())
                                {
                                    isWhileTrue = false;
                                    runWhileConditionTrueCommand = whileConditionTrueCommands.ToArray();

                                    if (command.IsWhileConditionTrue)
                                    {
                                        while (command.IsWhileConditionTrue)
                                        {
                                            for (int j = 0; j < runWhileConditionTrueCommand.Length; j++)
                                            {
                                                if (command.IsWhileConditionTrue)
                                                {
                                                    command.Command = SplitCommand(runWhileConditionTrueCommand[j]);
                                                    command.Is_A_Variable();
                                                    command.Is_A_If_Statement();
                                                    command.Is_A_EndIf_Statement();
                                                    command.Is_A_While_Loop();
                                                    command.Is_A_End_Loop();
                                                    command.Is_A_Method();
                                                    command.Is_A_End_Method();
                                                    command.ValidateCommandName();
                                                    command.ValidateParameters();
                                                    command.Color = btn_PenColour.BackColor;
                                                    command.XPos = Convert.ToInt32(xValue.Text);
                                                    command.YPos = Convert.ToInt32(yValue.Text);
                                                    command.RunCommand(g, Convert.ToInt32(penSizes.Text));                                                    
                                                }
                                            }
                                        }       
                                    }
                                    whileConditionTrueCommands.Clear();
                                }

                                if(command.Is_A_Method())
                                {
                                    isMethodTrue = true;                                    
                                }

                                else if(command.Is_A_End_Method())
                                {
                                    isMethodTrue = false;
                                    if(command.Methods.ContainsKey(command.MethodName))
                                    {
                                        command.Methods[command.MethodName] = methodCommands.ToArray();
                                        runMethodCommands = command.Methods[command.MethodName];
                                    }
                                    methodCommands.Clear();

                                }

                                if(command.Is_Method_Called())
                                {
                                    if(runMethodCommands.Length > 0)
                                    {
                                        for (int j = 1; j < command.Methods[command.MethodName].Length; j++)
                                        {
                                            CommandParser methodComm = new CommandParser(new DisplayMessageBox(), this);
                                            methodComm.VariablesAndValues = command.VariablesAndValues;
                                            methodComm.Command = SplitCommand(command.Methods[command.MethodName][j]);
                                            methodComm.Is_A_Variable();
                                            methodComm.Is_A_If_Statement();
                                            methodComm.Is_A_EndIf_Statement();
                                            methodComm.Is_A_While_Loop();
                                            methodComm.Is_A_End_Loop();
                                            methodComm.ValidateCommandName();
                                            methodComm.ValidateParameters();
                                            methodComm.Color = btn_PenColour.BackColor;
                                            methodComm.XPos = Convert.ToInt32(xValue.Text);
                                            methodComm.YPos = Convert.ToInt32(yValue.Text);
                                            methodComm.Methods = command.Methods;
                                            methodComm.RunCommand(g, Convert.ToInt32(penSizes.Text));
                                        }
                                    }
                                }

                                if (!isIfTrue && !isWhileTrue && !isMethodTrue)
                                {
                                    command.Is_A_Variable();
                                    command.Is_Method_Called();
                                    command.ValidateCommandName();
                                    command.ValidateParameters();
                                    command.Command = SplitCommand(multiCommands[i]);
                                    command.RunCommand(g, Convert.ToInt32(penSizes.Text));
                                }

                                else if (isIfTrue)
                                {
                                    ifConditionTrueCommands.Add(multiCommands[i]);
                                }

                                else if (isWhileTrue)
                                {
                                    whileConditionTrueCommands.Add(multiCommands[i]);
                                }

                                else if (isMethodTrue)
                                {
                                    methodCommands.Add(multiCommands[i]);
                                }
                            }

                        }

                        else
                        {
                            command.IsMultiLine = false;
                            command.RunCommand(g, Convert.ToInt32(penSizes.Text));
                        }

                    }
                    syntaxChecked = false;
                    command.IsMultiLine = false;
                }

                else
                {
                    throw new SyntaxCheckException("Please check syntax before running the file.");
                }
            }

            catch (Exception error2)
            {
                MessageBox.Show(error2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            xValue.Text = Convert.ToString(command.XPos);
            yValue.Text = Convert.ToString(command.YPos);
            command.Color = btn_PenColour.BackColor;
            btn_PenColour.BackColor = command.Color;
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
            textBox_MultiCmd.Text = "";
            textBox_SingleCmd.Text = "";
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

            catch (Exception error3)
            {
                MessageBox.Show("An error occured: " + error3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }

            catch (Exception error4)
            {
                MessageBox.Show("An error occured: " + error4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Event handler for the event of about duplicateProgram option being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of duplicateProgram menu option being clicked.</param>
        /// <param name="e">The arguments of the duplicateProgram menu option click event.</param>
        private void DuplicateProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monitor.Enter(formMonitor);
            try
            {
                if (formCount < 2)
                {
                    formCount++;
                    Thread newThread = new Thread(InitializeSecondWindow);
                    newThread.Start();
                }

                else
                {
                    throw new FormLimitException("Maximum number of forms already created.");
                }
            }

            catch (Exception error5)
            {
                MessageBox.Show(error5.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Monitor.Exit(formMonitor);
            }
        }

        /// <summary>
        /// Void method to create a new Form_SPL or main form.
        /// </summary>
        private void InitializeSecondWindow()
        {
            Form_SPL_Form2 = new Form_SPL();
            Form_SPL_Form2.Text = "Duplicate Simple Programming Language";
            UpdateDrawingDelegate updateDrawingDelegate = new UpdateDrawingDelegate(Form_SPL_Form2.UpdateDrawing);
            Form_SPL_Form2.command = new CommandParser(new DisplayMessageBox(), this);
            Application.Run(Form_SPL_Form2);
        }

        /// <summary>
        /// Void method to update the drawing on the form according to the thread.
        /// </summary>
        /// <param name="shape">Instance of shape class which is used to draw on the form.</param>
        public void UpdateDrawing(Shape shape)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Shape>(UpdateDrawing), shape);
            }

            else
            {
                shape.Draw(g);
                Shapes.Add(shape);
                pnl_Paint.Invalidate();
            }
        }

        /// <summary>
        /// Event handler for the event of form being closed.
        /// </summary>
        /// <param name="sender">The object that triggered the event of form being closed.</param>
        /// <param name="e">The arguments of the form closed event.</param>
        private void Form_SPL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Monitor.Enter(formMonitor);
            try
            {
                formCount--;
                duplicateProgramToolStripMenuItem.Enabled = true;
            }

            finally
            {
                Monitor.Exit(formMonitor);
            }
        }

        /// <summary>
        /// Event handler for the event of pen colour button being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of pen colour button being clicked.</param>
        /// <param name="e">The arguments of the pen colour button being clicked.</param>
        private void Btn_PenColour_Click(object sender, EventArgs e)
        {
            penColour = new ColorDialog();
            if (penColour.ShowDialog() == DialogResult.OK)
            {
                command.Color = penColour.Color;
                btn_PenColour.BackColor = penColour.Color;
            }
        }

        /// <summary>
        /// Event handler for the event of the canvas colour button being clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event of canvas colour button being clicked.</param>
        /// <param name="e">The arguments of the form closed event.</param>
        private void Btn_CanvasColour_Click(object sender, EventArgs e)
        {
            canvasColour = new ColorDialog();
            if (canvasColour.ShowDialog() == DialogResult.OK)
            {
                pnl_Paint.BackColor = canvasColour.Color;
                btn_CanvasColour.BackColor = canvasColour.Color;
            }
        }

        /// <summary>
        /// Event handler for the event of X-Axis value being changed.
        /// </summary>
        /// <param name="sender">The object that triggered the event of X-Axis value being changed.</param>
        /// <param name="e">The arguments of the form closed event.</param>
        private void XValue_ValueChanged(object sender, EventArgs e)
        {
            command.XPos = Convert.ToInt32(xValue.Text);
        }

        /// <summary>
        /// Event handler for the event of Y-Axis value being changed.
        /// </summary>
        /// <param name="sender">The object that triggered the event of Y-Axis value being changed.</param>
        /// <param name="e">The arguments of the form closed event.</param>
        private void YValue_ValueChanged(object sender, EventArgs e)
        {
            command.YPos = Convert.ToInt32(yValue.Text);
        }      
    }
}