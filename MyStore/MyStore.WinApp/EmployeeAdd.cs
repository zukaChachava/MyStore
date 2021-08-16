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
    public partial class EmployeeAdd : AddForm<Employee, EmployeeRepository>
    {
        public EmployeeAdd(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
            dateBox_ValueChanged(null, null);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Firstname = nameTxt.Text;
        }

        private void lastnameTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Lastname = lastnameTxt.Text;
        }

        private void personalTxt_TextChanged(object sender, EventArgs e)
        {
            Model.PersonalID = personalTxt.Text;
        }

        private void phoneTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Phone = phoneTxt.Text;
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Email = emailTxt.Text;
        }

        private void addressTxt_TextChanged(object sender, EventArgs e)
        {
            Model.HomeAddress = addressTxt.Text;
        }

        private void dateBox_ValueChanged(object sender, EventArgs e)
        {
            Model.StartJob = dateBox.Value;
        }
    }
}
