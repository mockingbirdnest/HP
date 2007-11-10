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

Public Class HP97p40p42
    Inherits HP97p40p42Helper

    'Script Name   : HP97p40p42
    'Generated     : Jun 24, 2007 5:57:50 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")

        ' Window: Mockingbird.HP.HP97.exe: HP97
        PeriodButton().Click()
        _0Button().NClick(3, Left, AtPoint(85, 20))
        _0Button().Click()
        _1Button().Click()
        _2Button().Click()
        _3Button().Click()
        _4Button().Click()
        _5Button().Click()
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        SCIButton().Click()
        DSPButton().Click()
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _1Button().Click()
        _2Button().Click()
        _3Button().Click()
        _4Button().Click()
        _5Button().Click()
        _6Button().Click()
        _7Button().Click()
        _8Button().Click()
        _9Button().Click()
        _0Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        ENGButton().Click()
        DSPButton().Click()
        _6Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_2VP())
        ToggleOffOnButtonButton().Click()
        ToggleOffOnButtonButton().Click()
        FIXButton().Click()
        DSPButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _7Button().Click()
        _3Button().Click()
        _5Button().Click()
        PeriodButton().Click()
        _4Button().Click()
        _3Button().Click()
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        _2Button().Click()
        _3Button().Click()
        _5Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        _7Button().Click()
        _9Button().Click()
        PeriodButton().Click()
        _9Button().Click()
        _5Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        _5Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        _1Button().Click()
        PeriodButton().Click()
        _4Button().DoubleClick()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        _1Button().Click()
        _7Button().Click()
        PeriodButton().Click()
        _8Button().Click()
        _3Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        _5Button().Click()
        _0Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        _1Button().Click()
        _2Button().Click()
        PeriodButton().Click()
        _4Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        PeriodButton().Click()
        _0Button().NClick(3, LEFT, AtPoint(56,12))
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        ListBoxList().PerformTest(listBox_list_4VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


