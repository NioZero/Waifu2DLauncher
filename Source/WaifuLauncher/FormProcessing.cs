using System;
using System.ComponentModel;
using System.Diagnostics;

namespace WaifuLauncher;

public partial class FormProcessing : Form
{
    #region properties

    public string[] ImageFiles { get; set; }

    private readonly Stopwatch _watch = new Stopwatch();

    #endregion

    #region init

    public FormProcessing()
    {
        InitializeComponent();
    }

    #endregion

    #region methods

    #endregion

    #region events

    private void FormProcessing_Load(object sender, EventArgs e)
    {
        workerProcessing.RunWorkerAsync();

        _watch.Restart();
    }

    private void workerProcessing_DoWork(object sender, DoWorkEventArgs e)
    {
        var command = GlobalSettings.Default.WaifuLocation;
        var scale = GlobalSettings.Default.LastUpscaleRatio;
        var noise = GlobalSettings.Default.LastDenoiseLevel;
        var tile = GlobalSettings.Default.LastTileSize;
        var tta = GlobalSettings.Default.LastEnableTTAMode;
        var format = GlobalSettings.Default.LastOutputFormat;

        var commandFileName = Path.GetFileName(command);
        var workingDirectory = Path.GetDirectoryName(command);

        for (var i = 0; i < ImageFiles.Length; i++)
        {
            var percent = (int)Math.Ceiling(100d * i / ImageFiles.Length);
            var sourceLocation = ImageFiles[i];
            var process = new Process();

            var targetFileName = $"{Path.GetFileNameWithoutExtension(sourceLocation)}[x{scale}]{(noise != 0 ? $"[n{noise}]" : "")}{(tile != 0 ? $"[t{tile}]" : "")}.{format}";

            var targetLocation = Path.Combine(GlobalSettings.Default.LastTargetFolder, targetFileName);

            var args = $"-i \"{sourceLocation}\" -o \"{targetLocation}\" -v -s {scale}{(noise != 0 ? $" -n {noise}" : "")}{(tile != 0 ? $" -t {tile}" : "")}{(tta ? " -x" : "")} -f {format}";

            var log = $"EXEC {commandFileName} {args}";
            workerProcessing.ReportProgress(percent, log);

            process.StartInfo.FileName = command;
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.Arguments = args;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = false;
            process.OutputDataReceived += (sender, e) => workerProcessing.ReportProgress(percent, e.Data);
            process.ErrorDataReceived += (sender, e) => workerProcessing.ReportProgress(percent, e.Data);
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                workerProcessing.ReportProgress(percent, $"Process exited with non-zero exit code of: {process.ExitCode}");
            }
        }
    }

    private void workerProcessing_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;

        if (e.UserState is string output) textBoxLog.AppendText(output + Environment.NewLine);

        textBoxLog.SelectionStart = textBoxLog.Text.Length;
        textBoxLog.ScrollToCaret();
    }

    private void workerProcessing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _watch.Stop();

        progressBar.Value = progressBar.Maximum;

        MessageBox.Show($"Proceso finalizado con éxito. Se procesaron {ImageFiles.Length} en {_watch.Elapsed}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        Close();
    }

    #endregion
}