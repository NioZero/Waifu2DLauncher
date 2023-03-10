using NLog;
using NLog.Config;
using NLog.Targets;
using System.Xml.Serialization;

namespace WaifuLauncher.Utils;

/// <summary>
/// Static Class to store global configuration 
/// </summary>
public static class ProgramSettings
{
    private static Logger Logger = LogManager.GetCurrentClassLogger();

    internal static string SettingsFolder
    {
        get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProgramInfo.AssemblyCompany, ProgramInfo.AssemblyProduct);
    }

    /// <summary>
    /// Updates the logger targets.
    /// </summary>
    public static void UpdateLoggerTargets()
    {
        Logger.Trace("UpdateLoggerTargets()");

        var settings = GlobalSettings.Default;

        if (string.IsNullOrEmpty(settings.LogDirectory))
            settings.LogDirectory = Path.Combine(SettingsFolder, "Log");

        if (!Directory.Exists(settings.LogDirectory))
            Directory.CreateDirectory(settings.LogDirectory);

        var config = new LoggingConfiguration();
        var targetDefault = new FileTarget()
        {
            FileName = Path.Combine(settings.LogDirectory, ProgramInfo.AssemblyProduct + "_Default.log"),
            Layout = "[${longdate} (${level})] ${message}",
            ArchiveFileName = Path.Combine(settings.LogDirectory, "Archives", ProgramInfo.AssemblyProduct + "_Default_${shortdate}.{#}.zip"),
            ArchiveAboveSize = 512 * 1024 * 10,
            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveNumbering = ArchiveNumberingMode.Rolling,
            MaxArchiveFiles = 100,
            EnableArchiveFileCompression = true
        };
        var targetError = new FileTarget()
        {
            FileName = Path.Combine(settings.LogDirectory, ProgramInfo.AssemblyProduct + "_Error.log"),
            Layout = "[${longdate}] ${callsite} (${level}) ${message} ${exception:format=tostring}",
            ArchiveFileName = Path.Combine(settings.LogDirectory, "Archives", ProgramInfo.AssemblyProduct + "_Error_${shortdate}.{#}.zip"),
            ArchiveAboveSize = 512 * 1024 * 10,
            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveNumbering = ArchiveNumberingMode.Rolling,
            MaxArchiveFiles = 100,
            EnableArchiveFileCompression = true
        };

        config.AddTarget("logFile", targetDefault);
        config.AddTarget("logError", targetError);

        config.LoggingRules.Add(new LoggingRule("*", LogLevel.FromString(settings.DefaultLogVerbosity), targetDefault));
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, targetError));

        #if DEBUG
        var targetConsole = new ConsoleTarget();
        config.AddTarget("logConsole", targetConsole);
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, targetConsole));
        #endif

        LogManager.Configuration = config;
        LogManager.ReconfigExistingLoggers();
    }
}