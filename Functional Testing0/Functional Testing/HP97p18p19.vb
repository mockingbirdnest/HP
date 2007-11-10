#Region " Script Header "
' Functional Test Script
' author phl
Imports Microsoft.VisualBasic
Imports Rational.Test.Ft
Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Value
Imports Rational.Test.Ft.Vp
Imports Utilities
#End Region

Public Class HP97p18p19 
    Inherits HP97p18p19Helper

    'Script Name   : HP97p18p19
    'Generated     : Jun 16, 2007 10:49:33 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/16
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        toggleWpgrmRunButton().Click()
        FButton().Click()
        _3Button().Click()
        LBLButton().Click()
        AButton().Click()
        SquareButton().Click()
        FButton().Click()
        DivButton().Click()
        MultButton().Click()
        PRINTXButton().Click()
        RTNButton().Click()
        toggleWpgrmRunButton().Click()
        _3Button().Click()
        _2Button().Click()
        _0Button().DoubleClick()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        AButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _2Button().Click()
        _3Button().Click()
        _1Button().Click()
        _0Button().Click()
        AButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _1Button().Click()
        _9Button().Click()
        _5Button().Click()
        _0Button().Click()
        AButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _3Button().Click()
        _2Button().DoubleClick()
        _0Button().Click()
        AButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        MenuStripMenuBar().Click(AtText("Edit"))
        MenuStripMenuBar().Click(AtPath("Edit->Edit Labels"))
        TitleTextBoxText().DoubleClick(AtPoint(106,10))
        TitleTextBoxText().Hover(AtPoint(106,10))
        HP97Window().InputKeys("SPHERE SURFACE AREA{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("d->A{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}{TAB}")
        HP97Window().InputKeys("{BKSP}")
        MenuStripMenuBar().Click(AtText("File"))
        toggleWpgrmRunButton().Click()
        MenuStripMenuBar().Click(AtText("File"))
        MenuStripMenuBar().Click(AtPath("File->Save"))
        
        ' Window: Mockingbird.HP.HP97.exe: Save As
        MyDocumentsButton().Click(AtPoint(63, 44))
        SaveAsWindow().InputChars("CardFile" + Utilities.RandomString())
        SaveButton().Click(AtPoint(29, 6))
        Utilities.Delay(2)

        ' Window: Mockingbird.HP.HP97.exe: HP97
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


