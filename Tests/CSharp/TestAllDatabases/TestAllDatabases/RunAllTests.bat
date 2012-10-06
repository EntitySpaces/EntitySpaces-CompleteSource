@ECHO OFF
time /t >TestResults.txt

ECHO ***RunAllTests***
ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsMSAccessDyn***
ECHO ***TestsMSAccessDyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsMSAccessDyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsMSAccessSP***
REM ECHO ***TestsMSAccessSP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsMSAccessSP.nunit  /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsMySqlDyn***
ECHO ***TestsMySqlDyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsMySqlDyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsMySQLSP***
REM ECHO ***TestsMySQLSP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsMySQLSP.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsOracleDyn***
REM ECHO ***TestsOracleDyn*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsOracleDyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsOracleEnterprise***
REM ECHO ***TestsOracleEnterprise*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsOracleEnterprise.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsOracleSP***
REM ECHO ***TestsOracleSP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsOracleSP.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsOracleSPEnterprise***
REM ECHO ***TestsOracleSPEnterprise*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsOracleSPEnterprise.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsPgsqlDyn***
REM ECHO ***TestsPgsqlDyn*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsPgsqlDyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsPgsqlSP***
REM ECHO ***TestsPgsqlSP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsPgsqlSP.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsPgsql2Dyn***
ECHO ***TestsPgsql2Dyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsPgsql2Dyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsPgsql2SP***
REM ECHO ***TestsPgsql2SP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsPgsql2SP.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsSqlAzureDyn***
REM ECHO ***TestsSqlAzureDyn*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSqlAzureDyn.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsSqlCeDyn***
ECHO ***TestsSqlCeDyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSqlCeDyn.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsSqlCe4Dyn***
ECHO ***TestsSqlCe4Dyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSqlCe4Dyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsSqlCeCF***
REM ECHO ***TestsSqlCeCF*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSqlCe.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsSQLiteDyn***
ECHO ***TestsSQLiteDyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSQLiteDyn.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsSqlServerDyn***
ECHO ***TestsSqlServerDyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSqlServerDyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsSQLExpressEnterprise***
REM ECHO ***TestsSQLExpressEnterprise*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSQLExpressEnterprise.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsSqlServerSP***
REM ECHO ***TestsSqlServerSP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSqlServerSP.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsSQLExpressSPEnterprise***
REM ECHO ***TestsSQLExpressSPEnterprise*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSQLExpressSPEnterprise.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsSybaseDyn***
ECHO ***TestsSybaseDyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSybaseDyn.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsSybaseSP***
REM ECHO ***TestsSybaseSP*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsSybaseSP.nunit /nologo /nodots >>TestResults.txt

REM ECHO -------------------------------------- >>TestResults.txt
REM ECHO ***TestsVistaDB3Dyn***
REM ECHO ***TestsVistaDB3Dyn*** >>TestResults.txt
REM ECHO -------------------------------------- >>TestResults.txt
REM "C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsVistaDB3Dyn.nunit /nologo /nodots >>TestResults.txt

ECHO -------------------------------------- >>TestResults.txt
ECHO ***TestsVistaDB4Dyn***
ECHO ***TestsVistaDB4Dyn*** >>TestResults.txt
ECHO -------------------------------------- >>TestResults.txt
"C:\NUnit 2.5.7\bin\net-2.0\nunit-console-x86.exe" C:\SVNData\EntitySpacesNew\Code\ES2011\Tests\CSharp\TestAllDataBases\TestAllDatabases\TestsVistaDB4Dyn.nunit /nologo /nodots >>TestResults.txt

time /t >>TestResults.txt
PAUSE
