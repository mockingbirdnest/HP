using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.Xml;

namespace Mockingbird.HP.Class_Library
{
    /// <summary>
    /// The data registers of an HP calculator.
    /// </summary>
    public class Memory
    {
        public enum LetterRegister
        {
            A = 20,
            B = 21,
            C = 22,
            D = 23,
            E = 24,
            I = 25
        }

        public delegate Number Operator (Number X, Number Y);

        #region Private Declarations

        private const int displayDuration = 800;
        private IDisplay display;
        private IPrinter printer;
        private Number [] registers;

        private enum ΣRegister
        {
            Σx = 14,
            Σx2 = 15,
            Σy = 16,
            Σy2 = 17,
            Σxy = 18,
            n = 19
        }

        #endregion

        #region Constructors & Destructors

        public Memory (IDisplay display, IPrinter printer)
        {
            this.display = display;
            this.printer = printer;
            registers = new Number [(int) LetterRegister.I - 0 + 1];
            for (int i = 0; i < registers.Length; i++)
            {
                registers [i] = 0.0M;
            }
            Card.MergeFromDataset += new Card.DatasetImporterDelegate (MergeFromDataset);
            Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
            Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
        }

        #endregion

        #region Event Handlers

        public void MergeFromDataset (CardDataset cds, Reader reader)
        {
            CardDataset.CardRow cr;
            CardDataset.MemoryRow mr;
            CardDataset.MemoryRow [] mrs;
            CardDataset.RegisterRow [] rrs;
            bool sourceMemoryIsEmpty;

            cr = cds.Card [0];
            mrs = cr.GetMemoryRows ();
            if (mrs.Length > 0)
            {
                mr = mrs [0];
                rrs = mr.GetRegisterRows ();

                // A source card that only constains zeros is considered empty.  No merge takes
                // place in this case.
                sourceMemoryIsEmpty = true;
                foreach (CardDataset.RegisterRow rr in rrs)
                {
                    if (rr.Value != 0.0)
                    {
                        sourceMemoryIsEmpty = false;
                        break;
                    }
                }

                if (!sourceMemoryIsEmpty)
                {
                    int last = (int) Number.Floor (Number.Abs (this [LetterRegister.I]));

                    foreach (CardDataset.RegisterRow rr in rrs)
                    {
                        if (rr.Id <= last)
                        {
                            registers [rr.Id] = Number.ReadFromRow (rr);
                        }
                    }
                }
            }
        }

        public void ReadFromDataset (CardDataset cds, Reader reader)
        {
            CardDataset.CardRow cr;
            CardDataset.MemoryRow mr;
            CardDataset.MemoryRow [] mrs;
            CardDataset.RegisterRow [] rrs;

            cr = cds.Card [0];
            mrs = cr.GetMemoryRows ();
            if (mrs.Length > 0)
            {
                mr = mrs [0];
                registers = new Number [mr.RegisterCount];
                rrs = mr.GetRegisterRows ();
                foreach (CardDataset.RegisterRow rr in rrs)
                {
                    registers [rr.Id] = Number.ReadFromRow (rr);
                }
            }
        }

        public void WriteToDataset (CardDataset cds, CardPart part)
        {
            if (part == CardPart.Data)
            {
                CardDataset.MemoryRow mr;
                CardDataset.RegisterRow rr;

                for (int i = 0; i < cds.Memory.Count; i++)
                {
                    cds.Memory.RemoveMemoryRow (cds.Memory [i]);
                }
                mr = cds.Memory.NewMemoryRow ();
                mr.RegisterCount = registers.Length;
                mr.CardRow = cds.Card [0];
                cds.Memory.AddMemoryRow (mr);
                for (int i = 0; i < registers.Length; i++)
                {
                    rr = cds.Register.NewRegisterRow ();
                    rr.Id = i;
                    // rr.Value = ...; // Not used anymore!
                    registers [i].WriteToRow (rr);
                    rr.MemoryRow = mr;
                    cds.Register.AddRegisterRow (rr);
                }
            }
        }

        #endregion

        #region Private Operations

        private Number this [int r]
        {
            get
            {
                return registers [r];
            }
            set
            {
                registers [r] = value;
            }
        }

        private Number this [LetterRegister r]
        {
            get
            {
                return registers [(int) r];
            }
            set
            {
                registers [(int) r] = value;
            }
        }

        private Number this [ΣRegister r]
        {
            get
            {
                return registers [(int) r];
            }
            set
            {
                registers [(int) r] = value;
            }
        }

        private Number this [double r]
        {
            get
            {
                return registers [(int) r];
            }
            set
            {
                registers [(int) r] = value;
            }
        }

        #endregion

        #region Public Properties

        public Number N
        {
            get
            {
                return this [ΣRegister.n];
            }
        }

        #endregion

        #region Public Operations

        public void ΣPlus (Number X, Number Y)
        {
            this [ΣRegister.n]++;
            this [ΣRegister.Σxy] += X * Y;
            this [ΣRegister.Σy2] += Y * Y;
            this [ΣRegister.Σy] += Y;
            this [ΣRegister.Σx2] += X * X;
            this [ΣRegister.Σx] += X;
        }

        public void ΣMinus (Number X, Number Y)
        {
            this [ΣRegister.n]--;
            this [ΣRegister.Σxy] -= X * Y;
            this [ΣRegister.Σy2] -= Y * Y;
            this [ΣRegister.Σy] -= Y;
            this [ΣRegister.Σx2] -= X * X;
            this [ΣRegister.Σx] -= X;
        }

        private void CheckIndex ()
        {
            if (Number.Floor (Number.Abs (this [LetterRegister.I])) > (int) LetterRegister.I)
            {
                throw new Error ();
            }
        }

        public void Clear ()
        {
            for (int i = 0; i <= 9; i++)
            {
                this [i] = 0.0M;
            }
            for (LetterRegister i = LetterRegister.A; i <= LetterRegister.I; i++)
            {
                this [i] = 0.0M;
            }
        }

        public bool DecrementAndSkipIfZero ()
        {
            this [LetterRegister.I]--;
            return Number.Abs (this [LetterRegister.I]) < 1.0M;
        }

        public bool DecrementAndSkipIfZeroIndexed ()
        {
            CheckIndex ();
            this [Number.Floor (Number.Abs (this [LetterRegister.I]))]--;
            return Number.Abs (this [Number.Floor (Number.Abs (this [LetterRegister.I]))]) < 1.0M;
        }

        public void Display ()
        {
            for (int i = 0; i <= 9; i++)
            {
                display.ShowMemory (i, this [i], displayDuration);
            }
            for (LetterRegister i = LetterRegister.A; i <= LetterRegister.I; i++)
            {
                display.ShowMemory ((int) i, this [i], displayDuration);
            }
        }

        public bool IncrementAndSkipIfZero ()
        {
            this [LetterRegister.I]++;
            return Number.Abs (this [LetterRegister.I]) < 1.0M;
        }

        public bool IncrementAndSkipIfZeroIndexed ()
        {
            CheckIndex ();
            this [Number.Floor (Number.Abs (this [LetterRegister.I]))]++;
            return Number.Abs (this [Number.Floor (Number.Abs (this [LetterRegister.I]))]) < 1.0M;
        }

        public void PrimarySecondaryExchange ()
        {
            Number temp;

            for (int i = 0; i <= 9; i++)
            {
                temp = registers [i];
                registers [i] = registers [i + 10];
                registers [i + 10] = temp;
            }
        }

        public void Print ()
        {
            for (int i = 0; i <= 9; i++)
            {
                printer.Formatter.Value = this [i];
                printer.PrintNumeric ();
                printer.PrintAddress (new Digit ((byte) i));
            }
            for (LetterRegister i = LetterRegister.A; i <= LetterRegister.I; i++)
            {
                printer.Formatter.Value = this [i];
                printer.PrintNumeric ();
                printer.PrintAddress
                    (new Letter (Enum.Format (typeof (LetterRegister), i, "G") [0]));
            }
        }

        public Number Recall (Byte Index)
        {
            Trace.Assert (Index <= 9);
            return registers [Index];
        }

        public Number Recall (LetterRegister Index)
        {
            return this [Index];
        }

        public void RecallΣPlus (out Number x, out Number y)
        {
            x = this [ΣRegister.Σx];
            y = this [ΣRegister.Σy];
        }

        public Number RecallIndexed ()
        {
            CheckIndex ();
            return this [Number.Floor (Number.Abs (this [LetterRegister.I]))];
        }

        public void S (out Number x, out Number y)
        {
            int n = Number.Floor (this [ΣRegister.n]);

            if (n <= 1)
            {
                throw new Error ();
            }
            else
            {
                x = Number.Sqrt 
                        ((this [ΣRegister.Σx2] -
                            (this [ΣRegister.Σx] * this [ΣRegister.Σx]) / n) / (n - 1));
                y = Number.Sqrt 
                        ((this [ΣRegister.Σy2] -
                            (this [ΣRegister.Σy] * this [ΣRegister.Σy]) / n) / (n - 1));
            }
        }

        public void Store (Number Value, Byte Index)
        {
            Trace.Assert (Index <= 9);
            registers [Index] = Value;
        }

        public void Store (Number Value, LetterRegister Index)
        {
            this [Index] = Value;
        }

        public void Store (Number Value, Byte Index, Operator Modifier)
        {
            Trace.Assert (Index <= 9);
            registers [Index] = Modifier (registers [Index], Value);
        }

        public void StoreIndexed (Number Value)
        {
            CheckIndex ();
            this [Number.Floor (Number.Abs (this [LetterRegister.I]))] = Value;
        }

        public void StoreIndexed (Number Value, Operator Modifier)
        {
            CheckIndex ();
            this [Number.Floor (Number.Abs (this [LetterRegister.I]))] =
                Modifier (Number.Floor (Number.Abs (this [LetterRegister.I])), Value);
        }

        public void X̄ (out Number x, out Number y)
        {
            int n = Number.Floor (this [ΣRegister.n]);

            if (n == 0)
            {
                throw new Error ();
            }
            else
            {
                x = this [ΣRegister.Σx] / n;
                y = this [ΣRegister.Σy] / n;
            }
        }

        #endregion

    }
}
