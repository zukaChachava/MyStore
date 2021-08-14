using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class ProductEdit : EditForm<Product, ProductRepository>, IProductForm
    {
        public ProductEdit(AppDbContext context) : base(new ProductRepository(context))
        {
            InitializeComponent();
            FormTools.LoadRelatedData(_repository, categoryBox);
        }

        public int Id
        {
            get
            {
                return (idBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public int CategoryId
        {
            get
            {
                return (categoryBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public string ProductionName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        public decimal Price
        {
            get
            {
                return Convert.ToDecimal(priceTxt.Text);
            }
        }



        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(CategoryList))
                Abort();

            //Product model = _repository.Get(listForm.GetSelectedId());
            //LoadModel(model);

            void LoadModel(Product model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.ID });
                idBox.SelectedIndex = 0;
                idBox.Enabled = false;
                nameTxt.Text = model.Name;
                categoryBox.SelectedIndex = categoryBox.Items.IndexOf(model);
                priceTxt.Text = model.Price.ToString();
            }
        }

        protected override Product ReadModel()
        {
            return FormTools.ReadInputModel(this);
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
