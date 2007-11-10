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

Public Class HP97p27 
    Inherits HP97p27Helper

    'Script Name   : HP97p27
    'Generated     : Jun 17, 2007 11:21:19 AM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/17
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Utilities.Move1Left(ToggleManTraceNormButton())
        _4Button().Click()
        Utilities.Delay(1) ' For some reason the first update of the display takes time.
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ReciprocalButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _2Button().Click()
        _5Button().Click()
        ReciprocalButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _2Button().Click()
        _5Button().Click()
        _0Button().DoubleClick()
        SqrtButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _5Button().Click()
        FButton().Click()
        ExpButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        _3Button().Click()
        _2Button().Click()
        _0Button().Click()
        _4Button().Click()
        _1Button().Click()
        _0Button().DoubleClick()
        SqrtButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        _1Button().Click()
        _2Button().Click()
        PeriodButton().Click()
        _5Button().Click()
        _8Button().Click()
        _9Button().Click()
        _2Button().Click()
        _5Button().Click()
        _4Button().Click()
        _1Button().DoubleClick()
        FButton().Click()
        LNButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        _7Button().Click()
        _1Button().Click()
        SquareButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


