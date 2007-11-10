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

Public Class HP97p25 
    Inherits HP97p25Helper

    'Script Name   : HP97p25
    'Generated     : Jun 17, 2007 8:49:42 AM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/17
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Utilities.Move1Left(ToggleManTraceNormButton())
        _1Button().Click()
        _4Button().Click()
        _8Button().Click()
        PeriodButton().Click()
        _8Button().Click()
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        SqrtButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        SquareButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


