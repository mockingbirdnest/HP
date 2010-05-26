using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void PeriodCHS ()
        {
            UIMap.Period ();
            UIMap.CHS ();
            UIMap.AssertNumeric (" .             ");
            UIMap.CLx ();
            UIMap.Zero ();
            UIMap.Zero ();
            UIMap.Zero ();
            UIMap.CHS ();
            UIMap.AssertNumeric (" 000.          ");
            UIMap.CLx ();
            UIMap.Period ();
            UIMap.Three ();
            UIMap.CHS ();
            UIMap.AssertNumeric ("-.3            ");
            UIMap.CLx ();
            UIMap.Zero ();
            UIMap.One ();
            UIMap.Zero ();
            UIMap.CHS ();
            UIMap.AssertNumeric ("-010.          ");
        }
    }
}
