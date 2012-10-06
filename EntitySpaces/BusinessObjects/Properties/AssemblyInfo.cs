using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if (!WindowsCE)
using System.Security;
#endif

[assembly: CLSCompliant(true)]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if (!WindowsCE)
[assembly: AssemblyTitle("BusinessObjects")]
[assembly: AllowPartiallyTrustedCallers]
#else
[assembly: AssemblyTitle("EntitySpaces.Core.CF")]
#endif
[assembly: AssemblyDescription("The EntitySpaces BusinessObjects Sample Code")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("EntitySpaces, LLC")]
[assembly: AssemblyProduct("EntitySpacesArchitecture")]
[assembly: AssemblyCopyright("Copyright © EntitySpaces, LLC. 2005 - 2012")]
[assembly: AssemblyTrademark("EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC.")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM componenets.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5f9fc230-0ca1-4625-b5a1-4bb1f9c11d1e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("2012.0.0319.0")]
#if (!WindowsCE)
[assembly: AssemblyFileVersion("2012.0.0319.0")]
#endif
