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
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class UserAdd : AddForm<User, UserRepository>
    {
        public UserAdd(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
            LoadEmployees();
            addBtn.Enabled = false;
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

        protected void LoadEmployees()
        {
            //TODO: To Array here !
            var x = _repository.GetEmployees(LocalStorage.User);
            employeeBox.Items.AddRange(x.ToArray());
        }

        private void userTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Username = userTxt.Text;
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Password = passwordTxt.Text;
        }

        private void employeeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model = (employeeBox.SelectedItem as Employee).GenerateUser();
            addBtn.Enabled = true;
        }
    }
}
