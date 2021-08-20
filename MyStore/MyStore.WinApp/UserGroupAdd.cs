using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using System.Data;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.LocalData;
using System.Linq;

namespace MyStore.WinApp
{
    public partial class UserGroupAdd : AddForm<User, UserRepository>
    {
        private Groups _admin, _manager, _cashier, _supplyManager;

        public UserGroupAdd(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
            LoadUsers();
        }

        protected void LoadUsers()
        {
           userBox.Items.AddRange(_repository.Select(LocalStorage.User).ToArray());
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                Close();
                if (LocalStorage.User.Equals(Model))
                    Application.Restart();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            Model = userBox.SelectedItem as User;
        }

        private void adminBox_CheckedChanged(object sender, EventArgs e)
        {
            if (adminBox.Checked)
                _admin = _repository.GetAdminGroup();
            else
                _admin = null;
        }

        private void managerBox_CheckedChanged(object sender, EventArgs e)
        {
            if (managerBox.Checked)
                _manager = _repository.GetManagerGroup();
            else
                _manager = null;
        }

        private void cashierBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cashierBox.Checked)
                _cashier = _repository.GetCashierGroup();
            else
                _cashier = null;
        }

        private void supllyManagerBox_CheckedChanged(object sender, EventArgs e)
        {
            if (supllyManagerBox.Checked)
                _supplyManager = _repository.GetSupplyManager();
            else
                _supplyManager = null;
        }

        private void UserGroupAdd_Load(object sender, EventArgs e)
        {
            addBtn.Enabled = false;
        }

        public override void Add()
        {
            try
            {
                _repository.ChangeUserGroups(LocalStorage.User, Model, _admin, _manager, _cashier, _supplyManager);
                if (Model == LocalStorage.User)
                    Application.Restart();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
