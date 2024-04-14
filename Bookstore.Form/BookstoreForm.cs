using Bookstore.Data;
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

        private void buttonLoadExcel_Click(object sender, EventArgs e)
        {
            if (textboxDatabaseFile.Text == "")
            {
                MessageBox.Show("Please select database file to load.");
                return;
            }
            //try
            //{
            DatabaseConnection.OpenConnection(textboxDatabaseFile.Text);
            comboBoxMembershipCustomer.Items.AddRange(SelectCommands.SelectCustomers().ToArray());
            MessageBox.Show("Database connection has been established successfully!");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("An error occurred while establishing database connection. Please try again.");
            //}

        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            InsertCommands.InsertCustomer(textBoxCustomerFirstName.Text, textBoxCustomerMiddleName?.Text, textBoxCustomerLastName.Text, textBoxCustomerPhone.Text);
            MessageBox.Show("Customer has been added successfully!");
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

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            InsertCommands.InsertPurchase(Convert.ToInt32(
                comboBoxPurchaseCustomer.SelectedValue.ToString()),
                comboBoxPurchaseBookSelect.SelectedValue.ToString(),
                Convert.ToInt32(textBoxPurchaseQuantity.Text),
                Convert.ToInt32(comboBoxPurchaseStore.SelectedValue),
                Convert.ToDecimal(textBoxPurchasePrice.Text)
                );
            MessageBox.Show("Purchase has been added successfully!");
        }
    }
}
