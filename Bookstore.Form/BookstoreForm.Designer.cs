using Bookstore.Data;

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
            components = new System.ComponentModel.Container();
            labelWelcome = new Label();
            buttonEstablishDatabaseConnection = new Button();
            buttonBrowseFiles = new Button();
            textboxFileName = new TextBox();
            dataGridViewExcelFile = new DataGridView();
            textboxDatabaseFile = new TextBox();
            buttonBrowseDatabase = new Button();
            labelSuccessParsingExcel = new Label();
            labelCreateCustomer = new Label();
            textBoxCustomerFirstName = new TextBox();
            textBoxCustomerMiddleName = new TextBox();
            textBoxCustomerLastName = new TextBox();
            textBoxMembershipEmail = new TextBox();
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
            labelCreateMembership = new Label();
            comboBoxMembershipCustomer = new ComboBox();
            buttonCreateMembership = new Button();
            labelCreatePurchase = new Label();
            comboBoxPurchaseBookSelect = new ComboBox();
            comboBoxPurchaseStore = new ComboBox();
            textBoxPurchaseQuantity = new TextBox();
            comboBoxPurchaseCustomer = new ComboBox();
            buttonPurchase = new Button();
            buttonInsertData = new Button();
            textBoxPurchasePrice = new TextBox();
            selectCommandsBindingSource = new BindingSource(components);
            labelMembershipEmail = new Label();
            labelMembershipPassword = new Label();
            labelPurchasePrice = new Label();
            labelPurchaseQuantity = new Label();
            labelStoreLocation = new Label();
            labelInventoryQuantity = new Label();
            labelCustomerPhoneNumber = new Label();
            labelCustomerLastName = new Label();
            labelCustomerMiddleName = new Label();
            labelCustomerFirstName = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExcelFile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectCommandsBindingSource).BeginInit();
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
            // buttonEstablishDatabaseConnection
            // 
            buttonEstablishDatabaseConnection.Location = new Point(271, 55);
            buttonEstablishDatabaseConnection.Name = "buttonEstablishDatabaseConnection";
            buttonEstablishDatabaseConnection.Size = new Size(128, 23);
            buttonEstablishDatabaseConnection.TabIndex = 1;
            buttonEstablishDatabaseConnection.Text = "Establish Connection";
            buttonEstablishDatabaseConnection.UseVisualStyleBackColor = true;
            buttonEstablishDatabaseConnection.Click += buttonEstablishDatabaseConnection_Click;
            // 
            // buttonBrowseFiles
            // 
            buttonBrowseFiles.Location = new Point(190, 85);
            buttonBrowseFiles.Name = "buttonBrowseFiles";
            buttonBrowseFiles.Size = new Size(75, 23);
            buttonBrowseFiles.TabIndex = 2;
            buttonBrowseFiles.Text = "Browse ";
            buttonBrowseFiles.UseVisualStyleBackColor = true;
            buttonBrowseFiles.Click += buttonBrowseFiles_Click;
            // 
            // textboxFileName
            // 
            textboxFileName.Location = new Point(22, 85);
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
            dataGridViewExcelFile.Size = new Size(385, 409);
            dataGridViewExcelFile.TabIndex = 4;
            // 
            // textboxDatabaseFile
            // 
            textboxDatabaseFile.Location = new Point(22, 55);
            textboxDatabaseFile.Name = "textboxDatabaseFile";
            textboxDatabaseFile.Size = new Size(162, 23);
            textboxDatabaseFile.TabIndex = 7;
            textboxDatabaseFile.Text = "Database File";
            // 
            // buttonBrowseDatabase
            // 
            buttonBrowseDatabase.Location = new Point(190, 55);
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
            // labelCreateCustomer
            // 
            labelCreateCustomer.AutoSize = true;
            labelCreateCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCreateCustomer.ForeColor = SystemColors.HotTrack;
            labelCreateCustomer.Location = new Point(441, 53);
            labelCreateCustomer.Name = "labelCreateCustomer";
            labelCreateCustomer.Size = new Size(127, 21);
            labelCreateCustomer.TabIndex = 9;
            labelCreateCustomer.Text = "Create Customer";
            // 
            // textBoxCustomerFirstName
            // 
            textBoxCustomerFirstName.Location = new Point(442, 93);
            textBoxCustomerFirstName.Name = "textBoxCustomerFirstName";
            textBoxCustomerFirstName.Size = new Size(121, 23);
            textBoxCustomerFirstName.TabIndex = 10;
            // 
            // textBoxCustomerMiddleName
            // 
            textBoxCustomerMiddleName.Location = new Point(441, 137);
            textBoxCustomerMiddleName.Name = "textBoxCustomerMiddleName";
            textBoxCustomerMiddleName.Size = new Size(121, 23);
            textBoxCustomerMiddleName.TabIndex = 11;
            // 
            // textBoxCustomerLastName
            // 
            textBoxCustomerLastName.Location = new Point(442, 182);
            textBoxCustomerLastName.Name = "textBoxCustomerLastName";
            textBoxCustomerLastName.Size = new Size(121, 23);
            textBoxCustomerLastName.TabIndex = 12;
            // 
            // textBoxMembershipEmail
            // 
            textBoxMembershipEmail.Location = new Point(442, 409);
            textBoxMembershipEmail.Name = "textBoxMembershipEmail";
            textBoxMembershipEmail.Size = new Size(121, 23);
            textBoxMembershipEmail.TabIndex = 13;
            // 
            // textBoxMembershipPassword
            // 
            textBoxMembershipPassword.Location = new Point(442, 456);
            textBoxMembershipPassword.Name = "textBoxMembershipPassword";
            textBoxMembershipPassword.Size = new Size(121, 23);
            textBoxMembershipPassword.TabIndex = 14;
            // 
            // textBoxCustomerPhone
            // 
            textBoxCustomerPhone.Location = new Point(442, 226);
            textBoxCustomerPhone.Name = "textBoxCustomerPhone";
            textBoxCustomerPhone.Size = new Size(121, 23);
            textBoxCustomerPhone.TabIndex = 15;
            // 
            // buttonAddCustomer
            // 
            buttonAddCustomer.Location = new Point(433, 263);
            buttonAddCustomer.Name = "buttonAddCustomer";
            buttonAddCustomer.Size = new Size(138, 35);
            buttonAddCustomer.TabIndex = 16;
            buttonAddCustomer.Text = "Add Customer";
            buttonAddCustomer.UseVisualStyleBackColor = true;
            buttonAddCustomer.Click += buttonAddCustomer_Click;
            // 
            // labelAddInventory
            // 
            labelAddInventory.AutoSize = true;
            labelAddInventory.Font = new Font("Segoe UI", 12F);
            labelAddInventory.ForeColor = SystemColors.Highlight;
            labelAddInventory.Location = new Point(641, 24);
            labelAddInventory.Name = "labelAddInventory";
            labelAddInventory.Size = new Size(108, 21);
            labelAddInventory.TabIndex = 17;
            labelAddInventory.Text = "Add Inventory";
            // 
            // comboBoxInventoryBook
            // 
            comboBoxInventoryBook.FormattingEnabled = true;
            comboBoxInventoryBook.Location = new Point(641, 50);
            comboBoxInventoryBook.Name = "comboBoxInventoryBook";
            comboBoxInventoryBook.Size = new Size(121, 23);
            comboBoxInventoryBook.TabIndex = 18;
            comboBoxInventoryBook.Text = "Select Book ";
            // 
            // textBoxInventoryQuantity
            // 
            textBoxInventoryQuantity.Location = new Point(641, 125);
            textBoxInventoryQuantity.Name = "textBoxInventoryQuantity";
            textBoxInventoryQuantity.Size = new Size(121, 23);
            textBoxInventoryQuantity.TabIndex = 19;
            // 
            // comboBoxInventoryBookstore
            // 
            comboBoxInventoryBookstore.FormattingEnabled = true;
            comboBoxInventoryBookstore.Location = new Point(641, 81);
            comboBoxInventoryBookstore.Name = "comboBoxInventoryBookstore";
            comboBoxInventoryBookstore.Size = new Size(121, 23);
            comboBoxInventoryBookstore.TabIndex = 20;
            comboBoxInventoryBookstore.Text = "Select Bookstore";
            // 
            // labelAddBookstore
            // 
            labelAddBookstore.AutoSize = true;
            labelAddBookstore.Font = new Font("Segoe UI", 12F);
            labelAddBookstore.ForeColor = SystemColors.HotTrack;
            labelAddBookstore.Location = new Point(639, 208);
            labelAddBookstore.Name = "labelAddBookstore";
            labelAddBookstore.Size = new Size(112, 21);
            labelAddBookstore.TabIndex = 21;
            labelAddBookstore.Text = "Add Bookstore";
            // 
            // textBoxBookstoreLocation
            // 
            textBoxBookstoreLocation.Location = new Point(641, 247);
            textBoxBookstoreLocation.Name = "textBoxBookstoreLocation";
            textBoxBookstoreLocation.Size = new Size(121, 23);
            textBoxBookstoreLocation.TabIndex = 22;
            // 
            // buttonAddInventory
            // 
            buttonAddInventory.Location = new Point(628, 154);
            buttonAddInventory.Name = "buttonAddInventory";
            buttonAddInventory.Size = new Size(148, 35);
            buttonAddInventory.TabIndex = 23;
            buttonAddInventory.Text = "Add Inventory";
            buttonAddInventory.UseVisualStyleBackColor = true;
            buttonAddInventory.Click += buttonAddInventory_Click;
            // 
            // buttonAddBookstore
            // 
            buttonAddBookstore.Location = new Point(628, 276);
            buttonAddBookstore.Name = "buttonAddBookstore";
            buttonAddBookstore.Size = new Size(148, 35);
            buttonAddBookstore.TabIndex = 24;
            buttonAddBookstore.Text = "Add Bookstore";
            buttonAddBookstore.UseVisualStyleBackColor = true;
            buttonAddBookstore.Click += buttonAddBookstore_Click;
            // 
            // labelCreateMembership
            // 
            labelCreateMembership.AutoSize = true;
            labelCreateMembership.Font = new Font("Segoe UI", 12F);
            labelCreateMembership.ForeColor = SystemColors.HotTrack;
            labelCreateMembership.Location = new Point(433, 332);
            labelCreateMembership.Name = "labelCreateMembership";
            labelCreateMembership.Size = new Size(147, 21);
            labelCreateMembership.TabIndex = 25;
            labelCreateMembership.Text = "Create Membership";
            // 
            // comboBoxMembershipCustomer
            // 
            comboBoxMembershipCustomer.FormattingEnabled = true;
            comboBoxMembershipCustomer.Location = new Point(442, 365);
            comboBoxMembershipCustomer.Name = "comboBoxMembershipCustomer";
            comboBoxMembershipCustomer.Size = new Size(121, 23);
            comboBoxMembershipCustomer.TabIndex = 26;
            comboBoxMembershipCustomer.Text = "Select Customer";
            // 
            // buttonCreateMembership
            // 
            buttonCreateMembership.Location = new Point(433, 485);
            buttonCreateMembership.Name = "buttonCreateMembership";
            buttonCreateMembership.Size = new Size(138, 35);
            buttonCreateMembership.TabIndex = 27;
            buttonCreateMembership.Text = "Create Membership";
            buttonCreateMembership.UseVisualStyleBackColor = true;
            buttonCreateMembership.Click += buttonCreateMembership_Click;
            // 
            // labelCreatePurchase
            // 
            labelCreatePurchase.AutoSize = true;
            labelCreatePurchase.Font = new Font("Segoe UI", 12F);
            labelCreatePurchase.ForeColor = SystemColors.HotTrack;
            labelCreatePurchase.Location = new Point(643, 332);
            labelCreatePurchase.Name = "labelCreatePurchase";
            labelCreatePurchase.Size = new Size(122, 21);
            labelCreatePurchase.TabIndex = 28;
            labelCreatePurchase.Text = "Create Purchase";
            // 
            // comboBoxPurchaseBookSelect
            // 
            comboBoxPurchaseBookSelect.FormattingEnabled = true;
            comboBoxPurchaseBookSelect.Location = new Point(644, 365);
            comboBoxPurchaseBookSelect.Name = "comboBoxPurchaseBookSelect";
            comboBoxPurchaseBookSelect.Size = new Size(121, 23);
            comboBoxPurchaseBookSelect.TabIndex = 29;
            comboBoxPurchaseBookSelect.Text = "Select Book";
            // 
            // comboBoxPurchaseStore
            // 
            comboBoxPurchaseStore.FormattingEnabled = true;
            comboBoxPurchaseStore.Location = new Point(644, 440);
            comboBoxPurchaseStore.Name = "comboBoxPurchaseStore";
            comboBoxPurchaseStore.Size = new Size(121, 23);
            comboBoxPurchaseStore.TabIndex = 30;
            comboBoxPurchaseStore.Text = "Select Bookstore";
            // 
            // textBoxPurchaseQuantity
            // 
            textBoxPurchaseQuantity.Location = new Point(644, 412);
            textBoxPurchaseQuantity.Name = "textBoxPurchaseQuantity";
            textBoxPurchaseQuantity.Size = new Size(121, 23);
            textBoxPurchaseQuantity.TabIndex = 31;
            // 
            // comboBoxPurchaseCustomer
            // 
            comboBoxPurchaseCustomer.FormattingEnabled = true;
            comboBoxPurchaseCustomer.Location = new Point(643, 469);
            comboBoxPurchaseCustomer.Name = "comboBoxPurchaseCustomer";
            comboBoxPurchaseCustomer.Size = new Size(121, 23);
            comboBoxPurchaseCustomer.TabIndex = 32;
            comboBoxPurchaseCustomer.Text = "Select Customer";
            // 
            // buttonPurchase
            // 
            buttonPurchase.Location = new Point(628, 542);
            buttonPurchase.Name = "buttonPurchase";
            buttonPurchase.Size = new Size(148, 35);
            buttonPurchase.TabIndex = 35;
            buttonPurchase.Text = "Purchase";
            buttonPurchase.UseVisualStyleBackColor = true;
            buttonPurchase.Click += buttonPurchase_Click;
            // 
            // buttonInsertData
            // 
            buttonInsertData.Location = new Point(271, 84);
            buttonInsertData.Name = "buttonInsertData";
            buttonInsertData.Size = new Size(128, 23);
            buttonInsertData.TabIndex = 36;
            buttonInsertData.Text = "Insert Data";
            buttonInsertData.UseVisualStyleBackColor = true;
            buttonInsertData.Click += buttonInsertData_Click;
            // 
            // textBoxPurchasePrice
            // 
            textBoxPurchasePrice.Location = new Point(643, 513);
            textBoxPurchasePrice.Name = "textBoxPurchasePrice";
            textBoxPurchasePrice.Size = new Size(121, 23);
            textBoxPurchasePrice.TabIndex = 37;
            // 
            // selectCommandsBindingSource
            // 
            selectCommandsBindingSource.DataSource = typeof(SelectCommands);
            // 
            // labelMembershipEmail
            // 
            labelMembershipEmail.AutoSize = true;
            labelMembershipEmail.Location = new Point(442, 391);
            labelMembershipEmail.Name = "labelMembershipEmail";
            labelMembershipEmail.Size = new Size(39, 15);
            labelMembershipEmail.TabIndex = 38;
            labelMembershipEmail.Text = "Email:";
            // 
            // labelMembershipPassword
            // 
            labelMembershipPassword.AutoSize = true;
            labelMembershipPassword.Location = new Point(442, 435);
            labelMembershipPassword.Name = "labelMembershipPassword";
            labelMembershipPassword.Size = new Size(60, 15);
            labelMembershipPassword.TabIndex = 39;
            labelMembershipPassword.Text = "Password:";
            // 
            // labelPurchasePrice
            // 
            labelPurchasePrice.AutoSize = true;
            labelPurchasePrice.Location = new Point(645, 495);
            labelPurchasePrice.Name = "labelPurchasePrice";
            labelPurchasePrice.Size = new Size(36, 15);
            labelPurchasePrice.TabIndex = 40;
            labelPurchasePrice.Text = "Price:";
            // 
            // labelPurchaseQuantity
            // 
            labelPurchaseQuantity.AutoSize = true;
            labelPurchaseQuantity.Location = new Point(643, 394);
            labelPurchaseQuantity.Name = "labelPurchaseQuantity";
            labelPurchaseQuantity.Size = new Size(56, 15);
            labelPurchaseQuantity.TabIndex = 41;
            labelPurchaseQuantity.Text = "Quantity:";
            // 
            // labelStoreLocation
            // 
            labelStoreLocation.AutoSize = true;
            labelStoreLocation.Location = new Point(643, 229);
            labelStoreLocation.Name = "labelStoreLocation";
            labelStoreLocation.Size = new Size(86, 15);
            labelStoreLocation.TabIndex = 42;
            labelStoreLocation.Text = "Store Location:";
            // 
            // labelInventoryQuantity
            // 
            labelInventoryQuantity.AutoSize = true;
            labelInventoryQuantity.Location = new Point(641, 107);
            labelInventoryQuantity.Name = "labelInventoryQuantity";
            labelInventoryQuantity.Size = new Size(56, 15);
            labelInventoryQuantity.TabIndex = 43;
            labelInventoryQuantity.Text = "Quantity:";
            // 
            // labelCustomerPhoneNumber
            // 
            labelCustomerPhoneNumber.AutoSize = true;
            labelCustomerPhoneNumber.Location = new Point(442, 208);
            labelCustomerPhoneNumber.Name = "labelCustomerPhoneNumber";
            labelCustomerPhoneNumber.Size = new Size(91, 15);
            labelCustomerPhoneNumber.TabIndex = 44;
            labelCustomerPhoneNumber.Text = "Phone Number:";
            // 
            // labelCustomerLastName
            // 
            labelCustomerLastName.AutoSize = true;
            labelCustomerLastName.Location = new Point(441, 163);
            labelCustomerLastName.Name = "labelCustomerLastName";
            labelCustomerLastName.Size = new Size(66, 15);
            labelCustomerLastName.TabIndex = 45;
            labelCustomerLastName.Text = "Last Name:";
            // 
            // labelCustomerMiddleName
            // 
            labelCustomerMiddleName.AutoSize = true;
            labelCustomerMiddleName.Location = new Point(442, 119);
            labelCustomerMiddleName.Name = "labelCustomerMiddleName";
            labelCustomerMiddleName.Size = new Size(137, 15);
            labelCustomerMiddleName.TabIndex = 46;
            labelCustomerMiddleName.Text = "Middle Name (optional):";
            // 
            // labelCustomerFirstName
            // 
            labelCustomerFirstName.AutoSize = true;
            labelCustomerFirstName.Location = new Point(441, 75);
            labelCustomerFirstName.Name = "labelCustomerFirstName";
            labelCustomerFirstName.Size = new Size(67, 15);
            labelCustomerFirstName.TabIndex = 47;
            labelCustomerFirstName.Text = "First Name:";
            // 
            // BookstoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 588);
            Controls.Add(labelCustomerFirstName);
            Controls.Add(labelCustomerMiddleName);
            Controls.Add(labelCustomerLastName);
            Controls.Add(labelCustomerPhoneNumber);
            Controls.Add(labelInventoryQuantity);
            Controls.Add(labelStoreLocation);
            Controls.Add(labelPurchaseQuantity);
            Controls.Add(labelPurchasePrice);
            Controls.Add(labelMembershipPassword);
            Controls.Add(labelMembershipEmail);
            Controls.Add(textBoxPurchasePrice);
            Controls.Add(buttonInsertData);
            Controls.Add(buttonPurchase);
            Controls.Add(comboBoxPurchaseCustomer);
            Controls.Add(textBoxPurchaseQuantity);
            Controls.Add(comboBoxPurchaseStore);
            Controls.Add(comboBoxPurchaseBookSelect);
            Controls.Add(labelCreatePurchase);
            Controls.Add(buttonCreateMembership);
            Controls.Add(comboBoxMembershipCustomer);
            Controls.Add(labelCreateMembership);
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
            Controls.Add(textBoxMembershipEmail);
            Controls.Add(textBoxCustomerLastName);
            Controls.Add(textBoxCustomerMiddleName);
            Controls.Add(textBoxCustomerFirstName);
            Controls.Add(labelCreateCustomer);
            Controls.Add(labelSuccessParsingExcel);
            Controls.Add(textboxDatabaseFile);
            Controls.Add(buttonBrowseDatabase);
            Controls.Add(dataGridViewExcelFile);
            Controls.Add(textboxFileName);
            Controls.Add(buttonBrowseFiles);
            Controls.Add(buttonEstablishDatabaseConnection);
            Controls.Add(labelWelcome);
            Name = "BookstoreForm";
            Text = "Bits & Books";
            ((System.ComponentModel.ISupportInitialize)dataGridViewExcelFile).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectCommandsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Button buttonEstablishDatabaseConnection;
        private Button buttonBrowseFiles;
        private TextBox textboxFileName;
        public DataGridView dataGridViewExcelFile;
        private TextBox textboxDatabaseFile;
        private Button buttonBrowseDatabase;
        private Label labelSuccessParsingExcel;
        private Label labelCreateCustomer;
        private TextBox textBoxCustomerFirstName;
        private TextBox textBoxCustomerMiddleName;
        private TextBox textBoxCustomerLastName;
        private TextBox textBoxMembershipEmail;
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
        private Label labelCreateMembership;
        private ComboBox comboBoxMembershipCustomer;
        private Button buttonCreateMembership;
        private Label labelCreatePurchase;
        private ComboBox comboBoxPurchaseBookSelect;
        private ComboBox comboBoxPurchaseStore;
        private TextBox textBoxPurchaseQuantity;
        private ComboBox comboBoxPurchaseCustomer;
        private Button buttonPurchase;
        private Button buttonInsertData;
        private TextBox textBoxPurchasePrice;
        private BindingSource selectCommandsBindingSource;
        private Label labelMembershipEmail;
        private Label labelMembershipPassword;
        private Label labelPurchasePrice;
        private Label labelPurchaseQuantity;
        private Label labelStoreLocation;
        private Label labelInventoryQuantity;
        private Label labelCustomerPhoneNumber;
        private Label labelCustomerLastName;
        private Label labelCustomerMiddleName;
        private Label labelCustomerFirstName;
    }
}
