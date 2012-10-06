'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:25 PM
'===============================================================================

Imports System
Imports System.ComponentModel.DataAnnotations

Namespace BusinessObjects

	<MetadataType(GetType(EmployeesValidation))> _
	Public Partial Class Employees

	End Class

    Friend Class EmployeesValidation
    

		<KeyAttribute()> _
		<Editable(false)> _
		Public Property EmployeeID As Nullable(Of System.Int32)

		<StringLength(20)> _
		<Required> _
		Public Property LastName As System.String

		<StringLength(10)> _
		<Required> _
		Public Property FirstName As System.String

		<StringLength(30)> _
		Public Property Title As System.String

		<StringLength(25)> _
		Public Property TitleOfCourtesy As System.String

		Public Property BirthDate As Nullable(Of System.DateTime)

		Public Property HireDate As Nullable(Of System.DateTime)

		<StringLength(60)> _
		Public Property Address As System.String

		<StringLength(15)> _
		Public Property City As System.String

		<StringLength(15)> _
		Public Property Region As System.String

		<StringLength(10)> _
		Public Property PostalCode As System.String

		<StringLength(15)> _
		Public Property Country As System.String

		<StringLength(24)> _
		Public Property HomePhone As System.String

		<StringLength(4)> _
		Public Property Extension As System.String

		Public Property Photo As System.Byte()

		<StringLength(1073741823)> _
		Public Property Notes As System.String

		Public Property ReportsTo As Nullable(Of System.Int32)

		<StringLength(255)> _
		Public Property PhotoPath As System.String
    
	End Class
End Namespace