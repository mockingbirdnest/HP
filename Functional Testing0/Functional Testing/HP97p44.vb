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

Public Class HP97p44 
    Inherits HP97p44Helper

    'Script Name   : HP97p44
    'Generated     : Jun 24, 2007 9:35:28 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")

        ' Window: Mockingbird.HP.HP97.exe: HP97
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        EEXButton().Click()
        _4Button().Click()
        _9Button().Click()
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        EEXButton().Click()
        _5Button().Click()
        _0Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _1Button().Click()
        _0Button().Click()
        _0Button().Click()
        MultButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


