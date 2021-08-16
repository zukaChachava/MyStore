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
    public partial class CategoryEdit : EditForm<Category, CategoryRepository>, ICategoryForm
    {
        public CategoryEdit(AppDbContext context) : base (new CategoryRepository(context))
        {
            InitializeComponent();
        }

        public Category Category { get; private set; }

        protected override Category ReadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        protected override void LoadSelectedModel()
        {
            Category model = GetSelectedModel();
            if(model != null)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.ID });
                idBox.SelectedIndex = 0;
                idBox.Enabled = false;
                categoryTxt.Text = model.Name;
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
    }
}
