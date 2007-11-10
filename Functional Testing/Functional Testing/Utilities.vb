Imports Microsoft.VisualBasic
Imports Rational.Test.Ft
Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Value
Imports Rational.Test.Ft.Vp
Imports System
Imports System.Threading
Public Class Utilities

    Public Shared Sub Delay(ByVal seconds As Integer)
        Thread.Sleep(seconds * 1000)
    End Sub

    Public Shared Sub Move1Left(ByVal ThreeStateToggle As GuiTestObject)
        ThreeStateToggle.Drag(SubitemFactory.AtPoint(15, 1), SubitemFactory.AtPoint(0, 1))
    End Sub

    Public Shared Sub Move1Right(ByVal ThreeStateToggle As GuiTestObject)
        ThreeStateToggle.Drag(SubitemFactory.AtPoint(0, 1), SubitemFactory.AtPoint(20, 1))
    End Sub

    Public Shared Sub Move2Left(ByVal ThreeStateToggle As GuiTestObject)
        ThreeStateToggle.Drag(SubitemFactory.AtPoint(15, 1), SubitemFactory.AtPoint(0, 1))
        ThreeStateToggle.Drag(SubitemFactory.AtPoint(15, 1), SubitemFactory.AtPoint(0, 1))
    End Sub

    Public Shared Sub Move2Right(ByVal ThreeStateToggle As GuiTestObject)
        ThreeStateToggle.Drag(SubitemFactory.AtPoint(0, 1), SubitemFactory.AtPoint(20, 1))
        ThreeStateToggle.Drag(SubitemFactory.AtPoint(0, 1), SubitemFactory.AtPoint(20, 1))
    End Sub

    Public Shared Function RandomString() As String
        Dim r As New Random
        Return r.Next
    End Function

End Class
	
