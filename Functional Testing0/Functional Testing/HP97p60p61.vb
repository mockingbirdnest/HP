#Region " Script Header "
' Functional Test Script
' author robin
Imports Microsoft.VisualBasic
Imports Rational.Test.Ft
Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Value
Imports Rational.Test.Ft.Vp
Imports Utilities
#End Region

Public Class HP97p60p61 
    Inherits HP97p60p61Helper

    'Script Name   : HP97p60p61
    'Generated     : Nov 9, 2007 7:05:28 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/11/09
    'author robin

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Utilities.Move1Left(ToggleManTraceNormButton())    
        _1Button().Click()
        PeriodButton().Click()
        _1Button().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        _1Button().Click()
        _0Button().Click()
        _0Button().Click()
        _0Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        MultButton().Click()
        ListBoxList().PerformTest(listBox_list_1VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)

    Return Nothing
    End Function
End Class


