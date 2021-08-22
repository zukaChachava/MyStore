using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;
using System;
using System.Linq;

namespace MyStore.WinApp
{
    public partial class ProductEdit : EditForm<Product, ProductRepository>
    {
        public ProductEdit(AppDbContext context) : base(new ProductRepository(context))
        {
            InitializeComponent();
            LoadRelatedData();
        }

        protected override void LoadSelectedModel()
        {
            FormTools.LoadComboBoxID(idBox, Model.ID);
            // categoryBox.SelectedItem = Model.CategoryID;
            nameTxt.Text = Model.Name;
            priceTxt.Text = Model.Price.ToString();
        }

        protected void LoadRelatedData()
        {
            categoryBox.Items.AddRange(_repository.GetCategories(LocalStorage.User).ToArray());
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void idBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.ID = (int)idBox.SelectedItem;
        }

        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.CategoryID = (categoryBox.SelectedItem as Category).ID;
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Name = nameTxt.Text;
        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Model.Price = Convert.ToDecimal(priceTxt.Text);
            }
            catch (FormatException)
            {
                FormTools.ShowInfo("Ops", "Wrong numeric format !");
                priceTxt.Text = priceTxt.Text.Substring(0, priceTxt.Text.Length - 1);
            }
        }
    }
}
