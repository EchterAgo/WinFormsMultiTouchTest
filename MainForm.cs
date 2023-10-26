using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinFormsMultiTouchTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            NativeMethods.RegisterTouchWindow(Handle, 0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_TOUCH = 0x240;
            if (m.Msg == WM_TOUCH)
            {
                HandleTouchMessage(m);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        private void HandleTouchMessage(Message m)
        {
            var inputCount = (int)(m.WParam & 0xFFFF);
            var inputs = new TOUCHINPUT[inputCount];

            if (NativeMethods.GetTouchInputInfo(m.LParam, inputCount, inputs, Marshal.SizeOf<TOUCHINPUT>()))
            {
                try
                {
                    for (int i = 0; i < inputCount; i++)
                    {
                        int id = inputs[i].dwID;
                        int x = inputs[i].x;
                        int y = inputs[i].y;
                        int mask = inputs[i].dwMask;

                        // Process the touch input for the given touch point (id)
                        // Use the x, y, and mask values as needed.

                        Debug.WriteLine($"id = {id}, x = {x/100.0f}, y = {y/100.0f}, mask = {mask}");
                    }
                }
                finally
                {
                    NativeMethods.CloseTouchInputHandle(m.LParam);
                }
            }
        }
    }
}
