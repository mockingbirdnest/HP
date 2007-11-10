#Region " Script Header "
' Functional Test Script
' author Administrator
Imports Microsoft.VisualBasic
Imports Rational.Test.Ft
Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Value
Imports Rational.Test.Ft.Vp
Imports Utilities
#End Region

Public Class HP97p14 
    Inherits HP97p14Helper

    'Script Name   : HP97p14
    'Generated     : Jun 16, 2007 8:44:12 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/16
    'author Administrator

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Move2Left(toggleManTraceNormButton())
        _5Button().Click()
        ENTERButton().Click()
        _6Button().Click()
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        _8Button().Click()
        ENTERButton().Click()
        _2Button().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _7Button().Click()
        ENTERButton().Click()
        _4Button().Click()
        SubButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        _5Button().Click()
        ReciprocalButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _3Button().Click()
        _0Button().Click()
        SINButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        Move2Right(toggleManTraceNormButton())
        _3Button().Click()
        _2Button().Click()
        _0Button().DoubleClick()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        SquareButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        FButton().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        ListBoxList().PerformTest(listBox_listVP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


