using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class CategoryAdd : AddForm<Category, CategoryRepository>, ICategoryForm
    {
        public CategoryAdd(AppDbContext context) : base(new CategoryRepository(context)) 
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

        public string CategoryName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        protected override Category LoadModel()
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
