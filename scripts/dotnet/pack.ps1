[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]
    $PROJECT_PATH
)

if(![System.IO.File]::Exists($PROJECT_PATH)){
    throw "Path: '$PROJECT_PATH' does not exits"
}

#ToDo patch the version in src/*.csproj to git tag

$PACKAGE_VERSION=(git describe --abbrev=0 --tags)
$PACKAGE_VERSION=$PACKAGE_VERSION.SubString(1)

$(dotnet clean $PROJECT_PATH | Out-Host;$?) -and
    $(dotnet restore $PROJECT_PATH | Out-Host;$?) -and
    $(dotnet build $PROJECT_PATH | Out-Host;$?) -and
    #$(dotnet test | Out-Host;$?) -and
    $(dotnet pack $PROJECT_PATH -p:PackageVersion=$PACKAGE_VERSION | Out-Host;$?)