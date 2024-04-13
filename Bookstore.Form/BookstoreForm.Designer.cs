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
            textboxDatabaseFile = new TextBox();
            buttonBrowseDatabase = new Button();
            labelSuccessParsingExcel = new Label();
            labelAddCustomer = new Label();
            textBoxCustomerFirstName = new TextBox();
            textBoxCustomerMiddleName = new TextBox();
            textBoxCustomerLastName = new TextBox();
            textBoxCustomerEmail = new TextBox();
            textBoxMembershipPassword = new TextBox();
            textBoxCustomerPhone = new TextBox();
            buttonAddCustomer = new Button();
            labelAddInventory = new Label();
            comboBoxInventoryBook = new ComboBox();
            textBoxInventoryQuantity = new TextBox();
            comboBoxInventoryBookstore = new ComboBox();
            labelAddBookstore = new Label();
            textBoxBookstoreLocation = new TextBox();
            buttonAddInventory = new Button();
            buttonAddBookstore = new Button();
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
            buttonLoadExcel.Location = new Point(133, 113);
            buttonLoadExcel.Name = "buttonLoadExcel";
            buttonLoadExcel.Size = new Size(96, 23);
            buttonLoadExcel.TabIndex = 1;
            buttonLoadExcel.Text = "Load Database Data";
            buttonLoadExcel.UseVisualStyleBackColor = true;
            buttonLoadExcel.Click += buttonLoadExcel_Click;
            // 
            // buttonBrowseFiles
            // 
            buttonBrowseFiles.Location = new Point(235, 84);
            buttonBrowseFiles.Name = "buttonBrowseFiles";
            buttonBrowseFiles.Size = new Size(75, 23);
            buttonBrowseFiles.TabIndex = 2;
            buttonBrowseFiles.Text = "Browse ";
            buttonBrowseFiles.UseVisualStyleBackColor = true;
            buttonBrowseFiles.Click += buttonBrowseFiles_Click;
            // 
            // textboxFileName
            // 
            textboxFileName.Location = new Point(67, 84);
            textboxFileName.Name = "textboxFileName";
            textboxFileName.Size = new Size(162, 23);
            textboxFileName.TabIndex = 3;
            textboxFileName.Text = "Excel File";
            // 
            // dataGridViewExcelFile
            // 
            dataGridViewExcelFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExcelFile.Location = new Point(12, 142);
            dataGridViewExcelFile.Name = "dataGridViewExcelFile";
            dataGridViewExcelFile.Size = new Size(345, 260);
            dataGridViewExcelFile.TabIndex = 4;
            // 
            // textboxDatabaseFile
            // 
            textboxDatabaseFile.Location = new Point(67, 52);
            textboxDatabaseFile.Name = "textboxDatabaseFile";
            textboxDatabaseFile.Size = new Size(162, 23);
            textboxDatabaseFile.TabIndex = 7;
            textboxDatabaseFile.Text = "Database File";
            // 
            // buttonBrowseDatabase
            // 
            buttonBrowseDatabase.Location = new Point(235, 52);
            buttonBrowseDatabase.Name = "buttonBrowseDatabase";
            buttonBrowseDatabase.Size = new Size(75, 23);
            buttonBrowseDatabase.TabIndex = 6;
            buttonBrowseDatabase.Text = "Browse ";
            buttonBrowseDatabase.UseVisualStyleBackColor = true;
            buttonBrowseDatabase.Click += buttonBrowseDatabase_Click;
            // 
            // labelSuccessParsingExcel
            // 
            labelSuccessParsingExcel.AutoSize = true;
            labelSuccessParsingExcel.Location = new Point(99, 415);
            labelSuccessParsingExcel.Name = "labelSuccessParsingExcel";
            labelSuccessParsingExcel.Size = new Size(0, 15);
            labelSuccessParsingExcel.TabIndex = 8;
            // 
            // labelAddCustomer
            // 
            labelAddCustomer.AutoSize = true;
            labelAddCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAddCustomer.Location = new Point(405, 16);
            labelAddCustomer.Name = "labelAddCustomer";
            labelAddCustomer.Size = new Size(110, 21);
            labelAddCustomer.TabIndex = 9;
            labelAddCustomer.Text = "Add Customer";
            // 
            // textBoxCustomerFirstName
            // 
            textBoxCustomerFirstName.Location = new Point(405, 44);
            textBoxCustomerFirstName.Name = "textBoxCustomerFirstName";
            textBoxCustomerFirstName.Size = new Size(100, 23);
            textBoxCustomerFirstName.TabIndex = 10;
            textBoxCustomerFirstName.Text = "First Name";
            // 
            // textBoxCustomerMiddleName
            // 
            textBoxCustomerMiddleName.Location = new Point(405, 73);
            textBoxCustomerMiddleName.Name = "textBoxCustomerMiddleName";
            textBoxCustomerMiddleName.Size = new Size(100, 23);
            textBoxCustomerMiddleName.TabIndex = 11;
            textBoxCustomerMiddleName.Text = "Middle Name";
            // 
            // textBoxCustomerLastName
            // 
            textBoxCustomerLastName.Location = new Point(405, 102);
            textBoxCustomerLastName.Name = "textBoxCustomerLastName";
            textBoxCustomerLastName.Size = new Size(100, 23);
            textBoxCustomerLastName.TabIndex = 12;
            textBoxCustomerLastName.Text = "Last Name";
            // 
            // textBoxCustomerEmail
            // 
            textBoxCustomerEmail.Location = new Point(670, 285);
            textBoxCustomerEmail.Name = "textBoxCustomerEmail";
            textBoxCustomerEmail.Size = new Size(100, 23);
            textBoxCustomerEmail.TabIndex = 13;
            textBoxCustomerEmail.Text = "Email";
            // 
            // textBoxMembershipPassword
            // 
            textBoxMembershipPassword.Location = new Point(564, 285);
            textBoxMembershipPassword.Name = "textBoxMembershipPassword";
            textBoxMembershipPassword.Size = new Size(100, 23);
            textBoxMembershipPassword.TabIndex = 14;
            textBoxMembershipPassword.Text = "Password";
            // 
            // textBoxCustomerPhone
            // 
            textBoxCustomerPhone.Location = new Point(405, 131);
            textBoxCustomerPhone.Name = "textBoxCustomerPhone";
            textBoxCustomerPhone.Size = new Size(100, 23);
            textBoxCustomerPhone.TabIndex = 15;
            textBoxCustomerPhone.Text = "Phone Number";
            // 
            // buttonAddCustomer
            // 
            buttonAddCustomer.Location = new Point(405, 160);
            buttonAddCustomer.Name = "buttonAddCustomer";
            buttonAddCustomer.Size = new Size(100, 23);
            buttonAddCustomer.TabIndex = 16;
            buttonAddCustomer.Text = "Add Customer";
            buttonAddCustomer.UseVisualStyleBackColor = true;
            // 
            // labelAddInventory
            // 
            labelAddInventory.AutoSize = true;
            labelAddInventory.Font = new Font("Segoe UI", 12F);
            labelAddInventory.Location = new Point(536, 16);
            labelAddInventory.Name = "labelAddInventory";
            labelAddInventory.Size = new Size(108, 21);
            labelAddInventory.TabIndex = 17;
            labelAddInventory.Text = "Add Inventory";
            // 
            // comboBoxInventoryBook
            // 
            comboBoxInventoryBook.FormattingEnabled = true;
            comboBoxInventoryBook.Location = new Point(536, 42);
            comboBoxInventoryBook.Name = "comboBoxInventoryBook";
            comboBoxInventoryBook.Size = new Size(121, 23);
            comboBoxInventoryBook.TabIndex = 18;
            comboBoxInventoryBook.Text = "Book ";
            // 
            // textBoxInventoryQuantity
            // 
            textBoxInventoryQuantity.Location = new Point(536, 102);
            textBoxInventoryQuantity.Name = "textBoxInventoryQuantity";
            textBoxInventoryQuantity.Size = new Size(100, 23);
            textBoxInventoryQuantity.TabIndex = 19;
            textBoxInventoryQuantity.Text = "Quantity";
            // 
            // comboBoxInventoryBookstore
            // 
            comboBoxInventoryBookstore.FormattingEnabled = true;
            comboBoxInventoryBookstore.Location = new Point(536, 73);
            comboBoxInventoryBookstore.Name = "comboBoxInventoryBookstore";
            comboBoxInventoryBookstore.Size = new Size(121, 23);
            comboBoxInventoryBookstore.TabIndex = 20;
            comboBoxInventoryBookstore.Text = "Bookstore";
            // 
            // labelAddBookstore
            // 
            labelAddBookstore.AutoSize = true;
            labelAddBookstore.Font = new Font("Segoe UI", 12F);
            labelAddBookstore.Location = new Point(670, 16);
            labelAddBookstore.Name = "labelAddBookstore";
            labelAddBookstore.Size = new Size(112, 21);
            labelAddBookstore.TabIndex = 21;
            labelAddBookstore.Text = "Add Bookstore";
            // 
            // textBoxBookstoreLocation
            // 
            textBoxBookstoreLocation.Location = new Point(679, 42);
            textBoxBookstoreLocation.Name = "textBoxBookstoreLocation";
            textBoxBookstoreLocation.Size = new Size(100, 23);
            textBoxBookstoreLocation.TabIndex = 22;
            textBoxBookstoreLocation.Text = "Store Location";
            // 
            // buttonAddInventory
            // 
            buttonAddInventory.Location = new Point(536, 131);
            buttonAddInventory.Name = "buttonAddInventory";
            buttonAddInventory.Size = new Size(106, 23);
            buttonAddInventory.TabIndex = 23;
            buttonAddInventory.Text = "Add Inventory";
            buttonAddInventory.UseVisualStyleBackColor = true;
            // 
            // buttonAddBookstore
            // 
            buttonAddBookstore.Location = new Point(678, 70);
            buttonAddBookstore.Name = "buttonAddBookstore";
            buttonAddBookstore.Size = new Size(101, 23);
            buttonAddBookstore.TabIndex = 24;
            buttonAddBookstore.Text = "Add Bookstore";
            buttonAddBookstore.UseVisualStyleBackColor = true;
            // 
            // BookstoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 432);
            Controls.Add(buttonAddBookstore);
            Controls.Add(buttonAddInventory);
            Controls.Add(textBoxBookstoreLocation);
            Controls.Add(labelAddBookstore);
            Controls.Add(comboBoxInventoryBookstore);
            Controls.Add(textBoxInventoryQuantity);
            Controls.Add(comboBoxInventoryBook);
            Controls.Add(labelAddInventory);
            Controls.Add(buttonAddCustomer);
            Controls.Add(textBoxCustomerPhone);
            Controls.Add(textBoxMembershipPassword);
            Controls.Add(textBoxCustomerEmail);
            Controls.Add(textBoxCustomerLastName);
            Controls.Add(textBoxCustomerMiddleName);
            Controls.Add(textBoxCustomerFirstName);
            Controls.Add(labelAddCustomer);
            Controls.Add(labelSuccessParsingExcel);
            Controls.Add(textboxDatabaseFile);
            Controls.Add(buttonBrowseDatabase);
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
        private TextBox textboxDatabaseFile;
        private Button buttonBrowseDatabase;
        private Label labelSuccessParsingExcel;
        private Label labelAddCustomer;
        private TextBox textBoxCustomerFirstName;
        private TextBox textBoxCustomerMiddleName;
        private TextBox textBoxCustomerLastName;
        private TextBox textBoxCustomerEmail;
        private TextBox textBoxMembershipPassword;
        private TextBox textBoxCustomerPhone;
        private Button buttonAddCustomer;
        private Label labelAddInventory;
        private ComboBox comboBoxInventoryBook;
        private TextBox textBoxInventoryQuantity;
        private ComboBox comboBoxInventoryBookstore;
        private Label labelAddBookstore;
        private TextBox textBoxBookstoreLocation;
        private Button buttonAddInventory;
        private Button buttonAddBookstore;
    }
}
