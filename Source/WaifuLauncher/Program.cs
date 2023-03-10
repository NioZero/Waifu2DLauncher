using System.Diagnostics;
using WaifuLauncher.Utils;

namespace WaifuLauncher;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        #if DEBUG
        if (Debugger.IsAttached)
            GlobalSettings.Default.Reset();
        #endif

        ProgramSettings.UpdateLoggerTargets();

        Application.Run(new FormPrincipal());
    }
}