using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using System.Data;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using MyStore.Repository.Context;

namespace MyStore.WinApp
{
    public partial class ProductAdd : AddForm<Product, ProductRepository>, IProductForm
    {
        public ProductAdd(AppDbContext context) : base(new ProductRepository(context))
        {
            InitializeComponent();
            FormTools.LoadRelatedData(_repository, categoryBox);
        }

        public int Id
        {
            get
            {
                return default;
            }
        }

        public int CategoryId
        {
            get
            {
                return (categoryBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public decimal Price
        {
            get
            {
                return Convert.ToDecimal(priceTxt.Text);
            }
        }

        public string ProductionName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        protected override Product LoadModel()
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
