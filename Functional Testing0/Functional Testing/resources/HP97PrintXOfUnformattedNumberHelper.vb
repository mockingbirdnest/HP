#Region " DO NOT EDIT: This file is automatically generated "

'Only the associated template file should be edited directly.
'Helper class files are automatically regenerated from the template
'files at various times, including record actions and test object
'insertion actions.  Any changes made directly to a helper class
'file will be lost when automatically updated.

Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Vp



'Script Name   : HP97PrintXOfUnformattedNumber
'Generated     : 2007/11/03 1:49:09 PM
'Description   : Helper class for script
'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2
 
'since  November 03, 2007
'author phl
 
Public MustInherit Class HP97PrintXOfUnformattedNumberHelper 
    Inherits RationalTestScript
    
    '
    ' HP97: with default state.
    '		Name : HP97
    ' 		Text : HP97
    ' 		TabIndex : 0
    ' 		.class : Mockingbird.HP.HP97.HP97
    ' 		.processName : Mockingbird.HP.HP97.exe
    '
    Protected Function HP97Window() As TopLevelSubitemTestObject
        HP97Window = New TopLevelSubitemTestObject(GetMappedTestObject("HP97Window"))
    End Function
    '
    ' HP97: with specific test context and state.
    '		Name : HP97
    ' 		Text : HP97
    ' 		TabIndex : 0
    ' 		.class : Mockingbird.HP.HP97.HP97
    ' 		.processName : Mockingbird.HP.HP97.exe
    '
    Protected Function HP97Window(anchor As TestObject, flags As Long) As  TopLevelSubitemTestObject
        HP97Window = New TopLevelSubitemTestObject(GetMappedTestObject("HP97Window"), anchor, flags)
    End Function
	
    '
    ' listBox: with default state.
    '		Name : listBox
    ' 		TabIndex : 0
    ' 		.class : System.Windows.Forms.ListBox
    ' 		.classIndex : 0
    '
    Protected Function ListBoxList() As SelectGuiSubitemTestObject
        ListBoxList = New SelectGuiSubitemTestObject(GetMappedTestObject("ListBoxList"))
    End Function
    '
    ' listBox: with specific test context and state.
    '		Name : listBox
    ' 		TabIndex : 0
    ' 		.class : System.Windows.Forms.ListBox
    ' 		.classIndex : 0
    '
    Protected Function ListBoxList(anchor As TestObject, flags As Long) As  SelectGuiSubitemTestObject
        ListBoxList = New SelectGuiSubitemTestObject(GetMappedTestObject("ListBoxList"), anchor, flags)
    End Function
	
    '
    ' PRINTX: with default state.
    '		Name : button
    ' 		Text : PRINT x
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function PRINTXButton() As GuiTestObject
        PRINTXButton = New GuiTestObject(GetMappedTestObject("PRINTXButton"))
    End Function
    '
    ' PRINTX: with specific test context and state.
    '		Name : button
    ' 		Text : PRINT x
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function PRINTXButton(anchor As TestObject, flags As Long) As  GuiTestObject
        PRINTXButton = New GuiTestObject(GetMappedTestObject("PRINTXButton"), anchor, flags)
    End Function
	
    '
    ' _1: with default state.
    '		Name : button
    ' 		Text : 1
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _1Button() As GuiTestObject
        _1Button = New GuiTestObject(GetMappedTestObject("_1Button"))
    End Function
    '
    ' _1: with specific test context and state.
    '		Name : button
    ' 		Text : 1
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _1Button(anchor As TestObject, flags As Long) As  GuiTestObject
        _1Button = New GuiTestObject(GetMappedTestObject("_1Button"), anchor, flags)
    End Function
	
    '
    ' _2: with default state.
    '		Name : button
    ' 		Text : 2
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _2Button() As GuiTestObject
        _2Button = New GuiTestObject(GetMappedTestObject("_2Button"))
    End Function
    '
    ' _2: with specific test context and state.
    '		Name : button
    ' 		Text : 2
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _2Button(anchor As TestObject, flags As Long) As  GuiTestObject
        _2Button = New GuiTestObject(GetMappedTestObject("_2Button"), anchor, flags)
    End Function
	
    '
    ' _3: with default state.
    '		Name : button
    ' 		Text : 3
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _3Button() As GuiTestObject
        _3Button = New GuiTestObject(GetMappedTestObject("_3Button"))
    End Function
    '
    ' _3: with specific test context and state.
    '		Name : button
    ' 		Text : 3
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _3Button(anchor As TestObject, flags As Long) As  GuiTestObject
        _3Button = New GuiTestObject(GetMappedTestObject("_3Button"), anchor, flags)
    End Function
	
    '
    ' Locate and return the verification point listBox_list_1 object in the SUT.
    '
    Protected Function listBox_list_1VP() As IFtVerificationPoint
        listBox_list_1VP = vp("listBox_list_1")
    End Function
    Protected Function listBox_list_1VP(anchor As TestObject)As IFtVerificationPoint
        listBox_list_1VP = vp("listBox_list_1", anchor)
    End Function
	
    

    Protected Sub New()
        Dim ISI As Rational.Test.Ft.Script.Impl.IScriptInternal = Me
        ISI.SetScriptName("HP97PrintXOfUnformattedNumber")
    End Sub
End Class
	

#End Region

