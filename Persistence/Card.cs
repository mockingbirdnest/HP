using HP67_Class_Library;
using HP_Parser;
using System;
using System.IO;
using System.Windows.Forms;

namespace HP67_Persistence
{

	public enum CardPart
	{
		Data,
		Program
	}

	/// <summary>
	/// A card used to store the program, memory and other state of the HP67 calculator.
	/// </summary>
	public class Card
	{
		private const float Version = 1.6F;

		#region Event Definitions

		public delegate void DatasetExporterDelegate (CardDataset cds, CardPart part);
		public delegate void DatasetImporterDelegate (CardDataset cds, Reader reader);
		static public event DatasetImporterDelegate MergeFromDataset;
		static public event DatasetImporterDelegate ReadFromDataset;
		static public event DatasetExporterDelegate WriteToDataset;

		#endregion

		#region Constructors & Destructors

		public Card ()
		{
		}

		#endregion

		#region Private Operations

		static private bool CheckVersion (CardDataset cds) 
		{
			CardDataset.CardRow cr = cds.Card [0];
			CardDataset.InstructionRow [] irs;
			CardDataset.ProgramRow pr;
			CardDataset.ProgramRow [] prs;

			if (cr.Version == Version) 
			{
				return true;
			}

			// We didn't support compatibility before version 1.4.
			if (cr.Version < 1.4F || cr.Version > Version) 
			{
				// For some reason (read: compiler bug) we must compute text and caption separately,
				// we cannot just write one humongous statement.
				string text = string.Format (
					Localization.GetString (Localization.FileHasVersion),
					cds.Card [0].Version.ToString (),
					Version.ToString ());
				string caption = Localization.GetString (Localization.IncompatibleVersion);

				MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Compatibility code to read older cards.
			if (cr.Version <= 1.4F) 
			{
				// Version 1.4 used to have Text in instructions.
			}
			if (cr.Version <= 1.5F)
			{
				// Version 1.5 used to have GSB_F and LBL_F.
				prs = cr.GetProgramRows ();
				if (prs.Length > 0) 
				{
					pr = prs [0];
					irs = pr.GetInstructionRows ();
					foreach (CardDataset.InstructionRow ir in irs) 
					{
						if (ir.Instruction == "Gsb_f") 
						{
							ir.Instruction = "Gsb";
						}
						else if (ir.Instruction == "Lbl_f")
						{
							ir.Instruction = "Lbl";
						}
					}
				}
			}
				cds.Card [0].Version = Version;
			return true;
		}

		#endregion

		#region Public Operations

		static public bool Merge (Stream stream, Reader reader)
		{
			CardDataset cds = new CardDataset ();
			cds.ReadXml (stream);
			if (CheckVersion (cds)) 
			{
				MergeFromDataset (cds, reader);
				return true;
			}
			else 
			{
				return false;
			}
		}

		static public bool Read (Stream stream, Reader reader)
		{
			CardDataset cds = new CardDataset ();
			cds.ReadXml (stream);
			if (CheckVersion (cds)) 
			{
				ReadFromDataset (cds, reader);
				return true;
			}
			else 
			{
				return false;
			}
		}

		static public bool Write (Stream stream, CardPart part)
		{
			CardDataset cds = new CardDataset ();

			if (stream.Length > 0) 
			{
				cds.ReadXml (stream);
				if (! CheckVersion (cds)) 
				{
					return false;
				}
			}
			else 
			{
				CardDataset.CardRow cr;

				cr = cds.Card.NewCardRow ();
				cr.Version = Version;
				cds.Card.AddCardRow (cr);
			}
			WriteToDataset (cds, part);
			stream.SetLength (0);
			cds.WriteXml (stream);
			return true;
		}

		#endregion

	}
}
