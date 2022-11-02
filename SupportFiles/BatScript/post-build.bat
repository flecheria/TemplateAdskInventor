REM copy inventor addin manifest to Application Plugins Data
if $(ConfigurationName) == Debug (
    echo D | xcopy "$(ProjectDir)\AddinManifest\DebugManifest\Autodesk.$(ProjectName).Inventor.addin" "%AppData%\Autodesk\ApplicationPlugins\$(ProjectName)" /S /Q /Y /F
) ELSE (
    echo D | xcopy "$(ProjectDir)\AddinManifest\ReleaseManifest\Autodesk.$(ProjectName).Inventor.addin" "%AppData%\Autodesk\ApplicationPlugins\$(ProjectName)" /S /Q /Y /F
)

REM copy main dll
echo D | xcopy "$(TargetDir)\$(TargetFileName)" "%AppData%\Autodesk\ApplicationPlugins\$(ProjectName)" /S /Q /Y /F