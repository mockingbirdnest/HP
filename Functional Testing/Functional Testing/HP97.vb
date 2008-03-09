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

Public Class HP97 
    Inherits HP97Helper

    'Script Name   : HP97
    'Generated     : Jun 17, 2007 10:05:41 AM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/17
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        CallScript("HP97p14")
        CallScript("HP97p15p17")
        CallScript("HP97p18p19")
        CallScript("HP97p24")
        CallScript("HP97p25")
        CallScript("HP97p27")
        CallScript("HP97p27p28")
        CallScript("HP97p29p33")
        CallScript("HP97p35p39")
        CallScript("HP97p40p42")
        CallScript("HP97p42p43")
        CallScript("HP97p43p44")
        CallScript("HP97p44")
        CallScript("HP97p45")
        CallScript("HP97p47")
        CallScript("HP97p48p53")
        CallScript("HP97p53p54")
        CallScript("HP97p55p57")
        CallScript("HP97p58")
        CallScript("HP97p59")
        CallScript("HP97p59p60")
        CallScript("HP97p60p61")
        CallScript("HP97p64p65")
        CallScript("HP97p65")
        CallScript("HP97p66p72")
        CallScript("HP97p73p74")

        CallScript("HP97PeriodCHS")
        CallScript("HP97PrintXOfUnformattedNumber")
        CallScript("HP97PrintXStartup")

        Return Nothing
    End Function
End Class


