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

dotnet watch format --project $PROJECT_PATH
dotnet watch test --project $PROJECT_PATH