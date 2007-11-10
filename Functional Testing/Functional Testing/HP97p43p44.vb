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

Public Class HP97p43p44 
    Inherits HP97p43p44Helper

    'Script Name   : HP97p43p44
    'Generated     : Jun 24, 2007 9:20:57 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _1Button().Click()
        _5Button().Click()
        PeriodButton().Click()
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        EEXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _1Button().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _2Button().Click()
        _5Button().Click()
        MultButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        EEXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        _5Button().Click()
        _2Button().Click()
        DivButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        SCIButton().Click()
        DSPButton().Click()
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        FIXButton().Click()
        DSPButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        _6Button().Click()
        PeriodButton().Click()
        _6Button().Click()
        _2Button().Click()
        _5Button().Click()
        EEXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        _2Button().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        _5Button().Click()
        _0Button().Click()
        MultButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        ListBoxList().PerformTest(listBox_list_4VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


