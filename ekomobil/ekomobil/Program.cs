using System;
using System.Windows.Forms;

namespace ekomobil
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Handle unhandled exceptions
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
                ShowErrorDialog(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                ShowErrorDialog(e.ExceptionObject as Exception);

            // Run the main form
            Application.Run(new Form1());
        }

        private static void ShowErrorDialog(Exception ex)
        {
            string errorMessage = "Kritik bir hata oluştu:\n\n" +
                                $"{ex?.Message}\n\n" +
                                "Uygulama kapatılacak.";

            MessageBox.Show(errorMessage, "Kritik Hata",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(1);
        }
    }
}