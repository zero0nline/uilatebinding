#! /bin/sh

project="uilatebinding"
projectdir="$(dirname "$(pwd)")"

echo projectpath is $projectdir

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -silent-crashes -logFile $projectdir/unity.log -projectPath $projectdir -buildWindowsPlayer "$projectdir/Build/windows/$project.exe" -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -silent-crashes -logFile $projectdir/unity.log -projectPath $projectdir -buildOSXUniversalPlayer "$projectdir/Build/osx/$project.app" -quit

echo 'Logs from build'
cat $(pwd)/unity.log

echo 'Attempting to zip builds'
zip -r $projectdir/Build/mac.zip $projectdir/Build/osx/
zip -r $projectdir/Build/windows.zip $projectdir/Build/windows/