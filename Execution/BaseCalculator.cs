using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    /// <summary>
    /// Abstract base class for all calculators.
    /// </summary>
    public abstract partial class BaseCalculator : Form
    {

        #region Protected & Private Data

        private const string configCulture = "Culture";

        protected Display display;
        protected Execution.Thread executionThread;
        private Control [] allControls;

        // Note on the separation of concerns regarding UI elements.
        //
        // The purpose of the various calculator classes is to factor out code that is concerned
        // with a set of behaviors specific to each class.  For instance, all calculators have an
        // OFF/ON toggle, so this control should be declared here, together with the related
        // handlers.  The purpose of the various calculator classes, however, is not to factor
        // out common layout, font, color, or localization characteristics.  Therefore the 
        // initialization of the controls is entirely performed in the InitializeComponent routine
        // of the concrete classes.  There is a small set of processing that should logically be
        // factored in abstract classes, instead of being distributed in concrete classes.  This
        // includes in particular (1) the creation of controls and (2) the registration of handlers.
        // However, scattering the code in this fashion would prevent us from using the UI designer,
        // which would be unfortunate.  So concrete classes are expected to be well-behaved and to
        // do all the required initialization (if they don't, it will soon be apparent).

        protected Mockingbird.HP.Control_Library.Toggle toggleOffOn;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors & Destructors

        public BaseCalculator (string [] arguments, CalculatorModel model)
        {

            PreInitializeComponent (arguments, model);

            // Required for Windows Form Designer support.  Beware, only the base class can call
            // this operation: it will dispatch to the most derived (concrete) so as to initialize
            // all the controls.  Explicitly calling InitializeComponent in the constructor of
            // derived classes would result in multiple initializations (which are bad for
            // handlers).
            InitializeComponent ();

            PostInitializeComponent (arguments, model, new Control [] { display });
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

        protected virtual void PreInitializeComponent (string [] arguments, CalculatorModel model)
        {

            // Set the current culture.  This must take place before initializing the UI so that the
            // controls get the proper resources.
            string cultureName = ConfigurationManager.AppSettings.GetValues (configCulture) [0];
            if (cultureName != "")
            {
                try
                {
                    CultureInfo cultureInfo = new CultureInfo (cultureName);
                    Localization.Culture = cultureInfo;
                    System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
                }
                catch (ArgumentException)
                {
                }
            }
        }

        protected abstract void InitializeComponent ();

        protected virtual void PostInitializeComponent
            (string [] arguments, CalculatorModel model, Control [] sharedControls)
        {

            // Read the parser tables.
            allControls = GetAllControls (this);
            string [] tags = new string [allControls.Length];
            int i = 0;
            foreach (Control control in allControls)
            {
                tags [i] = (string) control.Tag;
                i++;
            }

            // Initialize the execution thread and wait until it is ready to process requests.
            executionThread = new Execution.Thread
                (model,
                 tags,
                 sharedControls,
                 new Execution.Thread.CrossThreadUINotification (CrossThreadNotifyUI));

            // Now see if we were called from the command line with arguments.
            if (arguments.Length > 0)
            {
                ProcessCommandLine (arguments);
            }

            // Start the calculator.
            PowerOn ();
        }

        #endregion

        #region Abstract Operations

        // Returns true if key events are preempted by a nested control instead of being sent to
        // the form for processing.
        protected abstract bool KeyEventsPreempted
        {
            get;
        }

        // Make the UI busy so as to prevent user interactions.
        protected abstract void BusyUI ();

        // Called by the execution thread to notify the UI thread that of a state change.
        public abstract void CrossThreadNotifyUI (bool threadIsBusy, bool programIsEmpty);

        // Power-off the calculator.
        protected abstract void PowerOff ();

        // Process the given command line arguments.
        protected abstract void ProcessCommandLine (string [] arguments);

        // Make the UI unbusy so as to allow user interactions.
        protected abstract void UnbusyUI ();

        #endregion

        #region Dispatching Operations

        protected virtual void PowerOn ()
        {
            // Prepare the UI.
            UnbusyUI ();

            // Power on.
            executionThread.PowerOn.Set ();
        }

        #endregion

        #region UI Event Handlers

        protected void Calculator_FormClosing (object sender, FormClosingEventArgs e)
        {
            executionThread.Abort ();
        }

        protected void Calculator_KeyDown (object sender, KeyEventArgs e)
        {
            // If a key event is received when the user is not editing the card slot, we look for
            // a key that has the corresponding code as one of its shortcuts, and we send it a
            // mouse event.  A control or alt key is merely passed up the chain.			
            if (e.Control || e.Alt)
            {
            }
            else if (!KeyEventsPreempted)
            {
                foreach (Control c in AllControls)
                {
                    if (c is Key)
                    {
                        foreach (Keys k in ((Key) c).Shortcuts)
                        {
                            if (k == e.KeyCode)
                            {
                                Key_LeftMouseDown
                                    ((Key) c, new MouseEventArgs (MouseButtons.Left, 0, 0, 0, 0));
                            }
                        }
                    }
                }
            }
        }

        protected void Calculator_KeyUp (object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt)
            {
            }
            else if (!KeyEventsPreempted)
            {
                foreach (Control c in AllControls)
                {
                    if (c is Key)
                    {
                        foreach (Keys k in ((Key) c).Shortcuts)
                        {
                            if (k == e.KeyCode)
                            {
                                Key_LeftMouseUp
                                    ((Key) c, new MouseEventArgs (MouseButtons.Left, 0, 0, 0, 0));
                            }
                        }
                    }
                }
            }
        }

        protected void Key_LeftMouseDown (object sender, MouseEventArgs e)
        {

            // Queue a keystroke, and notify the execution thread that its queue is not empty.
            executionThread.Enqueue
                (new KeystrokeMessage ((Control) sender, e, KeystrokeMotion.Down));
        }

        protected void Key_LeftMouseUp (object sender, MouseEventArgs e)
        {

            // Queue a keystroke, and notify the execution thread that its queue is not empty.
            executionThread.Enqueue
                (new KeystrokeMessage ((Control) sender, e, KeystrokeMotion.Up));
        }

        protected void toggleOffOn_ToggleMoved (object sender, TogglePosition position)
        {
            switch (toggleOffOn.Position)
            {
                case TogglePosition.Left:
                    PowerOff ();
                    break;
                case TogglePosition.Right:
                    // ON.  First, we cancel any key typed when the power was off.  Next we prepare
                    // the UI to receive user interaction.  Then we queue a message to force the
                    // thread to refresh (e.g., to read the W/PRGM-RUN toggle).  And finally we 
                    // release the execution thread.
                    //TODO: This comment is wrong.
                    executionThread.Clear ();
                    PowerOn ();
                    break;
            }
        }

        #endregion

        #region Utilities

        private Control [] GetAllControls (Control control)
        {
            ArrayList allControls = new ArrayList ();

            foreach (Control c in control.Controls)
            {
                allControls.AddRange (GetAllControls (c));
                allControls.Add (c);
            }
            return (Control []) allControls.ToArray (typeof (Control));
        }

        #endregion

        #region Properties

        protected Control [] AllControls
        {
            get
            {
                return allControls;
            }
        }

        #endregion

    }
}

