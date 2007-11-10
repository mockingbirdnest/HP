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

Public Class HP97p65 
    Inherits HP97p65Helper

    'Script Name   : HP97p65
    'Generated     : Nov 10, 2007 2:22:15 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/11/10
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _3Button().Click()
        _Button().Click()
        _7Button().Click()
        _8Button().Click()
        _5Button().Click()
        STOButton().Click()
        IButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standardVP())
        _2Button().Click()
        _Button2().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _1Button().Click()
        _4Button().Click()
        _Button().Click()
        _4Button().Click()
        IButton().Click()
        _Button2().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        _5Button().Click()
        _5Button().Click()
        IButton().Click()
        _Button2().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        ListBoxList().PerformTest(listBox_listVP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


