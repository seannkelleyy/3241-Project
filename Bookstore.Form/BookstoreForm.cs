using Bookstore.Data;
using Bookstore.Domain;
using ExcelDataReader;

namespace Bookstore
{
    public partial class BookstoreForm : Form
    {
        public BookstoreForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Call CloseConnection when the form is closing
            DatabaseConnection.CloseConnection();
        }

        #region Database Connection

        private void buttonBrowseDatabase_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SQLite Database Files|*.db;*.db3;*.sqlite;*.sqlite3";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textboxDatabaseFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonBrowseFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textboxFileName.Text = openFileDialog.FileName;
            }
            using (var stream = File.Open(textboxFileName.Text, FileMode.Open, FileAccess.Read))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    dataGridViewExcelFile.DataSource = result.Tables[0];
                }
            }

        }

        private void buttonEstablishDatabaseConnection_Click(object sender, EventArgs e)
        {
            if (textboxDatabaseFile.Text == "")
            {
                MessageBox.Show("Please select database file to load.");
                return;
            }
            try
            {
                DatabaseConnection.OpenConnection(textboxDatabaseFile.Text);
                LoadComboBoxData();
                MessageBox.Show("Database connection has been established successfully!");
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while establishing database connection. Please try again.");
            }

        }

        private void buttonInsertData_Click(object sender, EventArgs e)
        {
            if (textboxFileName.Text == "")
            {
                MessageBox.Show("Please select an excel file to load.");
                return;
            }
            try
            {
                LoadData.LoadExcelData(textboxFileName.Text);
                MessageBox.Show("Data has been loaded successfully!");
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while loading data. Please try again.");
            }
        }

        #endregion Data Insertion

        #region buttonClickEvents
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommands.InsertCustomer(textBoxCustomerFirstName.Text, textBoxCustomerMiddleName?.Text, textBoxCustomerLastName.Text, textBoxCustomerPhone.Text);
                MessageBox.Show("Customer has been added successfully!");
                textBoxCustomerFirstName.Text = "";
                textBoxCustomerMiddleName.Text = "";
                textBoxCustomerLastName.Text = "";
                textBoxCustomerPhone.Text = "";
                LoadComboBoxData();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while adding customer. Please try again.");
            }

        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommands.InsertPurchase(Convert.ToInt32(
                    comboBoxPurchaseCustomer.SelectedValue.ToString()),
                    comboBoxPurchaseBookSelect.SelectedValue.ToString(),
                    Convert.ToInt32(textBoxPurchaseQuantity.Text),
                    Convert.ToInt32(comboBoxPurchaseStore.SelectedValue),
                    Convert.ToDecimal(textBoxPurchasePrice.Text)
                    );
                MessageBox.Show("Purchase has been added successfully!");
                textBoxPurchaseQuantity.Text = "";
                textBoxPurchasePrice.Text = "";
                comboBoxPurchaseBookSelect.SelectedIndex = -1;
                comboBoxPurchaseStore.SelectedIndex = -1;
                comboBoxPurchaseCustomer.SelectedIndex = -1;
                LoadComboBoxData();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while adding purchase. Please try again.");
            }
        }

        private void buttonCreateMembership_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommands.InsertMembership(Convert.ToInt32(comboBoxMembershipCustomer.SelectedValue.ToString()), textBoxMembershipEmail.Text, textBoxMembershipPassword.Text);
                MessageBox.Show("Membership has been created successfully!");
                textBoxMembershipEmail.Text = "";
                textBoxMembershipPassword.Text = "";
                comboBoxMembershipCustomer.SelectedIndex = -1;
                LoadComboBoxData();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while creating membership. Please try again.");
            }
        }

        private void buttonAddBookstore_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommands.InsertBookstore(textBoxBookstoreLocation.Text);
                MessageBox.Show("Bookstore has been added successfully!");
                textBoxBookstoreLocation.Text = "";
                LoadComboBoxData();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while adding bookstore. Please try again.");
            }
        }

        private void buttonAddInventory_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommands.InsertInventory(comboBoxInventoryBook.SelectedValue.ToString(), Convert.ToInt32(comboBoxInventoryBookstore.SelectedValue), Convert.ToInt32(textBoxInventoryQuantity.Text));
                MessageBox.Show("Inventory has been added successfully!");
                comboBoxInventoryBook.SelectedIndex = -1;
                comboBoxInventoryBookstore.SelectedIndex = -1;
                textBoxInventoryQuantity.Text = "";
                LoadComboBoxData();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while adding inventory. Please try again.");
            }
        }

        #endregion buttonClickEvents

        #region load data
        private void LoadComboBoxData()
        {
            List<Customer> membershipCustomers = SelectCommands.SelectCustomers();
            comboBoxMembershipCustomer.DataSource = membershipCustomers;
            comboBoxMembershipCustomer.DisplayMember = "First_Name";
            comboBoxMembershipCustomer.ValueMember = "Cust_Id";
            comboBoxMembershipCustomer.SelectedIndex = -1;
            comboBoxMembershipCustomer.SelectedText = "Select Customer";
            List<Customer> purchaseCustomers = SelectCommands.SelectCustomers();
            comboBoxPurchaseCustomer.DataSource = purchaseCustomers;
            comboBoxPurchaseCustomer.DisplayMember = "First_Name";
            comboBoxPurchaseCustomer.ValueMember = "Cust_Id";
            comboBoxPurchaseCustomer.SelectedIndex = -1;
            comboBoxPurchaseCustomer.SelectedText = "Select Customer";
            List<Book> purchaseBooks = SelectCommands.SelectBooks();
            comboBoxPurchaseBookSelect.DataSource = purchaseBooks;
            comboBoxPurchaseBookSelect.DisplayMember = "Title";
            comboBoxPurchaseBookSelect.ValueMember = "ISBN";
            comboBoxPurchaseBookSelect.SelectedIndex = -1;
            comboBoxPurchaseBookSelect.SelectedText = "Select Book";
            List<Store> purchaseBookstores = SelectCommands.SelectBookstores();
            comboBoxPurchaseStore.DataSource = purchaseBookstores;
            comboBoxPurchaseStore.DisplayMember = "Store_Loc";
            comboBoxPurchaseStore.ValueMember = "Store_No";
            comboBoxPurchaseStore.SelectedIndex = -1;
            comboBoxPurchaseStore.SelectedText = "Select Store";
            List<Book> inventoryBooks = SelectCommands.SelectBooks();
            comboBoxInventoryBook.DataSource = inventoryBooks;
            comboBoxInventoryBook.DisplayMember = "Title";
            comboBoxInventoryBook.ValueMember = "ISBN";
            comboBoxInventoryBook.SelectedIndex = -1;
            comboBoxInventoryBook.SelectedText = "Select Book";
            List<Store> inventoryBookstores = SelectCommands.SelectBookstores();
            comboBoxInventoryBookstore.DataSource = inventoryBookstores;
            comboBoxInventoryBookstore.DisplayMember = "Store_Loc";
            comboBoxInventoryBookstore.ValueMember = "Store_No";
            comboBoxInventoryBookstore.SelectedIndex = -1;
            comboBoxInventoryBookstore.SelectedText = "Select Store";
        }
        #endregion load data
    }
}
