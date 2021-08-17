using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;


namespace MyStore.WinApp
{
    public partial class UserEdit : EditForm<User, UserRepository>
    {
        public UserEdit(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
        }
        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model.ID);
            userTxt.Text = Model.Username;
            passwordTxt.Text = Model.Password;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void idBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.ID = (int)idBox.SelectedItem;
        }

        private void userTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Username = userTxt.Text;
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Password = passwordTxt.Text;
        }
    }
}
