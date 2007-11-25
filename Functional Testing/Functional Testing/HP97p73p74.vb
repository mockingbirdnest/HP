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

Public Class HP97p73p74 
    Inherits HP97p73p74Helper

    'Script Name   : HP97p73p74
    'Generated     : Nov 25, 2007 1:05:30 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/11/25
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")

        ' Window: Mockingbird.HP.HP97.exe: HP-97
        _2Button().Click()
        _5Button().Click()
        ENTERButton().Click()
        _2Button().Click()
        _7Button().Click()
        _Button().Click()
        _1Button().Click()
        _9Button().Click()
        _Button().Click()
        _2Button().Click()
        _3Button().Click()
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standardVP())
        _5Button().Click()
        _5Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        STOButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _2Button().Click()
        PercentButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        STOButton().Click()
        SubButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ListBoxList().PerformTest(listBox_listVP())
        _2Button().Click()
        _6Button().Click()
        ENTERButton().Click()
        _2Button().Click()
        _8Button().Click()
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _5Button().Click()
        _7Button().Click()
        PeriodButton().Click()
        _5Button().Click()
        _0Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        STOButton().Click()
        _Button().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        _3Button().Click()
        PercentButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        STOButton().Click()
        SubButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        RCLButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


