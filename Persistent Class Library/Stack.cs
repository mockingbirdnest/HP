using Mockingbird.HP.Control_Library;
using System;

namespace Mockingbird.HP.Class_Library
{
	/// <summary>
	/// Evaluation stack of the HP67 calculator.
	/// </summary>
	public class Stack
	{

		#region Private Data

		private enum Position
		{
			x = -1, // Not stored, see the indexer.
			y = 0,
			z = 1,
			t = 2
		}

		private double lastX;
		private double[] stack;

		private Display theDisplay;

		#endregion

		#region Contructors & Destructors

		public Stack (Display display)
		{
			theDisplay = display;

			// Tricky!  The x element is *not* represented.  See the indexer.
			stack = new double [Position.t - Position.y + 1];
			lastX = 0.0;

			for (int i = 0; i < stack.Length; i++)
			{
				stack[i] = 0.0;
			}
		}

		#endregion

		#region Private Operations

		private double this [Position p] 
		{

			// We do not represent the x element of the stack.  Because it is supposedly always
			// reflected by the display, we read/write it from the display as needed.  This ensures
			// that we cannot possibly get into an inconsistent state.
			get 
			{
				if (p == Position.x) 
				{
					double x = theDisplay.Value;
					theDisplay.Value = x; // Refresh the display.
					return x;
				}
				else
				{
					return stack [(int) p];
				}
			}
			set 
			{
				if (p == Position.x) 
				{
					theDisplay.Value = value;
				}
				else
				{
					stack [(int) p] = value;
				}
			}
		}

		#endregion

		#region Public Operations & Properties

		public void XExchangeY ()
		{
			double temp;
			temp = this [Position.x];
			this [Position.x] = this [Position.y];
			this [Position.y] = temp;
		}

		public void RollDown ()
		{
			double temp;
			temp = this [Position.x];
			for (Position i = Position.x; i < Position.t; i++)
			{
				this [i] = this [i + 1];
			}
			this [Position.t] = temp;
		}

		public void RollUp ()
		{
			double temp;
			temp = this [Position.t];
			for (Position i = Position.t; i > Position.x; i--)
			{
				this [i] = this [i - 1];
			}
			this [Position.x] = temp;
		}
		
		public double LastX
		{
			get
			{
				return lastX;
			}
		}

		public double X
		{
			get 
			{
				return this [Position.x];
			}
			set 
			{
				this [Position.x] = value;
			}
		}

		public double Y
		{
			get 
			{
				return this [Position.y];
			}
			set 
			{
				this [Position.y] = value;
			}
		}

		public void Get (out double X)
		{
			X = this [Position.x];
			lastX = this [Position.x];
		}

		public void Get (out double X, out double Y)
		{
			X = this [Position.x];
			Y = this [Position.y];
			lastX = this [Position.x];
			for (Position i = Position.x; i < Position.t; i++)
			{
				this [i] = this [i + 1];
			}
		}

		public void Enter ()
		{
			for (Position i = Position.t; i > Position.x; i--)
			{
				this [i] = this [i - 1];
			}
		}

		public void Display ()
		{
			for (Position p = Position.x; p <= Position.t; p++) 
			{
				RollUp ();
				theDisplay.Pause (500);
			}
		}

		#endregion

	}
}
