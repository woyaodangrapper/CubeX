using System;

namespace XLauncher.Interfaces
{
    internal interface IGameSettingsValue<T> : IEquatable<T>
    {
        abstract static T Load();
        void Save();
    }
}
