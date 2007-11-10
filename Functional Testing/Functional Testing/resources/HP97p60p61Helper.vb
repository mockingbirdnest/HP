#Region " DO NOT EDIT: This file is automatically generated "

'Only the associated template file should be edited directly.
'Helper class files are automatically regenerated from the template
'files at various times, including record actions and test object
'insertion actions.  Any changes made directly to a helper class
'file will be lost when automatically updated.

Imports Rational.Test.Ft.Object.Interfaces
Imports Rational.Test.Ft.Script
Imports Rational.Test.Ft.Vp



'Script Name   : HP97p60p61
'Generated     : 2007/11/09 7:38:49 PM
'Description   : Helper class for script
'Original Host : Windows XP x86 5.1 build 2600 Service Pack 2
 
'since  November 09, 2007
'author robin
 
Public MustInherit Class HP97p60p61Helper 
    Inherits RationalTestScript
    
    '
    ' ENTER: with default state.
    '		Name : button
    ' 		Text : ENTER ↑
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function ENTERButton() As GuiTestObject
        ENTERButton = New GuiTestObject(GetMappedTestObject("ENTERButton"))
    End Function
    '
    ' ENTER: with specific test context and state.
    '		Name : button
    ' 		Text : ENTER ↑
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function ENTERButton(anchor As TestObject, flags As Long) As  GuiTestObject
        ENTERButton = New GuiTestObject(GetMappedTestObject("ENTERButton"), anchor, flags)
    End Function
	
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
    ' _: with default state.
    '		Name : button
    ' 		Text : ×
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function MultButton() As GuiTestObject
        MultButton = New GuiTestObject(GetMappedTestObject("MultButton"))
    End Function
    '
    ' _: with specific test context and state.
    '		Name : button
    ' 		Text : ×
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function MultButton(anchor As TestObject, flags As Long) As  GuiTestObject
        MultButton = New GuiTestObject(GetMappedTestObject("MultButton"), anchor, flags)
    End Function
	
    '
    ' numericTextBox: with default state.
    '		Name : numericTextBox
    ' 		TabIndex : 0
    ' 		.class : System.Windows.Forms.TextBox
    ' 		.classIndex : 0
    '
    Protected Function NumericTextBoxText() As TextGuiSubitemTestObject
        NumericTextBoxText = New TextGuiSubitemTestObject(GetMappedTestObject("NumericTextBoxText"))
    End Function
    '
    ' numericTextBox: with specific test context and state.
    '		Name : numericTextBox
    ' 		TabIndex : 0
    ' 		.class : System.Windows.Forms.TextBox
    ' 		.classIndex : 0
    '
    Protected Function NumericTextBoxText(anchor As TestObject, flags As Long) As  TextGuiSubitemTestObject
        NumericTextBoxText = New TextGuiSubitemTestObject(GetMappedTestObject("NumericTextBoxText"), anchor, flags)
    End Function
	
    '
    ' _: with default state.
    '		Name : button
    ' 		Text :  ・
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function PeriodButton() As GuiTestObject
        PeriodButton = New GuiTestObject(GetMappedTestObject("PeriodButton"))
    End Function
    '
    ' _: with specific test context and state.
    '		Name : button
    ' 		Text :  ・
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function PeriodButton(anchor As TestObject, flags As Long) As  GuiTestObject
        PeriodButton = New GuiTestObject(GetMappedTestObject("PeriodButton"), anchor, flags)
    End Function
	
    '
    ' button: with default state.
    '		Name : button
    ' 		Text : 
    ' 		TabIndex : 5
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function ToggleManTraceNormButton() As GuiTestObject
        ToggleManTraceNormButton = New GuiTestObject(GetMappedTestObject("ToggleManTraceNormButton"))
    End Function
    '
    ' button: with specific test context and state.
    '		Name : button
    ' 		Text : 
    ' 		TabIndex : 5
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function ToggleManTraceNormButton(anchor As TestObject, flags As Long) As  GuiTestObject
        ToggleManTraceNormButton = New GuiTestObject(GetMappedTestObject("ToggleManTraceNormButton"), anchor, flags)
    End Function
	
    '
    ' _0: with default state.
    '		Name : button
    ' 		Text : 0
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _0Button() As GuiTestObject
        _0Button = New GuiTestObject(GetMappedTestObject("_0Button"))
    End Function
    '
    ' _0: with specific test context and state.
    '		Name : button
    ' 		Text : 0
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _0Button(anchor As TestObject, flags As Long) As  GuiTestObject
        _0Button = New GuiTestObject(GetMappedTestObject("_0Button"), anchor, flags)
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
    ' _5: with default state.
    '		Name : button
    ' 		Text : 5
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _5Button() As GuiTestObject
        _5Button = New GuiTestObject(GetMappedTestObject("_5Button"))
    End Function
    '
    ' _5: with specific test context and state.
    '		Name : button
    ' 		Text : 5
    ' 		TabIndex : 1
    ' 		.class : System.Windows.Forms.Button
    ' 		.classIndex : 0
    '
    Protected Function _5Button(anchor As TestObject, flags As Long) As  GuiTestObject
        _5Button = New GuiTestObject(GetMappedTestObject("_5Button"), anchor, flags)
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
	
    '
    ' Locate and return the verification point listBox_list_2 object in the SUT.
    '
    Protected Function listBox_list_2VP() As IFtVerificationPoint
        listBox_list_2VP = vp("listBox_list_2")
    End Function
    Protected Function listBox_list_2VP(anchor As TestObject)As IFtVerificationPoint
        listBox_list_2VP = vp("listBox_list_2", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_1 object in the SUT.
    '
    Protected Function numericTextBox_standard_1VP() As IFtVerificationPoint
        numericTextBox_standard_1VP = vp("numericTextBox_standard_1")
    End Function
    Protected Function numericTextBox_standard_1VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_1VP = vp("numericTextBox_standard_1", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_10 object in the SUT.
    '
    Protected Function numericTextBox_standard_10VP() As IFtVerificationPoint
        numericTextBox_standard_10VP = vp("numericTextBox_standard_10")
    End Function
    Protected Function numericTextBox_standard_10VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_10VP = vp("numericTextBox_standard_10", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_11 object in the SUT.
    '
    Protected Function numericTextBox_standard_11VP() As IFtVerificationPoint
        numericTextBox_standard_11VP = vp("numericTextBox_standard_11")
    End Function
    Protected Function numericTextBox_standard_11VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_11VP = vp("numericTextBox_standard_11", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_2 object in the SUT.
    '
    Protected Function numericTextBox_standard_2VP() As IFtVerificationPoint
        numericTextBox_standard_2VP = vp("numericTextBox_standard_2")
    End Function
    Protected Function numericTextBox_standard_2VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_2VP = vp("numericTextBox_standard_2", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_3 object in the SUT.
    '
    Protected Function numericTextBox_standard_3VP() As IFtVerificationPoint
        numericTextBox_standard_3VP = vp("numericTextBox_standard_3")
    End Function
    Protected Function numericTextBox_standard_3VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_3VP = vp("numericTextBox_standard_3", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_4 object in the SUT.
    '
    Protected Function numericTextBox_standard_4VP() As IFtVerificationPoint
        numericTextBox_standard_4VP = vp("numericTextBox_standard_4")
    End Function
    Protected Function numericTextBox_standard_4VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_4VP = vp("numericTextBox_standard_4", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_5 object in the SUT.
    '
    Protected Function numericTextBox_standard_5VP() As IFtVerificationPoint
        numericTextBox_standard_5VP = vp("numericTextBox_standard_5")
    End Function
    Protected Function numericTextBox_standard_5VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_5VP = vp("numericTextBox_standard_5", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_6 object in the SUT.
    '
    Protected Function numericTextBox_standard_6VP() As IFtVerificationPoint
        numericTextBox_standard_6VP = vp("numericTextBox_standard_6")
    End Function
    Protected Function numericTextBox_standard_6VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_6VP = vp("numericTextBox_standard_6", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_7 object in the SUT.
    '
    Protected Function numericTextBox_standard_7VP() As IFtVerificationPoint
        numericTextBox_standard_7VP = vp("numericTextBox_standard_7")
    End Function
    Protected Function numericTextBox_standard_7VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_7VP = vp("numericTextBox_standard_7", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_8 object in the SUT.
    '
    Protected Function numericTextBox_standard_8VP() As IFtVerificationPoint
        numericTextBox_standard_8VP = vp("numericTextBox_standard_8")
    End Function
    Protected Function numericTextBox_standard_8VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_8VP = vp("numericTextBox_standard_8", anchor)
    End Function
	
    '
    ' Locate and return the verification point numericTextBox_standard_9 object in the SUT.
    '
    Protected Function numericTextBox_standard_9VP() As IFtVerificationPoint
        numericTextBox_standard_9VP = vp("numericTextBox_standard_9")
    End Function
    Protected Function numericTextBox_standard_9VP(anchor As TestObject)As IFtVerificationPoint
        numericTextBox_standard_9VP = vp("numericTextBox_standard_9", anchor)
    End Function
	
    

    Protected Sub New()
        Dim ISI As Rational.Test.Ft.Script.Impl.IScriptInternal = Me
        ISI.SetScriptName("HP97p60p61")
    End Sub
End Class
	

#End Region
