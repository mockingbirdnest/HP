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

Public Class HP97p42p43 
    Inherits HP97p42p43Helper

    'Script Name   : HP97p42p43
    'Generated     : Jun 24, 2007 8:40:45 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        
        StartApp("Mockingbird.HP.HP97")

        ' Window: Mockingbird.HP.HP97.exe: HP97
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        PeriodButton().Click()
        _0Button().Click()
        _5Button().Click()
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _3Button().Click()
        YToTheXthButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _1Button().Click()
        _5Button().Click()
        _8Button().Click()
        _2Button().Click()
        _0Button().NClick(3, LEFT, AtPoint(36, 15))
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _1Button().Click()
        _8Button().Click()
        _4Button().Click()
        _2Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        _1Button().Click()
        _0Button().Click()
        MultButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


