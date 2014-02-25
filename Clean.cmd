@echo off
SET Root=%~dp0
SET TestResult=%Root%TestResults
SET Sources=%Root%Sources
SET Tests=%Root%Tests
SET Package=%Root%Package
SET Packages=%Root%Packages

IF EXIST %TestResult% (
echo Removing TestResults from %TestResult%
rd /S /Q "%TestResult%"
) ELSE (
rem echo No TestResults
)
echo Removing bin folders from %Sources%
for /d /r "%Sources%" %%d in (bin) do (
if exist "%%d" (
echo Removing: %%d
rd /s/q "%%d"
)
)

echo Removing obj folders from %Sources%
for /d /r "%Sources%" %%d in (obj) do (
if exist "%%d" (
echo Removing: %%d
rd /s/q "%%d"
)
)

echo Removing bin folders from %Tests%
for /d /r "%Tests%" %%d in (bin) do (
if exist "%%d" (
echo Removing: %%d
rd /s/q "%%d"
)
)

echo Removing obj folders from %Tests%
for /d /r "%Tests%" %%d in (obj) do (
if exist "%%d" (
echo Removing: %%d
rd /s/q "%%d"
)
)

echo Removing folders from %Package%
for /d /r "%Package%" %%d in (dir *.*) do (
if exist "%%d" (
echo Removing: %%d
rd /s/q "%%d"
)
)

echo Removing nupkg files from %Package%
for /r "%Package%" %%d in (dir *.nupkg) do (
if exist "%%d" (
echo Removing: %%d
del "%%d"
)
)