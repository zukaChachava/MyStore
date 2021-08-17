using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class EmployeeDelete : DeleteForm<Employee, EmployeeRepository>
    {
        public EmployeeDelete(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
