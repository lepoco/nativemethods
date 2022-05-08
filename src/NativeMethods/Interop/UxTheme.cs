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

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
public static class UxTheme
{
    /// <summary>
    /// Specifies the type of visual style attribute to set on a window.
    /// </summary>
    public enum WINDOWTHEMEATTRIBUTETYPE : uint
    {
        /// <summary>
        /// Non-client area window attributes will be set.
        /// </summary>
        WTA_NONCLIENT = 1,
    }

    /// <summary>
    /// WindowThemeNonClientAttributes
    /// </summary>
    [Flags]
    public enum WTNCA : uint
    {
        /// <summary>
        /// Prevents the window caption from being drawn.
        /// </summary>

        NODRAWCAPTION = 0x00000001,

        /// <summary>
        /// Prevents the system icon from being drawn.
        /// </summary>
        NODRAWICON = 0x00000002,

        /// <summary>
        /// Prevents the system icon menu from appearing.
        /// </summary>
        NOSYSMENU = 0x00000004,

        /// <summary>
        /// Prevents mirroring of the question mark, even in right-to-left (RTL) layout.
        /// </summary>
        NOMIRRORHELP = 0x00000008,

        /// <summary>
        /// A mask that contains all the valid bits.
        /// </summary>
        VALIDBITS = NODRAWCAPTION | NODRAWICON | NOMIRRORHELP | NOSYSMENU,
    }

    /// <summary>
    /// Defines options that are used to set window visual style attributes.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WTA_OPTIONS
    {
        // public static readonly uint Size = (uint)Marshal.SizeOf(typeof(WTA_OPTIONS));
        public const uint Size = 8;

        /// <summary>
        /// A combination of flags that modify window visual style attributes.
        /// Can be a combination of the WTNCA constants.
        /// </summary>
        [FieldOffset(0)]
        public WTNCA dwFlags;

        /// <summary>
        /// A bitmask that describes how the values specified in dwFlags should be applied.
        /// If the bit corresponding to a value in dwFlags is 0, that flag will be removed.
        /// If the bit is 1, the flag will be added.
        /// </summary>
        [FieldOffset(4)]
        public WTNCA dwMask;
    }

    /// <summary>
    /// Sets attributes to control how visual styles are applied to a specified window.
    /// </summary>
    /// <param name="hwnd">
    /// Handle to a window to apply changes to.
    /// </param>
    /// <param name="eAttribute">
    /// Value of type WINDOWTHEMEATTRIBUTETYPE that specifies the type of attribute to set.
    /// The value of this parameter determines the type of data that should be passed in the pvAttribute parameter.
    /// Can be the following value:
    /// <list>WTA_NONCLIENT (Specifies non-client related attributes).</list>
    /// pvAttribute must be a pointer of type WTA_OPTIONS.
    /// </param>
    /// <param name="pvAttribute">
    /// A pointer that specifies attributes to set. Type is determined by the value of the eAttribute value.
    /// </param>
    /// <param name="cbAttribute">
    /// Specifies the size, in bytes, of the data pointed to by pvAttribute.
    /// </param>
    [DllImport(Libraries.UxTheme, PreserveSig = false)]
    public static extern void SetWindowThemeAttribute([In] IntPtr hwnd, [In] WINDOWTHEMEATTRIBUTETYPE eAttribute, [In] ref WTA_OPTIONS pvAttribute, [In] uint cbAttribute);
}
