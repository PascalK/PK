@echo off
SET CurrentDirectory=%~dp0
SET NuGet=%CurrentDirectory%..\..\..\..\.nuget\NuGet.exe
SET PackageFolder=%CurrentDirectory%..\..\..\..\Package\

%NuGet% pack %PackageFolder%PK.Common\PK.Common.nuspec -o %PackageFolder% -Symbols
