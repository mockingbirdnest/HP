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

Public Class HP97PeriodCHS 
    Inherits HP97PeriodCHSHelper

    'Script Name   : HP97PeriodCHS
    'Generated     : Mar 9, 2008 6:06:21 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2008/03/09
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP-97
        PeriodButton().Click()
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        CLXButton().Click()
        _0Button().Click()
        _0Button().Click()
        _0Button().Click()
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        CLXButton().Click()
        PeriodButton().Click()
        _3Button().Click()
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        CLXButton().Click()
        _0Button().Click()
        _1Button().Click()
        _0Button().Click()
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


