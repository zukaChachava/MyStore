using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using System;
using System.Windows.Forms;

namespace MyStore.WinApp
{
    public partial class EmployeeEdit : EditForm<Employee, EmployeeRepository>
    {
        public EmployeeEdit(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model.ID);
            nameTxt.Text = Model.Firstname;
            lastnameTxt.Text = Model.Lastname;
            personalTxt.Text = Model.PersonalID;
            phoneTxt.Text = Model.Phone;
            emailTxt.Text = Model.Email;
            adressTxt.Text = Model.HomeAddress;
            dateBox.Value = Model.StartJob ?? DateTime.Now;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void idBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.ID = (int)idBox.SelectedItem;
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

        private void adressTxt_TextChanged(object sender, EventArgs e)
        {
            Model.HomeAddress = adressTxt.Text;
        }

        private void dateBox_ValueChanged(object sender, EventArgs e)
        {
            Model.StartJob = dateBox.Value;
        }
    }
}
