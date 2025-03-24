# SocialNetworkGraph

Reads data from `UserGraph.json` and creates two iterators that process the data

## How to run the project
### Windows
1. Clone the repository
2. Open the `.sln` or `.csproj` in Visual Studio and click "Build Solution"
3. Navigate to `./bin/Debug/net8.0` and open it in cmd or powershell
4. Launch the program with `SocialNetworkGraph.exe "full path to UserGraph.json"`

Alternatively, you can try building the solution with `msbuild` or any other tool for building `.csproj` files
### Linux
This approach was not tested, but the installation process for .NET on Linux has been explained in this tutorial: https://learn.microsoft.com/en-us/dotnet/core/install/linux?tabs=netcore2x

After installing, you should be able to invoke msbuild with `dotnet build SocialNetworkGraph.csproj` and launch the executable with `SocialNetworkGraph "full path to UserGraph.json"`


## Expected output
![image](https://github.com/user-attachments/assets/f1d1393b-b23f-4644-a91c-70f3e13ae377)
