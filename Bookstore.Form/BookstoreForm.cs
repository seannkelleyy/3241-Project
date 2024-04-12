using Bookstore.Data;

namespace Bookstore
{
    public partial class BookstoreForm : Form
    {
        public BookstoreForm()
        {
            InitializeComponent();
        }

        private void buttonLoadExcel_Click(object sender, EventArgs e)
        {
            SQLitePCL.Batteries.Init();
            if (textboxFileName.Text == "")
            {
                MessageBox.Show("Please select a file to load.");
                return;
            }
            //dataGridViewExcelFile.DataSource = LoadData.LoadExcelData(textboxFileName.Text);
            LoadData.LoadExcelData(textboxFileName.Text);
        }

        private void buttonBrowseFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textboxFileName.Text = openFileDialog.FileName;
            }
        }
    }
}
