@echo off
SET CurrentDirectory=%~dp0
SET NuGet=%CurrentDirectory%..\..\..\..\.nuget\NuGet.exe
SET PackageFolder=%CurrentDirectory%..\..\..\..\Package\

%NuGet% pack %PackageFolder%PK.Settings.StoreApps\PK.Settings.StoreApps.nuspec -o %PackageFolder% -Symbols
