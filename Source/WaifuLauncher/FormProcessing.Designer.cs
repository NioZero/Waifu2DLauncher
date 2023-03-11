namespace WaifuLauncher
{
    partial class FormProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            workerProcessing = new System.ComponentModel.BackgroundWorker();
            progressBar = new ProgressBar();
            labelStatus = new Label();
            btnCancel = new Button();
            textBoxLog = new RichTextBox();
            imageList = new ImageList(components);
            SuspendLayout();
            // 
            // workerProcessing
            // 
            workerProcessing.WorkerReportsProgress = true;
            workerProcessing.WorkerSupportsCancellation = true;
            workerProcessing.DoWork += workerProcessing_DoWork;
            workerProcessing.ProgressChanged += workerProcessing_ProgressChanged;
            workerProcessing.RunWorkerCompleted += workerProcessing_RunWorkerCompleted;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 36);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(673, 23);
            progressBar.TabIndex = 0;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 18);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(110, 15);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "Iniciando proceso...";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(571, 288);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 42);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // textBoxLog
            // 
            textBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLog.BackColor = SystemColors.ControlDark;
            textBoxLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLog.Location = new Point(12, 65);
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ReadOnly = true;
            textBoxLog.Size = new Size(673, 217);
            textBoxLog.TabIndex = 3;
            textBoxLog.Text = "";
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // FormProcessing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 342);
            ControlBox = false;
            Controls.Add(textBoxLog);
            Controls.Add(btnCancel);
            Controls.Add(labelStatus);
            Controls.Add(progressBar);
            MinimumSize = new Size(520, 300);
            Name = "FormProcessing";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Procesando";
            Load += FormProcessing_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker workerProcessing;
        private ProgressBar progressBar;
        private Label labelStatus;
        private Button btnCancel;
        private RichTextBox textBoxLog;
        internal ImageList imageList;
    }
}