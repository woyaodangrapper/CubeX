﻿using XLauncher.Statics;
using Microsoft.Win32;

namespace XLauncher.GameSettings
{
    internal static class Statics
    {
#nullable enable
        internal static string RegistryRootPath { get => $"Software\\{PageStatics._GameVersion.VendorTypeProp.VendorType}"; }
        internal static string? RegistryPath;
        internal static RegistryKey? RegistryRoot;
#nullable disable
    }
}
