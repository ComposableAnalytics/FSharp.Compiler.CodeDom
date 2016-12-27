namespace Internal.Utilities
open System
open System.Runtime.InteropServices

module internal FSharpEnvironment =

    // The F# team version number. This version number is used for
    //     - the F# version number reported by the fsc.exe and fsi.exe banners in the CTP release
    //     - the F# version number printed in the HTML documentation generator
    //     - the .NET DLL version number for all VS2008 DLLs
    //     - the VS2008 registry key, written by the VS2008 installer
    //         HKEY_LOCAL_MACHINE\Software\Microsoft\.NETFramework\AssemblyFolders\Microsoft.FSharp-" + FSharpTeamVersionNumber
    // Also
    //     - for Beta2, the language revision number indicated on the F# language spec
    //
    // It is NOT the version number listed on FSharp.Core.dll
    let FSharpTeamVersionNumber = "1.9.9.9"

    module Option =
        /// Convert string into Option string where null and String.Empty result in None
        let ofString s =
            if String.IsNullOrEmpty s then None
            else Some s

    let BinFolderOfDefaultFSharpCompiler =
        try
            Option.ofString(Environment.GetEnvironmentVariable("FSHARPINSTALLDIR"))
        with _ ->
            System.Diagnostics.Debug.Assert(false, "Error while determining default location of F# compiler")
            None

