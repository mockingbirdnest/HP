using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    /// <summary>
    /// Abstract base class for programmable calculators.
    /// </summary>
    public abstract class ProgrammableCalculator : BaseCalculator
    {

        #region Protected & Private Data

        private const string commandOpen = "/open";
        private const string commandPrint = "/print";

        protected string fileName = null;

        protected Mockingbird.HP.Control_Library.Toggle toggleWprgmRun;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Drawing.Printing.PrintDocument printDocument;
        protected MenuStrip menuStrip;
        protected ToolStripMenuItem fileToolStripMenuItem;
        protected ToolStripMenuItem openToolStripMenuItem;
        protected ToolStripMenuItem saveToolStripMenuItem;
        protected ToolStripMenuItem saveAsToolStripMenuItem;
        protected ToolStripMenuItem printToolStripMenuItem;
        protected ToolStripMenuItem exitToolStripMenuItem;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors & Destructors

        public ProgrammableCalculator (string [] argument, CalculatorModel model)
            :
            base (argument, model)
        {
            UpdateUI (true);
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose ();
                }
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected abstract override void InitializeComponent ();
        //TODO: Localize the UI.
        //			openMenuItem.Text = Localization.GetString (Localization.OpenMenuItem);
        //			printMenuItem.Text = Localization.GetString (Localization.PrintMenuItem);
        //			saveMenuItem.Text = Localization.GetString (Localization.SaveMenuItem);
        //			saveAsMenuItem.Text = Localization.GetString (Localization.SaveAsMenuItem);
        #endregion

        #endregion

        #region Abstract Operations

        // Update the UI after a change to the program state.
        protected abstract void UpdateUI (bool programIsEmpty);

        #endregion

        #region Overriding Operations

        protected override void BusyUI ()
        {

            // Disabling the menu items makes it clear to the user which operations are forbidden
            // while the program runs.  It is doesn't help thread-safety, though: it could be
            // possible for a print operation to start, followed immediately by the execution of a
            // program, in which case both would proceed in parallel.  Thread safety is achieved by
            // locking the operations that must access the execution data structures.
            openToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
        }

        protected override Execution.Thread CreateExecutionThread
            (CalculatorModel model, string [] tags)
        {
            return new Execution.Thread
                (display,
                model,
                tags,
                new Execution.Thread.CrossThreadUINotification (CrossThreadNotifyUI));
        }

        public override EngineMode CrossThreadNotifyUI (bool threadIsBusy, bool programIsEmpty)
        {
            if (threadIsBusy)
            {
                BusyUI ();
                return EngineMode.Run;
            }
            else
            {
                // Make sure that the state of the UI reflects the state of the program memory.
                UpdateUI (programIsEmpty);
                return UnbusyUIAndGetEngineMode ();
            }
        }

        protected override void ProcessCommandLine (string [] arguments)
        {
            string caption = Localization.GetString (Localization.IncorrectCommandLineArguments);
            FileStream stream;

            switch (arguments.Length)
            {
                case 0:
                    break;
                case 2:
                    if (arguments [0] == commandOpen)
                    {
                        fileName = arguments [1];
                        stream = Open (ref fileName);
                        if (stream != null)
                        {
                            executionThread.Enqueue (new OpenMessage (/* merge */ false, stream));
                        }
                    }
                    else if (arguments [0] == commandPrint)
                    {
                        Print (arguments [1]);

                        // For some reason Close and Application.Exit won't have an effect here
                        // (maybe because we are in the constructor?).  So I am calling the cleanup
                        // code by hand, and raising an exception to get out of the constructor.
                        Calculator_FormClosing (null, null);
                        throw new Shutdown ();
                    }
                    else
                    {
                        MessageBox.Show (string.Format (
                            Localization.GetString (Localization.IncorrectCommand),
                            arguments [0],
                            commandOpen,
                            commandPrint),
                            caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show (string.Format (
                        Localization.GetString (Localization.IncorrectArgumentCount),
                        arguments.Length.ToString (), 0, 2),
                        caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        protected override void UnbusyUI ()
        {
            UnbusyUIAndGetEngineMode ();
        }

        #endregion

        #region Command Execution Utilities

        public FileStream Open (ref string name)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream (name, FileMode.Open, FileAccess.Read);
                return stream;
            }
            catch (FileNotFoundException)
            {
                string text = string.Format (
                    Localization.GetString (Localization.CannotOpenFile),
                    name);
                string caption = Localization.GetString (Localization.FileNotFound);

                if (stream != null)
                {
                    stream.Close ();
                }
                MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                string text = string.Format (
                    Localization.GetString (Localization.ExceptionOpeningFile),
                    name,
                    ex.Message);
                string caption = Localization.GetString (Localization.ErrorDuringOpen);

                if (stream != null)
                {
                    stream.Close ();
                }
                MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void Print (string name)
        {
            FileStream stream = Open (ref name);
            if (stream != null)
            {
                executionThread.Enqueue (new OpenMessage (/* merge */ false, stream));
                printToolStripMenuItem_Click (null, null);
            }
        }

        protected FileStream Save (bool saveAs, ref string name)
        {
            bool fileIsNullOrReadOnly;
            bool fileIsReadOnly;
            bool mustShowDialog = saveAs;
            FileStream stream = null;

            // If we don't have a currently open file, or if it is read-only, or if this is a
            // Save As, we bring up the menu.  We keep doing so until either the user cancels the
            // operation, or selects a writeable or nonexistent file.
            for (; ; )
            {
                fileIsReadOnly = File.Exists (name) &&
                    ((File.GetAttributes (name) & FileAttributes.ReadOnly) != 0);
                fileIsNullOrReadOnly = (name == null || fileIsReadOnly);
                if (!mustShowDialog && !fileIsNullOrReadOnly)
                {
                    break;
                }
                if (fileIsNullOrReadOnly)
                {
                    saveFileDialog.FileName = Localization.GetString (Localization.UntitledFileName);
                }
                else
                {
                    saveFileDialog.FileName = name;
                }
                if (saveFileDialog.ShowDialog () == DialogResult.OK)
                {
                    name = saveFileDialog.FileName;
                    mustShowDialog = false;
                }
                else
                {
                    return null;
                }
            }

            // Open the file to write.  Use OpenOrCreate so as to be able to read the part of the
            // file that we won't overwrite.
            try
            {
                stream = new FileStream (name, FileMode.OpenOrCreate);
                return stream;
            }
            catch (Exception ex)
            {
                string text = string.Format (
                    Localization.GetString (Localization.ExceptionSavingFile),
                    name,
                    ex.Message);
                string caption = Localization.GetString (Localization.ErrorDuringSave);

                if (stream != null)
                {
                    stream.Close ();
                }
                MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region UI Utilities

        private EngineMode UnbusyUIAndGetEngineMode ()
        {
            printToolStripMenuItem.Enabled = true;
            switch (toggleWprgmRun.Position)
            {
                case TogglePosition.Left:

                    // W/PRGM, can only save.
                    display.Mode = DisplayMode.Instruction;
                    openToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                    return EngineMode.WriteProgram;

                case TogglePosition.Right:

                    // RUN, can only open.
                    display.Mode = DisplayMode.Numeric;
                    openToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    return EngineMode.Run;

                default:
                    return EngineMode.Run; // To make the compiler happy.
            }
        }

        #endregion

        #region UI Event Handlers

        protected void printDocument_PrintPage (object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            executionThread.Enqueue (new PrintMessage (e));
        }

        protected void toggleWprgmRun_ToggleClick (object sender,
            System.EventArgs e,
			Mockingbird.HP.Control_Library.TogglePosition position)
        {

            // Changes to this toggle are actually delayed until the end of the current execution.
            // If the execution thread is idle, we are going to be able to grab the lock and
            // proceed immediately.  If it is busy, we won't be able to grab the lock, and we will
            // return without doing anything.  That's not a problem because the execution thread
            // will update the menus as soon as the current computation finishes.
            if (Monitor.TryEnter (executionThread.IsBusy))
            {
                try
                {

                    // Ask the execution thread to refresh its state based on the new state of the
                    // UI.  This will cause the display mode and the menus to reflect the current
                    // position of the toggle.
                    executionThread.Enqueue (new RefreshMessage ());
                }
                finally
                {
                    Monitor.Exit (executionThread.IsBusy);
                }
            }
        }

        protected void exitToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            Close ();
        }

        protected void openToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            FileStream stream;

            if (openFileDialog.ShowDialog () == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                stream = Open (ref fileName);
                if (stream != null)
                {
                    executionThread.Enqueue (new OpenMessage (/* merge */ false, stream));
                }
            }
        }

        protected void saveToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            FileStream stream = Save (/* saveAs */ false, ref fileName);
            if (stream != null)
            {
                executionThread.Enqueue (new SaveMessage (CardPart.Program, stream));
            }
        }

        protected void saveAsToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            FileStream stream = Save (/* saveAs */ true, ref fileName);
            if (stream != null)
            {
                executionThread.Enqueue (new SaveMessage (CardPart.Program, stream));
            }
        }

        protected void printToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            printDocument.Print ();
        }

        #endregion

    }
}
