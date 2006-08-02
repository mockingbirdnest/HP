using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using System;
using System.Windows.Forms;

namespace Mockingbird.HP.HP67
{
	/// <summary>
	/// Abstract base class for all calculators.
	/// </summary>
	public abstract class BaseCalculator : Form
	{

		#region Protected & Private Data

		protected ExecutionThread executionThread;
		protected Reader reader = null;

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
			// this operation: it will dispatch to the most derived class and go up the derivation
			// chain so as to initialize the components at each level.  Explicitly calling
			// InitializeComponent in the constructor of derived classes would result in multiple
			// initializations (which are bad for handlers).
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
		protected virtual void InitializeComponent ()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager (typeof (BaseCalculator));
			this.toggleOffOn = new Mockingbird.HP.Control_Library.Toggle();
			this.SuspendLayout();
			// 
			// toggleOffOn
			// 
			this.toggleOffOn.LeftText = "OFF";
			this.toggleOffOn.LeftWidth = 30;
			this.toggleOffOn.Location = new System.Drawing.Point(8, 56);
			this.toggleOffOn.MainWidth = 50;
			this.toggleOffOn.Name = "toggleOffOn";
			this.toggleOffOn.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
			this.toggleOffOn.RightText = "ON";
			this.toggleOffOn.RightWidth = 30;
			this.toggleOffOn.Size = new System.Drawing.Size(110, 16);
			this.toggleOffOn.TabIndex = 2;
			this.toggleOffOn.ToggleClick += new Mockingbird.HP.Control_Library.Toggle.ToggleClickEvent(this.toggleOffOn_ToggleClick);
			// 
			// BaseCalculator
			// 
			this.Controls.Add(this.toggleOffOn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Closing += new System.ComponentModel.CancelEventHandler (Calculator_Closing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler (Calculator_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler (Calculator_KeyUp);
			this.ResumeLayout(false);
		}
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
		protected abstract ExecutionThread CreateExecutionThread ();

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

		private void Calculator_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void Calculator_KeyUp (object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void toggleOffOn_ToggleClick (object sender,
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

