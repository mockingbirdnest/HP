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

Public Class HP97p55p57 
    Inherits HP97p55p57Helper

    'Script Name   : HP97p55p57
    'Generated     : Oct 27, 2007 5:28:07 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/10/27
    'author robin

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _1Button().Click()
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _3Button().Click()
        _0Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _1Button().DoubleClick()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _1Button().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        _Button().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        CLXButton().Click()
        _1Button().Click()
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        _3Button().Click()
        _0Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        _1Button().Click()
        _1Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        _1Button().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        _Button().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


