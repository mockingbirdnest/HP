using Mockingbird.HP.Persistence;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{

    public enum MessageKind
    {
        Keystroke,
        Open,
        Print,
        Refresh,
        Save
    }

    public enum KeystrokeMotion
    {
        Up,
        Down
    }

    #region Root for Messages

    public abstract class Message : Object
    {

        // By default, messages are executed asynchronously.  If clients want synchronized 
        // execution, they must ask for it.
        private bool synchronous = false;

        public abstract MessageKind Kind
        {
            get;
        }

        public bool Synchronous
        {
            get
            {
                return synchronous;
            }
            set
            {
                synchronous = value;
            }
        }
    }

    #endregion

    #region Concrete Messages

    public class KeystrokeMessage : Message
    {

        private Control control;
        private MouseEventArgs e;
        private KeystrokeMotion motion;

        public KeystrokeMessage (Control control, MouseEventArgs e, KeystrokeMotion motion)
        {
            this.control = control;
            this.e = e;
            this.motion = motion;
        }

        public override MessageKind Kind
        {
            get
            {
                return MessageKind.Keystroke;
            }
        }

        public KeystrokeMotion Motion
        {
            get
            {
                return motion;
            }
        }

        public string Tag
        {
            get
            {
                return (string) control.Tag;
            }
        }
    }

    public class OpenMessage : Message
    {
        private bool merge;
        private FileStream stream;

        public OpenMessage (bool merge, FileStream stream)
        {
            this.merge = merge;
            this.stream = stream;
        }

        public override MessageKind Kind
        {
            get
            {
                return MessageKind.Open;
            }
        }

        public bool Merge
        {
            get
            {
                return merge;
            }
        }

        public FileStream Stream
        {
            get
            {
                return stream;
            }
        }
    }

    public class PrintMessage : Message
    {
        private PrintPageEventArgs e;

        public PrintMessage (PrintPageEventArgs e)
        {
            this.e = e;
        }

        public override MessageKind Kind
        {
            get
            {
                return MessageKind.Print;
            }
        }

        public PrintPageEventArgs Arguments
        {
            get
            {
                return e;
            }
        }
    }

    public class RefreshMessage : Message
    {
        public RefreshMessage ()
        {
        }

        public override MessageKind Kind
        {
            get
            {
                return MessageKind.Refresh;
            }
        }
    }

    public class SaveMessage : Message
    {
        private CardPart part;
        private FileStream stream;

        public SaveMessage (CardPart part, FileStream stream)
        {
            this.part = part;
            this.stream = stream;
        }

        public override MessageKind Kind
        {
            get
            {
                return MessageKind.Save;
            }
        }

        public CardPart Part
        {
            get
            {
                return part;
            }
        }

        public FileStream Stream
        {
            get
            {
                return stream;
            }
        }
    }

#endregion
}
