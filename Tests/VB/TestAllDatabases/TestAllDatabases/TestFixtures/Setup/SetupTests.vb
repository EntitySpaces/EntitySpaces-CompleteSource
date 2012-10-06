'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
Imports BusinessObjects
Imports EntitySpaces.Interfaces

Namespace Tests.Base
	<SetUpFixture> _
	Public Class SetupTests
		<SetUp> _
		Public Sub Init()
            'esProviderFactory.Factory = New EntitySpaces.LoaderMT.esDataProviderFactory()
            esProviderFactory.Factory = New EntitySpaces.Loader.esDataProviderFactory()
			UnitTestBase.RefreshDatabase()
			UnitTestBase.RefreshForeignKeyTest()
		End Sub
	End Class
End Namespace
