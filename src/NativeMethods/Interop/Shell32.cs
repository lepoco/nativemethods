// This Source Code is partially based on reverse engineering of the Windows Operating System,
// and is intended for use on Windows systems only.
// This Source Code is partially based on the source code provided by the .NET Foundation.
// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski.
// All Rights Reserved.

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace NativeMethods.Interop;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
public static class Shell32
{
    /// <summary>
    /// DATAOBJ_GET_ITEM_FLAGS.  DOGIF_*.
    /// </summary>
    public enum DOGIF
    {
        DEFAULT = 0x0000,
        TRAVERSE_LINK = 0x0001, // if the item is a link get the target
        NO_HDROP = 0x0002, // don't fallback and use CF_HDROP clipboard format
        NO_URL = 0x0004, // don't fallback and use URL clipboard format
        ONLY_IF_ONE = 0x0008, // only return the item if there is one item in the array
    }

    /// <summary>
    /// Shell_NotifyIcon messages.  NIM_*
    /// </summary>
    public enum NIM : uint
    {
        ADD = 0,
        MODIFY = 1,
        DELETE = 2,
        SETFOCUS = 3,
        SETVERSION = 4,
    }

    /// <summary>
    /// Shell_NotifyIcon flags.  NIF_*
    /// </summary>
    [Flags]
    public enum NIF : uint
    {
        MESSAGE = 0x0001,
        ICON = 0x0002,
        TIP = 0x0004,
        STATE = 0x0008,
        INFO = 0x0010,
        GUID = 0x0020,

        /// <summary>
        /// Vista only.
        /// </summary>
        REALTIME = 0x0040,

        /// <summary>
        /// Vista only.
        /// </summary>
        SHOWTIP = 0x0080,

        XP_MASK = MESSAGE | ICON | STATE | INFO | GUID,
        VISTA_MASK = XP_MASK | REALTIME | SHOWTIP,
    }

    [StructLayout(LayoutKind.Sequential)]
    public class NOTIFYICONDATA
    {
        public int cbSize;
        public IntPtr hWnd;
        public int uID;
        public NIF uFlags;
        public int uCallbackMessage;
        public IntPtr hIcon;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public char[] szTip = new char[128];

        /// <summary>
        /// The state of the icon.  There are two flags that can be set independently.
        /// NIS_HIDDEN = 1.  The icon is hidden.
        /// NIS_SHAREDICON = 2.  The icon is shared.
        /// </summary>
        public uint dwState;

        public uint dwStateMask;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] szInfo = new char[256];

        // Prior to Vista this was a union of uTimeout and uVersion.  As of Vista, uTimeout has been deprecated.
        public uint uVersion; // Used with Shell_NotifyIcon flag NIM_SETVERSION.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szInfoTitle = new char[64];

        public uint dwInfoFlags;

        public Guid guidItem;

        // Vista only
        IntPtr hBalloonIcon;
    }

    [DllImport(Libraries.Shell32, PreserveSig = false)]
    public static extern void SHGetItemFromDataObject(IDataObject pdtobj, DOGIF dwFlags, [In] ref Guid riid,
        [Out, MarshalAs(UnmanagedType.Interface)] out object ppv);

    [DllImport(Libraries.Shell32)]
    public static extern int SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, IBindCtx pbc,
        [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out object ppv);

    [DllImport(Libraries.Shell32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool Shell_NotifyIcon(NIM dwMessage, [In] NOTIFYICONDATA lpdata);

    /// <summary>
    /// Sets the User Model AppID for the current process, enabling Windows to retrieve this ID
    /// </summary>
    /// <param name="AppID"></param>
    [DllImport(Libraries.Shell32, PreserveSig = false)]
    public static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

    /// <summary>
    /// Retrieves the User Model AppID that has been explicitly set for the current process via SetCurrentProcessExplicitAppUserModelID
    /// </summary>
    /// <param name="AppID"></param>
    [DllImport(Libraries.Shell32)]
    public static extern int GetCurrentProcessExplicitAppUserModelID(
        [Out, MarshalAs(UnmanagedType.LPWStr)] out string AppID);
}
