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

Public Class HP97p58 
    Inherits HP97p58Helper

    'Script Name   : HP97p58
    'Generated     : Oct 27, 2007 5:54:28 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/10/27
    'author robin

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        _Button2().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        _Button3().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        _Button4().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        _Button5().Click()
        _2Button().Click()
        _1Button().Click()
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        _Button3().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_19VP())
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_20VP())
        _Button3().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_21VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_22VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


