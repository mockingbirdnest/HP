using HP67_Control_Library;
using System;
using System.IO;

namespace HP67_Class_Library
{
	/// <summary>
	/// A card used to store the program, memory and other state of the HP67 calculator.
	/// </summary>
	public class Card
	{

		#region Event Definitions

		public delegate void DatasetIODelegate (CardDataset cds);
		static public event DatasetIODelegate ReadFromDataset;
		static public event DatasetIODelegate WriteToDataset;

		#endregion

		#region Constructors & Destructors

		public Card ()
		{
		}

		#endregion

		#region Public Operations

		static public void Read ()
		{
			CardDataset cds = new CardDataset ();
			ReadFromDataset (cds);
		}

		static public void Write (Stream stream)
		{
			CardDataset cds = new CardDataset ();
			CardDataset.CardRow cr;

			cr = cds.Card.NewCardRow ();
			cds.Card.AddCardRow (cr);
			WriteToDataset (cds);
			cds.WriteXml (stream);
		}

		#endregion

	}
}
