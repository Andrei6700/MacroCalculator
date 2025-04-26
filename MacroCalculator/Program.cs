using System;
using System.Windows.Forms;
using MacroCalculator.MainPage;

namespace MacroCalculator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MacroCalculator.MainPage.MainPage());
        }
    }
}