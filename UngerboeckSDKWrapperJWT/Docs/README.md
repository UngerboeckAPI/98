SDK for the Ungerboeck API 
==========================

You found the code tools for the Ungerboeck API!  This is the main SDK package you probably want to get started quickly on the Ungerboeck API.

## Getting Started
If you are looking to get going as fast as possible, here are step by step instructions.

Find and download your Ungerboeck version on [the examples page](https://github.com/UngerboeckAPI).  For example, Ungerboeck .98 would use the [98 example project](https://github.com/UngerboeckAPI/98).

Navigate to StartHere/Program.cs.  Fill in the values at the top of Main() in relation to your Ungerboeck URL and your API User values (Found in Ungerboeck -> Main Menu -> Api Users).

After that, running the program should return an Account name.

## Ungerboeck.Api.Sdk (Formerly Ungerboeck209XSDKWrapper/UngerboeckSDKWrapper)
Contains pre-made wrapper calls to quickly get your client connected to the Ungerboeck API.  This  coexists on Github to allow you to see the code.  
[Find the nuget package here.](https://www.nuget.org/packages/Ungerboeck.Api.Sdk/)

## Ungerboeck.Api.Models (Formerly Ungerboeck209XSDK/UngerboeckSDKPackage)
This contains pre-made models and constants to help your client code.  It only lives here.  
[Find the nuget package here.](https://www.nuget.org/packages/Ungerboeck.Api.Models/)


# Examples
[Find examples here.](https://github.com/UngerboeckAPI)

This class library shows how to use every endpoint programmatically, including specific scenarios and comments giving tips.  After downloading the project, you can surf the code to find the method you need.  Also, please ensure your Visual Studio is set up to download Nuget Packages (Visual Studio->Options->Nuget Package Manager-> General -> Ensure these are checked: "Allow NuGet to download missing packages" and "Automatically check for missing packages during build in Visual Studio").  You can make a simple app to call the examples to see how they work.

At any time, you can see the matching Ungerboeck version of Ungerboeck.Api.Models or Ungerboeck.Api.Sdk by going to the nuget package version.  Match the second version value to your Ungerboeck version (ex: 1.98 matches Ungerboeck version .98).  It's recommended to be on the latest SDK for your Ungerboeck version, as the SDK is always backwards compatible, but later versions always contain more.

A related tip about upgrading the SDK: The Ungerboeck.Api.Models and Ungerboeck.Api.Sdk packages are designed to be forwards compatible.  Upgrading from nuget to keep up with you Ungerboeck version isn't necessary.  You typically only upgrade to take advantage of new features.

# More Info
More infomration can be found [in our knowledgebase](https://supportcenter.ungerboeck.com/hc/en-us/sections/115001365327-API-Basics).

