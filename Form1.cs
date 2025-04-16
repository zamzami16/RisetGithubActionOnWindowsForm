using Axata.UIControls.Forms;
using DbService;
using System;
using System.Windows.Forms;

namespace RisetGithubActionOnWindowsForm
{
    public partial class Form1 : AxataForm1
    {
        readonly IDbService _dbService;

        public Form1()
        {
            InitializeComponent();
            _dbService = new DbService.DbService();
        }

        private async void BtnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                var data = await _dbService.GetAllDataAsync();
                dgvData.DataSource = null;
                dgvData.DataSource = data;
                dgvData.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
