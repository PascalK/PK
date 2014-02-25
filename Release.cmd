@echo off
SET Root=%~dp0
SET TestResult=%Root%TestResults
SET Sources=%Root%Sources
SET Tests=%Root%Tests
SET Package=%Root%Package
SET Packages=%Root%Packages
SET NuGet=%Root%.nuget\NuGet.exe

SET PKNuGet=%Sources%\PK.NuGet
SET PKNuGetProj=%PKNuGet%\PK.NuGet.csproj

SET PKCommon=%Sources%\PK.Common
SET PKCommonProj=%PKCommon%\PK.Common.csproj

SET PKSettings=%Sources%\PK.Settings
SET PKSettingsProj=%PKSettings%\PK.Settings.csproj

SET PKSettingsStoreApps=%Sources%\PK.Settings.StoreApps
SET PKSettingsStoreAppsProj=%PKSettingsStoreApps%\PK.Settings.StoreApps.csproj

SET PKSettingsAppSettings=%Sources%\PK.Settings.AppSettings.Net45
SET PKSettingsAppSettingsProj=%PKSettingsAppSettings%\PK.Settings.AppSettings.Net45.csproj

SET PKApplication=%Sources%\PK.Application
SET PKApplicationProj=%PKApplication%\PK.Application.csproj

SET PKApplicationWeb=%Sources%\PK.Application.Web.Net45
SET PKApplicationWebProj=%PKApplicationWeb%\PK.Application.Web.Net45.csproj

msbuild /t:Pack /p:Configuration=Release %PKNuGetProj%
msbuild /t:Pack /p:Configuration=Release %PKCommonProj%
msbuild /t:Pack /p:Configuration=Release %PKSettingsProj%
msbuild /t:Pack /p:Configuration=Release %PKSettingsStoreAppsProj%
msbuild /t:Pack /p:Configuration=Release %PKSettingsAppSettingsProj%
msbuild /t:Pack /p:Configuration=Release %PKApplicationProj%
msbuild /t:Pack /p:Configuration=Release %PKApplicationWebProj%