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
using MyStore.WinApp.Interfaces;
using MyStore.Repository.Context;
using MyStore.WinApp.Tools;
using MyStore.WinApp.BaseForms;

namespace MyStore.WinApp
{
    public partial class UserDelete : DeleteForm<User, UserRepository>
    {
        public UserDelete(AppDbContext context) : base(new UserRepository(context))
        {
            InitializeComponent();
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
