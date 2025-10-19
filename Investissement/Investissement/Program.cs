using System.Windows.Forms;
using System;

namespace Investissement
{
    internal static class Program
    {
        // Point d'entrée principal de l'application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
