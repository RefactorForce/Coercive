# Coercive Syntax Engine

This repository hosts the codebase of the Coercive Syntax Engine, a syntax styling, analysis, and regulatation conformance engine targeting Visual C# and Visual Basic .NET. It uses syntax interpretation technologies and functionality provided by the [Roslyn Compiler Platform](https://github.com/dotnet/roslyn) in order to power fundamental operation, and is packaged both as an extension for Visual Studio 2017 and as several NuGet packages, one containing the engine's Analysis, Styling, and Conformance APIs for easy access, and the other containing an MSBuild-integrated analyzer for project-specific and easily configurable compile-time-generated syntax formation messages.

## Origin

This project started out as a fork of [the CodeCracker repository master branch at commit 5e164b0](https://github.com/code-cracker/code-cracker/commit/5e164b0678b5ce35c4160ea36418b4608c553cb1) and was created mainly to address some of the analysis errors currently present in the latest version of the extension at the time.

## Contributing

Pull requests are accepted at this time. We ask that alongside every change and/or addition request submission there is a detailed explanation of the changes and/or additions that are being suggested to be merged into the codebase. If the changes are substantial, it would be reccomended that a discourse on the topic is opened publicly in the repository's "issues" section in order to validate whether or not the change is likely to be welcome.

If you decide to contribute you agree to grant copyright of all your contribution to this project, and agree to mention clearly if you are not in accordance with this policy. Your work shall be licensed with the [current licensing of the project](https://github.com/RefactorForce/Coercive/blob/master/LICENSE.txt).

## License

This software is open source, released under the Apache License, Version 2.0; see [LICENSE.txt](https://github.com/RefactorForce/Coercive/blob/master/LICENSE.txt) for a further, complete, description of what this entails.

Project reccomendation dictates that clients of this codebase should refer to the license for guidance before performing any administrative action on and/or with the codebase, including but not limited to modifying it, cloning it, forking it, or distributing it.
