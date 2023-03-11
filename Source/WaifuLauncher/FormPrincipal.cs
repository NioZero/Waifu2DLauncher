using System.Linq;
using WaifuLauncher.Utils;

namespace WaifuLauncher;

public partial class FormPrincipal : Form
{
    #region properties

    #region log
    private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    #endregion

    #endregion

    #region init

    public FormPrincipal()
    {
        InitializeComponent();

        InitializeExtraComponent();
    }

    #endregion

    #region methods

    private void InitializeExtraComponent()
    {
        Logger.Trace($"InitializeExtraComponent()");

        //txtWaifuLocation.Click += SetWaifuLocation_Event;
        btnFindWaifuLocation.Click += SetWaifuLocation_Event;

        //txtTargetFolder.Click += SetTargetFolder_Event;
        btnSelectTargetFolder.Click += SetTargetFolder_Event;

        numericDenoiseLevel.ValueChanged += UpdateSettings_Event;
        numericTileSize.ValueChanged += UpdateSettings_Event;
        comboBoxModelPath.SelectedIndexChanged += UpdateSettings_Event;
        rdBtnUpscaleRatio1.CheckedChanged += UpdateSettings_Event;
        rdBtnUpscaleRatio2.CheckedChanged += UpdateSettings_Event;
        rdBtnUpscaleRatio4.CheckedChanged += UpdateSettings_Event;
        rdBtnUpscaleRatio8.CheckedChanged += UpdateSettings_Event;
        rdBtnUpscaleRatio16.CheckedChanged += UpdateSettings_Event;
        rdBtnUpscaleRatio32.CheckedChanged += UpdateSettings_Event;
        checkBoxTtaMode.CheckedChanged += UpdateSettings_Event;
        rdBtnImageFormatJpg.CheckedChanged += UpdateSettings_Event;
        rdBtnImageFormatPng.CheckedChanged += UpdateSettings_Event;
        rdBtnImageFormatWebp.CheckedChanged += UpdateSettings_Event;

        txtWaifuLocation.Text = GlobalSettings.Default.WaifuLocation;
        txtTargetFolder.Text = GlobalSettings.Default.LastTargetFolder;

        numericDenoiseLevel.Value = GlobalSettings.Default.LastDenoiseLevel;
        numericTileSize.Value = GlobalSettings.Default.LastTileSize;
        checkBoxTileSizeAuto.Checked = GlobalSettings.Default.LastTileSizeAuto;
        comboBoxModelPath.Text = GlobalSettings.Default.LastModelPath;

        rdBtnUpscaleRatio1.Checked = false;
        rdBtnUpscaleRatio2.Checked = false;
        rdBtnUpscaleRatio4.Checked = false;
        rdBtnUpscaleRatio8.Checked = false;
        rdBtnUpscaleRatio16.Checked = false;
        rdBtnUpscaleRatio32.Checked = false;

        switch (GlobalSettings.Default.LastUpscaleRatio)
        {
            case 1: rdBtnUpscaleRatio1.Checked = true; break;
            case 2: rdBtnUpscaleRatio2.Checked = true; break;
            case 4: rdBtnUpscaleRatio4.Checked = true; break;
            case 8: rdBtnUpscaleRatio8.Checked = true; break;
            case 16: rdBtnUpscaleRatio16.Checked = true; break;
            case 32: rdBtnUpscaleRatio32.Checked = true; break;
        }

        checkBoxTtaMode.Checked = GlobalSettings.Default.LastEnableTTAMode;

        rdBtnImageFormatJpg.Checked = false;
        rdBtnImageFormatPng.Checked = false;
        rdBtnImageFormatWebp.Checked = false;

        if (GlobalSettings.Default.LastOutputFormat == rdBtnImageFormatJpg.Text) rdBtnImageFormatJpg.Checked = true;
        else if (GlobalSettings.Default.LastOutputFormat == rdBtnImageFormatPng.Text) rdBtnImageFormatPng.Checked = true;
        else if (GlobalSettings.Default.LastOutputFormat == rdBtnImageFormatWebp.Text) rdBtnImageFormatWebp.Checked = true;
    }

    private bool CheckFormValues()
    {
        Logger.Trace($"CheckFormValues()");

        var mensajes = new List<string>();

        if (string.IsNullOrEmpty(txtWaifuLocation.Text)) mensajes.Add("No se ha especificado la ubicación de waifu2x-*.exe");

        if (listFilesLocation.Items.Count == 0) mensajes.Add("No se ha seleccionado ninguna imagen");

        if (string.IsNullOrEmpty(txtTargetFolder.Text)) mensajes.Add("No se ha especificado una carpeta destino");

        if (!rdBtnUpscaleRatio1.Checked && !rdBtnUpscaleRatio2.Checked && !rdBtnUpscaleRatio4.Checked
            && !rdBtnUpscaleRatio8.Checked && !rdBtnUpscaleRatio16.Checked && !rdBtnUpscaleRatio32.Checked)
            mensajes.Add("No se ha especificado Upscale Ratio");

        if (!rdBtnImageFormatJpg.Checked && !rdBtnImageFormatPng.Checked && !rdBtnImageFormatWebp.Checked)
            mensajes.Add("No se ha especificado Output Format");

        if (mensajes.Count > 0)
        {
            MessageBox.Show(string.Join(Environment.NewLine, mensajes), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    private string[] GetImages()
    {
        var images = new List<string>();

        foreach (ListViewItem item in listFilesLocation.Items)
            images.Add(item.Name);

        return images.ToArray();
    }

    #endregion

    #region events

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        Logger.Trace($"FormPrincipal_Load(sender='{sender}', e='{e}')");

        // Recupero la última ubicación de la aplicación y restauro su ubicación original
        if (GlobalSettings.Default.LastWindowLocation.X > 0 && GlobalSettings.Default.LastWindowLocation.Y > 0)
            Location = GlobalSettings.Default.LastWindowLocation;

        if (GlobalSettings.Default.LastWindowSize.Width > 0 && GlobalSettings.Default.LastWindowSize.Height > 0)
            Size = GlobalSettings.Default.LastWindowSize;

        // En caso de que la ventana esté maximizada, aplico el estado
        if (GlobalSettings.Default.LastWindowIsMaximized)
            WindowState = FormWindowState.Maximized;
        else
            StartPosition = FormStartPosition.Manual;
    }

    private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
    {
        Logger.Trace($"FormPrincipal_FormClosing(sender='{sender}', e='{e}')");

        // Antes de cerrar la aplicación, guardo la posición actual,
        // el tamaño y el estado de la ventana
        if (WindowState == FormWindowState.Normal)
        {
            GlobalSettings.Default.LastWindowLocation = Location;
            GlobalSettings.Default.LastWindowSize = Size;
            GlobalSettings.Default.LastWindowIsMaximized = false;
        }
        else
        {
            GlobalSettings.Default.LastWindowLocation = RestoreBounds.Location;
            GlobalSettings.Default.LastWindowSize = RestoreBounds.Size;
        }

        GlobalSettings.Default.LastWindowIsMaximized = WindowState == FormWindowState.Maximized;
    }

    private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
    {
        Logger.Trace($"FormPrincipal_FormClosed(sender='{sender}', e='{e}')");

        // Guardo todos las opciones en el computador
        GlobalSettings.Default.Save();
    }

    #region tab-1

    private void SetWaifuLocation_Event(object sender, EventArgs e)
    {
        Logger.Trace($"SetWaifuLocation_Event(sender='{sender}', e='{e}')");

        if (openFileDialogWaifuLocation.ShowDialog() == DialogResult.OK)
        {
            // Asigno la ruta del binario al TextBox y guardo su ubicación
            // también en las opciones globales
            txtWaifuLocation.Text = openFileDialogWaifuLocation.FileName;
            GlobalSettings.Default.WaifuLocation = openFileDialogWaifuLocation.FileName;
        }
    }

    private void btnSelectFiles_Click(object sender, EventArgs e)
    {
        Logger.Trace($"btnSelectFiles_Click(sender='{sender}', e='{e}')");

        if (openFileDialogSelectImages.ShowDialog() == DialogResult.OK)
        {
            foreach (var imageFile in openFileDialogSelectImages.FileNames)
            {
                // Obtengo el nombre del archivo (sin la ruta)
                var fileName = Path.GetFileName(imageFile);

                // Agrego la imagen a la Lista (como icono)
                imageList.Images.Add(fileName, Image.FromFile(imageFile));

                // Creo un nuevo Item para visualizarlo en el Formulario
                var item = new ListViewItem()
                {
                    Text = fileName,
                    ImageKey = fileName,
                    Name = imageFile
                };

                // Agrego el Item al ListView
                listFilesLocation.Items.Add(item);
            }
        }
    }

    private void listFilesLocation_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            // Voy eliminando todos los Itemes uno a uno
            // Se debe hacer así porque la lista se va modificando cada vez que elimino un elemento
            while (listFilesLocation.SelectedItems.Count > 0)
            {
                listFilesLocation.Items.RemoveAt(listFilesLocation.SelectedItems[0].Index);
            }
        }
    }

    private void SetTargetFolder_Event(object sender, EventArgs e)
    {
        Logger.Trace($"SetTargetFolder_Event(sender='{sender}', e='{e}')");

        if (folderBrowserTargetFolder.ShowDialog() == DialogResult.OK)
        {
            // Sólo un aviso en caso de detectar que el directorio tiene algun archivo
            // puesto que se podría pisar con el resultado del proceso
            if (!FileUtils.IsDirectoryEmpty(folderBrowserTargetFolder.SelectedPath))
            {
                var result = MessageBox.Show("El directorio seleccionado no esta vacio. ¿Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }

            // Asigno la ruta de la carpeta al TextBox y guardo su ubicación
            // también en las opciones globales
            txtTargetFolder.Text = folderBrowserTargetFolder.SelectedPath;
            GlobalSettings.Default.LastTargetFolder = folderBrowserTargetFolder.SelectedPath;
        }
    }

    #endregion

    #region tab-2

    private void UpdateSettings_Event(object sender, EventArgs e)
    {
        GlobalSettings.Default.LastDenoiseLevel = numericDenoiseLevel.Value;
        GlobalSettings.Default.LastTileSize = numericTileSize.Value;
        GlobalSettings.Default.LastTileSizeAuto = checkBoxTileSizeAuto.Checked;
        GlobalSettings.Default.LastModelPath = comboBoxModelPath.Text;

        if (rdBtnUpscaleRatio1.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio1.Text);
        else if (rdBtnUpscaleRatio2.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio2.Text);
        else if (rdBtnUpscaleRatio2.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio2.Text);
        else if (rdBtnUpscaleRatio4.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio4.Text);
        else if (rdBtnUpscaleRatio8.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio8.Text);
        else if (rdBtnUpscaleRatio16.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio16.Text);
        else if (rdBtnUpscaleRatio32.Checked) GlobalSettings.Default.LastUpscaleRatio = int.Parse(rdBtnUpscaleRatio32.Text);

        GlobalSettings.Default.LastEnableTTAMode = checkBoxTtaMode.Checked;

        if (rdBtnImageFormatJpg.Checked) GlobalSettings.Default.LastOutputFormat = rdBtnImageFormatJpg.Text;
        else if (rdBtnImageFormatPng.Checked) GlobalSettings.Default.LastOutputFormat = rdBtnImageFormatPng.Text;
        else if (rdBtnImageFormatWebp.Checked) GlobalSettings.Default.LastOutputFormat = rdBtnImageFormatWebp.Text;
    }

    private void checkBoxTileSizeAuto_CheckedChanged(object sender, EventArgs e)
    {
        Logger.Trace($"checkBoxTileSizeAuto_CheckedChanged(sender='{sender}', e='{e}')");

        numericTileSize.Enabled = !checkBoxTileSizeAuto.Checked;
    }

    #endregion

    private void btnExportBatch_Click(object sender, EventArgs e)
    {
        Logger.Trace($"btnProcess_Click(sender='{sender}', e='{e}')");

        // Verifico que todas las opciones esten presentes antes de continuar
        if (!CheckFormValues())
            return;

        // Actualizo las opciones en caso de que no se haya realizado previamente
        UpdateSettings_Event(this, new EventArgs());
        GlobalSettings.Default.Save();

        // Inicializo el formulario de procesamiento
        // y le paso la ruta de todas las imagenes seleccionadas
        var form = new FormProcessing()
        {
            ImageFiles = GetImages()
        };

        // Recupero la lista de comandos
        var commands = form.GetCommands();

        // Ventana para guardar la lista de comandos
        if (saveFileDialogScript.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialogScript.FileName, commands);

            MessageBox.Show("Archivo de script guardado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnProcess_Click(object sender, EventArgs e)
    {
        Logger.Trace($"btnProcess_Click(sender='{sender}', e='{e}')");

        // Verifico que todas las opciones esten presentes antes de continuar
        if (!CheckFormValues())
            return;

        // Actualizo las opciones en caso de que no se haya realizado previamente
        UpdateSettings_Event(this, new EventArgs());
        GlobalSettings.Default.Save();

        // Inicializo el formulario de procesamiento
        // y le paso la ruta de todas las imagenes seleccionadas
        var form = new FormProcessing()
        {
            ImageFiles = GetImages()
        };

        // Muestro la ventana nueva y espero su resultado
        // En caso de ser exitoso, limpio la lista de registros
        if (form.ShowDialog() == DialogResult.OK)
            listFilesLocation.Items.Clear();
    }

    #endregion
}