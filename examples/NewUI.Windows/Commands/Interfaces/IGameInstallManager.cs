﻿using System;
using System.Threading.Tasks;

namespace XLauncher.Interfaces
{
    internal interface IGameInstallManager
    {
        event EventHandler<TotalPerfileProgress> ProgressChanged;
        event EventHandler<TotalPerfileStatus> StatusChanged;

        ValueTask<int> GetInstallationPath();
        Task StartPackageDownload(bool skipDialog = false);
        ValueTask<int> StartPackageVerification();
        Task StartPackageInstallation();
        Task StartPostInstallVerification();
        void ApplyGameConfig(bool forceUpdateToLatest = false);

        Task MoveGameLocation();
        ValueTask<bool> UninstallGame();
        void Flush();
        void CancelRoutine();
        bool IsPreloadCompleted();

        ValueTask<bool> TryShowFailedDeltaPatchState();
        ValueTask<bool> TryShowFailedGameConversionState();
    }
}
