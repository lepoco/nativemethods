# NativeMethods
[Created with ❤ in Poland by lepo.co](https://dev.lepo.co/)  
Set of tools and ready-made methods that are wrappers over the core functionalities of Windows, such as `User32`, `Shell32` or `Kernel32`.

[![GitHub license](https://img.shields.io/github/license/lepoco/nativemethods)](https://github.com/lepoco/nativemethods/blob/master/LICENSE) [![Nuget](https://img.shields.io/nuget/v/NativeMethods)](https://www.nuget.org/packages/NativeMethods/) [![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/NativeMethods?label=nuget-pre)](https://www.nuget.org/packages/NativeMethods/) [![Nuget](https://img.shields.io/nuget/dt/NativeMethods?label=nuget-downloads)](https://www.nuget.org/packages/NativeMethods/) [![Size](https://img.shields.io/github/repo-size/lepoco/nativemethods)](https://github.com/lepoco/nativemethods) [![Sponsors](https://img.shields.io/github/sponsors/lepoco)](https://github.com/sponsors/lepoco)

## 🚀 Getting started
**NativeMethods** is delivered via **NuGet** package manager. You can find the package here: https://www.nuget.org/packages/NativeMethods/

## Wrapped Methods
| Library | Method |
| --- | --- |
| **User32** | User32.SetWindowCompositionAttribute() |
| **Shell32** | Shell32.Shell_NotifyIcon() |
| **Kernel32** | Kernel32.CopyMemory() |
| **Gdip** | Gdip.GdipCreateHICONFromBitmap() |
| **Gdi32** | Gdi32.DeleteObject() |

## Microsoft Property
NativeMethods is based on source code provided by the .NET Foundation, WinApi headers and reverse engineer Windows libraries. The purpose of the library is to facilitate the management of WinApi via C# and it's designed exclusively for Windows systems.

## Compilation
Use Visual Studio 2022 and invoke the .sln.

Visual Studio  
**NativeMethods** is an Open Source project. You are entitled to download and use the freely available Visual Studio Community Edition to build, run or develop for NativeMethods. As per the Visual Studio Community Edition license, this applies regardless of whether you are an individual or a corporate user.

## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.

## License
NativeMethods is free and open source software licensed under **MIT License**. You can use it in private and commercial projects.  
Keep in mind that you must include a copy of the license in your project.