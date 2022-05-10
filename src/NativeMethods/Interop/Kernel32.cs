// This Source Code is partially based on reverse engineering of the Windows Operating System,
// and is intended for use on Windows systems only.
// This Source Code is partially based on the source code provided by the .NET Foundation.
// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski.
// All Rights Reserved.

using System;
using System.Runtime.InteropServices;
using NativeMethods.Attributes;

namespace NativeMethods.Interop;

/// <summary>
/// Used by multiple technologies.
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
#pragma warning disable CA1401 // P/Invokes should not be visible
[UnmanagedComponent]
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

    /// <summary>
    /// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
    /// </summary>
    /// <returns>The return value is the calling thread's last-error code.</returns>
    [DllImport(Libraries.Kernel32)]
    public static extern int GetLastError();

    /// <summary>
    /// Sets the last-error code for the calling thread.
    /// </summary>
    /// <param name="dwErrorCode">The last-error code for the thread.</param>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern void SetLastError([In] int dwErrorCode);

    /// <summary>
    /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted, FindFirstStreamTransactedW, or FindFirstStreamW functions.
    /// </summary>
    /// <param name="hFindFile">The file search handle.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(Libraries.Kernel32)]

    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool FindClose([In, Out] IntPtr hFindFile);

    /// <summary>
    /// Frees the specified global memory object and invalidates its handle.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object. This handle is returned by either the GlobalAlloc or GlobalReAlloc function. It is not safe to free memory allocated with LocalAlloc.</param>
    /// <returns>If the function succeeds, the return value is NULL.</returns>
    [DllImport(Libraries.Kernel32)]

    public static extern IntPtr GlobalFree(IntPtr hMem);

    /// <summary>
    /// Frees the specified local memory object and invalidates its handle.
    /// </summary>
    /// <param name="hMem">A handle to the local memory object. This handle is returned by either the LocalAlloc or LocalReAlloc function. It is not safe to free memory allocated with GlobalAlloc.</param>
    /// <returns>If the function succeeds, the return value is NULL.</returns>
    [DllImport(Libraries.Kernel32)]
    public static extern IntPtr LocalFree([In] IntPtr hMem);

    /// <summary>
    /// Locks a global memory object and returns a pointer to the first byte of the object's memory block.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object. This handle is returned by either the GlobalAlloc or GlobalReAlloc function.</param>
    /// <returns>If the function succeeds, the return value is a pointer to the first byte of the memory block.</returns>
    [DllImport(Libraries.Kernel32)]
    public static extern IntPtr GlobalLock([In] IntPtr hMem);

    /// <summary>
    /// Decrements the lock count associated with a memory object that was allocated with GMEM_MOVEABLE. This function has no effect on memory objects allocated with GMEM_FIXED.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object. This handle is returned by either the GlobalAlloc or GlobalReAlloc function.</param>
    /// <returns>If the memory object is still locked after decrementing the lock count, the return value is a nonzero value. If the memory object is unlocked after decrementing the lock count, the function returns zero and GetLastError returns NO_ERROR.</returns>
    [DllImport(Libraries.Kernel32)]
    public static extern bool GlobalUnlock([In] IntPtr hMem);

    /// <summary>
    /// Closes an open object handle.
    /// </summary>
    /// <param name="hObject">A valid handle to an open object.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);

    /// <summary>
    /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
    /// </summary>
    /// <param name="hLibModule">A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or GetModuleHandleEx function returns this handle.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool FreeLibrary([In] IntPtr hLibModule);

    /// <summary>
    /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
    /// </summary>
    /// <param name="hModule">A handle to the DLL module that contains the function or variable. The LoadLibrary, LoadLibraryEx, LoadPackagedLibrary, or GetModuleHandle function returns this handle.</param>
    /// <param name="lpProcName">The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
    /// <returns>If the function succeeds, the return value is the address of the exported function or variable.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    public static extern IntPtr GetProcAddress([In] IntPtr hModule, [In][MarshalAs(UnmanagedType.LPStr)] string lpProcName);

    /// <summary>
    /// Opens an existing local process object.
    /// </summary>
    /// <param name="dwDesiredAccess">The access to the process object. This access right is checked against the security descriptor for the process. This parameter can be one or more of the process access rights.</param>
    /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
    /// <param name="dwProcessId">The identifier of the local process to be opened.</param>
    /// <returns>If the function succeeds, the return value is an open handle to the specified process.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

    /// <summary>
    /// Retrieves the process identifier of the calling process.
    /// </summary>
    /// <returns>The return value is the process identifier of the calling process.</returns>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern int GetCurrentProcessId();

    /// <summary>
    /// Retrieves the Remote Desktop Services session associated with a specified process.
    /// </summary>
    /// <param name="dwProcessId">Specifies a process identifier. Use the GetCurrentProcessId function to retrieve the process identifier for the current process.</param>
    /// <param name="pSessionId">Pointer to a variable that receives the identifier of the Remote Desktop Services session under which the specified process is running.</param>
    /// <returns>If the function succeeds, the return value is a nonzero value.</returns>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ProcessIdToSessionId([In] int dwProcessId, [Out] out int pSessionId);

    /// <summary>
    /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
    /// </summary>
    /// <param name="lpLibFileName">A string that specifies the file name of the module to load. This name is not related to the name stored in a library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.</param>
    /// <param name="hFile">This parameter is reserved for future use. It must be NULL.</param>
    /// <param name="dwFlags">The action to be taken when loading the module. If no flags are specified, the behavior of this function is identical to that of the LoadLibrary function.</param>
    /// <returns>If the function succeeds, the return value is a handle to the loaded module.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    public static extern IntPtr LoadLibraryExW([In][MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName, IntPtr hFile, [In] uint dwFlags);

    /// <summary>
    /// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the function.
    /// </summary>
    /// <param name="dwFlags">The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.</param>
    /// <param name="lpSource">The location of the message definition.</param>
    /// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes FORMAT_MESSAGE_FROM_STRING.</param>
    /// <param name="dwLanguageId">The language identifier for the requested message. This parameter is ignored if dwFlags includes FORMAT_MESSAGE_FROM_STRING.</param>
    /// <param name="lpBuffer">A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes FORMAT_MESSAGE_ALLOCATE_BUFFER, the function allocates a buffer using the LocalAlloc function, and places the pointer to the buffer at the address specified in lpBuffer.</param>
    /// <param name="nSize">If the FORMAT_MESSAGE_ALLOCATE_BUFFER flag is not set, this parameter specifies the size of the output buffer, in TCHARs. If FORMAT_MESSAGE_ALLOCATE_BUFFER is set, this parameter specifies the minimum number of TCHARs to allocate for an output buffer.</param>
    /// <param name="arguments">An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.</param>
    /// <returns>If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character.</returns>
    [DllImport(Libraries.Kernel32, CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    public extern static int FormatMessageW([In] int dwFlags, [In, Optional] IntPtr lpSource, [In] int dwMessageId, [In] int dwLanguageId, [Out] System.Text.StringBuilder lpBuffer, [In] int nSize, [In, Optional] IntPtr arguments);

    /// <summary>
    /// Retrieves the thread identifier of the calling thread.
    /// </summary>
    /// <returns>The return value is the thread identifier of the calling thread.</returns>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern int GetCurrentThreadId();

    /// <summary>
    /// Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days.
    /// </summary>
    /// <returns>The return value is the number of milliseconds that have elapsed since the system was started.</returns>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern int GetTickCount();

    /// <summary>
    /// Retrieves the number of milliseconds that have elapsed since the system was started.
    /// </summary>
    /// <returns>The number of milliseconds.</returns>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern ulong GetTickCount64();

    /// <summary>
    /// Determines whether the calling process is being debugged by a user-mode debugger.
    /// </summary>
    /// <returns>If the current process is running in the context of a debugger, the return value is nonzero.</returns>
    [DllImport(Libraries.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsDebuggerPresent();

    /// <summary>
    /// Retrieves the current value of the performance counter, which is a high resolution (<1us) time stamp that can be used for time-interval measurements.
    /// </summary>
    /// <param name="lpPerformanceCount">A pointer to a variable that receives the current performance-counter value, in counts.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool QueryPerformanceCounter([Out] out long lpPerformanceCount);

    /// <summary>
    /// Retrieves the frequency of the performance counter. The frequency of the performance counter is fixed at system boot and is consistent across all processors. Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
    /// </summary>
    /// <param name="lpFrequency">A pointer to a variable that receives the current performance-counter frequency, in counts per second. If the installed hardware doesn't support a high-resolution performance counter, this parameter can be zero (this will not occur on systems that run Windows XP or later).</param>
    /// <returns>If the installed hardware supports a high-resolution performance counter, the return value is nonzero.</returns>
    [DllImport(Libraries.Kernel32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool QueryPerformanceFrequency(out long lpFrequency);

    /// <summary>
    /// Adds a character string to the global atom table and returns a unique value (an atom) identifying the string.
    /// </summary>
    /// <param name="lpString">The null-terminated string to be added. The string can have a maximum size of 255 bytes. Strings that differ only in case are considered identical. </param>
    /// <returns>If the function succeeds, the return value is the newly created atom.</returns>
    [DllImport(Libraries.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern short GlobalAddAtom(string lpString);

    [DllImport(Libraries.Kernel32, SetLastError = true)]
    public static extern IntPtr VirtualAlloc(IntPtr address, UIntPtr size, int allocationType, int protect);

    [DllImport(Libraries.Kernel32, SetLastError = true)]
    public static extern bool VirtualFree(IntPtr address, UIntPtr size, int freeType);

    /// <summary>
    /// Determines the length of the specified string (not including the terminating null character).
    /// </summary>
    /// <param name="lpString">The null-terminated string to be checked.</param>
    /// <returns>The function returns the length of the string, in characters. If lpString is NULL, the function returns 0.</returns>
    [DllImport(Libraries.Kernel32, CharSet = CharSet.Auto, BestFitMapping = false)]
    public static extern int lstrlen(String lpString);
}
#pragma warning restore CA1401 // P/Invokes should not be visible
