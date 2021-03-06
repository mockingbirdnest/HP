using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    /// <summary>
    /// Abstract base class for programmable calculators.
    /// </summary>
    public abstract partial class ProgrammableCalculator : BaseCalculator
    {

        #region Protected & Private Data

        private const string commandOpen = "/open";
        private const string commandPrint = "/print";

        private string fileName = null;

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
            : base (argument, model)
        {
        }

        protected override void PostInitializeComponent
            (string [] arguments, CalculatorModel model, Control [] sharedControls)
        {
            UpdateUIToReflectProgram (true);
            base.PostInitializeComponent (arguments, model, sharedControls);
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

        #endregion

        #region Dispatching Operations

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

        public override void CrossThreadNotifyUI (bool threadIsBusy, bool programIsEmpty)
        {
            if (threadIsBusy)
            {
                BusyUI ();
            }
            else
            {
                UpdateUIToReflectProgram (programIsEmpty);
                UnbusyUI ();
            }
        }

        protected override void PowerOff ()
        {
            // OFF.  We abort the execution thread and start a new one.  We leave it in the
            // state where its display is black and it doesn't accept keystrokes.
            BusyUI ();
            executionThread.Reset ();
            UpdateUIToReflectProgram (/* programIsEmpty */ true);
        }

        protected override void PowerOn ()
        {
            base.PowerOn ();
            toggleWprgmRun_ToggleMoved (toggleWprgmRun, toggleWprgmRun.Position);
        }

        protected override void ProcessCommandLine (string [] arguments)
        {
            string caption = Localization.IncorrectCommandLineArguments;
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
                        MessageBox.Show (Localization.IncorrectCommandFormat
                                            (arguments [0],
                                            commandOpen,
                                            commandPrint),
                            caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show (Localization.IncorrectArgumentCountFormat
                                            (arguments.Length.ToString (), 0, 2),
                        caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        protected override void UnbusyUI ()
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
                    break;

                case TogglePosition.Right:

                    // RUN, can only open.
                    display.Mode = DisplayMode.Numeric;
                    openToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        protected virtual void UpdateUIToReflectProgram (bool programIsEmpty)
        {
            try
            {
                saveToolStripMenuItem.Enabled = !programIsEmpty;
                saveAsToolStripMenuItem.Enabled = !programIsEmpty;
                printToolStripMenuItem.Enabled = !programIsEmpty;
            }
            finally
            {

                // If the program was cleared, clear the current file name.  This ensures that the
                // next program won't be stupidly saved on the previous card.
                if (programIsEmpty)
                {
                    fileName = null;
                }
            }
        }

        #endregion

        #region Cross-Thread Callbacks

        public FileStream CrossThreadOpen ()
        {
            string name;

            if (openFileDialog.ShowDialog () == DialogResult.OK)
            {
                name = openFileDialog.FileName;
                return Open (ref name);
            }
            else
            {
                return null;
            }
        }

        public FileStream CrossThreadSaveDataAs ()
        {
            string name = null;

            return Save (/* saveAs */ true, ref name);
        }

        #endregion

        #region Command Execution

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
                string text = Localization.CannotOpenFileFormat (name);
                string caption = Localization.FileNotFound;

                if (stream != null)
                {
                    stream.Close ();
                }
                MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                string text = Localization.ExceptionOpeningFileFormat (name, ex.Message);
                string caption = Localization.ErrorDuringOpen;

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
                    saveFileDialog.FileName = Localization.UntitledFileName;
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
                string text = Localization.ExceptionSavingFileFormat (name, ex.Message);
                string caption = Localization.ErrorDuringSave;

                if (stream != null)
                {
                    stream.Close ();
                }
                MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region Utilities

        protected bool FileIsReadOnly
        {
            get
            {
                return (fileName != null &&
                    ((File.GetAttributes (fileName) & FileAttributes.ReadOnly) != 0));
            }
        }

        #endregion

        #region Event Handlers

        protected void printDocument_PrintPage (object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintMessage message = new PrintMessage (e);

            // The message must be executed synchronously.  That's because the printing code will
            // need to access the graphic context contained in e, but if we were to return
            // immediately this graphic context would be discarded.  The execution thread would
            // then try to access random memory, and plague and pestilence would ensue.
            message.Synchronous = true;
            executionThread.Enqueue (message);
        }

        protected void toggleWprgmRun_ToggleMoved (object sender,
            Mockingbird.HP.Control_Library.TogglePosition position)
        {

            // Changes to this toggle are actually delayed until the end of the current execution.
            // If the execution thread is idle, we are going to be able to grab the lock and
            // proceed immediately.  If it is busy, we won't be able to grab the lock, and we will
            // return without doing anything.  That's not a problem because the execution thread
            // will update the menus as soon as the current computation finishes.

            // Ask the execution thread to refresh its state based on the new state of the
            // UI.  This will cause the display mode and the menus to reflect the current
            // position of the toggle.
            //TODO: This comment is incorrect.
            switch (position)
            {
                case TogglePosition.Left:
                    executionThread.Enqueue 
                        (new ExecutionModeMessage (EngineModes.Execution.WriteProgram));
                    break;
                case TogglePosition.Right:
                    executionThread.Enqueue
                        (new ExecutionModeMessage (EngineModes.Execution.Run));
                    break;
                default:
                    Trace.Assert (false);
                    break;
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
