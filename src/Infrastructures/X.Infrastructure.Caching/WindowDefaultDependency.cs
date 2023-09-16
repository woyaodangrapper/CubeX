using X.Infrastructure.Caching.Core;

namespace X.Infrastructure.Caching
{
    public class WindowDefaultDependency : IWindowDefaultDependency
    {
        private static readonly Lazy<ApplicationWindowInfo> instance = new(() => new ApplicationWindowInfo());
        public static ApplicationWindowInfo Instance => instance.Value;

        private WindowDefaultDependency()
        { }

        //private readonly IMemoryCache _memoryCache;
        //public WindowDefaultDependency(IMemoryCache memoryCache)
        //{
        //    _memoryCache = memoryCache;
        //}
    }
}