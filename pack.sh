#!/bin/sh

SCRIPTFILE=$0

#Get the absolute path to the containing folder
PROJECTFOLDER=${SCRIPTFILE%/*}

cd ${PROJECTFOLDER}

pwd

PROJECTFOLDER=$(pwd)

rm *.mpack

# Pack
#mono /Applications/Visual\ Studio\ \(2019\).app/Contents/Resources/lib/monodevelop/bin/vstool.exe setup pack ./VisualStudioMac.OneClickToOpenFile/bin/VisualStudioMac.OneClickToOpenFile.dll
/Applications/Visual\ Studio.app/Contents/MacOS/vstool setup pack /Users/ivokrugers/Xamarin_Projects/VisualStudioMac.OneClickToOpenFile/VisualStudioMac.OneClickToOpenFile/bin/VisualStudioMac.OneClickToOpenFile.dll

# Copy to local dir
for filename in /Applications/Visual\ Studio.app/*OneClickToOpenFile*.mpack;
do
  echo "move $filename"
  mv "$filename" .
done

# Uninstall
/Applications/Visual\ Studio.app/Contents/MacOS/vstool setup uninstall VisualStudioMac.OneClickToOpenFile -y

# # Install
# for filename in *.mpack;
# do
#   echo "$filename"
#   /Applications/Visual\ Studio\ \(Preview\).app/Contents/MacOS/vstool setup install "$PROJECTFOLDER/$filename"
# done
