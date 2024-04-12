namespace Bookstore
{
    public partial class BookstoreForm
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
            labelWelcome = new Label();
            buttonLoadExcel = new Button();
            buttonBrowseFiles = new Button();
            textboxFileName = new TextBox();
            dataGridViewExcelFile = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExcelFile).BeginInit();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 16F);
            labelWelcome.Location = new Point(11, 9);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(250, 30);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome To Bits & Books!";
            // 
            // buttonLoadExcel
            // 
            buttonLoadExcel.Location = new Point(261, 50);
            buttonLoadExcel.Name = "buttonLoadExcel";
            buttonLoadExcel.Size = new Size(96, 23);
            buttonLoadExcel.TabIndex = 1;
            buttonLoadExcel.Text = "Load Excel File";
            buttonLoadExcel.UseVisualStyleBackColor = true;
            buttonLoadExcel.Click += buttonLoadExcel_Click;
            // 
            // buttonBrowseFiles
            // 
            buttonBrowseFiles.Location = new Point(180, 50);
            buttonBrowseFiles.Name = "buttonBrowseFiles";
            buttonBrowseFiles.Size = new Size(75, 23);
            buttonBrowseFiles.TabIndex = 2;
            buttonBrowseFiles.Text = "Browse ";
            buttonBrowseFiles.UseVisualStyleBackColor = true;
            buttonBrowseFiles.Click += buttonBrowseFiles_Click;
            // 
            // textboxFileName
            // 
            textboxFileName.Location = new Point(12, 50);
            textboxFileName.Name = "textboxFileName";
            textboxFileName.Size = new Size(162, 23);
            textboxFileName.TabIndex = 3;
            // 
            // dataGridViewExcelFile
            // 
            dataGridViewExcelFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExcelFile.Location = new Point(15, 85);
            dataGridViewExcelFile.Name = "dataGridViewExcelFile";
            dataGridViewExcelFile.Size = new Size(333, 191);
            dataGridViewExcelFile.TabIndex = 4;
            // 
            // BookstoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewExcelFile);
            Controls.Add(textboxFileName);
            Controls.Add(buttonBrowseFiles);
            Controls.Add(buttonLoadExcel);
            Controls.Add(labelWelcome);
            Name = "BookstoreForm";
            Text = "Bits & Books";
            ((System.ComponentModel.ISupportInitialize)dataGridViewExcelFile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Button buttonLoadExcel;
        private Button buttonBrowseFiles;
        private TextBox textboxFileName;
        public DataGridView dataGridViewExcelFile;
    }
}
