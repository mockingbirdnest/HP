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

Public Class HP97PrintXOfUnformattedNumber 
    Inherits HP97PrintXOfUnformattedNumberHelper

    'Script Name   : HP97PrintXOfUnformattedNumber
    'Generated     : Nov 3, 2007 1:43:25 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/11/03
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        _1Button().Click()
        _2Button().Click()
        _3Button().Click()
        PRINTXButton().Click()
        ListBoxList().PerformTest(listBox_list_1VP())
        HP97Window(ANY,MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


