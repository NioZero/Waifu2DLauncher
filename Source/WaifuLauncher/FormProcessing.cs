using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace WaifuLauncher;

public partial class FormProcessing : Form
{
    #region properties

    #region log
    private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    #endregion

    /// <summary>
    /// Lista de Imagenes
    /// </summary>
    public string[] ImageFiles { get; set; }

    /// <summary>
    /// Reloj para contabilizar tiempo
    /// </summary>
    private readonly Stopwatch _watch = new Stopwatch();

    #endregion

    #region init

    public FormProcessing()
    {
        InitializeComponent();
    }

    #endregion

    #region methods

    public string GetCommands()
    {
        Logger.Trace($"GetCommands()");

        var builder = new StringBuilder();

        // Recupero parametros globales
        var command = GlobalSettings.Default.WaifuLocation;
        var scale = GlobalSettings.Default.LastUpscaleRatio;
        var noise = GlobalSettings.Default.LastDenoiseLevel;
        var tile = GlobalSettings.Default.LastTileSize;
        var tta = GlobalSettings.Default.LastEnableTTAMode;
        var format = GlobalSettings.Default.LastOutputFormat;

        for (var i = 0; i < ImageFiles.Length; i++)
        {
            var sourceLocation = ImageFiles[i];

            // Nombre del archivo anexando las opciones seleccionadas
            var targetFileName = $"{Path.GetFileNameWithoutExtension(sourceLocation)}[x{scale}]{(noise != 0 ? $"[n{noise}]" : "")}{(tile != 0 ? $"[t{tile}]" : "")}.{format}";

            // Ruta completa del archivo de destino
            var targetLocation = Path.Combine(GlobalSettings.Default.LastTargetFolder, targetFileName);

            // Argumentos en formato waifu2x
            var args = $"-i \"{sourceLocation}\" -o \"{targetLocation}\" -v -s {scale}{(noise != 0 ? $" -n {noise}" : "")}{(tile != 0 ? $" -t {tile}" : "")}{(tta ? " -x" : "")} -f {format}";

            // Guardo el comando en string
            builder.AppendLine($"{command} {args}");
        }

        return builder.ToString();
    }

    #endregion

    #region events

    private void FormProcessing_Load(object sender, EventArgs e)
    {
        Logger.Trace($"FormProcessing_Load(sender='{sender}', e='{e}')");

        workerProcessing.RunWorkerAsync();

        _watch.Restart();
    }

    private void workerProcessing_DoWork(object sender, DoWorkEventArgs e)
    {
        Logger.Trace($"workerProcessing_DoWork(sender='{sender}', e='{e}')");

        // Recupero parametros globales
        var command = GlobalSettings.Default.WaifuLocation;
        var scale = GlobalSettings.Default.LastUpscaleRatio;
        var noise = GlobalSettings.Default.LastDenoiseLevel;
        var tile = GlobalSettings.Default.LastTileSize;
        var tta = GlobalSettings.Default.LastEnableTTAMode;
        var format = GlobalSettings.Default.LastOutputFormat;

        // Carpeta y nombre del comando
        var commandFileName = Path.GetFileName(command);
        var workingDirectory = Path.GetDirectoryName(command);

        for (var i = 0; i < ImageFiles.Length; i++)
        {
            // En caso de que se haya presionado el botón cancelar,
            // tengo que interrumpir el ciclo y terminar el proceso
            if (workerProcessing.CancellationPending)
                break;

            // Porcentaje estimado
            var percent = (int)Math.Ceiling(100d * i / ImageFiles.Length);
            var sourceLocation = ImageFiles[i];

            // Subproceso
            var process = new Process();

            // Nombre del archivo anexando las opciones seleccionadas
            var targetFileName = $"{Path.GetFileNameWithoutExtension(sourceLocation)}[x{scale}]{(noise != 0 ? $"[n{noise}]" : "")}{(tile != 0 ? $"[t{tile}]" : "")}.{format}";

            // Ruta completa del archivo de destino
            var targetLocation = Path.Combine(GlobalSettings.Default.LastTargetFolder, targetFileName);

            // Argumentos en formato waifu2x
            var args = $"-i \"{sourceLocation}\" -o \"{targetLocation}\" -v -s {scale}{(noise != 0 ? $" -n {noise}" : "")}{(tile != 0 ? $" -t {tile}" : "")}{(tta ? " -x" : "")} -f {format}";

            // Mostrar el comando en el Log
            var log = $"EXEC {commandFileName} {args}";
            workerProcessing.ReportProgress(percent, log);

            // Propiedades del Subproceso
            process.StartInfo.FileName = command;
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.Arguments = args;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = false;

            // Eventos para capturar la salida del Programa
            process.OutputDataReceived += (sender, e) => workerProcessing.ReportProgress(percent, e.Data);
            process.ErrorDataReceived += (sender, e) => workerProcessing.ReportProgress(percent, e.Data);

            // Inicio el subproceso
            process.Start();

            // Capturo los mensajes de salida
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
        Logger.Trace($"workerProcessing_ProgressChanged(sender='{sender}', e='{e}')");

        progressBar.Value = e.ProgressPercentage;

        // En caso de que reporten un mensaje, lo anexo al TextBox
        if (e.UserState is string output) textBoxLog.AppendText(output + Environment.NewLine);

        // Muevo el scroll del TextBox al final
        textBoxLog.SelectionStart = textBoxLog.Text.Length;
        textBoxLog.ScrollToCaret();
    }

    private void workerProcessing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Logger.Trace($"workerProcessing_RunWorkerCompleted(sender='{sender}', e='{e}')");

        // En caso de ocurrir una Excepcion durante el proceso
        if (e.Error != null)
        {
            MessageBox.Show("Ocurrió un error durante el proceso. El mensaje fué: " + e.Error.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        // En caso de que se presione el botón Cancelar
        if (e.Cancelled)
        {
            MessageBox.Show("Proceso cancelado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _watch.Stop();

        // Barra de progreso con su valor máximo
        progressBar.Value = progressBar.Maximum;

        MessageBox.Show($"Proceso finalizado con éxito. Se procesaron {ImageFiles.Length} en {_watch.Elapsed}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Estado OK y cierro la ventana
        DialogResult = DialogResult.OK;
        Close();
    }

    #endregion

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Logger.Trace($"btnCancel_Click(sender='{sender}', e='{e}')");

        var confirm = MessageBox.Show("¿Esta seguro que desea cancelar la operación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm == DialogResult.Yes)
        {
            workerProcessing.CancelAsync();
        }
    }
}