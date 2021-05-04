[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [int]
    $VERSION_MAJOR,
    [Parameter(Mandatory=$true)]
    [int]
    $VERSION_MINOR,
    [Parameter(Mandatory=$true)]
    [int]
    $VERSION_PATCH,
    [Parameter(Mandatory=$true)]
    [string]
    $GIT_TAG_MESSAGE,
    [Parameter()]
    [string]
    $VERSION_SUFIX
)

if ($VERSION_SUFIX.Length -eq 0){
    $GIT_TAG_VERSION="v$VERSION_MAJOR.$VERSION_MINOR.$VERSION_PATCH"
}else{
    $GIT_TAG_VERSION="v$VERSION_MAJOR.$VERSION_MINOR.$VERSION_PATCH-$VERSION_SUFIX"
}

$Confirmation = Read-Host "Version: '$GIT_TAG_VERSION' Message: '$GIT_TAG_MESSAGE' (y,n)"
if ($Confirmation -ne 'y' -and $Confirmation -ne 'yes'){
    return
}

git tag -d (git describe --abbrev=0 --tags)
git tag -a $GIT_TAG_VERSION -m $GIT_TAG_MESSAGE