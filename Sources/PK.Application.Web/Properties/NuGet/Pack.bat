@echo off
SET CurrentDirectory=%~dp0
SET NuGet=%CurrentDirectory%..\..\..\..\.nuget\NuGet.exe
SET PackageFolder=%CurrentDirectory%..\..\..\..\Package\

%NuGet% pack %PackageFolder%PK.Application.Web\PK.Application.Web.nuspec -o %PackageFolder% -Symbols
