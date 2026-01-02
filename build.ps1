$baseDir = Resolve-Path $PSScriptRoot

if ((Split-Path $baseDir -Leaf) -eq "src") {
    $baseDir = Resolve-Path ..
}

$buildDir = "$baseDir\build"
$debugDir = "$buildDir\debug"
$sourceDir = "$baseDir\src"
$projectName = "CurrenSee"
$unitTestPath = "$sourceDir\$projectName.Tests"
$projectPath = "$sourceDir\$projectName"
$dotnetCliVerbosity = "m"
$buildConfiguration

function Init {
    Write-Output "Creating deployment directory"
    Remove-Item $buildDir -Recurse -Force -ErrorAction Ignore
    Remove-Item $debugDir -Recurse -Force -ErrorAction Ignore

    if ($buildConfiguration -eq "Debug") {
        New-Item -Path $debugDir -ItemType Directory > $null 
    } elseif ($buildConfiguration -eq "Release") {
        New-Item -Path $buildDir -ItemType Directory > $null 
    } else {
        throw "Unknown build configuration: $buildConfiguration"
    }

    Write-Output "Clean & restore solution"
    & dotnet clean "$sourceDir\$projectName.sln" --nologo -v $dotnetCliVerbosity
    & dotnet restore "$sourceDir\$projectName.sln" --nologo --interactive -v $dotnetCliVerbosity
}

function Compile {
    Write-Output "Compiling"

    if ($buildConfiguration -ne $null) {
        & dotnet build "$sourceDir\$projectName.sln" --nologo --no-restore -v $dotnetCliVerbosity --no-incremental -c $buildConfiguration 
    } else {
        & dotnet build "$sourceDir\$projectName.sln" --nologo --no-restore -v $dotnetCliVerbosity --no-incremental -c "Debug" 
    }
}

function UnitTests {
    Write-Output "Running Unit Tests"
    if ($buildConfiguration -ne $null) {
        & dotnet test "$unitTestPath\$projectName.Tests.csproj" --nologo -v $dotnetCliVerbosity --no-build --no-restore -c $buildConfiguration
    } else {
        & dotnet test "$unitTestPath\$projectName.Tests.csproj" --nologo -v $dotnetCliVerbosity --no-build --no-restore -c "Debug"
    }
}

function CopyOutput {
    Write-Output "Copying validated build to output"
    $outputPath = "$projectPath\bin\$buildConfiguration\net9.0"
    Copy-Item "$outputPath" -Destination "$buildDir\$buildConfiguration" -Recurse
}

function PrivateBuild {
    $buildConfiguration = "Debug"
    Init
    Compile
    UnitTests
    CopyOutput
}

function PublicBuild {
    $buildConfiguration = "Release"
    Init
    Compile
    UnitTests
    CopyOutput
}