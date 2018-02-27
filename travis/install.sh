#! /bin/sh

BASE_URL=http://netstorage.unity3d.com/unity
HASH=fc1d3344e6ea
VERSION=2017.3.1f1

download() {
  file=$1
  url="$BASE_URL/$HASH/$package"

  echo "Downloading from $url: "
  curl -o `basename "$package"` "$url"
}

install() {
  package=$1
  download "$package"

  echo "Installing "`basename "$package"`
  sudo installer -dumplog -package `basename "$package"` -target /
}

# See $BASE_URL/$HASH/unity-$VERSION-$PLATFORM.ini for complete list
# of available packages, where PLATFORM is `osx` or `win`

curl -o android-sdk.zip http://dl.google.com/android/android-sdk_r24.4.1-macosx.zip
unzip android-sdk.zip
export ANDROID_HOME=$PWD/android-sdk-macosx
export PATH=$PATH:$ANDROID_HOME/tools
export PATH=$PATH:$ANDROID_HOME/platform-tools
export JAVA_HOME=$(/usr/libexec/java_home)

echo $ANDROID_HOME
echo $JAVA_HOME

#install "MacEditorInstaller/Unity-$VERSION.pkg"
#install "MacEditorTargetInstaller/UnitySetup-Android-Support-for-Editor-$VERSION.pkg"