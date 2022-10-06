# Autodesk Inventor Addin Template for Microsoft VisualStudio

Project template for addin creation inside Autodesk Inventor (starting from Inventor 2018, but it works also for other lower version).

Zip all files inside TemplateAdskInventor.zip (without README ang .gitignore file) and put it inside C:\Users\info\Documents\Visual Studio [version]\Templates\ProjectTemplates

Build with Microsoft Visual Studio 2022.

## Before build

1 - rename Debug.Autodesk.[Project Name].Inventor to Autodesk.[Project Name].Inventor inside AddinManifest/Debug/
2 - update assembly path inside AddinManifest/Debug/Autodesk.[Project Name].Inventor

```xml
<Assembly>path to bin\x64\Debug\$safeprojectname$.dll</Assembly>
```

3 - set application for debug

![Application for Debug](ExcludeFromProject/DebugSetup.png)  

## Reference

[Template parameters](https://learn.microsoft.com/en-us/visualstudio/ide/template-parameters?view=vs-2022)  
[How to: Substitute parameters in a template](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-substitute-parameters-in-a-template?view=vs-2022)  
[How to: Create project templates](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-create-project-templates?view=vs-2022)  
[Custom Project Templates in Visual Studio 2019](https://www.youtube.com/watch?v=DLLsmb7En_8)  
