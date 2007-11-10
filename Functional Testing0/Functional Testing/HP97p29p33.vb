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

Public Class HP97p29p33 
    Inherits HP97p29p33Helper

    'Script Name   : HP97p29p33
    'Generated     : Jun 24, 2007 2:57:43 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/24
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        Utilities.Move1Left(ToggleManTraceNormButton)
        _1Button().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        ListBoxList().PerformTest(listBox_list_1VP())
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_6VP())
        ListBoxList().PerformTest(listBox_list_2VP())
        Utilities.Move1Right(ToggleManTraceNormButton)
        _1Button().Click()
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_7VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_8VP())
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_9VP())
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_10VP())
        _7Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_11VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_12VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_13VP())
        ListBoxList().PerformTest(listBox_list_3VP())
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        PlusButton().Click()
        _1Button().Click()
        _0Button().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_14VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_15VP())
        ListBoxList().PerformTest(listBox_list_4VP())
        _1Button().Click()
        _6Button().Click()
        ENTERButton().Click()
        _4Button().Click()
        SubButton().Click()
        _3Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_16VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_17VP())
        ListBoxList().PerformTest(listBox_list_5VP())
        _1Button().Click()
        _4Button().Click()
        ENTERButton().Click()
        _7Button().Click()
        PlusButton().Click()
        _3Button().Click()
        PlusButton().Click()
        _2Button().Click()
        SubButton().Click()
        _4Button().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_18VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_19VP())
        ListBoxList().PerformTest(listBox_list_6VP())
        _2Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_20VP())
        ENTERButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_21VP())
        _3Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_22VP())
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_23VP())
        ListBoxList().PerformTest(listBox_list_7VP())
        _4Button().Click()
        ENTERButton().Click()
        _5Button().Click()
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_24VP())
        ListBoxList().PerformTest(listBox_list_8VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_25VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_26VP())
        ListBoxList().PerformTest(listBox_list_9VP())
        _9Button().Click()
        ENTERButton().Click()
        _8Button().Click()
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_27VP())
        _7Button().Click()
        ENTERButton().Click()
        _2Button().Click()
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_28VP())
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_29VP())
        _4Button().Click()
        ENTERButton().Click()
        _5Button().Click()
        MultButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_30VP())
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_31VP())
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_32VP())
        ListBoxList().PerformTest(listBox_list_10VP())
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        MultButton().Click()
        _4Button().Click()
        ENTERButton().Click()
        _5Button().Click()
        MultButton().Click()
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_33VP())
        _1Button().Click()
        _4Button().Click()
        ENTERButton().Click()
        _1Button().Click()
        _2Button().Click()
        PlusButton().Click()
        _1Button().Click()
        _8Button().Click()
        ENTERButton().Click()
        _1Button().Click()
        _2Button().Click()
        SubButton().Click()
        MultButton().Click()
        _9Button().Click()
        ENTERButton().Click()
        _7Button().Click()
        SubButton().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_34VP())
        _1Button().Click()
        _6Button().Click()
        PeriodButton().Click()
        _3Button().Click()
        _8Button().Click()
        ENTERButton().Click()
        _5Button().Click()
        MultButton().Click()
        SqrtButton().Click()
        PeriodButton().Click()
        _0Button().Click()
        _5Button().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_35VP())
        _4Button().Click()
        ENTERButton().Click()
        _1Button().Click()
        _7Button().Click()
        ENTERButton().Click()
        _1Button().Click()
        _2Button().Click()
        SubButton().Click()
        MultButton().Click()
        _1Button().Click()
        _0Button().Click()
        ENTERButton().Click()
        _5Button().Click()
        SubButton().Click()
        DivButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_36VP())
        _2Button().Click()
        ENTERButton().Click()
        _3Button().Click()
        PlusButton().Click()
        _4Button().Click()
        ENTERButton().Click()
        _5Button().Click()
        PlusButton().Click()
        MultButton().Click()
        SqrtButton().Click()
        _6Button().Click()
        ENTERButton().Click()
        _7Button().Click()
        PlusButton().Click()
        _8Button().Click()
        ENTERButton().Click()
        _9Button().Click()
        PlusButton().Click()
        MultButton().Click()
        SqrtButton().Click()
        PlusButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_37VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class