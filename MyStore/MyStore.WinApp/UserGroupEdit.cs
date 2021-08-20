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
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class UserGroupEdit : EditForm<User, UserRepository>
    {
        private Groups _admin, _manager, _cashier, _supplyManager;

        public UserGroupEdit(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model);
            // TODO: without ToList An Exception occurres !
            LoadGroups(_repository.GetUserGroups(LocalStorage.User, Model).ToList());

            void LoadGroups(IEnumerable<Groups> groups)
            {
                foreach (Groups group in groups)
                {
                    switch (group.ID)
                    {
                        case 1:
                            adminBox.Checked = true;
                            break;
                        case 2:
                            managerBox.Checked = true;
                            break;
                        case 3:
                            cashierBox.Checked = true;
                            break;
                        case 4:
                            supllyManagerBox.Checked = true;
                            break;
                        default:
                            throw new Exception("Unknown Group type");
                    }
                }
            }
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
            Model = idBox.SelectedItem as User;
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

        protected override void Edit()
        {
            try
            {
                _repository.ChangeUserGroups(LocalStorage.User, Model, _admin, _manager, _cashier, _supplyManager);
                if (LocalStorage.User.Equals(Model))
                    Application.Restart();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
