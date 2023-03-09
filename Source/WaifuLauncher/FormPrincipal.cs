namespace WaifuLauncher;

public partial class FormPrincipal : Form
{
    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {

    }

    private void btnFindWaifuLocation_Click(object sender, EventArgs e)
    {
        if (openFileDialogWaifuLocation.ShowDialog() == DialogResult.OK)
        {
            txtWaifuLocation.Text = openFileDialogWaifuLocation.FileName;
        }
    }

    private void btnSelectFiles_Click(object sender, EventArgs e)
    {
        if (openFileDialogSelectImages.ShowDialog() == DialogResult.OK)
        {
            foreach (var imageFile in openFileDialogSelectImages.FileNames)
            {
                // Obtengo el nombre del archivo (sin la ruta)
                var fileName = Path.GetFileName(imageFile);

                // Agrego la imagen a la Lista
                imageList.Images.Add(fileName, Image.FromFile(imageFile));

                // Creo un nuevo Item para visualizarlo en el Formulario
                var item = new ListViewItem()
                {
                    Text = fileName,
                    ImageKey = fileName
                };

                // Agrego el Item al ListView
                listFilesLocation.Items.Add(item);
            }
        }
    }

    private void btnSelectTargetFolder_Click(object sender, EventArgs e)
    {
        if (folderBrowserTargetFolder.ShowDialog() == DialogResult.OK)
        {
            txtTargetFolder.Text = folderBrowserTargetFolder.SelectedPath;
        }
    }

    private void checkBoxTileSizeAuto_CheckedChanged(object sender, EventArgs e)
    {
        numericTileSize.Enabled = !checkBoxTileSizeAuto.Checked;
    }


}