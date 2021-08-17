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
    public partial class CategoryEdit : EditForm<Category, CategoryRepository>
    {
        public CategoryEdit(AppDbContext context) : base (new CategoryRepository(context))
        {
            InitializeComponent();
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model.ID);
            categoryTxt.Text = Model.Name;
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
            Model.ID = (int)idBox.SelectedItem;
        }

        private void categoryTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Name = categoryTxt.Text;
        }
    }
}
