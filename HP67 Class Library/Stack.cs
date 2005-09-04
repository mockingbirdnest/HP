using System;

namespace HP67_Class_Library
{
	/// <summary>
	/// Summary description for Stack.
	/// </summary>
	public class Stack
	{
		private enum Position
		{
			x = 0,
			y = 1,
			z = 2,
			t = 3
		}
		private double lastX;
		private double[] stack;

		public Stack()
		{
			lastX = 0.0;
			stack = new double[Position.t - Position.x + 1];
			for (int i = 0; i < stack.Length; i++)
			{
				stack[i] = 0.0;
			}
		}

		void ExchangeXY()
		{
			double temp;
			temp = stack[(int)Position.x];
			stack[(int)Position.x] = stack[(int)Position.y];
			stack[(int)Position.y] = temp;
		}

		public void RollDown()
		{
			double temp;
			temp = stack[(int)Position.x];
			for (int i = (int)Position.x; i < (int)Position.t; i++)
			{
				stack[i] = stack[i + 1];
			}
			stack[(int)Position.t] = temp;
		}

		public void RollUp()
		{
			double temp;
			temp = stack[(int)Position.t];
			for (int i = (int)Position.t; i > (int)Position.x; i--)
			{
				stack[i] = stack[i - 1];
			}
			stack[(int)Position.x] = temp;
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
				return stack[(int)Position.x];
			}
			set 
			{
				stack[(int)Position.x] = value;
			}
		}

		public void Get(out double X)
		{
			X = stack[(int)Position.x];
			lastX = stack[(int)Position.x];
		}

		public void Get(out double X, out double Y)
		{
			X = stack[(int)Position.x];
			Y = stack[(int)Position.y];
			lastX = stack[(int)Position.x];
			for (int i = (int)Position.x; i < (int)Position.t; i++)
			{
				stack[i] = stack[i + 1];
			}
		}

		public void Enter()
		{
			for (int i = (int)Position.t; i > (int)Position.x; i--)
			{
				stack[i] = stack[i - 1];
			}
		}

	}
}
