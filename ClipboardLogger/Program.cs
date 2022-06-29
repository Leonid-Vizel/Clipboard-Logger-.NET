using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardLogger
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(int value);

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetProcessDpiAwarenessContext(-1);
            Application.Run(new MainForm());
        }
    }
}
