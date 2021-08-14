using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using System.Data;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class UserGroupAdd : AddForm<User, UserRepository>, IUserGroupsForm
    {
        public UserGroupAdd(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
            LoadUsers();
        }

        public int Id
        {
            get
            {
                return (userBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public bool Admin => adminBox.Checked;

        public bool Cashier => cashierBox.Checked;

        public bool Manager => managerBox.Checked;

        public bool SupplyManager => supllyManagerBox.Checked;

        protected void LoadUsers()
        {
            
        }

        protected override User LoadModel()
        {
            return null; //FormTools.ReadInputModel(this);
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
