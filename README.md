SDK for the Ungerboeck API 
==========================

You found the code tools for the Ungerboeck API!  This is a C# solution designed to introduce you and get you going quickly.

# Getting Started
If you are looking to get going as fast as possible, here are step by step instructions.

Find and download your Ungerboeck version on [the examples page](https://github.com/UngerboeckAPI).  For example, Ungerboeck .98 would use the [98 example project](https://github.com/UngerboeckAPI/98).

Navigate to StartHere/Program.cs.  Fill in the values at the top of Main() in relation to your Ungerboeck URL and your API User values (Found in Ungerboeck -> Main Menu -> Api Users).

After that, running the program should return an Account name.

# Examples
This class library shows how to use every endpoint programmatically, including specific scenarios and comments giving tips.  

After downloading the project, you can surf the code to find the method you need.  Also, please ensure your Visual Studio is set up to download Nuget Packages (Visual Studio->Options->Nuget Package Manager-> General -> Ensure these are checked: "Allow NuGet to download missing packages" and "Automatically check for missing packages during build in Visual Studio").  You can make a simple app to call the examples to see how they work.

## Ungerboeck.Api.Sdk (Formerly Ungerboeck209XSDKWrapper/UngerboeckSDKWrapper)
Project Name UngerboeckSDKWrapperJWT.  Contains pre-made wrapper calls to quickly get your client connected to the Ungerboeck API.  This lives as a package on Nuget, but it coexists here to allow you to see the code.  

[Find the nuget package here](https://www.nuget.org/packages/Ungerboeck.Api.Sdk/)

## Ungerboeck.Api.Models (Formerly Ungerboeck209XSDK/UngerboeckSDKPackage)
This contains pre-made models and constants to help your client code.  It only lives on Nuget.  

[Find the nuget package here](https://www.nuget.org/packages/Ungerboeck.Api.Models/)

Match your Ungerboeck version of the Ungerboeck.Api.Sdk or Ungerboeck.Api.Models packages by using the package version.  The second value represents the Ungerboeck version.

For example 1.98.211206.1756 was made for Ungerboeck .98

