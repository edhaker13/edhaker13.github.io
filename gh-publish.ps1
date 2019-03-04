function Test-Dependencies {
    [CmdletBinding()]
    Param()

    Get-Command git | Out-Null
    if (-not ($env:GIT_SSH -and (Test-Path $env:GIT_SSH))){
        $ssh = $(Get-Command ssh -ErrorAction SilentlyContinue).Source
        if ($ssh -and (Test-Path $ssh)){
            Write-Output "Using SSH at $ssh"
            $env:GIT_SSH=$ssh
        }
    }
    Get-Command dotnet | Out-Null
}
function Build-Project {
    [CmdletBinding()]
    Param()

    Write-Output "`nBuilding project"
    Invoke-Expression 'dotnet publish -c Release'

    $publishDir=Resolve-Path '.\bin\Release\netstandard2.0\publish\BlazorStandalone\dist'
    if (-not (Test-Path $publishDir)){
        throw "Couldn't find output folder $publishDir"
    }
    Push-Location $publishDir
}

function Push-Project {
    [CmdletBinding()]
    Param()

    Invoke-Expression 'git init'
    Invoke-Expression 'git add .'
    Invoke-Expression 'git commit -m "Updated $(Get-Date -Format r)"'
    Invoke-Expression 'git remote add origin git@github.com:edhaker13/edhaker13.github.io.git'
    Invoke-Expression 'git push -f -u origin master'
    Pop-Location
}

Test-Dependencies -ErrorAction Stop
Build-Project -ErrorAction Stop
Push-Project -ErrorAction Stop
