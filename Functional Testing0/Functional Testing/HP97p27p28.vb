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

Public Class HP97p27p28 
    Inherits HP97p27p28Helper

    'Script Name   : HP97p27p28
    'Generated     : Jun 20, 2007 9:06:28 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/20
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Utilities.Move1Left(ToggleManTraceNormButton)
        _1Button().Click()
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        PlusButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _1Button().Click()
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _1Button().Click()
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _1Button().Click()
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        YToTheXthButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        _1Button().Click()
        _6Button().Click()
        ENTERButton().Click()
        _4Button().Click()
        YToTheXthButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        _8Button().Click()
        _1Button().Click()
        ENTERButton().Click()
        _2Button().Click()
        YToTheXthButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        _2Button().DoubleClick()
        _5Button().Click()
        ENTERButton().Click()
        PeriodButton().Click()
        _5Button().Click()
        YToTheXthButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        _2Button().Click()
        ENTERButton().Click()
        _1Button().Click()
        _6Button().Click()
        YToTheXthButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        _1Button().Click()
        _6Button().Click()
        ENTERButton().Click()
        PeriodButton().Click()
        _2Button().Click()
        _5Button().Click()
        YToTheXthButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


