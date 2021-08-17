using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using System.Data;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using MyStore.WinApp.BaseForms;

namespace MyStore.WinApp
{
    public partial class UserGroupAdd : AddForm<User, UserRepository>
    {
        public UserGroupAdd(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
            LoadUsers();
        }

        protected void LoadUsers()
        {
            
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
