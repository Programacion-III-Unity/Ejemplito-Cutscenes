$dateTime = (Get-Date).ToString('yyyyMMddhhmmss')
$projectPath=".\"
$buildMethodWin64="BuildProject.BuildWindows64"
$buildMethodWin32="BuildProject.BuildWindows32"
$env:gameName="Plataformote"
$env:projectVersion="0.1_$dateTime"
$env:environment="Test"

echo "Project Path: $projectPath"
echo "Project environment: $env:environment"
echo "Project version: $env:projectVersion"
echo ""
echo "Building Windows 64 bit executable, Using build method: $buildMethodWin64"

$resultado64 = Start-Process -Wait 'C:\Program Files\Unity\Hub\Editor\2020.3.14f1\Editor\Unity.exe' -ArgumentList "-nographics -batchmode -projectPath $buildPath -executeMethod $buildMethodWin64 -quit"


echo "Building Windows 32 bit executable, Using build method: $buildMethodWin32"

$resultado32 = Start-Process -Wait 'C:\Program Files\Unity\Hub\Editor\2020.3.14f1\Editor\Unity.exe' -ArgumentList "-nographics -batchmode -projectPath $buildPath -executeMethod $buildMethodWin32 -quit"

if($resultado32 -ne 0){
   exit 1
}
   
if($resultado64 -ne 0){
  exit 1
}

exit 0

Read-Host -Prompt 'Proceso terminado'