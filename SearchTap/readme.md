#### Steps to Build

- Update version info in SearchTap.nuspec file
- Create a new `.\nuget.exe pack .\SearchTap.csproj`
- `.\nuget.exe push .\SearchTap.0.1.0.nupkg <key> -Source https://api.nuget.org/v3/index.json`