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

Public Class HP97p47 
    Inherits HP97p47Helper

    'Script Name   : HP97p47
    'Generated     : Jun 25, 2007 7:09:10 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/25
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        FButton().Click()
        PRINTXButton().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standardVP())
        ListBoxList().PerformTest(listBox_listVP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


