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

Public Class HP97p15p17 
    Inherits HP97p15p17Helper

    'Script Name   : HP97p15p17
    'Generated     : Jun 18, 2007 12:20:30 PM
    'Description   : Functional Test Script
    'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2 

    'since  2007/06/18
    'author phl

    Public Function TestMain(ByVal args() As Object) As Object
        StartApp("Mockingbird.HP.HP97")
        
        ' Window: Mockingbird.HP.HP97.exe: HP97
        MenuStripMenuBar().Click(AtText("File"))
        MenuStripMenuBar().Click(AtPath("File->Open..."))
        
        ' Window: Mockingbird.HP.HP97.exe: Open
        MyComputerButton().Click(AtPoint(49, 24))
        MyDocumentsButton().Click(AtPoint(55, 32))
        FolderViewTable().Click(AtText("My Projects"), AtPoint(34, 5))
        OpenButton().Click(AtPoint(33, 8))
        FolderViewTable().Click(AtText("Mockingbird"), AtPoint(38, 9))
        OpenButton().Click(AtPoint(23, 12))
        FolderViewTable().Click(AtText("HP"), AtPoint(10, 9))
        OpenButton().Click(AtPoint(23, 15))
        FolderViewTable().Click(AtText("Pacs"), AtPoint(30, 9))
        OpenButton().Click(AtPoint(59, 6))
        FolderViewTable().Click(AtText("Standard Pac"), AtPoint(35, 11))
        OpenButton().Click(AtPoint(23, 17))
        OpenComboBox().Click(ARROW)
        OpenComboBox().Click(AtText("All files (*.*)"))
        FolderViewTable().Click(AtText("Calendar Functions.hp67"), _
                                AtPoint(79, 6))
        OpenButton().Click(AtPoint(13, 16))

        ' Window: Mockingbird.HP.HP97.exe: HP97
        Move2Left(ToggleManTraceNormButton())
        _0Button().Click()
        _9Button().Click()
        PeriodButton().Click()
        _0Button().Click()
        _3Button().Click()
        _1Button().Click()
        _9Button().Click()
        _4Button().DoubleClick()
        NumericTextBoxText().PerformTest(numericTextBox_standard_1VP())
        AButton().Click()
        Utilities.Delay(2)
        NumericTextBoxText().PerformTest(numericTextBox_standard_2VP())
        _1Button().DoubleClick()
        PeriodButton().Click()
        _2Button().Click()
        _1Button().DoubleClick()
        _9Button().Click()
        _7Button().Click()
        _5Button().Click()
        NumericTextBoxText().PerformTest(numericTextBox_standard_3VP())
        BButton().Click()
        Utilities.Delay(2)
        NumericTextBoxText().PerformTest(numericTextBox_standard_4VP())
        CButton().Click()
        Utilities.Delay(2)
        NumericTextBoxText().PerformTest(numericTextBox_standard_5VP())
        HP97Window(ANY, MAY_EXIT).Click(CLOSE_BUTTON)
    Return Nothing
    End Function
End Class


