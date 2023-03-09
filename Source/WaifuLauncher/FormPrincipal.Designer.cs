namespace WaifuLauncher;

partial class FormPrincipal
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
        txtWaifuLocation = new TextBox();
        groupWaifuLocation = new GroupBox();
        btnFindWaifuLocation = new Button();
        listFilesLocation = new ListView();
        imageList = new ImageList(components);
        groupFiles = new GroupBox();
        btnSelectFiles = new Button();
        openFileDialogWaifuLocation = new OpenFileDialog();
        openFileDialogSelectImages = new OpenFileDialog();
        tabsPrincipal = new TabControl();
        tabPage1 = new TabPage();
        groupTargetFolder = new GroupBox();
        txtTargetFolder = new TextBox();
        btnSelectTargetFolder = new Button();
        tabPage2 = new TabPage();
        groupImageFormat = new GroupBox();
        rdBtnWebp = new RadioButton();
        rdBtnImageFormatJpg = new RadioButton();
        rdBtnImageFormatPng = new RadioButton();
        groupDenoiseLevel = new GroupBox();
        numericDenoiseLevel = new NumericUpDown();
        groupTileSize = new GroupBox();
        numericTileSize = new NumericUpDown();
        checkBoxTileSizeAuto = new CheckBox();
        groupModelPath = new GroupBox();
        comboBoxModelPath = new ComboBox();
        groupUpscaleRatio = new GroupBox();
        rdBtnUpscaleRatio32 = new RadioButton();
        rdBtnUpscaleRatio16 = new RadioButton();
        rdBtnUpscaleRatio8 = new RadioButton();
        rdBtnUpscaleRatio4 = new RadioButton();
        rdBtnUpscaleRatio2 = new RadioButton();
        rdBtnUpscaleRatio1 = new RadioButton();
        groupTtaMode = new GroupBox();
        checkBoxTtaMode = new CheckBox();
        btnProcess = new Button();
        btnExportBatch = new Button();
        folderBrowserTargetFolder = new FolderBrowserDialog();
        groupWaifuLocation.SuspendLayout();
        groupFiles.SuspendLayout();
        tabsPrincipal.SuspendLayout();
        tabPage1.SuspendLayout();
        groupTargetFolder.SuspendLayout();
        tabPage2.SuspendLayout();
        groupImageFormat.SuspendLayout();
        groupDenoiseLevel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericDenoiseLevel).BeginInit();
        groupTileSize.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericTileSize).BeginInit();
        groupModelPath.SuspendLayout();
        groupUpscaleRatio.SuspendLayout();
        groupTtaMode.SuspendLayout();
        SuspendLayout();
        // 
        // txtWaifuLocation
        // 
        txtWaifuLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtWaifuLocation.Location = new Point(6, 22);
        txtWaifuLocation.Name = "txtWaifuLocation";
        txtWaifuLocation.ReadOnly = true;
        txtWaifuLocation.Size = new Size(663, 23);
        txtWaifuLocation.TabIndex = 0;
        // 
        // groupWaifuLocation
        // 
        groupWaifuLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupWaifuLocation.Controls.Add(txtWaifuLocation);
        groupWaifuLocation.Controls.Add(btnFindWaifuLocation);
        groupWaifuLocation.Location = new Point(6, 6);
        groupWaifuLocation.Name = "groupWaifuLocation";
        groupWaifuLocation.Size = new Size(756, 56);
        groupWaifuLocation.TabIndex = 1;
        groupWaifuLocation.TabStop = false;
        groupWaifuLocation.Text = "Ubicación de Waifu2x";
        // 
        // btnFindWaifuLocation
        // 
        btnFindWaifuLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnFindWaifuLocation.Location = new Point(675, 22);
        btnFindWaifuLocation.Name = "btnFindWaifuLocation";
        btnFindWaifuLocation.Size = new Size(75, 24);
        btnFindWaifuLocation.TabIndex = 1;
        btnFindWaifuLocation.Text = "Buscar";
        btnFindWaifuLocation.UseVisualStyleBackColor = true;
        btnFindWaifuLocation.Click += btnFindWaifuLocation_Click;
        // 
        // listFilesLocation
        // 
        listFilesLocation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listFilesLocation.LargeImageList = imageList;
        listFilesLocation.Location = new Point(6, 22);
        listFilesLocation.Name = "listFilesLocation";
        listFilesLocation.Size = new Size(744, 150);
        listFilesLocation.SmallImageList = imageList;
        listFilesLocation.TabIndex = 2;
        listFilesLocation.UseCompatibleStateImageBehavior = false;
        // 
        // imageList
        // 
        imageList.ColorDepth = ColorDepth.Depth8Bit;
        imageList.ImageSize = new Size(16, 16);
        imageList.TransparentColor = Color.Transparent;
        // 
        // groupFiles
        // 
        groupFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupFiles.Controls.Add(listFilesLocation);
        groupFiles.Controls.Add(btnSelectFiles);
        groupFiles.Location = new Point(6, 68);
        groupFiles.Name = "groupFiles";
        groupFiles.Size = new Size(756, 207);
        groupFiles.TabIndex = 3;
        groupFiles.TabStop = false;
        groupFiles.Text = "Lista de imágenes";
        // 
        // btnSelectFiles
        // 
        btnSelectFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnSelectFiles.Location = new Point(6, 178);
        btnSelectFiles.Name = "btnSelectFiles";
        btnSelectFiles.Size = new Size(744, 23);
        btnSelectFiles.TabIndex = 3;
        btnSelectFiles.Text = "Seleccionar imágenes";
        btnSelectFiles.UseVisualStyleBackColor = true;
        btnSelectFiles.Click += btnSelectFiles_Click;
        // 
        // openFileDialogWaifuLocation
        // 
        openFileDialogWaifuLocation.Filter = "Aplicación (*.exe)|*.exe|Todos los archivos (*.*)|*.*";
        // 
        // openFileDialogSelectImages
        // 
        openFileDialogSelectImages.Filter = "Todos los archivos (*.*)|*.*";
        openFileDialogSelectImages.Multiselect = true;
        // 
        // tabsPrincipal
        // 
        tabsPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabsPrincipal.Controls.Add(tabPage1);
        tabsPrincipal.Controls.Add(tabPage2);
        tabsPrincipal.Location = new Point(12, 12);
        tabsPrincipal.Name = "tabsPrincipal";
        tabsPrincipal.SelectedIndex = 0;
        tabsPrincipal.Size = new Size(776, 371);
        tabsPrincipal.TabIndex = 4;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(groupWaifuLocation);
        tabPage1.Controls.Add(groupFiles);
        tabPage1.Controls.Add(groupTargetFolder);
        tabPage1.Location = new Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(768, 343);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Imagenes";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // groupTargetFolder
        // 
        groupTargetFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupTargetFolder.Controls.Add(txtTargetFolder);
        groupTargetFolder.Controls.Add(btnSelectTargetFolder);
        groupTargetFolder.Location = new Point(6, 281);
        groupTargetFolder.Name = "groupTargetFolder";
        groupTargetFolder.Size = new Size(756, 56);
        groupTargetFolder.TabIndex = 2;
        groupTargetFolder.TabStop = false;
        groupTargetFolder.Text = "Carpeta destino";
        // 
        // txtTargetFolder
        // 
        txtTargetFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtTargetFolder.Location = new Point(6, 22);
        txtTargetFolder.Name = "txtTargetFolder";
        txtTargetFolder.ReadOnly = true;
        txtTargetFolder.Size = new Size(651, 23);
        txtTargetFolder.TabIndex = 0;
        // 
        // btnSelectTargetFolder
        // 
        btnSelectTargetFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSelectTargetFolder.Location = new Point(663, 20);
        btnSelectTargetFolder.Name = "btnSelectTargetFolder";
        btnSelectTargetFolder.Size = new Size(87, 24);
        btnSelectTargetFolder.TabIndex = 1;
        btnSelectTargetFolder.Text = "Seleccionar";
        btnSelectTargetFolder.UseVisualStyleBackColor = true;
        btnSelectTargetFolder.Click += btnSelectTargetFolder_Click;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(groupImageFormat);
        tabPage2.Controls.Add(groupDenoiseLevel);
        tabPage2.Controls.Add(groupTileSize);
        tabPage2.Controls.Add(groupModelPath);
        tabPage2.Controls.Add(groupUpscaleRatio);
        tabPage2.Controls.Add(groupTtaMode);
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(768, 343);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Opciones";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // groupImageFormat
        // 
        groupImageFormat.Controls.Add(rdBtnWebp);
        groupImageFormat.Controls.Add(rdBtnImageFormatJpg);
        groupImageFormat.Controls.Add(rdBtnImageFormatPng);
        groupImageFormat.Location = new Point(275, 66);
        groupImageFormat.Name = "groupImageFormat";
        groupImageFormat.Size = new Size(121, 109);
        groupImageFormat.TabIndex = 4;
        groupImageFormat.TabStop = false;
        groupImageFormat.Text = "Output format";
        // 
        // rdBtnWebp
        // 
        rdBtnWebp.AutoSize = true;
        rdBtnWebp.Location = new Point(6, 72);
        rdBtnWebp.Name = "rdBtnWebp";
        rdBtnWebp.Size = new Size(54, 19);
        rdBtnWebp.TabIndex = 8;
        rdBtnWebp.Text = "webp";
        rdBtnWebp.UseVisualStyleBackColor = true;
        // 
        // rdBtnImageFormatJpg
        // 
        rdBtnImageFormatJpg.AutoSize = true;
        rdBtnImageFormatJpg.Location = new Point(6, 22);
        rdBtnImageFormatJpg.Name = "rdBtnImageFormatJpg";
        rdBtnImageFormatJpg.Size = new Size(42, 19);
        rdBtnImageFormatJpg.TabIndex = 6;
        rdBtnImageFormatJpg.Text = "jpg";
        rdBtnImageFormatJpg.UseVisualStyleBackColor = true;
        // 
        // rdBtnImageFormatPng
        // 
        rdBtnImageFormatPng.AutoSize = true;
        rdBtnImageFormatPng.Checked = true;
        rdBtnImageFormatPng.Location = new Point(6, 47);
        rdBtnImageFormatPng.Name = "rdBtnImageFormatPng";
        rdBtnImageFormatPng.Size = new Size(46, 19);
        rdBtnImageFormatPng.TabIndex = 7;
        rdBtnImageFormatPng.TabStop = true;
        rdBtnImageFormatPng.Text = "png";
        rdBtnImageFormatPng.UseVisualStyleBackColor = true;
        // 
        // groupDenoiseLevel
        // 
        groupDenoiseLevel.Controls.Add(numericDenoiseLevel);
        groupDenoiseLevel.Location = new Point(6, 6);
        groupDenoiseLevel.Name = "groupDenoiseLevel";
        groupDenoiseLevel.Size = new Size(117, 54);
        groupDenoiseLevel.TabIndex = 0;
        groupDenoiseLevel.TabStop = false;
        groupDenoiseLevel.Text = "Denoise Level";
        // 
        // numericDenoiseLevel
        // 
        numericDenoiseLevel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        numericDenoiseLevel.Location = new Point(6, 22);
        numericDenoiseLevel.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
        numericDenoiseLevel.Name = "numericDenoiseLevel";
        numericDenoiseLevel.Size = new Size(105, 23);
        numericDenoiseLevel.TabIndex = 0;
        // 
        // groupTileSize
        // 
        groupTileSize.Controls.Add(numericTileSize);
        groupTileSize.Controls.Add(checkBoxTileSizeAuto);
        groupTileSize.Location = new Point(129, 6);
        groupTileSize.Name = "groupTileSize";
        groupTileSize.Size = new Size(140, 54);
        groupTileSize.TabIndex = 1;
        groupTileSize.TabStop = false;
        groupTileSize.Text = "Tile Size";
        // 
        // numericTileSize
        // 
        numericTileSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        numericTileSize.Location = new Point(6, 22);
        numericTileSize.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
        numericTileSize.Name = "numericTileSize";
        numericTileSize.Size = new Size(70, 23);
        numericTileSize.TabIndex = 0;
        // 
        // checkBoxTileSizeAuto
        // 
        checkBoxTileSizeAuto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        checkBoxTileSizeAuto.AutoSize = true;
        checkBoxTileSizeAuto.Checked = true;
        checkBoxTileSizeAuto.CheckState = CheckState.Checked;
        checkBoxTileSizeAuto.Location = new Point(82, 22);
        checkBoxTileSizeAuto.Name = "checkBoxTileSizeAuto";
        checkBoxTileSizeAuto.Size = new Size(52, 19);
        checkBoxTileSizeAuto.TabIndex = 1;
        checkBoxTileSizeAuto.Text = "Auto";
        checkBoxTileSizeAuto.UseVisualStyleBackColor = true;
        checkBoxTileSizeAuto.CheckedChanged += checkBoxTileSizeAuto_CheckedChanged;
        // 
        // groupModelPath
        // 
        groupModelPath.Controls.Add(comboBoxModelPath);
        groupModelPath.Location = new Point(275, 6);
        groupModelPath.Name = "groupModelPath";
        groupModelPath.Size = new Size(180, 54);
        groupModelPath.TabIndex = 2;
        groupModelPath.TabStop = false;
        groupModelPath.Text = "Model Path";
        // 
        // comboBoxModelPath
        // 
        comboBoxModelPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        comboBoxModelPath.FormattingEnabled = true;
        comboBoxModelPath.Items.AddRange(new object[] { "models-cunet" });
        comboBoxModelPath.Location = new Point(6, 20);
        comboBoxModelPath.Name = "comboBoxModelPath";
        comboBoxModelPath.Size = new Size(168, 23);
        comboBoxModelPath.TabIndex = 0;
        // 
        // groupUpscaleRatio
        // 
        groupUpscaleRatio.Controls.Add(rdBtnUpscaleRatio32);
        groupUpscaleRatio.Controls.Add(rdBtnUpscaleRatio16);
        groupUpscaleRatio.Controls.Add(rdBtnUpscaleRatio8);
        groupUpscaleRatio.Controls.Add(rdBtnUpscaleRatio4);
        groupUpscaleRatio.Controls.Add(rdBtnUpscaleRatio2);
        groupUpscaleRatio.Controls.Add(rdBtnUpscaleRatio1);
        groupUpscaleRatio.Location = new Point(6, 66);
        groupUpscaleRatio.Name = "groupUpscaleRatio";
        groupUpscaleRatio.Size = new Size(117, 109);
        groupUpscaleRatio.TabIndex = 1;
        groupUpscaleRatio.TabStop = false;
        groupUpscaleRatio.Text = "Upscale Ratio";
        // 
        // rdBtnUpscaleRatio32
        // 
        rdBtnUpscaleRatio32.AutoSize = true;
        rdBtnUpscaleRatio32.Location = new Point(55, 72);
        rdBtnUpscaleRatio32.Name = "rdBtnUpscaleRatio32";
        rdBtnUpscaleRatio32.Size = new Size(37, 19);
        rdBtnUpscaleRatio32.TabIndex = 5;
        rdBtnUpscaleRatio32.Text = "32";
        rdBtnUpscaleRatio32.UseVisualStyleBackColor = true;
        // 
        // rdBtnUpscaleRatio16
        // 
        rdBtnUpscaleRatio16.AutoSize = true;
        rdBtnUpscaleRatio16.Location = new Point(55, 47);
        rdBtnUpscaleRatio16.Name = "rdBtnUpscaleRatio16";
        rdBtnUpscaleRatio16.Size = new Size(37, 19);
        rdBtnUpscaleRatio16.TabIndex = 4;
        rdBtnUpscaleRatio16.Text = "16";
        rdBtnUpscaleRatio16.UseVisualStyleBackColor = true;
        // 
        // rdBtnUpscaleRatio8
        // 
        rdBtnUpscaleRatio8.AutoSize = true;
        rdBtnUpscaleRatio8.Location = new Point(55, 22);
        rdBtnUpscaleRatio8.Name = "rdBtnUpscaleRatio8";
        rdBtnUpscaleRatio8.Size = new Size(31, 19);
        rdBtnUpscaleRatio8.TabIndex = 3;
        rdBtnUpscaleRatio8.Text = "8";
        rdBtnUpscaleRatio8.UseVisualStyleBackColor = true;
        // 
        // rdBtnUpscaleRatio4
        // 
        rdBtnUpscaleRatio4.AutoSize = true;
        rdBtnUpscaleRatio4.Location = new Point(6, 72);
        rdBtnUpscaleRatio4.Name = "rdBtnUpscaleRatio4";
        rdBtnUpscaleRatio4.Size = new Size(31, 19);
        rdBtnUpscaleRatio4.TabIndex = 2;
        rdBtnUpscaleRatio4.Text = "4";
        rdBtnUpscaleRatio4.UseVisualStyleBackColor = true;
        // 
        // rdBtnUpscaleRatio2
        // 
        rdBtnUpscaleRatio2.AutoSize = true;
        rdBtnUpscaleRatio2.Checked = true;
        rdBtnUpscaleRatio2.Location = new Point(6, 47);
        rdBtnUpscaleRatio2.Name = "rdBtnUpscaleRatio2";
        rdBtnUpscaleRatio2.Size = new Size(31, 19);
        rdBtnUpscaleRatio2.TabIndex = 1;
        rdBtnUpscaleRatio2.TabStop = true;
        rdBtnUpscaleRatio2.Text = "2";
        rdBtnUpscaleRatio2.UseVisualStyleBackColor = true;
        // 
        // rdBtnUpscaleRatio1
        // 
        rdBtnUpscaleRatio1.AutoSize = true;
        rdBtnUpscaleRatio1.Location = new Point(6, 22);
        rdBtnUpscaleRatio1.Name = "rdBtnUpscaleRatio1";
        rdBtnUpscaleRatio1.Size = new Size(31, 19);
        rdBtnUpscaleRatio1.TabIndex = 0;
        rdBtnUpscaleRatio1.Text = "1";
        rdBtnUpscaleRatio1.UseVisualStyleBackColor = true;
        // 
        // groupTtaMode
        // 
        groupTtaMode.Controls.Add(checkBoxTtaMode);
        groupTtaMode.Location = new Point(129, 66);
        groupTtaMode.Name = "groupTtaMode";
        groupTtaMode.Size = new Size(140, 54);
        groupTtaMode.TabIndex = 3;
        groupTtaMode.TabStop = false;
        // 
        // checkBoxTtaMode
        // 
        checkBoxTtaMode.AutoSize = true;
        checkBoxTtaMode.Location = new Point(6, 22);
        checkBoxTtaMode.Name = "checkBoxTtaMode";
        checkBoxTtaMode.Size = new Size(117, 19);
        checkBoxTtaMode.TabIndex = 1;
        checkBoxTtaMode.Text = "Enable TTA Mode";
        checkBoxTtaMode.UseVisualStyleBackColor = true;
        // 
        // btnProcess
        // 
        btnProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnProcess.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
        btnProcess.Location = new Point(647, 389);
        btnProcess.Name = "btnProcess";
        btnProcess.Size = new Size(141, 49);
        btnProcess.TabIndex = 5;
        btnProcess.Text = "Procesar";
        btnProcess.UseVisualStyleBackColor = false;
        // 
        // btnExportBatch
        // 
        btnExportBatch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnExportBatch.Location = new Point(12, 415);
        btnExportBatch.Name = "btnExportBatch";
        btnExportBatch.Size = new Size(127, 23);
        btnExportBatch.TabIndex = 6;
        btnExportBatch.Text = "Exportar";
        btnExportBatch.UseVisualStyleBackColor = true;
        // 
        // folderBrowserTargetFolder
        // 
        folderBrowserTargetFolder.RootFolder = Environment.SpecialFolder.MyPictures;
        // 
        // FormPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnExportBatch);
        Controls.Add(btnProcess);
        Controls.Add(tabsPrincipal);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FormPrincipal";
        Text = "Waifu2x Launcher";
        Load += FormPrincipal_Load;
        groupWaifuLocation.ResumeLayout(false);
        groupWaifuLocation.PerformLayout();
        groupFiles.ResumeLayout(false);
        tabsPrincipal.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        groupTargetFolder.ResumeLayout(false);
        groupTargetFolder.PerformLayout();
        tabPage2.ResumeLayout(false);
        groupImageFormat.ResumeLayout(false);
        groupImageFormat.PerformLayout();
        groupDenoiseLevel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numericDenoiseLevel).EndInit();
        groupTileSize.ResumeLayout(false);
        groupTileSize.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericTileSize).EndInit();
        groupModelPath.ResumeLayout(false);
        groupUpscaleRatio.ResumeLayout(false);
        groupUpscaleRatio.PerformLayout();
        groupTtaMode.ResumeLayout(false);
        groupTtaMode.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TextBox txtWaifuLocation;
    private GroupBox groupWaifuLocation;
    private Button btnFindWaifuLocation;
    private ListView listFilesLocation;
    private GroupBox groupFiles;
    private Button btnSelectFiles;
    private OpenFileDialog openFileDialogWaifuLocation;
    private OpenFileDialog openFileDialogSelectImages;
    private ImageList imageList;
    private TabControl tabsPrincipal;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private Button btnProcess;
    private Button btnExportBatch;
    private GroupBox groupUpscaleRatio;
    private RadioButton rdBtnUpscaleRatio32;
    private RadioButton rdBtnUpscaleRatio16;
    private RadioButton rdBtnUpscaleRatio8;
    private RadioButton rdBtnUpscaleRatio4;
    private RadioButton rdBtnUpscaleRatio2;
    private RadioButton rdBtnUpscaleRatio1;
    private GroupBox groupDenoiseLevel;
    private NumericUpDown numericDenoiseLevel;
    private GroupBox groupTileSize;
    private NumericUpDown numericTileSize;
    private CheckBox checkBoxTileSizeAuto;
    private GroupBox groupTtaMode;
    private CheckBox checkBoxTtaMode;
    private GroupBox groupModelPath;
    private ComboBox comboBoxModelPath;
    private GroupBox groupTargetFolder;
    private TextBox txtTargetFolder;
    private Button btnSelectTargetFolder;
    private GroupBox groupImageFormat;
    private RadioButton rdBtnWebp;
    private RadioButton rdBtnImageFormatJpg;
    private RadioButton rdBtnImageFormatPng;
    private FolderBrowserDialog folderBrowserTargetFolder;
}