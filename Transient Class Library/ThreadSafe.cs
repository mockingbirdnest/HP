using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mockingbird.HP.Class_Library
{
    public class ThreadSafe
    {
        private delegate void CrossThreadBringToFront (Control control);
        private delegate string CrossThreadGetText (Control control);
        private delegate void CrossThreadSetEnabled (Control control, bool enabled);
        private delegate void CrossThreadSetFont (Control control, Font font);
        private delegate void CrossThreadSetSize (Control control, Size size);
        private delegate void CrossThreadSetText (Control control, string text);
        private delegate void CrossThreadUpdate (Control control);

        public static void BringToFront (Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThreadBringToFront (BringToFront), new object [] { control });
            }
            else
            {
                control.BringToFront ();
            }
        }

        public static string GetText (Control control)
        {
            if (control.InvokeRequired)
            {
                return (string) control.Invoke (new CrossThreadGetText (GetText), new object [] { control });
            }
            else
            {
                return control.Text;
            }
        }

        public static void SetEnabled (Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThreadSetEnabled (SetEnabled), new object [] { control, enabled });
            }
            else
            {
                control.Enabled = enabled;
            }
        }

        public static void SetFont (Control control, Font font)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThreadSetFont (SetFont), new object [] { control, font });
            }
            else
            {
                control.Font = font;
            }
        }

        public static void SetSize (Control control, Size size)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThreadSetSize (SetSize), new object [] { control, size });
            }
            else
            {
                control.Size = size;
            }
        }


        public static void SetText (Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThreadSetText (SetText), new object [] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public static void Update (Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThreadUpdate (Update), new object [] { control });
            }
            else
            {
                control.BringToFront ();
            }
        }
    }
}
