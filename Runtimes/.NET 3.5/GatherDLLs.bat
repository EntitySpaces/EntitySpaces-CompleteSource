xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.Core\bin\Release35\EntitySpaces.Core.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.DebuggerVisualizer\bin\Release35\EntitySpaces.DebuggerVisualizer.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.DynamicQuery\bin\Release35\EntitySpaces.DynamicQuery.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.Interfaces\bin\Release35\EntitySpaces.Interfaces.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.js\bin\Release35\EntitySpaces.js.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.Loader\bin\Release35\EntitySpaces.Loader.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.LoaderMT\bin\Release35\EntitySpaces.LoaderMT.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.Profiler\bin\Release35\EntitySpaces.Profiler.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.Web\bin\Release35\EntitySpaces.Web.dll
xcopy /Y /Q ..\..\EntitySpaces\EntitySpaces.Web.Design\bin\Release35\EntitySpaces.Web.Design.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.MSAccessProvider\bin\Release35\EntitySpaces.MSAccessProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.MySqlClientProvider\bin\Release35\EntitySpaces.MySqlClientProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.Npgsql2Provider\bin\Release35\EntitySpaces.Npgsql2Provider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.NpgsqlProvider\bin\Release35\EntitySpaces.NpgsqlProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.OracleClientProvider\bin\Release35\EntitySpaces.OracleClientProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.SqlClientProvider\bin\Release35\EntitySpaces.SqlClientProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.SQLiteProvider\bin\Release35\EntitySpaces.SQLiteProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.SqlServerCeProvider\bin\Release35\EntitySpaces.SqlServerCeProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.SybaseSqlAnywhereProvider\bin\Release35\EntitySpaces.SybaseSqlAnywhereProvider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.VistaDB4Provider\bin\Release35\EntitySpaces.VistaDB4Provider.dll
xcopy /Y /Q ..\..\EntitySpaces\Providers\EntitySpaces.VistaDBProvider\bin\Release35\EntitySpaces.VistaDBProvider.dll

cd ..\Silverlight\3

xcopy /Y /Q ..\..\..\EntitySpaces\EntitySpaces.DynamicQuery\bin\ReleaseSilverlight3\EntitySpaces.DynamicQuery.Silverlight.dll

cd ..\..\.NET 3.5
cd Web

xcopy /Y /Q ..\..\..\EntitySpaces\EntitySpaces.Core\bin\Release35Web\EntitySpaces.Core.dll