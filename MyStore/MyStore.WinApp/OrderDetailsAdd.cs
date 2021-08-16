using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class OrderDetailsAdd : Form, IModelForm<OrderDetails>
    {
        protected readonly OrderDetailsRepository _repository;
        protected List<OrderDetails> _orderDetails;

        public OrderDetailsAdd(OrderDetailsRepository repository, List<OrderDetails> orderDetails)
        {
            InitializeComponent();
            sellPriceTxt.Enabled = false;
            priceTxt.Enabled = false;
            _repository = repository;
            _orderDetails = orderDetails;
            LoadProducts();
            Model = new OrderDetails();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public OrderDetails Model { get; protected set; }

        protected void LoadProducts()
        {
            productBox.Items.AddRange(_repository.GetProducts(LocalStorage.User).ToArray());
        }

        protected void ReadInput()
        {
            if (Convert.ToDecimal(priceTxt.Text) > Convert.ToDecimal(sellPriceTxt.Text))
                throw new Exception("You pay more than it costs");

            OrderDetails model = new()
            {
                //ProductId = (productBox.SelectedItem as ComboBoxDetailedItem).Id,
                Quantity = Convert.ToInt32(quantityTxt.Text),
                UnitPrice = Convert.ToDecimal(priceTxt.Text),
                Valid = Convert.ToDateTime(validDate.Text),
                ProvideDate = DateTime.Now
            };
            Model = model;
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Product = productBox.SelectedItem as Product;
            sellPriceTxt.Text = Model.Product.Price.ToString();
            priceTxt.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderDetails.Contains(Model))
                    throw new Exception("Model already exists");
                _orderDetails.Add(Model);
                Close();
            }
            catch(Exception ex)
            {
               FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Model.UnitPrice = Convert.ToDecimal(priceTxt.Text);
                if (Convert.ToDecimal(sellPriceTxt.Text) < Convert.ToDecimal(priceTxt.Text))
                    throw new Exception("Sell price is lower !");
            }
            catch(FormatException)
            {
                FormTools.ShowInfo("Ops", "Wrong numeric format, Pleas write only numbers !");
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void quantityTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Quantity = Convert.ToInt32(quantityTxt.Text);
        }

        private void validDate_ValueChanged(object sender, EventArgs e)
        {
            Model.Valid = validDate.Value;
        }
    }
}
