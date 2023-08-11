using Hi3Helper;
using System.Drawing;

namespace NewUI.Welcome.Extensions
{
    public static class WindowExtension
    {
        public static void WindowSize(this IntPtr hwnd, int width = 1028, int height = 634)
        {
            if (hwnd == IntPtr.Zero)
                throw new ArgumentException("Invalid window handle 假如.", nameof(hwnd));

            var dpi = InvokeProp.GetDpiForWindow(hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            Size desktopSize = Hi3Helper.Screen.ScreenProp.GetScreenSize();
            int xOff = (desktopSize.Width - width) / 2;
            int hOff = (desktopSize.Height - height) / 2;

            InvokeProp.SetWindowPos(hwnd, (IntPtr)InvokeProp.SpecialWindowHandles.HWND_TOP,
                                        xOff, hOff, width, height,
                                        InvokeProp.SetWindowPosFlags.SWP_SHOWWINDOW);
        }
    }
}