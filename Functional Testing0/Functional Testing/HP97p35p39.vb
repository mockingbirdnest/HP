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

Public Class HP97p35p39 
    Inherits HP97p35p39Helper

    'Script Name   : HP97p35p39
    'Generated     : Jun 24, 2007 4:09:11 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        Utilities.Move2Left(ToggleManTraceNormButton())
        ToggleOffOnButton().Click()
        ToggleOffOnButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        DSPButton().Click()
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        DSPButton().Click()
        _9Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        DSPButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ToggleOffOnButton().Click()
        ToggleOffOnButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _1Button().Click()
        _2Button().Click()
        _3Button().Click()
        PeriodButton().Click()
        _4Button().Click()
        _5Button().Click()
        _6Button().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        SCIButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        DSPButton().Click()
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        DSPButton().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        DSPButton().Click()
        _9Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        DSPButton().Click()
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        _1Button().Click()
        _2Button().Click()
        _3Button().Click()
        PeriodButton().Click()
        _4Button().Click()
        _5Button().Click()
        _6Button().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        FIXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        DSPButton().Click()
        _0Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        DSPButton().Click()
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        DSPButton().Click()
        _1Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        DSPButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        PeriodButton().Click()
        _0Button().NClick(4, LEFT, AtPoint(55, 20))
        _1Button().Click()
        _2Button().Click()
        _3Button().Click()
        _4Button().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_19VP())
        ENGButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_20VP())
        DSPButton().Click()
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_21VP())
        DSPButton().Click()
        _9Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_22VP())
        DSPButton().Click()
        _0Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_23VP())
        DSPButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_24VP())
        _1Button().Click()
        _0Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_25VP())
        _1Button().Click()
        _0Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_26VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


