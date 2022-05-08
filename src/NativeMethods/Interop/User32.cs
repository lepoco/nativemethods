// This Source Code is partially based on reverse engineering of the Windows Operating System,
// and is intended for use on Windows systems only.
// This Source Code is partially based on the source code provided by the .NET Foundation.
// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski.
// All Rights Reserved.

using System;
using System.Runtime.InteropServices;

// Windows Kits\10\Include\10.0.22000.0\um\WinUser.h

namespace NativeMethods.Interop;

/// <summary>
/// USER procedure declarations, constant definitions and macros
/// <para>Copyright (c) Microsoft Corporation. All rights reserved</para>
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
public static class User32
{
    /// <summary>
    /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
    /// <para>If you are retrieving a pointer or a handle, this function has been superseded by the <see cref="GetWindowLongPtr"/> function.</para>
    /// <para>Unicode declaration for <see cref="GetWindowLong"/></para>
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">The zero-based offset to the value to be retrieved.</param>
    /// <returns>If the function succeeds, the return value is the requested value.</returns>
    [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
    public static extern int GetWindowLongW([In] IntPtr hWnd, [In] int nIndex);

    /// <summary>
    /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
    /// <para>If you are retrieving a pointer or a handle, this function has been superseded by the <see cref="GetWindowLongPtr"/> function.</para>
    /// <para>ANSI declaration for <see cref="GetWindowLong"/></para>
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">The zero-based offset to the value to be retrieved.</param>
    /// <returns>If the function succeeds, the return value is the requested value.</returns>
    [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
    public static extern int GetWindowLongA([In] IntPtr hWnd, [In] int nIndex);

    /// <summary>
    /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
    /// <para>If you are retrieving a pointer or a handle, this function has been superseded by the <see cref="GetWindowLongPtr"/> function.</para>
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">The zero-based offset to the value to be retrieved.</param>
    /// <returns>If the function succeeds, the return value is the requested value.</returns>
    [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
    public static extern int GetWindowLong([In] IntPtr hWnd, [In] int nIndex);

    /// <summary>
    /// Determines whether the specified window handle identifies an existing window.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be tested.</param>
    /// <returns>If the window handle identifies an existing window, the return value is nonzero.</returns>
    [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindow([In] IntPtr hWnd);

    /// <summary>
    /// Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to deactivate it and remove the keyboard focus from it.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be destroyed.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(Libraries.User32, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyWindow([In] IntPtr hWnd);
}

