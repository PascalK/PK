@echo off
SET CurrentDirectory=%~dp0
SET NuGet=%CurrentDirectory%..\..\..\..\.nuget\NuGet.exe

%NuGet% push PK.Common.0.5.0.0.nupkg -Source F:\NuGet