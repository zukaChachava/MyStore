using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class CategoryAdd : AddForm<Category, CategoryRepository>
    {
        public CategoryAdd(AppDbContext context) : base(new CategoryRepository(context)) 
        {
            InitializeComponent();
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

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Name = nameTxt.Text;
        }
    }
}
