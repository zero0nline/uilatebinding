#! /bin/sh

project="uilatebinding"
projectdir="$(dirname "$(pwd)")"

echo projectpath is $projectdir

echo "Attempting to build $project for Android"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -logFile $projectdir/unity.log -projectPath $projectdir -buildTarget Android "$projectdir/travis_build/app.apk" -quit

echo 'Logs from build'
cat $projectdir/unity.log

#echo 'Attempting to zip builds'
#zip -r $projectdir/Build/android.zip $projectdir/Build/android/