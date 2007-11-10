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

Public Class HP97p45 
    Inherits HP97p45Helper

    'Script Name   : HP97p45
    'Generated     : Jun 24, 2007 10:13:57 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")

        ' Window: Mockingbird.HP.HP97.exe: HP97
        _4Button().Click()
        CHSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        SqrtButton().Click()
        AlphabeticTextBoxText().PerformTest(alphabeticTextBox_standardVP())
        ListBoxList().PerformTest(listBox_listVP())
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


