@pushd %~dp0

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "JimmyJohnsAutomation.csproj" /p:Pickles_Generate=True /p:Pickles_FeatureDirectory=C:\jimmy\JimmyJohnsAutomation\JimmyJohnsAutomation\Features /p:Pickles_DocumentationFormat=word /p:Pickles_OutputDirectory=C:\MyFeatures

@if ERRORLEVEL 1 goto end

@cd ..\packages\SpecRun.Runner.*\tools

@set profile=%1
@if "%profile%" == "" set profile=Default

SpecRun.exe run %profile%.srprofile "/baseFolder:%~dp0\bin\Debug" /log:specrun.log %2 %3 %4 %5 /filter:@SMOKE

:end

@popd
