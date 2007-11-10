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

Public Class HP97p53p54 
    Inherits HP97p53p54Helper

    'Script Name   : HP97p53p54
    'Generated     : Oct 11, 2007 1:32:26 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/10/11
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _3Button().Click()
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _2Button().Click()
        _1Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        FButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        FButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


