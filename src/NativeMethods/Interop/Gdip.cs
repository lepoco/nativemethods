// This Source Code is partially based on reverse engineering of the Windows Operating System,
// and is intended for use on Windows systems only.
// This Source Code is partially based on the source code provided by the .NET Foundation.
// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski.
// All Rights Reserved.

using System;
using System.Runtime.InteropServices;

namespace NativeMethods.Interop;

/// <summary>
/// Windows GDI+ exposes a flat API that consists of about 600 functions, which are implemented in Gdiplus.dll and declared in Gdiplusflat.h.
/// </summary>
public static class Gdip
{
    /// <summary>
    /// The Bitmap::GetHICON method creates an icon from this Bitmap object.
    /// </summary>
    /// <param name="nativeBitmap"></param>
    /// <param name="hicon"></param>
    /// <returns>GpStatus HRESULT</returns>
    [DllImport(Libraries.Gdip, CharSet = CharSet.Auto)]
    public static extern int GdipCreateHICONFromBitmap(IntPtr nativeBitmap, out IntPtr hicon);
}

