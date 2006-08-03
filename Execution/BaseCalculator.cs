using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
	/// <summary>
	/// Abstract base class for all calculators.
	/// </summary>
	public abstract class BaseCalculator : Form
	{

		#region Protected & Private Data

		protected Execution.Thread executionThread;
		protected Reader reader = null;

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
		// which would unfortunate.  So concrete classes are expected to be well-behaved and to
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
			// Required for Windows Form Designer support.  Beware, only the base class can call
			// this operation: it will dispatch to the most derived (concrete) so as to initialize
			// all the controls.  Explicitly calling InitializeComponent in the constructor of
			// derived classes would result in multiple initializations (which are bad for
			// handlers).
			InitializeComponent();

			// Read the parser tables.
			string [] tags = new string [Controls.Count];
			int i = 0;
			foreach (Control control in Controls) 
			{
				tags [i] = (string) control.Tag;
				i++;
			}
			reader = new Reader ("Mockingbird.HP.Parser.Parser", "CGT", model, tags);

			// Initialize the execution thread and wait until it is ready to process requests.
			executionThread = CreateExecutionThread ();

			// Now see if we were called from the command line with arguments.
			if (arguments.Length > 0) 
			{
				ProcessCommandLine (arguments);
			}

			// Prepare the UI.
			UnbusyUI ();

			// Power on.
			executionThread.PowerOn.Set ();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		protected abstract void InitializeComponent ();
		#endregion

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

		// Creates the execution thread that parses and processes output.
		protected abstract Execution.Thread CreateExecutionThread ();

		// Call by the execution thread to notify the UI thread that the busy state has changed.
		public abstract EngineMode CrossThreadNotifyUI (bool busy);

		// Power-off the calculator.
		protected abstract void PowerOff ();

		// Process the given command line arguments.
		protected abstract void ProcessCommandLine (string [] arguments);

		// Make the UI unbusy so as to allow user interactions.
		protected abstract void UnbusyUI ();

		#endregion

		#region UI Event Handlers

		protected void Calculator_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			executionThread.Abort ();
		}

		protected void Calculator_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// If a key event is received when the user is not editing the card slot, we look for
			// a key that has the corresponding code as one of its shortcuts, and we send it a
			// mouse event.  A control or alt key is merely passed up the chain.			
			if (e.Control || e.Alt) 
			{
			}
			else if (! KeyEventsPreempted) 
			{
				foreach (Control c in this.Controls) 
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

		protected void Calculator_KeyUp (object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control || e.Alt) 
			{
			}
			else if (! KeyEventsPreempted)
			{
				foreach (Control c in this.Controls) 
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

		protected void Key_LeftMouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Queue a keystroke, and notify the execution thread that its queue is not empty.
			executionThread.Enqueue
				(new Keystroke ((System.Windows.Forms.Control) sender, e, KeystrokeMotion.Down));
		}

		protected void Key_LeftMouseUp (object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Queue a keystroke, and notify the execution thread that its queue is not empty.
			executionThread.Enqueue
				(new Keystroke ((System.Windows.Forms.Control) sender, e, KeystrokeMotion.Up));
		}

		protected void toggleOffOn_ToggleClick (object sender,
			System.EventArgs e,
			Mockingbird.HP.Control_Library.TogglePosition position)
		{
			switch (toggleOffOn.Position)
			{
				case TogglePosition.Left :
					PowerOff ();
					break;
				case TogglePosition.Right :
					// ON.  First, we cancel any key typed when the power was off.  Then we enqueue
					// a dummy keystroke to cause the execution thread to set the display mode.
					// Finally we release the execution thread.
					executionThread.Clear ();
					executionThread.Enqueue (Keystroke.Noop);
					executionThread.PowerOn.Set ();
					break;
			}		
		}

		#endregion

	}
}

