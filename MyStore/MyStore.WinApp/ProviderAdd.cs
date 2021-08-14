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
    public partial class ProviderAdd : AddForm<Provider, ProviderRepository>, IProviderForm
    {
        public ProviderAdd(AppDbContext context) : base (new ProviderRepository(context))
        {
            InitializeComponent();
        }

        public int Id
        {
            get
            {
                return default;
            }
        }

        public string Phone
        {
            get
            {
                return phoneTxt.Text;
            }
        }

        public string Email
        {
            get
            {
                return emailTxt.Text;
            }
        }

        public string ProviderName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        string IProviderForm.Location
        {
            get
            {
                return locationTxt.Text;
            }
        }

        protected override Provider LoadModel()
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
