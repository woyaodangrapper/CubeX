﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace XLauncher.Interfaces
{
    internal interface ICache : IDisposable
    {
        ObservableCollection<AssetProperty<CacheAssetType>> AssetEntry { get; set; }
        event EventHandler<TotalPerfileProgress> ProgressChanged;
        event EventHandler<TotalPerfileStatus> StatusChanged;
        Task<bool> StartCheckRoutine(bool useFastCheck = false);
        Task StartUpdateRoutine(bool showInteractivePrompt = false);
        void CancelRoutine();
    }
}
