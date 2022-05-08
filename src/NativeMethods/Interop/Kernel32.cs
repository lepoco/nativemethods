﻿// This Source Code is partially based on reverse engineering of the Windows Operating System,
// and is intended for use on Windows systems only.
// This Source Code is partially based on the source code provided by the .NET Foundation.
// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski.
// All Rights Reserved.

using System;
using System.Runtime.InteropServices;

namespace NativeMethods.Interop;

public static class Kernel32
{
    /// <summary>
    /// Copies a block of memory from one location to another.
    /// </summary>
    /// <param name="destination">A pointer to the starting address of the copied block's destination.</param>
    /// <param name="source">A pointer to the starting address of the block of memory to copy.</param>
    /// <param name="length">The size of the block of memory to copy, in bytes.</param>
    [DllImport(Libraries.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
    public static extern void CopyMemory([In] IntPtr destination, [In] IntPtr source, [In] uint length);
}
