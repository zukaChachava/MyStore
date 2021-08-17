using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using System.Data;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.LocalData;
using System.Linq;

namespace MyStore.WinApp
{
    public partial class ProductAdd : AddForm<Product, ProductRepository>
    {
        public ProductAdd(AppDbContext context) : base(new ProductRepository(context))
        {
            InitializeComponent();;
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

        protected void LoadRelatedData()
        {
            // TODO: ToArray() Here
            categoryBox.Items.AddRange(_repository.GetCategories(LocalStorage.User).ToArray());
        }

        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Category = categoryBox.SelectedItem as Category;
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Name = nameTxt.Text;
        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Price = Convert.ToDecimal(priceTxt.Text);
        }
    }
}
