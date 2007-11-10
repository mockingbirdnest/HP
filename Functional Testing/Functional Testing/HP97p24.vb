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

Public Class HP97p24 
    Inherits HP97p24Helper

    'Script Name   : HP97p24
    'Generated     : Jun 20, 2007 8:59:24 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/20
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Move2Left(toggleManTraceNormButton())
        _1Button().Click()
        _4Button().Click()
        _8Button().Click()
        PeriodButton().Click()
        _8Button().Click()
        _4Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


