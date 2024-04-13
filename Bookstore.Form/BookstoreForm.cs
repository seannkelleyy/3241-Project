using Bookstore.Data;
using ExcelDataReader;

namespace Bookstore
{
    public partial class BookstoreForm : Form
    {
        public BookstoreForm()
        {
            InitializeComponent();
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
            SQLitePCL.Batteries.Init();
            if (textboxFileName.Text == "")
            {
                MessageBox.Show("Please select an excel file to load.");
                return;
            }

            if (textboxDatabaseFile.Text == "")
            {
                MessageBox.Show("Please select database file to load.");
                return;
            }
            //try
            //{
            LoadData.LoadExcelData(textboxFileName.Text, textboxDatabaseFile.Text);
            labelSuccessParsingExcel.Text = "Data has been loaded successfully!";
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("An error occurred while loading the data. Please try again.");
            //    labelSuccessParsingExcel.Text = "Data failed to load. Please try again.";
            //}

        }

    }
}
