using System;
using System.Windows.Forms;

namespace AW_AuthClient
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Default URL if no arguments are provided.
            string url = "https://angelware.net";

            // Get the URL from the application's launch argument.
            if (args.Length > 0)
            {
                url = args[0];
            }

            Application.Run(new Window(url));
        }
    }
}