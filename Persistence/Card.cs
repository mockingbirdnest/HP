using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Parser;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mockingbird.HP.Persistence
{

	public enum CardPart
	{
		Data,
		Program
	}

	/// <summary>
	/// A card used to store the program, memory and other state of an HP calculator.
	/// </summary>
	public class Card
	{
		private const float Version = 1.8F;

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

		static private void CheckVersion (CardDataset cds) 
		{
			CardDataset.CardRow cr = cds.Card [0];
			CardDataset.ArgumentRow [] ars;
			CardDataset.InstructionRow [] irs;
			CardDataset.ProgramRow pr;
			CardDataset.ProgramRow [] prs;

			if (cr.Version == Version) 
			{
				return;
			}

			// We didn't support compatibility before version 1.4.
			if (cr.Version < 1.4F || cr.Version > Version) 
			{
				// For some reason (read: compiler bug) we must compute text and caption separately,
				// we cannot just write one humongous statement.
				string text = Localization.FileHasVersionFormat (
					cds.Card [0].Version.ToString (),
					Version.ToString ());
				string caption = Localization.IncompatibleVersion;

				MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw new Error ();
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
			if (cr.Version <= 1.6F) 
			{
				// Version 1.6 used to have argument types starting with HP67_Class_Library.
				prs = cr.GetProgramRows ();
				if (prs.Length > 0) 
				{
					pr = prs [0];
					irs = pr.GetInstructionRows ();
					foreach (CardDataset.InstructionRow ir in irs) 
					{
						ars = ir.GetArgumentRows ();
						foreach (CardDataset.ArgumentRow ar in ars) 
						{
							if (ar.Type.StartsWith ("HP67_Class_Library.")) 
							{
								ar.Type =
									ar.Type.Replace
										("HP67_Class_Library.", "Mockingbird.HP.Class_Library.");
							}
						}
					}
				}
			}
            if (cr.Version <= 1.7F)
            {
                // Version 1.7 used to have RC_I and ST_I.
                prs = cr.GetProgramRows ();
                if (prs.Length > 0)
                {
                    pr = prs [0];
                    irs = pr.GetInstructionRows ();
                    foreach (CardDataset.InstructionRow ir in irs)
                    {
                        bool mustPatch = false;

                        if (ir.Instruction == "Rc_I")
                        {
                            ir.Instruction = "Rcl";
                            mustPatch = true;
                        }
                        else if (ir.Instruction == "St_I")
                        {
                            ir.Instruction = "Sto";
                            mustPatch = true;
                        }
                        if (mustPatch)
                        {
                            CardDataset.ArgumentRow ar;

                            ir.ArgumentCount = 1;
                            ar = cds.Argument.NewArgumentRow ();
                            ar.Id = 0;
                            ar.Type = "Mockingbird.HP.Class_Library.Letter";
                            ar.Value = "I";
                            ar.InstructionRow = ir;
                            cds.Argument.AddArgumentRow (ar);
                        }
                    }
                }
            }
            cds.Card [0].Version = Version;
        }

		#endregion

		#region Public Operations

		static public void Merge (Stream stream, Reader reader)
		{
			CardDataset cds = new CardDataset ();
			cds.ReadXml (stream);
			CheckVersion (cds); 
			MergeFromDataset (cds, reader);
		}

		static public void Read (Stream stream, Reader reader)
		{
			CardDataset cds = new CardDataset ();
			cds.ReadXml (stream);
			CheckVersion (cds);
			ReadFromDataset (cds, reader);
		}

		static public void Write (Stream stream, CardPart part)
		{
			CardDataset cds = new CardDataset ();

			if (stream.Length > 0) 
			{
				cds.ReadXml (stream);
                CheckVersion (cds);
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
		}

		#endregion

	}
}
