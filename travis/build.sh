#! /bin/sh

project="uilatebinding"
projectdir="$(dirname "$(pwd)")"
#projectdir="/Users/alt/Projects/Unity/uilatebinding"

echo projectpath is $projectdir

echo "Attempting to build $project for Android"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -silent-crashes -logFile $projectdir/unity.log -projectPath $projectdir  -executeMethod Editor.AppBuilder.BuildAndroid -quit

echo 'Logs from build'
cat $projectdir/unity.log

#echo 'Attempting to zip builds'
#zip -r $projectdir/Build/android.zip $projectdir/Build/android/