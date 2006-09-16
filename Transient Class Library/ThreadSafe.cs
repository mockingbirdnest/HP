using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mockingbird.HP.Class_Library
{
    public static class ThreadSafe
    {
        private delegate int CrossThreadGetInt (Control control);
        private delegate object CrossThreadGetObjectFromInt (Control control, int i);
        private delegate string CrossThreadGetString (Control control);
        private delegate void CrossThread (Control control);
        private delegate void CrossThreadSetBool (Control control, bool b);
        private delegate void CrossThreadSetColor (Control control, Color c);
        private delegate void CrossThreadSetFont (Control control, Font f);
        private delegate void CrossThreadSetInt (Control control, int i);
        private delegate void CrossThreadSetIntObject (Control control, int i, Object o);
        private delegate void CrossThreadSetObject (Control control, Object o);
        private delegate void CrossThreadSetPoint (Control control, Point p);
        private delegate void CrossThreadSetSize (Control control, Size s);
        private delegate void CrossThreadSetString (Control control, string s);

        public static void BringToFront (Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke (new CrossThread (BringToFront), new object [] { control });
            }
            else
            {
                control.BringToFront ();
            }
        }

        public static int GetItemsCount (Control control)
        {
            if (control.InvokeRequired)
            {
                return (int) control.Invoke
                    (new CrossThreadGetInt (GetItemsCount), new object [] { control });
            }
            else
            {
                return ((ListBox) control).Items.Count;
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

        public static void SetTopIndex (Control control, int i)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetInt (SetTopIndex), new object [] { control, i });
            }
            else
            {
                ((ListBox) control).TopIndex = i;
            }
        }

        public static void ItemsAdd (Control control, object o)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetObject (ItemsAdd), new object [] { control, o });
            }
            else
            {
                ((ListBox) control).Items.Add (o);
            }
        }

        public static int ItemsCount (Control control)
        {
            if (control.InvokeRequired)
            {
                return (int) control.Invoke
                    (new CrossThreadGetInt (ItemsCount), new object [] { control });
            }
            else
            {
                return ((ListBox) control).Items.Count;
            }
        }

        public static object ItemsGetItem (Control control, int i)
        {
            if (control.InvokeRequired)
            {
                return control.Invoke
                    (new CrossThreadGetObjectFromInt (ItemsGetItem), new object [] { control, i });
            }
            else
            {
                return ((ListBox) control).Items [i];
            }
        }

        public static void ItemsInsert (Control control, int i, object o)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetIntObject (ItemsInsert), new object [] { control, i, o });
            }
            else
            {
                ((ListBox) control).Items.Insert (i, o);
            }
        }

        public static void ItemsRemoveAt (Control control, int i)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetInt (ItemsRemoveAt), new object [] { control, i });
            }
            else
            {
                ((ListBox) control).Items.RemoveAt (i);
            }
        }

        public static void ItemsSetItem (Control control, int i, object o)
        {
            if (control.InvokeRequired)
            {
                control.Invoke
                    (new CrossThreadSetIntObject (ItemsSetItem), new object [] { control, i, o });
            }
            else
            {
                ((ListBox) control).Items [i] = o;
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
                control.Invoke (new CrossThread (Update), new object [] { control });
            }
            else
            {
                control.BringToFront ();
            }
        }

    }
}
