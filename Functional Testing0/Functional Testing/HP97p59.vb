#Region " Script Header "
' Functional Test Script
' author robin
Imports Microsoft.VisualBasic
Imports Rational.Test.Ft
Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Value
Imports Rational.Test.Ft.Vp
Imports Utilities
#End Region

Public Class HP97p59 
    Inherits HP97p59Helper

    'Script Name   : HP97p59
    'Generated     : Oct 27, 2007 6:29:26 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/10/27
    'author robin

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _1Button().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _3Button().Click()
        _Button().Click()
        _1Button().Click()
        _5Button().Click()
        _7Button().Click()
        _Button2().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        FButton().Click()
        DSPButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _Button3().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        _2Button().Click()
        _Button().Click()
        _1Button().Click()
        _5Button().Click()
        _7Button().Click()
        _Button2().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


