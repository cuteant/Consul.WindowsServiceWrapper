@set NUGET_PACK_OPTS= -Version 2.0.0-rtm-170501
@set NUGET_PACK_OPTS= %NUGET_PACK_OPTS% -OutputDirectory Publish

%~dp0nuget.exe pack %~dp0Consul.Windows.ServiceWrapper.nuspec %NUGET_PACK_OPTS%
