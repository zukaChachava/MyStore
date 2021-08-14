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
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class UserAdd : AddForm<User, UserRepository>, IUserForm
    {
        public UserAdd(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
            FormTools.LoadRelatedData(_repository, employeeBox);
        }

        public int Id
        {
            get
            {
                return (employeeBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public string Username
        {
            get
            {
                return userTxt.Text;
            }
        }

        public string Password
        {
            get
            {
                return passwordTxt.Text;
            }
        }

        protected override User LoadModel()
        {
            return FormTools.ReadInputModel(this);
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
    }
}
