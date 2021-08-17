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
    public partial class UserGroupEdit : EditForm<User, UserRepository>
    {
        public UserGroupEdit(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
        }

        protected override void LoadSelectedModel()
        {

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

        }

        private void adminBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void managerBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cashierBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void supllyManagerBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
