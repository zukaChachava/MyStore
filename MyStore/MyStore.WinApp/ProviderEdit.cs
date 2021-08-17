using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class ProviderEdit : EditForm<Provider, ProviderRepository>
    {
        public ProviderEdit(AppDbContext context) : base(new ProviderRepository(context))
        {
            InitializeComponent();
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model.ID);
            nameTxt.Text = Model.Name;
            phoneTxt.Text = Model.Phone;
            emailTxt.Text = Model.Email;
            locationTxt.Text = Model.Location;
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
            Model.Name = nameTxt.Text;
        }

        private void phoneTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Phone = phoneTxt.Text;
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Email = emailTxt.Text;
        }

        private void locationTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Location = locationTxt.Text;
        }
    }
}
