using System.Runtime.InteropServices;

namespace WinFormsMultiTouchTest
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterTouchWindow(IntPtr hWnd, uint flags);

        [DllImport("user32.dll")]
        internal static extern bool GetTouchInputInfo(IntPtr hTouchInput, int cInputs, [In, Out] TOUCHINPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        internal static extern void CloseTouchInputHandle(IntPtr lParam);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TOUCHINPUT
    {
        public int x;
        public int y;
        public IntPtr hSource;
        public int dwID;
        public int dwFlags;
        public int dwMask;
        public int dwTime;
        public IntPtr dwExtraInfo;
        public int cxContact;
        public int cyContact;
    }
}
