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
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class SellDetailsAdd : Form
    {
        protected SellDetailsRepository _repository;

        public SellDetailsAdd(SellDetailsRepository repository, SellDetails model = null)
        {
            InitializeComponent();
            _repository = repository;
            LoadProducts();
            if (model != null) LoadModel(model);
        }

        public SellDetails Model { get; protected set; }

        protected void LoadProducts()
        {
        }

        protected void ReadInput()
        {
            if(Convert.ToInt32(maxQuantityTxt.Text) < Convert.ToInt32(quantityTxt.Text))
                throw new Exception("There is not enough quantity");

            SellDetails model = new()
            {
                //ProductId = (productBox.SelectedItem as ComboBoxDetailedItem).Id,
                Discount =  Convert.ToDecimal(discountTxt.Text),
                Quantity = Convert.ToInt32(quantityTxt.Text),
                UnitPrice = (productBox.SelectedItem as ComboBoxDetailedItem).Price
            };
            Model = model;
        }

        protected void LoadModel(SellDetails model)
        {
            foreach (ComboBoxDetailedItem item in productBox.Items)
            {
                if (item.Id == model.ProductID)
                {
                    productBox.SelectedItem = item;
                    break;
                }
            }

            quantityTxt.Text = model.Quantity.ToString();
            discountTxt.Text = model.Discount.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ReadInput();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //maxQuantityTxt.Text = _repository.GetProductQuantityById((productBox.SelectedItem as ComboBoxDetailedItem).Id).ToString();
        }

        public ComboBoxDetailedItem GetProductName()
        {
            return productBox.SelectedItem as ComboBoxDetailedItem;
        }
    }
}
