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

Public Class HP97p48p53 
    Inherits HP97p48p53Helper

    'Script Name   : HP97p48p53
    'Generated     : Aug 15, 2007 5:40:05 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/08/15
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _4Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        ENTERButton().Click()
        _2Button().Click()
        ENTERButton().Click()
        _1Button().Click()
        ListBoxList().PerformTest(listBox_list_1VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_2VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        RDownButton().Click()
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_3VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        RDownButton().Click()
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_4VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        RDownButton().Click()
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_5VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        RDownButton().Click()
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_6VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_7VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        XExchangeYButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_8VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        CLXButton().Click()
        FButton().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_9VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        HP97Window().Click(CAPTION)
        _3Button().Click()
        _1Button().Click()
        _4Button().Click()
        _Button().Click()
        _3Button().Click()
        _2Button().Click()
        ENTERButton().Click()
        ListBoxList().PerformTest(listBox_list_10VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        _5Button().Click()
        _4Button().Click()
        _3Button().Click()
        _Button().Click()
        _2Button().Click()
        _8Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        _6Button().Click()
        _8Button().Click()
        _9Button().Click()
        _Button().Click()
        _4Button().Click()
        SqrtButton().Click()
        ListBoxList().PerformTest(listBox_list_11VP())
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


