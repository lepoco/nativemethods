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
/// Desktop Window Manager (DWM).
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
public static class Dwmapi
{
    /// <summary>
    /// Defines a data type used by the Desktop Window Manager (DWM) APIs. It represents a generic ratio and is used for different purposes and units even within a single API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UNSIGNED_RATIO
    {
        /// <summary>
        /// The ratio numerator.
        /// </summary>
        public uint uiNumerator;

        /// <summary>
        /// The ratio denominator.
        /// </summary>
        public uint uiDenominator;
    }

    /// <summary>
    /// Specifies Desktop Window Manager (DWM) composition timing information. Used by the <see cref="DwmGetCompositionTimingInfo"/> function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DWM_TIMING_INFO
    {
        public int cbSize;
        public UNSIGNED_RATIO rateRefresh;
        public ulong qpcRefreshPeriod;
        public UNSIGNED_RATIO rateCompose;
        public ulong qpcVBlank;
        public ulong cRefresh;
        public uint cDXRefresh;
        public ulong qpcCompose;
        public ulong cFrame;
        public uint cDXPresent;
        public ulong cRefreshFrame;
        public ulong cFrameSubmitted;
        public uint cDXPresentSubmitted;
        public ulong cFrameConfirmed;
        public uint cDXPresentConfirmed;
        public ulong cRefreshConfirmed;
        public uint cDXRefreshConfirmed;
        public ulong cFramesLate;
        public uint cFramesOutstanding;
        public ulong cFrameDisplayed;
        public ulong qpcFrameDisplayed;
        public ulong cRefreshFrameDisplayed;
        public ulong cFrameComplete;
        public ulong qpcFrameComplete;
        public ulong cFramePending;
        public ulong qpcFramePending;
        public ulong cFramesDisplayed;
        public ulong cFramesComplete;
        public ulong cFramesPending;
        public ulong cFramesAvailable;
        public ulong cFramesDropped;
        public ulong cFramesMissed;
        public ulong cRefreshNextDisplayed;
        public ulong cRefreshNextPresented;
        public ulong cRefreshesDisplayed;
        public ulong cRefreshesPresented;
        public ulong cRefreshStarted;
        public ulong cPixelsReceived;
        public ulong cPixelsDrawn;
        public ulong cBuffersEmpty;
    }

    /// <summary>
    /// SIT flags.
    /// </summary>
    public enum DWM_SIT
    {
        None,

        /// <summary>
        /// Displays a frame around the provided bitmap.
        /// </summary>
        DISPLAYFRAME = 1,
    }

    /// <summary>
    /// Extends the window frame into the client area.
    /// </summary>
    /// <param name="hWnd">The handle to the window in which the frame will be extended into the client area.</param>
    /// <param name="pMarInset">A pointer to a MARGINS structure that describes the margins to use when extending the frame into the client area.</param>
    [DllImport(Libraries.Dwmapi, PreserveSig = false)]
    public static extern void DwmExtendFrameIntoClientArea([In] IntPtr hWnd, [In] ref UxTheme.MARGINS pMarInset);

    /// <summary>
    /// Retrieves the current composition timing information for a specified window.
    /// </summary>
    /// <param name="hWnd">The handle to the window for which the composition timing information should be retrieved.</param>
    /// <param name="pTimingInfo">A pointer to a <see cref="DWM_TIMING_INFO"/> structure that, when this function returns successfully, receives the current composition timing information for the window.</param>
    [DllImport(Libraries.Dwmapi)]
    public static extern void DwmGetCompositionTimingInfo([In] IntPtr hWnd, [In] ref DWM_TIMING_INFO pTimingInfo);

    /// <summary>
    /// Called by an application to indicate that all previously provided iconic bitmaps from a window, both thumbnails and peek representations, should be refreshed.
    /// </summary>
    /// <param name="hWnd">A handle to the window or tab whose bitmaps are being invalidated through this call. This window must belong to the calling process.</param>
    [DllImport(Libraries.Dwmapi, PreserveSig = false)]
    public static extern void DwmInvalidateIconicBitmaps([In] IntPtr hWnd);

    /// <summary>
    /// Sets a static, iconic bitmap on a window or tab to use as a thumbnail representation. The taskbar can use this bitmap as a thumbnail switch target for the window or tab.
    /// </summary>
    /// <param name="hWnd">A handle to the window or tab. This window must belong to the calling process.</param>
    /// <param name="hbmp">A handle to the bitmap to represent the window that hwnd specifies.</param>
    /// <param name="dwSITFlags">The display options for the thumbnail.</param>
    [DllImport(Libraries.Dwmapi, PreserveSig = false)]
    public static extern void DwmSetIconicThumbnail([In] IntPtr hWnd, [In] IntPtr hbmp, [In] DWM_SIT dwSITFlags);

    /// <summary>
    /// Sets a static, iconic bitmap to display a live preview (also known as a Peek preview) of a window or tab. The taskbar can use this bitmap to show a full-sized preview of a window or tab.
    /// </summary>
    /// <param name="hWnd">A handle to the window. This window must belong to the calling process.</param>
    /// <param name="hbmp">A handle to the bitmap to represent the window that hwnd specifies.</param>
    /// <param name="pptClient">The offset of a tab window's client region (the content area inside the client window frame) from the host window's frame. This offset enables the tab window's contents to be drawn correctly in a live preview when it is drawn without its frame.</param>
    /// <param name="dwSITFlags">The display options for the live preview.</param>
    [DllImport(Libraries.Dwmapi, PreserveSig = false)]
    public static extern void DwmSetIconicLivePreviewBitmap([In] IntPtr hWnd, [In] IntPtr hbmp, [In, Optional] WinDef.RefPOINT pptClient, [In] DWM_SIT dwSITFlags);
}

