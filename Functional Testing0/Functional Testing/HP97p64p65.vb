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

Public Class HP97p64p65 
    Inherits HP97p64p65Helper

    'Script Name   : HP97p64p65
    'Generated     : Nov 9, 2007 10:07:04 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/11/09
    'author robin

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _6Button().Click()
        PeriodButton().Click()
        _0Button().Click()
        _2Button().Click()
        EEXButton().Click()
        _2Button().Click()
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        STOButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        XButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        STOButton().Click()
        BButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        RCLButton().Click()
        BButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        RCLButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        ListBoxList().PerformTest(listBox_list_4VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


