[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [ValidateSet('major', 'minor', 'patch', 'preview')]
    [string]
    $ARG_VERSION_TYPE,
    [int]
    $ARG_VERSION = -1
)

$TAG        =(git describe --abbrev=0 --tags)
$TAG_REGEX  ='v(\d+).(\d+).(\d+)(-preview\+?(\w){8})?'

if (-not ($TAG -match $TAG_REGEX)) {
    throw "Tag: '$TAG' does not match pattern: '$TAG_REGEX'"
}

$VERSION_MAJOR  =[int]::Parse($Matches[1])
$VERSION_MINOR  =[int]::Parse($Matches[2])
$VERSION_PATCH  =[int]::Parse($Matches[3])
$VERSION_PREVIEW=$Matches[4]

$VERSION_MESSAGE="$VERSION_MAJOR.$VERSION_MINOR.$VERSION_PATCH"
if($ARG_VERSION_TYPE -eq 'preview' -and $VERSION_PREVIEW.Length -ne 0){
    $VERSION_MESSAGE += "-preview$VERSION_PREVIEW"
}

Write-Host $VERSION_MESSAGE

switch ($ARG_VERSION_TYPE) {
    "major" {
        if ($ARG_VERSION -eq -1) {
            $VERSION_MAJOR += 1
        }else {
            $VERSION_MAJOR = $ARG_VERSION
        }
        
        $VERSION_MINOR = 0
        $VERSION_PATCH = 0
    }
    "minor" {
        if ($ARG_VERSION -eq -1) {
            $VERSION_MINOR += 1
        }else {
            $VERSION_MINOR = $ARG_VERSION
        }

        $VERSION_PATCH = 0
    }
    "patch" {
        if ($ARG_VERSION -eq -1) {
            $VERSION_PATCH += 1
        }else {
            $VERSION_PATCH = $ARG_VERSION
        }
    }
    "preview" {
        if($ARG_VERSION -eq 0){
            $VERSION_PREVIEW += "+"
            $VERSION_PREVIEW += (git rev-parse --short HEAD)
        }else{
            $VERSION_PREVIEW=$ARG_VERSION.ToString().PadLeft(8, '0')
        }
    }
}

$VERSION_MESSAGE="$VERSION_MAJOR.$VERSION_MINOR.$VERSION_PATCH"
if($ARG_VERSION_TYPE -eq 'preview'){
    $VERSION_MESSAGE += "-preview$VERSION_PREVIEW"
}
Write-Host $VERSION_MESSAGE

if($ARG_VERSION_TYPE -eq 'preview'){
    ./scripts/git/tag.ps1 $VERSION_MAJOR $VERSION_MINOR $VERSION_PATCH "$VERSION_MESSAGE-preview$VERSION_PREVIEW" "preview$VERSION_PREVIEW"
}else{
    ./scripts/git/tag.ps1 $VERSION_MAJOR $VERSION_MINOR $VERSION_PATCH $VERSION_MESSAGE
}