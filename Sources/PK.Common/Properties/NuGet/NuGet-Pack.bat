@echo off
SET CurrentDirectory=%~dp0
SET NuGet=%CurrentDirectory%..\..\..\..\.nuget\NuGet.exe
%NuGet% pack %CurrentDirectory%..\..\PK.Common.csproj -Prop Configuration=Release -Symbols