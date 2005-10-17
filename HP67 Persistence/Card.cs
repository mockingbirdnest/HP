using HP67_Parser;
using System;
using System.IO;
using System.Windows.Forms;

namespace HP67_Persistence
{
	/// <summary>
	/// A card used to store the program, memory and other state of the HP67 calculator.
	/// </summary>
	public class Card
	{
		private const float Version = 1.2F;

		#region Event Definitions

		public delegate void DatasetExporterDelegate (CardDataset cds);
		public delegate void DatasetImporterDelegate (CardDataset cds, Parser parser);
		static public event DatasetImporterDelegate ReadFromDataset;
		static public event DatasetExporterDelegate WriteToDataset;

		#endregion

		#region Constructors & Destructors

		public Card ()
		{
		}

		#endregion

		#region Public Operations

		static public bool Read (Stream stream, Parser parser)
		{
			CardDataset cds = new CardDataset ();
			cds.ReadXml (stream);
			if (cds.Card [0].Version != Version) 
			{
				// TODO: Localization.
				MessageBox.Show ("Incompatible version: file has version " +
					cds.Card [0].Version.ToString () + " but program expects version " +
					Version.ToString (), "Incompatible Version", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return false;
			}
			else
			{
				ReadFromDataset (cds, parser);
				return true;
			}
		}

		static public void Write (Stream stream)
		{
			CardDataset cds = new CardDataset ();
			CardDataset.CardRow cr;

			cr = cds.Card.NewCardRow ();
			cr.Version = Version;
			cds.Card.AddCardRow (cr);
			WriteToDataset (cds);
			cds.WriteXml (stream);
		}

		#endregion

	}
}
