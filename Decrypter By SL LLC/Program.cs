using System;
using System.Windows.Forms;

namespace Decrypter_By_SL_LLC
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Decrypter());
        }
    }
}
