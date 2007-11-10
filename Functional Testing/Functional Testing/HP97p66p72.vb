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

Public Class HP97p66p72 
    Inherits HP97p66p72Helper

    'Script Name   : HP97p66p72
    'Generated     : Nov 10, 2007 5:37:49 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/11/10
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")

        ' Some setup that is normally obtained by the tests on pp. 64-65.
        Utilities.Move2Left(ButtonButton())
        _6Button().Click()
        _Button2().Click()
        _0Button().Click()
        _2Button().Click()
        EEXButton().Click()
        _2Button().Click()
        _3Button().Click()
        STOButton().Click()
        _2Button().Click()
        XButton().Click()
        STOButton().Click()
        BButton().Click()
        _3Button().Click()
        _Button2().Click()
        _7Button().Click()
        _9Button().Click()
        STOButton().Click()
        IButton().Click()
        Utilities.Move2Right(ButtonButton())

        ' Window: Mockingbird.HP.HP97.exe: HP97
        _1Button().Click()
        _6Button().Click()
        _4Button().Click()
        _9Button().Click()
        _5Button().Click()
        _0Button().NClick(3, LEFT, AtPoint(104, 23))
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        STOButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        RCLButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        RCLButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        _5Button().Click()
        _Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        STOButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        ListBoxList().PerformTest(listBox_list_4VP())
        RCLButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        RCLButton().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        ListBoxList().PerformTest(listBox_list_5VP())
        FButton().Click()
        ENGButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        ListBoxList().PerformTest(listBox_list_6VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        FButton().Click()
        ENGButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        ListBoxList().PerformTest(listBox_list_7VP())
        _0Button().Click()
        STOButton().Click()
        BButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        FButton().Click()
        ENGButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        PrinterFeedButtonButton().Click()
        FButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_19VP())
        FButton().Click()
        ENGButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_20VP())
        ListBoxList().PerformTest(listBox_list_8VP())
        FButton().Click()
        CLXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_21VP())
        FButton().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_22VP())
        FButton().Click()
        ENGButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_23VP())
        ListBoxList().PerformTest(listBox_list_9VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


