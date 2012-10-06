'===============================================================================
'                   EntitySpaces 2010 by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2010.1.0726.0
' EntitySpaces Driver  : SQL
' Date Generated       : 7/31/2010 9:21:25 PM
'===============================================================================

Imports System

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace BusinessObjects

	Partial Public Class ConstructorTest 
		Inherits esConstructorTest

        Public Sub New()
            Me.DefaultDateTime = DateTime.Now
            Me.DefaultBool = False
            Me.DefaultInt = 0
            Me.DefaultString = "[new]"
        End Sub
		
	End Class

End Namespace
