 # Script to build infrastructure project and copy it to the Photoblog bin/Debug/... folder
 param (
    [string]$workspaceFolder,
    [string]$argument2 = "/property:GenerateFullPaths=true",
    [string]$argument3 = "/consoleloggerparameters:NoSummary",
	[string]$Configuration = "Debug"
 )
 
dotnet build $workspaceFolder/PhotoblogInfrastructure/PhotoblogInfrastructure.csproj $argument2 $argument3
Copy-Item "$($workspaceFolder)/PhotoblogInfrastructure/bin/$($Configuration)/netcoreapp3.1/PhotoblogInfrastructure.dll" -Destination "$($workspaceFolder)/Photoblog/bin/$($Configuration)/netcoreapp3.1"
$result = dotnet build $workspaceFolder/Photoblog/Photoblog.csproj $argument2 $argument3

# $nl = [Environment]::NewLine
# Write-host "result:$($nl)"
# Write-host $result
