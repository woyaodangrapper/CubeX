using Microsoft.UI.Xaml.Controls;
using static X.Infrastructure.Caching.Configurations.AppEnums;

namespace X.Infrastructure.Caching.Core;

public class ApplicationWindowInfo
{
    /// <summary>
    /// 应用程序模式
    /// </summary>
    public AppMode ApplicationMode { get; set; }

    /// <summary>
    ///  版本号
    /// </summary>
    public ushort[]? VersionNumbers { get; set; }

    /// <summary>
    /// 窗口对象
    /// </summary>
    public Window? Window { get; set; }

    /// <summary>
    /// 窗口是否支持自定义标题
    /// </summary>
    public bool HasCustomTitle { get; set; }

    /// <summary>
    /// 窗口句柄
    /// </summary>
    public nint WindowHandle { get; set; }

    /// <summary>
    /// 窗口位置和大小
    /// </summary>
    public Rect WindowPosSize { get; set; }

    /// <summary>
    /// 窗口 ID
    /// </summary>
    public WindowId WindowID { get; set; }

    /// <summary>
    /// 应用程序窗口
    /// </summary>
    public AppWindow? ApplicationWindow { get; set; }

    /// <summary>
    /// 叠加式呈现器
    /// </summary>
    public OverlappedPresenter? Presenter { get; set; }

    /// <summary>
    /// 实际主框架大小
    /// </summary>
    public Size ActualMainFrameSize { get; set; }

    /// <summary>
    /// 应用程序缩放比例
    /// </summary>
    public double ApplicationScale { get; set; }

    /// <summary>
    /// 当前帧名称
    /// </summary>
    public string? ApplicationCurrentFrameName { get; set; }

    /// <summary>
    /// 应用程序主题
    /// </summary>
    public ApplicationTheme ApplicationTheme { get; set; }

    /// <summary>
    /// 应用程序主题模式
    /// </summary>
    public AppThemeMode ApplicationThemeMode { get; set; }

    /// <summary>
    /// 系统应用程序主题颜色
    /// </summary>
    public System.Drawing.Color SystemApplicationTheme { get; set; }

    // 是否自定义背景
    public bool IsCustomBackground { get; set; }

    /// <summary>
    /// 是否跳过更新检查
    /// </summary>
    public bool IsSkippingUpdateCheck { get; set; }

    /// <summary>
    /// 根框架
    /// </summary>
    public Frame? RootFrame { get; set; }
}