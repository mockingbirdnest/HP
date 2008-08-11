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

Public Class HP97TrigonometricsLargeAngles 
    Inherits HP97TrigonometricsLargeAnglesHelper

    'Script Name   : HP97TrigonometricsLargeAngles
    'Generated     : Aug 11, 2008 12:10:49 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2008/08/11
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP-97
        FButton().Click()
        CHSButton().Click()
        EEXButton().Click()
        _1Button().Click()
        _0Button().Click()
        SINButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        DSPButton().Click()
        _9Button().Click()
        SCIButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        EEXButton().Click()
        _2Button().Click()
        _0Button().Click()
        COSButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        EEXButton().Click()
        _4Button().Click()
        _0Button().Click()
        TANButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        EEXButton().Click()
        _8Button().Click()
        _0Button().Click()
        ENTERButton().Click()
        CHSButton().Click()
        SINButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
        Return Nothing
    End Function
End Class


