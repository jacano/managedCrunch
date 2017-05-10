call "%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsMSBuildCmd.bat"

msbuild crunchlib.sln /p:Configuration="Release" /p:Platform="x86"
msbuild crunchlib.sln /p:Configuration="Release" /p:Platform="x64"
msbuild crunchlib.sln /p:Configuration="Release" /p:Platform="ARM"
msbuild crunchlib.sln /p:Configuration="Release" /p:Platform="ARM64"

xcopy /Y lib\android\x86\Release\libCrunch.so ManagedCrunch.Android\libs\x86
xcopy /Y lib\android\x64\Release\libCrunch.so ManagedCrunch.Android\libs\x86_64
xcopy /Y lib\android\ARM\Release\libCrunch.so ManagedCrunch.Android\libs\armeabi-v7a
xcopy /Y lib\android\ARM64\Release\libCrunch.so ManagedCrunch.Android\libs\arm64-v8a

nuget restore ManagedCrunch.sln
msbuild ManagedCrunch.sln /p:Configuration="Release" /p:Platform="Any CPU"