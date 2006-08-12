using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mockingbird.HP.Class_Library
{
    public class ThreadSafe
    {
        private delegate void CrossThreadBringToFront (Control control);
        private delegate string CrossThreadGetString (Control control);
        private delegate void CrossThreadSetBool (Control control, bool b);
        private delegate void CrossThreadSetColor (Control control, Color c);
        private delegate void CrossThreadSetFont (Control control, Font f);
        private delegate void CrossThreadSetPoint (Control control, Point p);
        private delegate void CrossThreadSetSize (Control control, Size s);
        private delegate void CrossThreadSetString (Control control, string s);
        private delegate void CrossThreadUpdate (Control control);

        public static void BringToFront (Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadBringToFront (BringToFront), new object [] { control });
            }
            else
            {
                control.BringToFront ();
            }
        }

        public static string GetRtf (Control control)
        {
            if (control.InvokeRequired)
            {
                return (string) control.Invoke
                    (new CrossThreadGetString (GetRtf), new object [] { control });
            }
            else
            {
                return ((RichTextBox) control).Rtf;
            }
        }

        public static string GetText (Control control)
        {
            if (control.InvokeRequired)
            {
                return (string) control.Invoke
                    (new CrossThreadGetString (GetText), new object [] { control });
            }
            else
            {
                return control.Text;
            }
        }

        public static void SetBackColor (Control control, Color backColor)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetColor (SetBackColor), new object [] { control, backColor });
            }
            else
            {
                control.BackColor = backColor;
            }
        }

        public static void SetEnabled (Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetBool (SetEnabled), new object [] { control, enabled });
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
                control.Invoke
                    (new CrossThreadSetFont (SetFont), new object [] { control, font });
            }
            else
            {
                control.Font = font;
            }
        }

        public static void SetLocation (Control control, Point point)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetPoint (SetLocation), new object [] { control, point });
            }
            else
            {
                control.Location = point;
            }
        }

        public static void SetReadOnly (Control control, bool readOnly)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetBool (SetReadOnly), new object [] { control, readOnly });
            }
            else
            {
                ((TextBoxBase) control).ReadOnly = readOnly;
            }
        }

        public static void SetRtf (Control control, string rtf)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetString (SetRtf), new object [] { control, rtf });
            }
            else
            {
                ((RichTextBox) control).Rtf = rtf;
            }
        }

        public static void SetSize (Control control, Size size)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetSize (SetSize), new object [] { control, size });
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
                control.Invoke
                    (new CrossThreadSetString (SetText), new object [] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public static void SetVisible (Control control, bool visible)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetBool (SetVisible), new object [] { control, visible });
            }
            else
            {
                control.Visible = visible;
            }
        }

        public static void Update (Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadUpdate (Update), new object [] { control });
            }
            else
            {
                control.BringToFront ();
            }
        }

    }
}
