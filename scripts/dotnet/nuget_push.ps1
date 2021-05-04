[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]
    $NUPKG_PATH,
    [Parameter(Mandatory=$true)]
    [string]
    $NUGET_API_KEY,
    [Parameter()]
    [string]
    $NUGET_SOURCE = "https://api.nuget.org/v3/index.json"
)

if(![System.IO.File]::Exists($NUPKG_PATH)){
    throw "Path: '$PROJECT_PATH' does not exits"
}

dotnet nuget push $NUPKG_PATH --api-key $NUGET_API_KEY --source $NUGET_SOURCE